using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab3_QuanLySinhVien
{
    /// <summary>
    /// Lớp QuanLySinhVien: Đóng vai trò tầng nghiệp vụ (Business Logic / Service Layer).
    /// Quản lý danh sách sinh viên trong bộ nhớ, thực hiện các thuật toán:
    /// - Kiểm tra tính hợp lệ của MSSV theo quy tắc AABBCCC (AA: 2 số cuối năm nhập học theo khóa, BB: 10, CCC: 3 số bất kỳ).
    /// - Thêm mới sinh viên (kiểm tra trùng mã).
    /// - Cập nhật thông tin sinh viên.
    /// - Xóa 1 sinh viên hoặc xóa hàng loạt sinh viên được đánh dấu.
    /// - Tìm kiếm sinh viên theo MSSV, Tên, Lớp hoặc tìm kiếm đa tiêu chí.
    /// - Đọc và lưu trữ dữ liệu thông qua chiến lược IFileStorage (TXT, XML, JSON).
    /// </summary>
    public class QuanLySinhVien
    {
        // =========================================================================
        // 1. CÁC TRƯỜNG DỮ LIỆU NỘI BỘ (FIELDS)
        // =========================================================================

        /// <summary>
        /// Danh sách sinh viên được lưu trữ trong RAM
        /// </summary>
        private List<SinhVien> _danhSach;

        /// <summary>
        /// Đối tượng thực thi cơ chế lưu trữ file (Strategy Pattern)
        /// Có thể là TxtStorage, XmlStorage hoặc JsonStorage
        /// </summary>
        private IFileStorage _storage;

        /// <summary>
        /// Tên đường dẫn file hiện hành mà chương trình đang làm việc
        /// </summary>
        public string DuongDanHienHanh { get; set; } = "students.txt";

        /// <summary>
        /// Kiểu tập tin hiện hành (TXT, XML, JSON)
        /// </summary>
        public KieuTapTin DinhDangHienHanh { get; private set; } = KieuTapTin.TXT;

        // =========================================================================
        // 2. THUỘC TÍNH (PROPERTIES)
        // =========================================================================

        /// <summary>
        /// Truy xuất danh sách sinh viên hiện có trong hệ thống
        /// </summary>
        public List<SinhVien> DanhSach => _danhSach;

        /// <summary>
        /// Tổng số lượng sinh viên hiện có
        /// </summary>
        public int TongSoLuong => _danhSach.Count;

        // =========================================================================
        // 3. HÀM KHỞI TẠO (CONSTRUCTOR)
        // =========================================================================

        /// <summary>
        /// Hàm khởi tạo mặc định: Khởi tạo danh sách rỗng và áp dụng mặc định TxtStorage
        /// </summary>
        public QuanLySinhVien()
        {
            _danhSach = new List<SinhVien>();
            ChuyenDinhDangLuuTru(KieuTapTin.TXT);
        }

        // =========================================================================
        // 4. CÁC HÀM XỬ LÝ LƯU TRỮ VÀ ĐỌC FILE (FILE IO OPERATIONS)
        // =========================================================================

        /// <summary>
        /// Chuyển đổi định dạng lưu trữ giữa TXT, XML và JSON.
        /// Hàm này khởi tạo lại đối tượng _storage tương ứng với kiểu được chọn.
        /// </summary>
        /// <param name="kieu">KieuTapTin.TXT, KieuTapTin.XML, hoặc KieuTapTin.JSON</param>
        public void ChuyenDinhDangLuuTru(KieuTapTin kieu)
        {
            DinhDangHienHanh = kieu;

            switch (kieu)
            {
                case KieuTapTin.TXT:
                    _storage = new TxtStorage();
                    DuongDanHienHanh = "students.txt";
                    break;
                case KieuTapTin.XML:
                    _storage = new XmlStorage();
                    DuongDanHienHanh = "students.xml";
                    break;
                case KieuTapTin.JSON:
                    _storage = new JsonStorage();
                    DuongDanHienHanh = "students.json";
                    break;
            }
        }

        /// <summary>
        /// Nạp danh sách sinh viên từ tập tin hiện hành vào bộ nhớ RAM.
        /// Trỏ tới phương thức DocDanhSach của đối tượng _storage (TxtStorage/XmlStorage/JsonStorage).
        /// </summary>
        public void DocTuTapTin(string duongDan = null)
        {
            string path = duongDan ?? DuongDanHienHanh;
            _danhSach = _storage.DocDanhSach(path);
        }

        /// <summary>
        /// Lưu toàn bộ danh sách sinh viên hiện có trong RAM xuống tập tin.
        /// Trỏ tới phương thức GhiDanhSach của đối tượng _storage (TxtStorage/XmlStorage/JsonStorage).
        /// </summary>
        public void LuuVaoTapTin(string duongDan = null)
        {
            string path = duongDan ?? DuongDanHienHanh;
            _storage.GhiDanhSach(path, _danhSach);
        }

        // =========================================================================
        // 5. CÁC HÀM NGHIỆP VỤ QUẢN LÝ SINH VIÊN (CRUD OPERATIONS)
        // =========================================================================

        /// <summary>
        /// Thêm mới một sinh viên vào danh sách và tự động ghi đè xuống file.
        /// Luồng kiểm tra:
        /// 1. Kiểm tra mã sinh viên đã tồn tại chưa bằng phương thức KiemTraTrungMSSV().
        /// 2. Thêm sinh viên vào List nội bộ.
        /// 3. Gọi LuuVaoTapTin() để dữ liệu bền vững xuống ổ đĩa.
        /// </summary>
        public bool Them(SinhVien sv, out string thongBaoLoi)
        {
            thongBaoLoi = string.Empty;

            // Kiểm tra trùng mã số sinh viên
            if (KiemTraTrungMSSV(sv.MaSo))
            {
                thongBaoLoi = $"Mã số sinh viên [{sv.MaSo}] đã tồn tại trong hệ thống! Vui lòng kiểm tra lại.";
                return false;
            }

            // Thêm vào danh sách trong bộ nhớ
            _danhSach.Add(sv);

            // Đồng bộ ghi xuống tập tin
            try
            {
                LuuVaoTapTin();
            }
            catch (Exception ex)
            {
                thongBaoLoi = $"Đã thêm vào bộ nhớ nhưng lỗi khi ghi file: {ex.Message}";
                return true; // Dữ liệu trong RAM vẫn thành công
            }

            return true;
        }

        /// <summary>
        /// Cập nhật thông tin của một sinh viên đã có trong hệ thống và tự động lưu file.
        /// </summary>
        public bool CapNhat(SinhVien svMoi, out string thongBaoLoi)
        {
            thongBaoLoi = string.Empty;

            // Tìm vị trí sinh viên cần sửa theo Mã số
            int index = _danhSach.FindIndex(s => s.MaSo.Equals(svMoi.MaSo, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
            {
                thongBaoLoi = $"Không tìm thấy sinh viên có mã [{svMoi.MaSo}] để cập nhật!";
                return false;
            }

            // Cập nhật thông tin mới vào vị trí tìm thấy
            _danhSach[index] = svMoi;

            // Đồng bộ ghi xuống tập tin
            try
            {
                LuuVaoTapTin();
            }
            catch (Exception ex)
            {
                thongBaoLoi = $"Đã cập nhật bộ nhớ nhưng lỗi khi ghi file: {ex.Message}";
            }

            return true;
        }

        /// <summary>
        /// Xóa một sinh viên khỏi danh sách theo Mã số sinh viên và tự động lưu file.
        /// </summary>
        public bool Xoa(string maSo)
        {
            int index = _danhSach.FindIndex(s => s.MaSo.Equals(maSo, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                _danhSach.RemoveAt(index);
                LuuVaoTapTin();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Xóa hàng loạt nhiều sinh viên dựa trên danh sách các Mã số sinh viên được đánh dấu chọn (CheckBox).
        /// </summary>
        public int XoaNhieu(List<string> dsMaSo)
        {
            if (dsMaSo == null || dsMaSo.Count == 0) return 0;

            // HashSet giúp tra cứu mã cần xóa với tốc độ O(1)
            HashSet<string> maSet = new HashSet<string>(dsMaSo, StringComparer.OrdinalIgnoreCase);

            int soLuongXoa = _danhSach.RemoveAll(s => maSet.Contains(s.MaSo));

            if (soLuongXoa > 0)
            {
                LuuVaoTapTin();
            }

            return soLuongXoa;
        }

        /// <summary>
        /// Kiểm tra xem một mã số sinh viên đã tồn tại trong danh sách hay chưa
        /// </summary>
        public bool KiemTraTrungMSSV(string maSo)
        {
            return _danhSach.Any(s => s.MaSo.Equals(maSo, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tìm kiếm 1 sinh viên thỏa mãn điều kiện delegate Predicate
        /// </summary>
        public SinhVien Tim(Predicate<SinhVien> match)
        {
            return _danhSach.Find(match);
        }

        // =========================================================================
        // 6. THUẬT TOÁN TÌM KIẾM ĐA ĐIỀU KIỆN (SEARCH LOGIC)
        // =========================================================================

        /// <summary>
        /// Tìm kiếm sinh viên theo một hoặc nhiều tiêu chí kết hợp:
        /// - mssv: Tìm kiếm theo mã số sinh viên (chứa chuỗi con)
        /// - hoTen: Tìm kiếm theo họ tên (chứa chuỗi con)
        /// - lop: Tìm kiếm theo mã lớp (chính xác hoặc chứa)
        /// </summary>
        public List<SinhVien> TimKiem(string mssv = null, string hoTen = null, string lop = null)
        {
            IEnumerable<SinhVien> query = _danhSach;

            // Nếu người dùng nhập điều kiện MSSV
            if (!string.IsNullOrWhiteSpace(mssv))
            {
                query = query.Where(s => s.MaSo.IndexOf(mssv.Trim(), StringComparison.OrdinalIgnoreCase) >= 0);
            }

            // Nếu người dùng nhập điều kiện Họ và tên
            if (!string.IsNullOrWhiteSpace(hoTen))
            {
                string tenTrim = hoTen.Trim();
                query = query.Where(s => s.HoTenDayDu.IndexOf(tenTrim, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                         s.Ten.IndexOf(tenTrim, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            // Nếu người dùng chọn điều kiện Lớp
            if (!string.IsNullOrWhiteSpace(lop))
            {
                query = query.Where(s => s.Lop.Equals(lop.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            return query.ToList();
        }

        // =========================================================================
        // 7. KIỂM TRA QUY TẮC ĐỊNH DẠNG MSSV (AABBCCC)
        // =========================================================================

        /// <summary>
        /// Kiểm tra tính hợp lệ của MSSV theo yêu cầu mục 3 trang 59 trong tài liệu:
        /// - MSSV gồm đúng 7 chữ số: dạng AABBCCC.
        /// - AA: 2 số cuối năm nhập học của sinh viên (dựa vào lớp để biết năm nhập học: CTK43 -> 19, CTK44 -> 20, CTK45 -> 21, CTK46 -> 22, ...).
        /// - BB: Phải luôn bằng 10.
        /// - CCC: 3 chữ số bất kỳ.
        /// </summary>
        /// <param name="mssv">Chuỗi MSSV cần kiểm tra</param>
        /// <param name="lop">Mã lớp sinh viên đang theo học (ví dụ: CTK44)</param>
        /// <param name="thongBaoLoi">Chuỗi thông báo lỗi trả về nếu không hợp lệ</param>
        /// <returns>True nếu hợp lệ, False nếu sai quy tắc</returns>
        public static bool KiemTraQuyTacMSSV(string mssv, string lop, out string thongBaoLoi)
        {
            thongBaoLoi = string.Empty;

            if (string.IsNullOrWhiteSpace(mssv))
            {
                thongBaoLoi = "Mã số sinh viên không được để trống!";
                return false;
            }

            string cleanMssv = mssv.Trim();

            // 1. Kiểm tra độ dài đúng 7 ký tự số
            if (cleanMssv.Length != 7 || !cleanMssv.All(char.IsDigit))
            {
                thongBaoLoi = "Mã số sinh viên phải gồm đúng 7 chữ số (ví dụ: 2010123)!";
                return false;
            }

            // 2. Tách các thành phần AA, BB, CCC
            string aa = cleanMssv.Substring(0, 2);
            string bb = cleanMssv.Substring(2, 2);
            string ccc = cleanMssv.Substring(4, 3);

            // 3. Kiểm tra BB bắt buộc phải bằng 10
            if (bb != "10")
            {
                thongBaoLoi = $"Hai chữ số giữa (BB) của MSSV phải là '10' theo quy định (hiện tại là '{bb}')!";
                return false;
            }

            // 4. Kiểm tra AA có khớp với năm nhập học suy ra từ Lớp không (nếu có thông tin lớp)
            if (!string.IsNullOrWhiteSpace(lop))
            {
                int namNhapHoc = LayNamNhapHocTuLop(lop);
                if (namNhapHoc > 0)
                {
                    string aaDuKien = (namNhapHoc % 100).ToString("D2"); // Lấy 2 số cuối của năm
                    if (aa != aaDuKien)
                    {
                        thongBaoLoi = $"Lớp [{lop}] có năm nhập học là {namNhapHoc}, vì vậy 2 chữ số đầu của MSSV phải là '{aaDuKien}' (hiện tại bạn nhập '{aa}')!";
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Hàm nội bộ: Suy ra năm nhập học từ tên lớp theo truyền thống ĐH Đà Lạt.
        /// Khóa K43 nhập học năm 2019, K44 nhập học năm 2020, K45 nhập học năm 2021, K46 nhập học năm 2022, K47 nhập học năm 2023, K48 nhập học năm 2024.
        /// Công thức tổng quát: Năm nhập học = 2019 + (K - 43) = 1976 + K.
        /// </summary>
        public static int LayNamNhapHocTuLop(string tenLop)
        {
            if (string.IsNullOrWhiteSpace(tenLop)) return 0;

            // Tìm số khóa trong tên lớp (ví dụ "CTK44" -> 44)
            string digits = new string(tenLop.Where(char.IsDigit).ToArray());
            if (int.TryParse(digits, out int khoa))
            {
                // Khóa 43: 2019, Khóa 44: 2020, Khóa 45: 2021, Khóa 46: 2022
                return 1976 + khoa;
            }

            return 0;
        }
    }
}
