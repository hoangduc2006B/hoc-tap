using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Lab3_QuanLySinhVien
{
    /// <summary>
    /// Lớp JsonStorage: Chuyên trách đọc và ghi dữ liệu sinh viên dưới định dạng JSON (*.json).
    /// Áp dụng thư viện phổ biến nhất của hệ sinh thái .NET là Newtonsoft.Json (Json.NET)
    /// theo đúng hướng dẫn thực hành của Chủ đề 3 (trang 52 - 53).
    /// Ưu điểm của JSON:
    /// - Nhẹ, dung lượng nhỏ gọn hơn XML rất nhiều.
    /// - Tốc độ phân tích (parse) siêu nhanh, thân thiện với cả Web API và Mobile.
    /// - Dễ đọc và chỉnh sửa thủ công khi cần.
    /// </summary>
    public class JsonStorage : IFileStorage
    {
        // Cấu hình định dạng JSON: Formatting.Indented để file JSON được định dạng thụt lề đẹp mắt
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            DateFormatString = "dd/MM/yyyy" // Định dạng ngày sinh theo chuẩn Việt Nam
        };

        /// <summary>
        /// Phương thức đọc danh sách sinh viên từ tập tin JSON.
        /// Luồng hoạt động:
        /// 1. Kiểm tra File.Exists(duongDan).
        /// 2. Đọc toàn bộ nội dung chuỗi JSON bằng File.ReadAllText với Encoding.UTF8.
        /// 3. Dùng JsonConvert.DeserializeObject<List<SinhVien>>() để tự động chuyển chuỗi JSON thành List<SinhVien>.
        /// 4. Trả về danh sách sinh viên hoàn chỉnh.
        /// </summary>
        public List<SinhVien> DocDanhSach(string duongDan)
        {
            // Kiểm tra an toàn sự tồn tại của file
            if (!File.Exists(duongDan))
            {
                return new List<SinhVien>();
            }

            try
            {
                // Bước 1: Đọc toàn bộ nội dung text của file JSON
                string jsonText = File.ReadAllText(duongDan, Encoding.UTF8);

                if (string.IsNullOrWhiteSpace(jsonText))
                {
                    return new List<SinhVien>();
                }

                // Bước 2: Chuyển đổi từ chuỗi JSON sang danh sách đối tượng C#
                List<SinhVien> danhSach = JsonConvert.DeserializeObject<List<SinhVien>>(jsonText, _jsonSettings);

                return danhSach ?? new List<SinhVien>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi trong quá trình đọc tập tin JSON [{duongDan}]: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Phương thức ghi toàn bộ danh sách sinh viên xuống tập tin JSON.
        /// Luồng hoạt động:
        /// 1. Tạo thư mục cha nếu chưa có.
        /// 2. Gọi JsonConvert.SerializeObject(danhSach, Formatting.Indented) để biến List<SinhVien> thành chuỗi JSON.
        /// 3. Dùng File.WriteAllText với Encoding.UTF8 để ghi chuỗi JSON xuống ổ cứng.
        /// </summary>
        public void GhiDanhSach(string duongDan, List<SinhVien> danhSach)
        {
            try
            {
                // Bước 1: Tạo thư mục chứa file nếu chưa có
                string folder = Path.GetDirectoryName(duongDan);
                if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                // Bước 2: Tuần tự hóa danh sách sinh viên thành chuỗi định dạng JSON
                string jsonText = JsonConvert.SerializeObject(danhSach, _jsonSettings);

                // Bước 3: Ghi toàn bộ chuỗi xuống file với mã hóa UTF-8
                File.WriteAllText(duongDan, jsonText, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi trong quá trình ghi tập tin JSON [{duongDan}]: {ex.Message}", ex);
            }
        }
    }
}
