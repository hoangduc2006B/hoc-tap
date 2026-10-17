using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bai5_SinhVienKhoaCNTT
{
    public partial class frmSinhVien : Form
    {
        private readonly QuanLySinhVien _qlsv;
        private readonly string _filePath;
        private bool _isModified = false;

        public frmSinhVien()
        {
            InitializeComponent();
            _qlsv = new QuanLySinhVien();
            _filePath = Path.Combine(Application.StartupPath, "DSNV.txt");
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            if (cboLop.Items.Count > 0)
                cboLop.SelectedIndex = 0;

            TaiDuLieuTuFile();
            _isModified = false;
        }

        private void TaiDuLieuTuFile()
        {
            if (!File.Exists(_filePath))
            {
                // Fallback nếu chạy trong IDE
                string altPath = "DSNV.txt";
                if (File.Exists(altPath))
                    _qlsv.DocTuFile(altPath);
            }
            else
            {
                _qlsv.DocTuFile(_filePath);
            }

            HienThiLenListView();
        }

        private void HienThiLenListView()
        {
            lvSinhVien.Items.Clear();
            foreach (SinhVien sv in _qlsv.DanhSach)
            {
                ListViewItem item = new ListViewItem(sv.MaSo);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.Phai ? "Nam" : "Nữ");
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.SoDT);
                item.SubItems.Add(sv.Email);
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(sv.Hinh);

                lvSinhVien.Items.Add(item);
            }
        }

        private SinhVien ThuThapThongTin()
        {
            string maSo = mtxtMaSo.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            bool phai = rdNam.Checked;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string lop = cboLop.SelectedItem?.ToString() ?? "";
            string soDT = mtxtSoDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string hinh = txtHinh.Text.Trim();

            return new SinhVien(maSo, hoTen, phai, ngaySinh, lop, soDT, email, diaChi, hinh);
        }

        private void ThietLapThongTin(SinhVien sv)
        {
            mtxtMaSo.Text = sv.MaSo;
            txtHoTen.Text = sv.HoTen;
            rdNam.Checked = sv.Phai;
            rdNu.Checked = !sv.Phai;
            dtpNgaySinh.Value = sv.NgaySinh;
            cboLop.SelectedItem = sv.Lop;
            mtxtSoDT.Text = sv.SoDT;
            txtEmail.Text = sv.Email;
            txtDiaChi.Text = sv.DiaChi;
            txtHinh.Text = sv.Hinh;

            if (!string.IsNullOrEmpty(sv.Hinh) && File.Exists(sv.Hinh))
            {
                try
                {
                    pbHinh.Image = Image.FromFile(sv.Hinh);
                }
                catch
                {
                    pbHinh.Image = null;
                }
            }
            else
            {
                pbHinh.Image = null;
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                string maSo = lvSinhVien.SelectedItems[0].Text;
                SinhVien sv = _qlsv.TimTheoMa(maSo);
                if (sv != null)
                {
                    ThietLapThongTin(sv);
                }
            }
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All Files (*.*)|*.*";
                ofd.Title = "Chọn hình ảnh sinh viên";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtHinh.Text = ofd.FileName;
                    try
                    {
                        pbHinh.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            mtxtMaSo.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            rdNam.Checked = true;
            rdNu.Checked = false;
            if (cboLop.Items.Count > 0)
                cboLop.SelectedIndex = 0;
            mtxtSoDT.Clear();
            txtHinh.Clear();
            pbHinh.Image = null;
            mtxtMaSo.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã sinh viên 7 chữ số
            string maSo = mtxtMaSo.Text.Trim();
            if (maSo.Length != 7)
            {
                MessageBox.Show("Mã số sinh viên phải đúng 7 ký tự số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtMaSo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ và tên sinh viên không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            SinhVien sv = ThuThapThongTin();
            SinhVien svCu = _qlsv.TimTheoMa(sv.MaSo);

            if (svCu != null)
            {
                // Cập nhật thông tin sinh viên đã tồn tại
                _qlsv.CapNhat(sv);
                MessageBox.Show($"Cập nhật sinh viên {sv.MaSo} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Thêm sinh viên mới
                _qlsv.Them(sv);
                MessageBox.Show($"Thêm mới sinh viên {sv.MaSo} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _isModified = true;
            HienThiLenListView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa {lvSinhVien.SelectedItems.Count} sinh viên đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                foreach (ListViewItem item in lvSinhVien.SelectedItems)
                {
                    _qlsv.Xoa(item.Text);
                }
                _isModified = true;
                HienThiLenListView();
                btnMacDinh_Click(sender, e);
            }
        }

        private void mnuTaiLai_Click(object sender, EventArgs e)
        {
            TaiDuLieuTuFile();
            _isModified = false;
        }

        private void frmSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isModified)
            {
                DialogResult dr = MessageBox.Show("Danh sách sinh viên đã có sự thay đổi. Bạn có muốn lưu lại vào tập tin DSNV.txt không?", "Xác nhận lưu thay đổi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        _qlsv.GhiRaFile(_filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
