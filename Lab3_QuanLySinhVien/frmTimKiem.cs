using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab3_QuanLySinhVien
{
    /// <summary>
    /// Lớp frmTimKiem: Form tìm kiếm thông tin sinh viên theo yêu cầu mục 2 trang 59:
    /// "Khi nhấp chuột vào nút Tìm kiếm, chương trình phải hiển thị giao diện cho người dùng
    /// nhập điều kiện tìm kiếm (theo MSSV/Tên/Lớp hoặc nhiều điều kiện bất kỳ)".
    /// </summary>
    public partial class frmTimKiem : Form
    {
        // Tham chiếu tới đối tượng QuanLySinhVien được truyền từ Form chính
        private readonly QuanLySinhVien _qlsv;

        /// <summary>
        /// Mã sinh viên được người dùng chọn từ kết quả tìm kiếm (để trả về Form chính)
        /// </summary>
        public string MaSinhVienDaChon { get; private set; } = string.Empty;

        /// <summary>
        /// Hàm khởi tạo nhận đối tượng QuanLySinhVien từ frmSinhVien truyền sang
        /// </summary>
        public frmTimKiem(QuanLySinhVien qlsv)
        {
            InitializeComponent();
            _qlsv = qlsv;
        }

        /// <summary>
        /// Sự kiện Load Form: Nạp danh sách các lớp vào ComboBox để người dùng dễ chọn
        /// </summary>
        private void frmTimKiem_Load(object sender, EventArgs e)
        {
            cboLop.Items.Clear();
            cboLop.Items.Add("-- Tất cả các lớp --");

            // Nạp các lớp phổ biến tại ĐH Đà Lạt
            cboLop.Items.Add("CTK43");
            cboLop.Items.Add("CTK44");
            cboLop.Items.Add("CTK45");
            cboLop.Items.Add("CTK46");
            cboLop.Items.Add("CTK47");

            // Lấy thêm các lớp thực tế có trong dữ liệu sinh viên
            foreach (var sv in _qlsv.DanhSach)
            {
                if (!cboLop.Items.Contains(sv.Lop) && !string.IsNullOrWhiteSpace(sv.Lop))
                {
                    cboLop.Items.Add(sv.Lop);
                }
            }

            cboLop.SelectedIndex = 0;
        }

        /// <summary>
        /// Xử lý sự kiện bấm nút "Tìm kiếm":
        /// Luồng hoạt động:
        /// 1. Đọc các giá trị điều kiện từ TextBox và ComboBox.
        /// 2. Kiểm tra xem người dùng đã nhập ít nhất 1 điều kiện chưa. Nếu chưa thì cảnh báo.
        /// 3. Gọi hàm TimKiem của lớp QuanLySinhVien.
        /// 4. Đổ danh sách sinh viên tìm thấy lên ListView kết quả.
        /// </summary>
        private void btnTim_Click(object sender, EventArgs e)
        {
            string mssv = chkMSSV.Checked ? txtMSSV.Text.Trim() : null;
            string hoTen = chkTen.Checked ? txtHoTen.Text.Trim() : null;
            string lop = null;

            if (chkLop.Checked && cboLop.SelectedIndex > 0)
            {
                lop = cboLop.SelectedItem.ToString();
            }

            // Kiểm tra người dùng có nhập điều kiện nào không
            if (string.IsNullOrWhiteSpace(mssv) && string.IsNullOrWhiteSpace(hoTen) && string.IsNullOrWhiteSpace(lop))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một điều kiện để tìm kiếm (MSSV, Họ tên hoặc Lớp)!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi hàm tìm kiếm từ tầng nghiệp vụ QuanLySinhVien
            List<SinhVien> ketQua = _qlsv.TimKiem(mssv, hoTen, lop);

            // Hiển thị danh sách kết quả lên ListView
            HienThiKetQua(ketQua);
        }

        /// <summary>
        /// Hàm nội bộ: Đổ danh sách sinh viên kết quả lên ListView
        /// </summary>
        private void HienThiKetQua(List<SinhVien> danhSach)
        {
            lvKetQua.Items.Clear();

            if (danhSach.Count == 0)
            {
                lblTongKetQua.Text = "Không tìm thấy sinh viên nào thỏa mãn điều kiện!";
                MessageBox.Show("Không tìm thấy kết quả nào phù hợp với yêu cầu tìm kiếm!", "Kết quả tìm kiếm",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var sv in danhSach)
            {
                ListViewItem item = new ListViewItem(sv.MaSo);
                item.SubItems.Add(sv.HoTenLot);
                item.SubItems.Add(sv.Ten);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.SoCMND);
                item.SubItems.Add(sv.SoDT);
                item.SubItems.Add(sv.DiaChi);

                // Lưu đối tượng sinh viên vào thuộc tính Tag của item để tiện truy xuất
                item.Tag = sv;

                lvKetQua.Items.Add(item);
            }

            lblTongKetQua.Text = $"* Tìm thấy {danhSach.Count} sinh viên. Nhấp đúp vào dòng để chọn về Form chính.";
        }

        /// <summary>
        /// Xóa trắng các ô nhập điều kiện để người dùng tìm đợt mới
        /// </summary>
        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            cboLop.SelectedIndex = 0;
            lvKetQua.Items.Clear();
            lblTongKetQua.Text = "* Gợi ý: Nhấp đúp vào sinh viên để chọn về Form chính";
        }

        /// <summary>
        /// Nhấp đúp vào 1 dòng trong kết quả để chọn sinh viên đó trả về cho Form chính
        /// </summary>
        private void lvKetQua_DoubleClick(object sender, EventArgs e)
        {
            if (lvKetQua.SelectedItems.Count > 0)
            {
                MaSinhVienDaChon = lvKetQua.SelectedItems[0].Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Đóng Form tìm kiếm
        /// </summary>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
