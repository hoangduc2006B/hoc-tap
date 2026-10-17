using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lab3_QuanLySinhVien
{
    /// <summary>
    /// Lớp SinhVien: Đại diện cho thực thể Sinh viên trong hệ thống quản lý.
    /// Chứa toàn bộ thông tin cá nhân và danh sách môn học đăng ký của sinh viên.
    /// Lớp này hỗ trợ tuần tự hóa (Serialization) sang XML, JSON và Text.
    /// </summary>
    [Serializable]
    public class SinhVien
    {
        // =========================================================================
        // 1. CÁC THUỘC TÍNH DỮ LIỆU (PROPERTIES)
        // =========================================================================

        /// <summary>
        /// Mã số sinh viên (gồm đúng 7 chữ số: AABBCCC)
        /// Ví dụ: 2010123 (20: năm 2020, 10: mã ngành, 123: số thứ tự)
        /// </summary>
        public string MaSo { get; set; } = string.Empty;

        /// <summary>
        /// Họ và tên lót của sinh viên (Ví dụ: "Nguyễn Văn")
        /// </summary>
        public string HoTenLot { get; set; } = string.Empty;

        /// <summary>
        /// Tên của sinh viên (Ví dụ: "An")
        /// </summary>
        public string Ten { get; set; } = string.Empty;

        /// <summary>
        /// Giới tính: true = Nam, false = Nữ
        /// </summary>
        public bool GioiTinh { get; set; } = true;

        /// <summary>
        /// Ngày tháng năm sinh của sinh viên
        /// </summary>
        public DateTime NgaySinh { get; set; } = DateTime.Now;

        /// <summary>
        /// Mã lớp học (Ví dụ: "CTK43", "CTK44", "CTK45", "CTK46")
        /// </summary>
        public string Lop { get; set; } = string.Empty;

        /// <summary>
        /// Số CMND hoặc Căn cước công dân (gồm đúng 9 hoặc 12 số)
        /// </summary>
        public string SoCMND { get; set; } = string.Empty;

        /// <summary>
        /// Số điện thoại liên lạc (gồm đúng 10 số, định dạng 0000.000.000)
        /// </summary>
        public string SoDT { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ liên lạc thường trú của sinh viên
        /// </summary>
        public string DiaChi { get; set; } = string.Empty;

        /// <summary>
        /// Danh sách các môn học mà sinh viên đã đăng ký trong học kỳ
        /// Thuộc tính XmlArray và XmlArrayItem hỗ trợ XmlSerializer ghi ra thẻ <MonHocDangKy><Mon>...</Mon></MonHocDangKy>
        /// </summary>
        [XmlArray("MonHocDangKy")]
        [XmlArrayItem("Mon")]
        public List<string> MonHocDangKy { get; set; } = new List<string>();

        // =========================================================================
        // 2. CÁC THUỘC TÍNH TIỆN ÍCH (GETTER-ONLY PROPERTIES)
        // =========================================================================

        /// <summary>
        /// Họ và tên đầy đủ = Họ tên lót + Tên
        /// </summary>
        [XmlIgnore]
        public string HoTenDayDu => $"{HoTenLot} {Ten}".Trim();

        /// <summary>
        /// Chuỗi hiển thị giới tính dưới dạng văn bản thân thiện ("Nam" hoặc "Nữ")
        /// </summary>
        [XmlIgnore]
        public string GioiTinhStr => GioiTinh ? "Nam" : "Nữ";

        /// <summary>
        /// Chuỗi gom tất cả các môn đăng ký ngăn cách bởi dấu phẩy
        /// Phục vụ hiển thị trên ListView và xuất file Text
        /// </summary>
        [XmlIgnore]
        public string MonHocString => MonHocDangKy != null && MonHocDangKy.Count > 0
            ? string.Join(", ", MonHocDangKy)
            : "Chưa đăng ký môn nào";

        // =========================================================================
        // 3. HÀM KHỞI TẠO (CONSTRUCTORS)
        // =========================================================================

        /// <summary>
        /// Hàm khởi tạo không tham số (Bắt buộc phải có để XmlSerializer và JsonConvert có thể tái tạo đối tượng)
        /// </summary>
        public SinhVien()
        {
            MonHocDangKy = new List<string>();
        }

        /// <summary>
        /// Hàm khởi tạo đầy đủ tham số giúp tạo nhanh đối tượng sinh viên khi nhập liệu từ Form
        /// </summary>
        public SinhVien(string maSo, string hoTenLot, string ten, bool gioiTinh,
                        DateTime ngaySinh, string lop, string soCmnd, string soDt,
                        string diaChi, List<string> monHocDangKy)
        {
            MaSo = maSo;
            HoTenLot = hoTenLot;
            Ten = ten;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            Lop = lop;
            SoCMND = soCmnd;
            SoDT = soDt;
            DiaChi = diaChi;
            MonHocDangKy = monHocDangKy ?? new List<string>();
        }

        // =========================================================================
        // 4. PHƯƠNG THỨC XUẤT CHUỖI TOSTRING
        // =========================================================================

        /// <summary>
        /// Chuyển đổi thông tin sinh viên thành chuỗi định dạng phân cách bởi ký tự đặc biệt (dấu |)
        /// Hàm này được dùng trong lớp TxtStorage để ghi dòng dữ liệu vào file students.txt
        /// </summary>
        public override string ToString()
        {
            // Danh sách các môn đăng ký nối nhau bằng dấu chấm phẩy ; để không lẫn với dấu phân cách |
            string monHocSerialized = MonHocDangKy != null ? string.Join(";", MonHocDangKy) : "";

            return $"{MaSo}|{HoTenLot}|{Ten}|{(GioiTinh ? "Nam" : "Nữ")}|{NgaySinh:dd/MM/yyyy}|{Lop}|{SoCMND}|{SoDT}|{DiaChi}|{monHocSerialized}";
        }
    }
}
