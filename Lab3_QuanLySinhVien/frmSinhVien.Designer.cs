namespace Lab3_QuanLySinhVien
{
    partial class frmSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.mtxtMSSV = new System.Windows.Forms.MaskedTextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.lblHoTenLot = new System.Windows.Forms.Label();
            this.txtHoTenLot = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblCMND = new System.Windows.Forms.Label();
            this.mtxtCMND = new System.Windows.Forms.MaskedTextBox();
            this.lblSoDT = new System.Windows.Forms.Label();
            this.mtxtSoDT = new System.Windows.Forms.MaskedTextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.clbMonHoc = new System.Windows.Forms.CheckedListBox();
            this.ctxMonHoc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuThemMon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXoaMon = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblDanhSachSV = new System.Windows.Forms.Label();
            this.lvSinhVien = new System.Windows.Forms.ListView();
            this.colMSSV = new System.Windows.Forms.ColumnHeader();
            this.colHoTenLot = new System.Windows.Forms.ColumnHeader();
            this.colTen = new System.Windows.Forms.ColumnHeader();
            this.colNgaySinh = new System.Windows.Forms.ColumnHeader();
            this.colLop = new System.Windows.Forms.ColumnHeader();
            this.colCMND = new System.Windows.Forms.ColumnHeader();
            this.colSoDT = new System.Windows.Forms.ColumnHeader();
            this.colDiaChi = new System.Windows.Forms.ColumnHeader();
            this.ctxListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuXoaChecked = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuChonTatCa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBoChonTatCa = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssSoLuong = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDinhDang = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDinhDang = new System.Windows.Forms.Label();
            this.cboDinhDang = new System.Windows.Forms.ComboBox();
            this.ctxMonHoc.SuspendLayout();
            this.ctxListView.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // lblMSSV
            //
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMSSV.Location = new System.Drawing.Point(30, 25);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(43, 15);
            this.lblMSSV.TabIndex = 0;
            this.lblMSSV.Text = "MSSV :";
            //
            // mtxtMSSV
            //
            this.mtxtMSSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mtxtMSSV.Location = new System.Drawing.Point(140, 22);
            this.mtxtMSSV.Mask = "0000000";
            this.mtxtMSSV.Name = "mtxtMSSV";
            this.mtxtMSSV.Size = new System.Drawing.Size(250, 23);
            this.mtxtMSSV.TabIndex = 1;
            //
            // lblGioiTinh
            //
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGioiTinh.Location = new System.Drawing.Point(440, 25);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(58, 15);
            this.lblGioiTinh.TabIndex = 2;
            this.lblGioiTinh.Text = "Giới tính :";
            //
            // rdNam
            //
            this.rdNam.AutoSize = true;
            this.rdNam.Checked = true;
            this.rdNam.Location = new System.Drawing.Point(525, 23);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(51, 19);
            this.rdNam.TabIndex = 3;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            //
            // rdNu
            //
            this.rdNu.AutoSize = true;
            this.rdNu.Location = new System.Drawing.Point(600, 23);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(41, 19);
            this.rdNu.TabIndex = 4;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            //
            // lblHoTenLot
            //
            this.lblHoTenLot.AutoSize = true;
            this.lblHoTenLot.Location = new System.Drawing.Point(30, 58);
            this.lblHoTenLot.Name = "lblHoTenLot";
            this.lblHoTenLot.Size = new System.Drawing.Size(81, 15);
            this.lblHoTenLot.TabIndex = 5;
            this.lblHoTenLot.Text = "Họ và tên lót :";
            //
            // txtHoTenLot
            //
            this.txtHoTenLot.Location = new System.Drawing.Point(140, 55);
            this.txtHoTenLot.Name = "txtHoTenLot";
            this.txtHoTenLot.Size = new System.Drawing.Size(250, 23);
            this.txtHoTenLot.TabIndex = 6;
            //
            // lblTen
            //
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(440, 58);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(31, 15);
            this.lblTen.TabIndex = 7;
            this.lblTen.Text = "Tên :";
            //
            // txtTen
            //
            this.txtTen.Location = new System.Drawing.Point(525, 55);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(225, 23);
            this.txtTen.TabIndex = 8;
            //
            // lblNgaySinh
            //
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(30, 92);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(66, 15);
            this.lblNgaySinh.TabIndex = 9;
            this.lblNgaySinh.Text = "Ngày sinh :";
            //
            // dtpNgaySinh
            //
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(140, 89);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(250, 23);
            this.dtpNgaySinh.TabIndex = 10;
            //
            // lblLop
            //
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(440, 92);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(33, 15);
            this.lblLop.TabIndex = 11;
            this.lblLop.Text = "Lớp :";
            //
            // cboLop
            //
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(525, 89);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(225, 23);
            this.cboLop.TabIndex = 12;
            //
            // lblCMND
            //
            this.lblCMND.AutoSize = true;
            this.lblCMND.Location = new System.Drawing.Point(30, 126);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(61, 15);
            this.lblCMND.TabIndex = 13;
            this.lblCMND.Text = "Số CMND :";
            //
            // mtxtCMND
            //
            this.mtxtCMND.Location = new System.Drawing.Point(140, 123);
            this.mtxtCMND.Mask = "000000000";
            this.mtxtCMND.Name = "mtxtCMND";
            this.mtxtCMND.Size = new System.Drawing.Size(250, 23);
            this.mtxtCMND.TabIndex = 14;
            //
            // lblSoDT
            //
            this.lblSoDT.AutoSize = true;
            this.lblSoDT.Location = new System.Drawing.Point(440, 126);
            this.lblSoDT.Name = "lblSoDT";
            this.lblSoDT.Size = new System.Drawing.Size(43, 15);
            this.lblSoDT.TabIndex = 15;
            this.lblSoDT.Text = "Số ĐT :";
            //
            // mtxtSoDT
            //
            this.mtxtSoDT.Location = new System.Drawing.Point(525, 123);
            this.mtxtSoDT.Mask = "0000.000.000";
            this.mtxtSoDT.Name = "mtxtSoDT";
            this.mtxtSoDT.Size = new System.Drawing.Size(225, 23);
            this.mtxtSoDT.TabIndex = 16;
            //
            // lblDiaChi
            //
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(30, 160);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(89, 15);
            this.lblDiaChi.TabIndex = 17;
            this.lblDiaChi.Text = "Địa chỉ liên lạc :";
            //
            // txtDiaChi
            //
            this.txtDiaChi.Location = new System.Drawing.Point(140, 157);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(610, 23);
            this.txtDiaChi.TabIndex = 18;
            //
            // lblMonHoc
            //
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(30, 195);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(109, 15);
            this.lblMonHoc.TabIndex = 19;
            this.lblMonHoc.Text = "Môn học đăng ký :";
            //
            // clbMonHoc
            //
            this.clbMonHoc.CheckOnClick = true;
            this.clbMonHoc.ColumnWidth = 280;
            this.clbMonHoc.ContextMenuStrip = this.ctxMonHoc;
            this.clbMonHoc.FormattingEnabled = true;
            this.clbMonHoc.Location = new System.Drawing.Point(140, 192);
            this.clbMonHoc.MultiColumn = true;
            this.clbMonHoc.Name = "clbMonHoc";
            this.clbMonHoc.Size = new System.Drawing.Size(610, 94);
            this.clbMonHoc.TabIndex = 20;
            //
            // ctxMonHoc
            //
            this.ctxMonHoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThemMon,
            this.mnuXoaMon});
            this.ctxMonHoc.Name = "ctxMonHoc";
            this.ctxMonHoc.Size = new System.Drawing.Size(193, 48);
            //
            // mnuThemMon
            //
            this.mnuThemMon.Name = "mnuThemMon";
            this.mnuThemMon.Size = new System.Drawing.Size(192, 22);
            this.mnuThemMon.Text = "Thêm môn học mới...";
            this.mnuThemMon.Click += new System.EventHandler(this.mnuThemMon_Click);
            //
            // mnuXoaMon
            //
            this.mnuXoaMon.Name = "mnuXoaMon";
            this.mnuXoaMon.Size = new System.Drawing.Size(192, 22);
            this.mnuXoaMon.Text = "Xóa môn đang chọn";
            this.mnuXoaMon.Click += new System.EventHandler(this.mnuXoaMon_Click);
            //
            // btnTimKiem
            //
            this.btnTimKiem.Location = new System.Drawing.Point(280, 298);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(95, 30);
            this.btnTimKiem.TabIndex = 21;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            //
            // btnThem
            //
            this.btnThem.Location = new System.Drawing.Point(395, 298);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 30);
            this.btnThem.TabIndex = 22;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            //
            // btnCapNhat
            //
            this.btnCapNhat.Location = new System.Drawing.Point(510, 298);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(95, 30);
            this.btnCapNhat.TabIndex = 23;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            //
            // btnThoat
            //
            this.btnThoat.Location = new System.Drawing.Point(655, 298);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(95, 30);
            this.btnThoat.TabIndex = 24;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            //
            // lblDanhSachSV
            //
            this.lblDanhSachSV.AutoSize = true;
            this.lblDanhSachSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDanhSachSV.Location = new System.Drawing.Point(12, 335);
            this.lblDanhSachSV.Name = "lblDanhSachSV";
            this.lblDanhSachSV.Size = new System.Drawing.Size(120, 15);
            this.lblDanhSachSV.TabIndex = 25;
            this.lblDanhSachSV.Text = "Danh sách sinh viên";
            //
            // lvSinhVien
            //
            this.lvSinhVien.CheckBoxes = true;
            this.lvSinhVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMSSV,
            this.colHoTenLot,
            this.colTen,
            this.colNgaySinh,
            this.colLop,
            this.colCMND,
            this.colSoDT,
            this.colDiaChi});
            this.lvSinhVien.ContextMenuStrip = this.ctxListView;
            this.lvSinhVien.FullRowSelect = true;
            this.lvSinhVien.GridLines = true;
            this.lvSinhVien.Location = new System.Drawing.Point(12, 355);
            this.lvSinhVien.MultiSelect = false;
            this.lvSinhVien.Name = "lvSinhVien";
            this.lvSinhVien.Size = new System.Drawing.Size(760, 230);
            this.lvSinhVien.TabIndex = 26;
            this.lvSinhVien.UseCompatibleStateImageBehavior = false;
            this.lvSinhVien.View = System.Windows.Forms.View.Details;
            this.lvSinhVien.SelectedIndexChanged += new System.EventHandler(this.lvSinhVien_SelectedIndexChanged);
            //
            // colMSSV
            //
            this.colMSSV.Text = "MSSV";
            this.colMSSV.Width = 75;
            //
            // colHoTenLot
            //
            this.colHoTenLot.Text = "Họ và tên lót";
            this.colHoTenLot.Width = 140;
            //
            // colTen
            //
            this.colTen.Text = "Tên";
            this.colTen.Width = 70;
            //
            // colNgaySinh
            //
            this.colNgaySinh.Text = "Ngày sinh";
            this.colNgaySinh.Width = 85;
            //
            // colLop
            //
            this.colLop.Text = "Lớp";
            this.colLop.Width = 70;
            //
            // colCMND
            //
            this.colCMND.Text = "Số CMND";
            this.colCMND.Width = 90;
            //
            // colSoDT
            //
            this.colSoDT.Text = "Số điện thoại";
            this.colSoDT.Width = 100;
            //
            // colDiaChi
            //
            this.colDiaChi.Text = "Địa chỉ liên lạc";
            this.colDiaChi.Width = 130;
            //
            // ctxListView
            //
            this.ctxListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuXoaChecked,
            this.toolStripSeparator1,
            this.mnuChonTatCa,
            this.mnuBoChonTatCa});
            this.ctxListView.Name = "ctxListView";
            this.ctxListView.Size = new System.Drawing.Size(262, 76);
            //
            // mnuXoaChecked
            //
            this.mnuXoaChecked.Name = "mnuXoaChecked";
            this.mnuXoaChecked.Size = new System.Drawing.Size(261, 22);
            this.mnuXoaChecked.Text = "Xóa các sinh viên đã đánh dấu (check)";
            this.mnuXoaChecked.Click += new System.EventHandler(this.mnuXoaChecked_Click);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
            //
            // mnuChonTatCa
            //
            this.mnuChonTatCa.Name = "mnuChonTatCa";
            this.mnuChonTatCa.Size = new System.Drawing.Size(261, 22);
            this.mnuChonTatCa.Text = "Chọn tất cả";
            this.mnuChonTatCa.Click += new System.EventHandler(this.mnuChonTatCa_Click);
            //
            // mnuBoChonTatCa
            //
            this.mnuBoChonTatCa.Name = "mnuBoChonTatCa";
            this.mnuBoChonTatCa.Size = new System.Drawing.Size(261, 22);
            this.mnuBoChonTatCa.Text = "Bỏ chọn tất cả";
            this.mnuBoChonTatCa.Click += new System.EventHandler(this.mnuBoChonTatCa_Click);
            //
            // statusStrip1
            //
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSoLuong,
            this.tssDinhDang});
            this.statusStrip1.Location = new System.Drawing.Point(0, 597);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            //
            // tssSoLuong
            //
            this.tssSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tssSoLuong.Name = "tssSoLuong";
            this.tssSoLuong.Size = new System.Drawing.Size(142, 17);
            this.tssSoLuong.Text = "Tổng số sinh viên: 0";
            //
            // tssDinhDang
            //
            this.tssDinhDang.Name = "tssDinhDang";
            this.tssDinhDang.Size = new System.Drawing.Size(155, 17);
            this.tssDinhDang.Text = "| Định dạng file: students.txt";
            //
            // lblDinhDang
            //
            this.lblDinhDang.AutoSize = true;
            this.lblDinhDang.Location = new System.Drawing.Point(12, 303);
            this.lblDinhDang.Name = "lblDinhDang";
            this.lblDinhDang.Size = new System.Drawing.Size(84, 15);
            this.lblDinhDang.TabIndex = 28;
            this.lblDinhDang.Text = "Định dạng file:";
            //
            // cboDinhDang
            //
            this.cboDinhDang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDinhDang.FormattingEnabled = true;
            this.cboDinhDang.Items.AddRange(new object[] {
            "Tập tin văn bản (TXT)",
            "Tập tin XML (XML)",
            "Tập tin JSON (JSON)"});
            this.cboDinhDang.Location = new System.Drawing.Point(105, 300);
            this.cboDinhDang.Name = "cboDinhDang";
            this.cboDinhDang.Size = new System.Drawing.Size(155, 23);
            this.cboDinhDang.TabIndex = 29;
            this.cboDinhDang.SelectedIndexChanged += new System.EventHandler(this.cboDinhDang_SelectedIndexChanged);
            //
            // frmSinhVien
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 619);
            this.Controls.Add(this.cboDinhDang);
            this.Controls.Add(this.lblDinhDang);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvSinhVien);
            this.Controls.Add(this.lblDanhSachSV);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.clbMonHoc);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.mtxtSoDT);
            this.Controls.Add(this.lblSoDT);
            this.Controls.Add(this.mtxtCMND);
            this.Controls.Add(this.lblCMND);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtHoTenLot);
            this.Controls.Add(this.lblHoTenLot);
            this.Controls.Add(this.rdNu);
            this.Controls.Add(this.rdNam);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.mtxtMSSV);
            this.Controls.Add(this.lblMSSV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thông tin sinh viên";
            this.Load += new System.EventHandler(this.frmSinhVien_Load);
            this.ctxMonHoc.ResumeLayout(false);
            this.ctxListView.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.MaskedTextBox mtxtMSSV;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.Label lblHoTenLot;
        private System.Windows.Forms.TextBox txtHoTenLot;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblCMND;
        private System.Windows.Forms.MaskedTextBox mtxtCMND;
        private System.Windows.Forms.Label lblSoDT;
        private System.Windows.Forms.MaskedTextBox mtxtSoDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.CheckedListBox clbMonHoc;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblDanhSachSV;
        private System.Windows.Forms.ListView lvSinhVien;
        private System.Windows.Forms.ColumnHeader colMSSV;
        private System.Windows.Forms.ColumnHeader colHoTenLot;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colNgaySinh;
        private System.Windows.Forms.ColumnHeader colLop;
        private System.Windows.Forms.ColumnHeader colCMND;
        private System.Windows.Forms.ColumnHeader colSoDT;
        private System.Windows.Forms.ColumnHeader colDiaChi;
        private System.Windows.Forms.ContextMenuStrip ctxMonHoc;
        private System.Windows.Forms.ToolStripMenuItem mnuThemMon;
        private System.Windows.Forms.ToolStripMenuItem mnuXoaMon;
        private System.Windows.Forms.ContextMenuStrip ctxListView;
        private System.Windows.Forms.ToolStripMenuItem mnuXoaChecked;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuChonTatCa;
        private System.Windows.Forms.ToolStripMenuItem mnuBoChonTatCa;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssSoLuong;
        private System.Windows.Forms.ToolStripStatusLabel tssDinhDang;
        private System.Windows.Forms.Label lblDinhDang;
        private System.Windows.Forms.ComboBox cboDinhDang;
    }
}
