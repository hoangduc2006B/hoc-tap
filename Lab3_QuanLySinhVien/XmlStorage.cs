using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Lab3_QuanLySinhVien
{
    /// <summary>
    /// Lớp XmlStorage: Chuyên trách đọc và ghi dữ liệu sinh viên dưới định dạng XML (*.xml).
    /// Sử dụng kỹ thuật XmlSerializer (Tuần tự hóa XML) được giảng dạy trong Chủ đề 3 (trang 57-58).
    /// Ưu điểm của XmlSerializer:
    /// - Tự động ánh xạ giữa các thuộc tính của C# Object và các thẻ XML (<SinhVien>, <MaSo>, <MonHocDangKy>).
    /// - Không cần phải thủ công parse từng chuỗi như file TXT thông thường.
    /// - Dữ liệu có cấu trúc thẻ tự mô tả (self-describing), dễ dàng mở rộng và trao đổi dữ liệu với các hệ thống khác.
    /// </summary>
    public class XmlStorage : IFileStorage
    {
        // Khởi tạo một đối tượng XmlSerializer tương ứng với kiểu dữ liệu List<SinhVien>
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<SinhVien>), new XmlRootAttribute("DanhSachSinhVien"));

        /// <summary>
        /// Phương thức đọc danh sách sinh viên từ tập tin XML.
        /// Luồng hoạt động:
        /// 1. Kiểm tra tập tin có tồn tại không bằng File.Exists().
        /// 2. Mở FileStream ở chế độ đọc FileMode.Open.
        /// 3. Sử dụng XmlSerializer.Deserialize() để giải mã toàn bộ cây XML thành đối tượng C# List<SinhVien>.
        /// 4. Đóng FileStream an toàn thông qua khối lệnh using.
        /// </summary>
        public List<SinhVien> DocDanhSach(string duongDan)
        {
            // Kiểm tra an toàn sự tồn tại của tập tin XML
            if (!File.Exists(duongDan))
            {
                return new List<SinhVien>();
            }

            try
            {
                using (FileStream fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read))
                {
                    // Giải tuần tự hóa từ XML sang List<SinhVien>
                    object obj = _serializer.Deserialize(fs);
                    if (obj is List<SinhVien> danhSach)
                    {
                        return danhSach;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi trong quá trình đọc tập tin XML [{duongDan}]: {ex.Message}", ex);
            }

            return new List<SinhVien>();
        }

        /// <summary>
        /// Phương thức ghi toàn bộ danh sách sinh viên xuống tập tin XML.
        /// Luồng hoạt động:
        /// 1. Đảm bảo thư mục lưu trữ đã được tạo sẵn.
        /// 2. Cấu hình XmlWriterSettings với Indent = true để file XML sinh ra có thụt đầu dòng đẹp mắt, dễ đọc.
        /// 3. Khởi tạo XmlWriter bao bọc FileStream để ghi file theo chuẩn mã hóa UTF-8.
        /// 4. Gọi XmlSerializer.Serialize() để tự động chuyển toàn bộ danh sách sinh viên thành các thẻ XML.
        /// </summary>
        public void GhiDanhSach(string duongDan, List<SinhVien> danhSach)
        {
            try
            {
                // Bước 1: Tạo thư mục cha nếu chưa tồn tại
                string folder = Path.GetDirectoryName(duongDan);
                if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                // Bước 2: Thiết lập cấu hình định dạng thụt lề XML cho ngay ngắn, chuẩn mực
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,                     // Tự động thụt lề giữa các thẻ cha - con
                    IndentChars = "  ",                // Dùng 2 khoảng trắng cho mỗi bậc thụt lề
                    Encoding = Encoding.UTF8,          // Mã hóa UTF-8 để hỗ trợ đầy đủ tiếng Việt có dấu
                    OmitXmlDeclaration = false         // Giữ nguyên dòng khai báo <?xml version="1.0" encoding="utf-8"?> ở đầu file
                };

                // Bước 3: Mở luồng XmlWriter và tiến hành tuần tự hóa dữ liệu
                using (XmlWriter writer = XmlWriter.Create(duongDan, settings))
                {
                    _serializer.Serialize(writer, danhSach);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi trong quá trình ghi tập tin XML [{duongDan}]: {ex.Message}", ex);
            }
        }
    }
}
