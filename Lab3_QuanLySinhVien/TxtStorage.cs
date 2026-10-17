using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Lab3_QuanLySinhVien
{
    /// <summary>
    /// Lớp TxtStorage: Chuyên trách đọc và ghi dữ liệu danh sách sinh viên dưới dạng tập tin văn bản thuần (*.txt).
    /// Áp dụng System.IO, StreamReader, StreamWriter theo đúng chuẩn hướng dẫn thực hành của Chủ đề 3 (trang 51).
    /// Quy ước định dạng mỗi dòng trong file:
    /// MaSo|HoTenLot|Ten|GioiTinh|NgaySinh|Lop|SoCMND|SoDT|DiaChi|Mon1;Mon2;Mon3
    /// </summary>
    public class TxtStorage : IFileStorage
    {
        /// <summary>
        /// Phương thức đọc danh sách sinh viên từ tập tin TXT.
        /// Luồng hoạt động:
        /// 1. Kiểm tra tập tin có tồn tại hay không bằng File.Exists().
        /// 2. Dùng StreamReader với Encoding UTF-8 để đọc tiếng Việt có dấu chuẩn xác.
        /// 3. Lặp qua từng dòng, tách chuỗi theo ký tự '|' bằng phương thức Split.
        /// 4. Ép kiểu dữ liệu từng cột (Parse ngày tháng, giới tính, danh sách môn học).
        /// 5. Tạo đối tượng SinhVien và thêm vào List kết quả.
        /// </summary>
        public List<SinhVien> DocDanhSach(string duongDan)
        {
            List<SinhVien> ketQua = new List<SinhVien>();

            // Bước 1: Kiểm tra an toàn trước khi mở file để tránh lỗi FileNotFoundException
            if (!File.Exists(duongDan))
            {
                return ketQua; // Nếu file chưa tồn tại, trả về danh sách rỗng an toàn
            }

            try
            {
                // Bước 2: Khởi tạo luồng đọc StreamReader với mã hóa UTF-8
                // Sử dụng khối lệnh 'using' để đảm bảo tự động đóng luồng (Dispose) giải phóng tài nguyên hệ điều hành
                using (StreamReader reader = new StreamReader(duongDan, Encoding.UTF8))
                {
                    string line;
                    // Đọc tuần tự từng dòng văn bản cho tới khi hết file (đạt giá trị null)
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Bỏ qua các dòng trống hoặc chỉ toàn khoảng trắng
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        // Bước 3: Tách dòng thành các trường thông tin thông qua dấu phân cách '|'
                        string[] parts = line.Split('|');

                        // Đảm bảo dòng có tối thiểu 9 trường thông tin cơ bản
                        if (parts.Length >= 9)
                        {
                            SinhVien sv = new SinhVien();
                            sv.MaSo = parts[0].Trim();
                            sv.HoTenLot = parts[1].Trim();
                            sv.Ten = parts[2].Trim();
                            sv.GioiTinh = parts[3].Trim().Equals("Nam", StringComparison.OrdinalIgnoreCase);

                            // Chuyển đổi chuỗi ngày sinh "dd/MM/yyyy" sang kiểu DateTime
                            if (DateTime.TryParseExact(parts[4].Trim(), "dd/MM/yyyy",
                                                       CultureInfo.InvariantCulture,
                                                       DateTimeStyles.None, out DateTime ns))
                            {
                                sv.NgaySinh = ns;
                            }
                            else
                            {
                                sv.NgaySinh = DateTime.Now;
                            }

                            sv.Lop = parts[5].Trim();
                            sv.SoCMND = parts[6].Trim();
                            sv.SoDT = parts[7].Trim();
                            sv.DiaChi = parts[8].Trim();

                            // Trường thứ 10 (chỉ số 9) chứa danh sách các môn học phân cách bởi dấu chấm phẩy ';'
                            if (parts.Length >= 10 && !string.IsNullOrWhiteSpace(parts[9]))
                            {
                                string[] dsMon = parts[9].Split(';');
                                foreach (string m in dsMon)
                                {
                                    string monTrim = m.Trim();
                                    if (!string.IsNullOrEmpty(monTrim))
                                        sv.MonHocDangKy.Add(monTrim);
                                }
                            }

                            // Bước 4: Thêm sinh viên vừa bóc tách thành công vào danh sách kết quả
                            ketQua.Add(sv);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi trong quá trình đọc tập tin TXT [{duongDan}]: {ex.Message}", ex);
            }

            return ketQua;
        }

        /// <summary>
        /// Phương thức ghi toàn bộ danh sách sinh viên xuống tập tin TXT.
        /// Luồng hoạt động:
        /// 1. Tự động tạo thư mục cha nếu chưa tồn tại.
        /// 2. Khởi tạo StreamWriter với UTF-8 để ghi dữ liệu tiếng Việt.
        /// 3. Lặp qua từng sinh viên, gọi phương thức sv.ToString() để lấy chuỗi định dạng '|'.
        /// 4. Ghi từng dòng xuống đĩa bằng WriteLine().
        /// </summary>
        public void GhiDanhSach(string duongDan, List<SinhVien> danhSach)
        {
            try
            {
                // Đảm bảo thư mục chứa file đã tồn tại trước khi mở luồng ghi
                string folder = Path.GetDirectoryName(duongDan);
                if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                // Khởi tạo luồng ghi StreamWriter (tham số false: ghi đè file mới)
                using (StreamWriter writer = new StreamWriter(duongDan, false, Encoding.UTF8))
                {
                    foreach (SinhVien sv in danhSach)
                    {
                        // Phương thức sv.ToString() đã được ghi đè chuẩn định dạng "MaSo|HoTenLot|..."
                        writer.WriteLine(sv.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi trong quá trình ghi tập tin TXT [{duongDan}]: {ex.Message}", ex);
            }
        }
    }
}
