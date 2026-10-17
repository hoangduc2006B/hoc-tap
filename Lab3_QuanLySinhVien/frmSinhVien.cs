using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab3_QuanLySinhVien
{
    /// <summary>
    /// Lớp frmSinhVien: Giao diện chính của chương trình Quản lý sinh viên (Lab 3).
    /// Tuân thủ kiến trúc phân tầng:
    /// - Tầng Presentation (Giao diện): frmSinhVien tiếp nhận sự kiện người dùng (Click, Select, Check...).
    /// - Tầng Business Logic (Nghiệp vụ): Gọi đối tượng QuanLySinhVien để xử lý dữ liệu và kiểm tra ràng buộc.
    /// - Tầng Data Access (Lưu trữ): Thông qua IFileStorage đọc/ghi dữ liệu ra TXT, XML, hoặc JSON.
    /// </summary>
    public partial class frmSinhVien : Form
    {
        // =========================================================================
        // 1. CÁC TRƯỜNG DỮ LIỆU NỘI BỘ (FIELDS)
        // =========================================================================

        /// <summary>
        /// Đối tượng nghiệp vụ quản lý toàn bộ logic sinh viên và lưu trữ file
        /// </summary>
        private readonly QuanLySinhVien _qlsv;

        // =========================================================================
        // 2. HÀM KHỞI TẠO (CONSTRUCTOR)
        // =========================================================================

        public frmSinhVien()
        {
            InitializeComponent();
            _qlsv = new QuanLySinhVien();
        }

        // =========================================================================
        // 3. SỰ KIỆN LOAD VÀ KHỞI TẠO DỮ LIỆU BAN ĐẦU (FORM LOAD)
        // =========================================================================

        /// <summary>
        /// Sự kiện Form_Load: Được gọi tự động một lần duy nhất khi Form bắt đầu hiển thị.
        /// Luồng xử lý và quan hệ gọi hàm:
        /// frmSinhVien_Load
        ///   ├──> KhoiTaoDanhSachLop()
        ///   ├──> KhoiTaoDanhSachMonHoc()
        ///   ├──> cboDinhDang.SelectedIndex = 0 (Kích hoạt cboDinhDang_SelectedIndexChanged)
        ///   │      ├──> _qlsv.ChuyenDinhDangLuuTru()
        ///   │      ├──> _qlsv.DocTuTapTin()
        ///   │      └──> HienThiDanhSachLenListView()
        ///   │             └──> CapNhatThanhTrangThai()
        /// </summary>
        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            // 1. Khởi tạo danh sách các lớp vào ComboBox
            KhoiTaoDanhSachLop();

            // 2. Khởi tạo danh sách môn học mặc định vào CheckedListBox
            KhoiTaoDanhSachMonHoc();

            // 3. Đặt mặc định định dạng lưu trữ là TXT (vị trí 0)
            cboDinhDang.SelectedIndex = 0;
        }

        /// <summary>
        /// Hàm nội bộ: Nạp các lớp học truyền thống của khoa CNTT - ĐH Đà Lạt vào cboLop
        /// </summary>
        private void KhoiTaoDanhSachLop()
        {
            cboLop.Items.Clear();
            cboLop.Items.Add("CTK43");
            cboLop.Items.Add("CTK44");
            cboLop.Items.Add("CTK45");
            cboLop.Items.Add("CTK46");
            cboLop.Items.Add("CTK47");
            cboLop.SelectedIndex = 1; // Mặc định chọn CTK44
        }

        /// <summary>
        /// Hàm nội bộ: Nạp 8 môn học cơ sở và chuyên ngành vào clbMonHoc
        /// theo đúng giao diện mẫu tại trang 58 của tài liệu thực hành
        /// </summary>
        private void KhoiTaoDanhSachMonHoc()
        {
            clbMonHoc.Items.Clear();
            clbMonHoc.Items.Add("Mạng máy tính");
            clbMonHoc.Items.Add("Hệ điều hành");
            clbMonHoc.Items.Add("Lập trình CSDL");
            clbMonHoc.Items.Add("Lập trình mạng");
            clbMonHoc.Items.Add("Đồ án cơ sở");
            clbMonHoc.Items.Add("Phương pháp NCKH");
            clbMonHoc.Items.Add("Lập trình trên thiết bị di động");
            clbMonHoc.Items.Add("An toàn và bảo mật hệ thống");
        }

        // =========================================================================
        // 4. CHUYỂN ĐỔI ĐỊNH DẠNG LƯU TRỮ (STRATEGY PATTERN IN ACTION)
        // =========================================================================

        /// <summary>
        /// Sự kiện ComboBox Định dạng thay đổi lựa chọn (TXT, XML, JSON).
        /// Luồng xử lý:
        /// 1. Xác định người dùng chọn loại nào.
        /// 2. Gọi _qlsv.ChuyenDinhDangLuuTru(kieu) để chuyển đổi thuật toán đọc/ghi.
        /// 3. Nếu file đích chưa tồn tại nhưng đang có dữ liệu trong RAM, tự động lưu sang file mới.
        /// 4. Đọc dữ liệu từ file mới và hiển thị lại lên ListView.
        /// </summary>
        private void cboDinhDang_SelectedIndexChanged(object sender, EventArgs e)
        {
            KieuTapTin kieuChon = (KieuTapTin)cboDinhDang.SelectedIndex;
            _qlsv.ChuyenDinhDangLuuTru(kieuChon);

            // Kiểm tra xem file đã có trên đĩa chưa
            if (!File.Exists(_qlsv.DuongDanHienHanh))
            {
                // Nếu chưa có file nhưng RAM đã có dữ liệu từ định dạng trước, ghi ra file mới luôn
                if (_qlsv.DanhSach.Count > 0)
                {
                    _qlsv.LuuVaoTapTin();
                }
                else
                {
                    // Nếu chưa có gì, tạo file mẫu ban đầu
                    TaoDuLieuMauNeuChuaCo();
                }
            }

            // Đọc dữ liệu từ tập tin hiện hành vào RAM
            try
            {
                _qlsv.DocTuTapTin();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể đọc tập tin {_qlsv.DuongDanHienHanh}: {ex.Message}",
                                "Lỗi đọc file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Đổ danh sách sinh viên lên giao diện ListView
            HienThiDanhSachLenListView();
        }

        /// <summary>
        /// Hàm nội bộ: Tự động khởi tạo dữ liệu mẫu nếu ứng dụng mới chạy lần đầu chưa có file
        /// </summary>
        private void TaoDuLieuMauNeuChuaCo()
        {
            var sv1 = new SinhVien
            {
                MaSo = "2010123",
                HoTenLot = "Nguyễn Văn",
                Ten = "An",
                GioiTinh = true,
                NgaySinh = new DateTime(2002, 5, 15),
                Lop = "CTK44",
                SoCMND = "123456789",
                SoDT = "0912.345.678",
                DiaChi = "01 Phù Đổng Thiên Vương, Đà Lạt",
                MonHocDangKy = new List<string> { "Mạng máy tính", "Hệ điều hành", "Lập trình CSDL" }
            };

            var sv2 = new SinhVien
            {
                MaSo = "2010456",
                HoTenLot = "Trần Thị",
                Ten = "Bình",
                GioiTinh = false,
                NgaySinh = new DateTime(2002, 8, 20),
                Lop = "CTK44",
                SoCMND = "987654321",
                SoDT = "0987.654.321",
                DiaChi = "12 Trần Phú, Đà Lạt",
                MonHocDangKy = new List<string> { "Đồ án cơ sở", "Phương pháp NCKH" }
            };

            var sv3 = new SinhVien
            {
                MaSo = "2110789",
                HoTenLot = "Lê Hoàng",
                Ten = "Cường",
                GioiTinh = true,
                NgaySinh = new DateTime(2003, 11, 10),
                Lop = "CTK45",
                SoCMND = "234567890",
                SoDT = "0905.111.222",
                DiaChi = "25 Bùi Thị Xuân, Đà Lạt",
                MonHocDangKy = new List<string> { "Lập trình mạng", "Lập trình trên thiết bị di động", "An toàn và bảo mật hệ thống" }
            };

            _qlsv.DanhSach.Add(sv1);
            _qlsv.DanhSach.Add(sv2);
            _qlsv.DanhSach.Add(sv3);
            _qlsv.LuuVaoTapTin();
        }

        // =========================================================================
        // 5. HIỂN THỊ DỮ LIỆU LÊN GIAO DIỆN (UI BINDING)
        // =========================================================================

        /// <summary>
        /// Hiển thị toàn bộ danh sách sinh viên từ RAM lên ListView
        /// </summary>
        private void HienThiDanhSachLenListView()
        {
            lvSinhVien.Items.Clear();

            foreach (var sv in _qlsv.DanhSach)
            {
                ListViewItem item = new ListViewItem(sv.MaSo);
                item.SubItems.Add(sv.HoTenLot);
                item.SubItems.Add(sv.Ten);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.SoCMND);
                item.SubItems.Add(sv.SoDT);
                item.SubItems.Add(sv.DiaChi);

                // Gán cả đối tượng SinhVien vào thuộc tính Tag của dòng để lấy lại nhanh chóng khi click
                item.Tag = sv;

                lvSinhVien.Items.Add(item);
            }

            // Cập nhật dòng trạng thái góc dưới Form
            CapNhatThanhTrangThai();
        }

        /// <summary>
        /// Cập nhật nhãn tổng số sinh viên và tên file hiện tại trên StatusStrip
        /// </summary>
        private void CapNhatThanhTrangThai()
        {
            tssSoLuong.Text = $"Tổng số sinh viên: {_qlsv.TongSoLuong}";
            tssDinhDang.Text = $"| Tập tin hiện hành: {_qlsv.DuongDanHienHanh} ({_qlsv.DinhDangHienHanh})";
        }

        /// <summary>
        /// Đọc các giá trị người dùng vừa nhập trên các Control của Form và đóng gói thành một đối tượng SinhVien
        /// </summary>
        private SinhVien ThuThapThongTinTuGiaoDien()
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = mtxtMSSV.Text.Trim();
            sv.HoTenLot = txtHoTenLot.Text.Trim();
            sv.Ten = txtTen.Text.Trim();
            sv.GioiTinh = rdNam.Checked; // Nếu rdNam được chọn thì true, ngược lại false
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.Lop = cboLop.SelectedItem != null ? cboLop.SelectedItem.ToString() : string.Empty;
            sv.SoCMND = mtxtCMND.Text.Trim();
            sv.SoDT = mtxtSoDT.Text.Trim();
            sv.DiaChi = txtDiaChi.Text.Trim();

            // Thu thập các môn học được đánh dấu kiểm (Checked) trong CheckedListBox
            sv.MonHocDangKy = new List<string>();
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
            {
                if (clbMonHoc.GetItemChecked(i))
                {
                    sv.MonHocDangKy.Add(clbMonHoc.Items[i].ToString());
                }
            }

            return sv;
        }

        /// <summary>
        /// Đổ dữ liệu từ đối tượng SinhVien lên các Control nhập liệu trên Form
        /// </summary>
        private void DoDuLieuLenGiaoDien(SinhVien sv)
        {
            if (sv == null) return;

            mtxtMSSV.Text = sv.MaSo;
            txtHoTenLot.Text = sv.HoTenLot;
            txtTen.Text = sv.Ten;
            rdNam.Checked = sv.GioiTinh;
            rdNu.Checked = !sv.GioiTinh;
            dtpNgaySinh.Value = sv.NgaySinh;
            cboLop.SelectedItem = sv.Lop;
            mtxtCMND.Text = sv.SoCMND;
            mtxtSoDT.Text = sv.SoDT;
            txtDiaChi.Text = sv.DiaChi;

            // Xóa tất cả đánh dấu cũ của CheckedListBox
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
            {
                clbMonHoc.SetItemChecked(i, false);
            }

            // Đánh dấu lại những môn học sinh viên này đã đăng ký
            if (sv.MonHocDangKy != null)
            {
                for (int i = 0; i < clbMonHoc.Items.Count; i++)
                {
                    string tenMon = clbMonHoc.Items[i].ToString();
                    if (sv.MonHocDangKy.Contains(tenMon))
                    {
                        clbMonHoc.SetItemChecked(i, true);
                    }
                }
            }
        }

        /// <summary>
        /// Xóa trắng tất cả các ô nhập liệu trên Form để chuẩn bị thêm sinh viên mới
        /// </summary>
        private void XoaTrangGiaoDien()
        {
            mtxtMSSV.Clear();
            txtHoTenLot.Clear();
            txtTen.Clear();
            rdNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            mtxtCMND.Clear();
            mtxtSoDT.Clear();
            txtDiaChi.Clear();

            for (int i = 0; i < clbMonHoc.Items.Count; i++)
            {
                clbMonHoc.SetItemChecked(i, false);
            }

            mtxtMSSV.Focus();
        }

        // =========================================================================
        // 6. XỬ LÝ CÁC NÚT BẤM VÀ SỰ KIỆN CHÍNH (EVENT HANDLERS)
        // =========================================================================

        /// <summary>
        /// Xử lý sự kiện bấm nút "Thêm mới" sinh viên:
        /// Luồng hoạt động và quan hệ hàm:
        /// btnThem_Click
        ///   ├──> ThuThapThongTinTuGiaoDien() -> Trả về đối tượng SinhVien
        ///   ├──> KiemTraDuLieuDauVao() -> Kiểm tra không để trống các trường bắt buộc
        ///   ├──> QuanLySinhVien.KiemTraQuyTacMSSV() -> Kiểm tra quy tắc AABBCCC trang 59
        ///   ├──> _qlsv.Them(sv, out thongBaoLoi) -> Lưu RAM và đồng bộ xuống File
        ///   └──> HienThiDanhSachLenListView() -> Làm mới ListView và StatusStrip
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Bước 1: Thu thập thông tin từ các điều khiển
            SinhVien sv = ThuThapThongTinTuGiaoDien();

            // Bước 2: Kiểm tra dữ liệu đầu vào bắt buộc
            if (!KiemTraDuLieuDauVao(sv, out string loiDauVao))
            {
                MessageBox.Show(loiDauVao, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 3: Kiểm tra quy tắc MSSV AABBCCC theo mục 3 trang 59 tài liệu
            if (!QuanLySinhVien.KiemTraQuyTacMSSV(sv.MaSo, sv.Lop, out string loiQuyTac))
            {
                MessageBox.Show(loiQuyTac, "Vi phạm quy tắc MSSV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtMSSV.Focus();
                return;
            }

            // Bước 4: Thêm vào tầng nghiệp vụ (kiểm tra trùng mã và ghi file)
            if (_qlsv.Them(sv, out string thongBaoLoi))
            {
                MessageBox.Show($"Thêm thành công sinh viên [{sv.HoTenDayDu}] vào hệ thống!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại giao diện danh sách
                HienThiDanhSachLenListView();

                // Xóa trắng form để người dùng tiện nhập tiếp
                XoaTrangGiaoDien();
            }
            else
            {
                MessageBox.Show(thongBaoLoi, "Không thể thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện bấm nút "Cập nhật" thông tin sinh viên:
        /// Cho phép người dùng chỉnh sửa thông tin của sinh viên đang chọn dựa trên MSSV.
        /// </summary>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SinhVien sv = ThuThapThongTinTuGiaoDien();

            // Kiểm tra dữ liệu đầu vào
            if (!KiemTraDuLieuDauVao(sv, out string loiDauVao))
            {
                MessageBox.Show(loiDauVao, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra quy tắc MSSV
            if (!QuanLySinhVien.KiemTraQuyTacMSSV(sv.MaSo, sv.Lop, out string loiQuyTac))
            {
                MessageBox.Show(loiQuyTac, "Vi phạm quy tắc MSSV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi hàm cập nhật từ tầng nghiệp vụ
            if (_qlsv.CapNhat(sv, out string thongBaoLoi))
            {
                MessageBox.Show($"Đã cập nhật thông tin cho sinh viên [{sv.HoTenDayDu}] thành công!",
                                "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                HienThiDanhSachLenListView();
            }
            else
            {
                MessageBox.Show(thongBaoLoi, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện chọn một dòng trong ListView:
        /// Tự động lấy đối tượng sinh viên từ dòng được chọn và nạp lên các điều khiển phía trên Form.
        /// </summary>
        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lvSinhVien.SelectedItems[0];
                SinhVien sv = item.Tag as SinhVien;
                if (sv != null)
                {
                    DoDuLieuLenGiaoDien(sv);
                }
            }
        }

        /// <summary>
        /// Sự kiện bấm nút "Tìm kiếm":
        /// Yêu cầu mục 2 trang 59: Hiển thị form tìm kiếm theo MSSV/Tên/Lớp.
        /// Khi người dùng chọn kết quả trong form tìm kiếm, tự động định vị và nạp sinh viên đó lên Form chính.
        /// </summary>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (frmTimKiem frm = new frmTimKiem(_qlsv))
            {
                // Hiển thị Form tìm kiếm dưới dạng hộp thoại Modal
                if (frm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(frm.MaSinhVienDaChon))
                {
                    // Tìm kiếm và đánh dấu sinh viên được trả về trên ListView chính
                    foreach (ListViewItem item in lvSinhVien.Items)
                    {
                        if (item.Text.Equals(frm.MaSinhVienDaChon, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            item.EnsureVisible(); // Cuộn thanh trượt tới vị trí sinh viên
                            lvSinhVien.Focus();

                            // Nạp dữ liệu lên Form
                            SinhVien sv = item.Tag as SinhVien;
                            if (sv != null)
                            {
                                DoDuLieuLenGiaoDien(sv);
                            }
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện bấm nút "Thoát": Hỏi xác nhận trước khi đóng phần mềm
        /// </summary>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình Quản lý sinh viên?",
                                                  "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // =========================================================================
        // 7. XỬ LÝ CONTEXT MENU STRIP (CHUỘT PHẢI) TRÊN LISTVIEW VÀ CHECKEDLISTBOX
        // =========================================================================

        /// <summary>
        /// Menu chuột phải trên ListView: Xóa các sinh viên được đánh dấu chọn (Checked).
        /// Yêu cầu mục 1 trang 59:
        /// "Thực hiện chức năng xóa sinh viên bằng cách chọn 1 hoặc nhiều sinh viên
        /// (có thể dùng phím kết hợp Shift, Ctrl hoặc đánh dấu chọn vào ô CheckBox ở đầu mỗi dòng),
        /// nhấp phím Delete hoặc nhấp chuột phải chọn lệnh Xóa trên menu ngữ cảnh".
        /// </summary>
        private void mnuXoaChecked_Click(object sender, EventArgs e)
        {
            List<string> dsMaCanXoa = new List<string>();

            // 1. Quét qua các dòng được đánh dấu CheckBox
            foreach (ListViewItem item in lvSinhVien.CheckedItems)
            {
                dsMaCanXoa.Add(item.Text);
            }

            // 2. Nếu không có CheckBox nào được chọn, kiểm tra các dòng đang được bôi xanh (SelectedItems)
            if (dsMaCanXoa.Count == 0 && lvSinhVien.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvSinhVien.SelectedItems)
                {
                    dsMaCanXoa.Add(item.Text);
                }
            }

            // 3. Nếu vẫn không có dòng nào được chọn thì nhắc người dùng
            if (dsMaCanXoa.Count == 0)
            {
                MessageBox.Show("Vui lòng đánh dấu chọn (Check) hoặc bôi chọn ít nhất một sinh viên để xóa!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. Hỏi xác nhận người dùng trước khi thực hiện xóa vĩnh viễn
            DialogResult hoi = MessageBox.Show($"Bạn có thực sự muốn xóa {dsMaCanXoa.Count} sinh viên đã chọn ra khỏi hệ thống và tập tin?",
                                               "Xác nhận xóa sinh viên", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (hoi == DialogResult.Yes)
            {
                // Gọi hàm XoaNhieu ở tầng nghiệp vụ
                int daXoa = _qlsv.XoaNhieu(dsMaCanXoa);

                MessageBox.Show($"Đã xóa thành công {daXoa} sinh viên!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại giao diện và xóa trắng các ô nhập
                HienThiDanhSachLenListView();
                XoaTrangGiaoDien();
            }
        }

        /// <summary>
        /// Menu chuột phải trên ListView: Đánh dấu CheckBox cho tất cả sinh viên
        /// </summary>
        private void mnuChonTatCa_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvSinhVien.Items)
            {
                item.Checked = true;
            }
        }

        /// <summary>
        /// Menu chuột phải trên ListView: Bỏ chọn CheckBox cho tất cả sinh viên
        /// </summary>
        private void mnuBoChonTatCa_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvSinhVien.Items)
            {
                item.Checked = false;
            }
        }

        /// <summary>
        /// Menu chuột phải trên CheckedListBox: Thêm một môn học mới vào danh sách môn học
        /// Yêu cầu mục 4 trang 59: "Thêm menu ngữ cảnh vào CheckedListBox cho phép thêm, xóa môn học".
        /// </summary>
        private void mnuThemMon_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại nhập tên môn học nhanh chóng bằng một Form nhỏ
            using (Form prompt = new Form())
            {
                prompt.Width = 420;
                prompt.Height = 160;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "Thêm môn học mới";
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label textLabel = new Label() { Left = 20, Top = 20, Text = "Tên môn học mới:", AutoSize = true };
                TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 360 };
                Button confirmation = new Button() { Text = "Thêm", Left = 210, Width = 80, Top = 80, DialogResult = DialogResult.OK };
                Button cancel = new Button() { Text = "Hủy", Left = 300, Width = 80, Top = 80, DialogResult = DialogResult.Cancel };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);
                prompt.AcceptButton = confirmation;
                prompt.CancelButton = cancel;

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    string monMoi = textBox.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(monMoi))
                    {
                        if (!clbMonHoc.Items.Contains(monMoi))
                        {
                            clbMonHoc.Items.Add(monMoi, true); // Thêm và tích chọn luôn
                            MessageBox.Show($"Đã thêm môn [{monMoi}] vào danh sách!", "Thành công",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Môn học [{monMoi}] đã có trong danh sách!", "Cảnh báo",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Menu chuột phải trên CheckedListBox: Xóa môn học đang được chọn khỏi danh sách
        /// </summary>
        private void mnuXoaMon_Click(object sender, EventArgs e)
        {
            if (clbMonHoc.SelectedIndex >= 0)
            {
                string tenMon = clbMonHoc.SelectedItem.ToString();
                DialogResult hoi = MessageBox.Show($"Bạn có muốn xóa môn học [{tenMon}] khỏi danh sách môn đăng ký?",
                                                   "Xác nhận xóa môn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hoi == DialogResult.Yes)
                {
                    clbMonHoc.Items.RemoveAt(clbMonHoc.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhấp chọn một môn học trong danh sách trước khi xóa!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =========================================================================
        // 8. HÀM KIỂM TRA TÍNH TOÀN VẸN DỮ LIỆU ĐẦU VÀO (VALIDATION)
        // =========================================================================

        /// <summary>
        /// Kiểm tra tính đầy đủ và hợp lệ của thông tin sinh viên trước khi thêm/sửa
        /// </summary>
        private bool KiemTraDuLieuDauVao(SinhVien sv, out string thongBaoLoi)
        {
            thongBaoLoi = string.Empty;

            if (string.IsNullOrWhiteSpace(sv.MaSo))
            {
                thongBaoLoi = "Mã số sinh viên không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sv.HoTenLot))
            {
                thongBaoLoi = "Họ và tên lót không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sv.Ten))
            {
                thongBaoLoi = "Tên sinh viên không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sv.Lop))
            {
                thongBaoLoi = "Vui lòng chọn lớp học cho sinh viên!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sv.SoCMND) || sv.SoCMND.Length != 9)
            {
                thongBaoLoi = "Số CMND phải gồm đúng 9 chữ số!";
                return false;
            }

            return true;
        }
    }
}
