using System.Collections.Generic;

namespace Lab3_QuanLySinhVien
{
    /// <summary>
    /// Enum định nghĩa các kiểu file được chương trình hỗ trợ theo yêu cầu Lab 3:
    /// - TXT: students.txt
    /// - XML: students.xml
    /// - JSON: students.json
    /// </summary>
    public enum KieuTapTin
    {
        TXT,
        XML,
        JSON
    }

    /// <summary>
    /// Giao diện chuẩn IFileStorage:
    /// Áp dụng mẫu thiết kế Strategy Pattern để trừu tượng hóa hành vi Đọc và Ghi danh sách sinh viên.
    /// Giúp Form chính hoặc lớp QuanLySinhVien có thể linh hoạt chuyển đổi giữa TXT, XML và JSON
    /// mà không cần phải viết lại code xử lý nghiệp vụ hay sửa đổi giao diện người dùng.
    /// </summary>
    public interface IFileStorage
    {
        /// <summary>
        /// Đọc toàn bộ danh sách sinh viên từ tập tin trên ổ đĩa vào bộ nhớ RAM.
        /// </summary>
        /// <param name="duongDan">Đường dẫn đầy đủ hoặc tương đối tới tập tin dữ liệu</param>
        /// <returns>Danh sách đối tượng SinhVien</returns>
        List<SinhVien> DocDanhSach(string duongDan);

        /// <summary>
        /// Ghi toàn bộ danh sách sinh viên từ bộ nhớ RAM xuống tập tin trên ổ đĩa.
        /// </summary>
        /// <param name="duongDan">Đường dẫn đầy đủ hoặc tương đối tới tập tin dữ liệu cần lưu</param>
        /// <param name="danhSach">Danh sách các đối tượng SinhVien cần lưu</param>
        void GhiDanhSach(string duongDan, List<SinhVien> danhSach);
    }
}
