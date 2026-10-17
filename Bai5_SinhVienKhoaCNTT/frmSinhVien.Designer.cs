namespace Bai5_SinhVienKhoaCNTT
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
            this.gbDSSV = new System.Windows.Forms.GroupBox();
            this.lvSinhVien = new System.Windows.Forms.ListView();
            this.colMSSV = new System.Windows.Forms.ColumnHeader();
            this.colHoTen = new System.Windows.Forms.ColumnHeader();
            this.colPhai = new System.Windows.Forms.ColumnHeader();
            this.colNgaySinh = new System.Windows.Forms.ColumnHeader();
            this.colLop = new System.Windows.Forms.ColumnHeader();
            this.colSoDT = new System.Windows.Forms.ColumnHeader();
            this.colEmail = new System.Windows.Forms.ColumnHeader();
            this.colDiaChi = new System.Windows.Forms.ColumnHeader();
            this.colHinh = new System.Windows.Forms.ColumnHeader();
            this.ctxListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaiLai = new System.Windows.Forms.ToolStripMenuItem();
            this.pbHinh = new System.Windows.Forms.PictureBox();
            this.gbTTSV = new System.Windows.Forms.GroupBox();
            this.mtxtMaSo = new System.Windows.Forms.MaskedTextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.mtxtSoDT = new System.Windows.Forms.MaskedTextBox();
            this.btnChonHinh = new System.Windows.Forms.Button();
            this.btnMacDinh = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtHinh = new System.Windows.Forms.TextBox();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblPhai = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblSoDT = new System.Windows.Forms.Label();
            this.lblHinh = new System.Windows.Forms.Label();
            this.gbDSSV.SuspendLayout();
            this.ctxListView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHinh)).BeginInit();
            this.gbTTSV.SuspendLayout();
            this.SuspendLayout();
            //
            // gbDSSV (Tab: 0)
            //
            this.gbDSSV.Controls.Add(this.lvSinhVien);
            this.gbDSSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbDSSV.Location = new System.Drawing.Point(12, 230);
            this.gbDSSV.Name = "gbDSSV";
            this.gbDSSV.Padding = new System.Windows.Forms.Padding(8);
            this.gbDSSV.Size = new System.Drawing.Size(860, 319);
            this.gbDSSV.TabIndex = 0;
            this.gbDSSV.TabStop = false;
            this.gbDSSV.Text = "Danh sách sinh viên";
            //
            // lvSinhVien (Tab: 0.0)
            //
            this.lvSinhVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMSSV,
            this.colHoTen,
            this.colPhai,
            this.colNgaySinh,
            this.colLop,
            this.colSoDT,
            this.colEmail,
            this.colDiaChi,
            this.colHinh});
            this.lvSinhVien.ContextMenuStrip = this.ctxListView;
            this.lvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSinhVien.FullRowSelect = true;
            this.lvSinhVien.GridLines = true;
            this.lvSinhVien.Location = new System.Drawing.Point(8, 24);
            this.lvSinhVien.Name = "lvSinhVien";
            this.lvSinhVien.Size = new System.Drawing.Size(844, 287);
            this.lvSinhVien.TabIndex = 0;
            this.lvSinhVien.UseCompatibleStateImageBehavior = false;
            this.lvSinhVien.View = System.Windows.Forms.View.Details;
            this.lvSinhVien.SelectedIndexChanged += new System.EventHandler(this.lvSinhVien_SelectedIndexChanged);
            //
            // colMSSV
            //
            this.colMSSV.Text = "MSSV";
            this.colMSSV.Width = 85;
            //
            // colHoTen
            //
            this.colHoTen.Text = "Họ và tên";
            this.colHoTen.Width = 145;
            //
            // colPhai
            //
            this.colPhai.Text = "Phái";
            this.colPhai.Width = 55;
            //
            // colNgaySinh
            //
            this.colNgaySinh.Text = "Ngày sinh";
            this.colNgaySinh.Width = 85;
            //
            // colLop
            //
            this.colLop.Text = "Lớp";
            this.colLop.Width = 65;
            //
            // colSoDT
            //
            this.colSoDT.Text = "Số điện thoại";
            this.colSoDT.Width = 105;
            //
            // colEmail
            //
            this.colEmail.Text = "Email";
            this.colEmail.Width = 125;
            //
            // colDiaChi
            //
            this.colDiaChi.Text = "Địa chỉ";
            this.colDiaChi.Width = 100;
            //
            // colHinh
            //
            this.colHinh.Text = "Hình";
            this.colHinh.Width = 70;
            //
            // ctxListView
            //
            this.ctxListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuXoa,
            this.mnuTaiLai});
            this.ctxListView.Name = "ctxListView";
            this.ctxListView.Size = new System.Drawing.Size(158, 48);
            //
            // mnuXoa
            //
            this.mnuXoa.Name = "mnuXoa";
            this.mnuXoa.Size = new System.Drawing.Size(157, 22);
            this.mnuXoa.Text = "Xóa";
            this.mnuXoa.Click += new System.EventHandler(this.mnuXoa_Click);
            //
            // mnuTaiLai
            //
            this.mnuTaiLai.Name = "mnuTaiLai";
            this.mnuTaiLai.Size = new System.Drawing.Size(157, 22);
            this.mnuTaiLai.Text = "Tải lại danh sách";
            this.mnuTaiLai.Click += new System.EventHandler(this.mnuTaiLai_Click);
            //
            // pbHinh (Tab: 1)
            //
            this.pbHinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbHinh.Location = new System.Drawing.Point(12, 12);
            this.pbHinh.Name = "pbHinh";
            this.pbHinh.Size = new System.Drawing.Size(155, 205);
            this.pbHinh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHinh.TabIndex = 1;
            this.pbHinh.TabStop = false;
            //
            // gbTTSV (Tab: 2)
            //
            this.gbTTSV.Controls.Add(this.mtxtMaSo);
            this.gbTTSV.Controls.Add(this.txtHoTen);
            this.gbTTSV.Controls.Add(this.txtEmail);
            this.gbTTSV.Controls.Add(this.txtDiaChi);
            this.gbTTSV.Controls.Add(this.dtpNgaySinh);
            this.gbTTSV.Controls.Add(this.rdNam);
            this.gbTTSV.Controls.Add(this.rdNu);
            this.gbTTSV.Controls.Add(this.cboLop);
            this.gbTTSV.Controls.Add(this.mtxtSoDT);
            this.gbTTSV.Controls.Add(this.btnChonHinh);
            this.gbTTSV.Controls.Add(this.btnMacDinh);
            this.gbTTSV.Controls.Add(this.btnLuu);
            this.gbTTSV.Controls.Add(this.btnThoat);
            this.gbTTSV.Controls.Add(this.txtHinh);
            this.gbTTSV.Controls.Add(this.lblMSSV);
            this.gbTTSV.Controls.Add(this.lblNgaySinh);
            this.gbTTSV.Controls.Add(this.lblHoTen);
            this.gbTTSV.Controls.Add(this.lblPhai);
            this.gbTTSV.Controls.Add(this.lblEmail);
            this.gbTTSV.Controls.Add(this.lblLop);
            this.gbTTSV.Controls.Add(this.lblDiaChi);
            this.gbTTSV.Controls.Add(this.lblSoDT);
            this.gbTTSV.Controls.Add(this.lblHinh);
            this.gbTTSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbTTSV.Location = new System.Drawing.Point(180, 7);
            this.gbTTSV.Name = "gbTTSV";
            this.gbTTSV.Size = new System.Drawing.Size(692, 210);
            this.gbTTSV.TabIndex = 2;
            this.gbTTSV.TabStop = false;
            this.gbTTSV.Text = "Thông tin sinh viên";
            //
            // mtxtMaSo (Tab: 2.0)
            //
            this.mtxtMaSo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mtxtMaSo.Location = new System.Drawing.Point(75, 23);
            this.mtxtMaSo.Mask = "0000000";
            this.mtxtMaSo.Name = "mtxtMaSo";
            this.mtxtMaSo.Size = new System.Drawing.Size(230, 23);
            this.mtxtMaSo.TabIndex = 0;
            //
            // txtHoTen (Tab: 2.1)
            //
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHoTen.Location = new System.Drawing.Point(75, 52);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(230, 23);
            this.txtHoTen.TabIndex = 1;
            //
            // txtEmail (Tab: 2.2)
            //
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail.Location = new System.Drawing.Point(75, 81);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(230, 23);
            this.txtEmail.TabIndex = 2;
            //
            // txtDiaChi (Tab: 2.3)
            //
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDiaChi.Location = new System.Drawing.Point(75, 110);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(230, 23);
            this.txtDiaChi.TabIndex = 3;
            //
            // dtpNgaySinh (Tab: 2.4)
            //
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(420, 23);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(255, 23);
            this.dtpNgaySinh.TabIndex = 4;
            //
            // rdNam (Tab: 2.5)
            //
            this.rdNam.AutoSize = true;
            this.rdNam.Checked = true;
            this.rdNam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdNam.Location = new System.Drawing.Point(425, 54);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(51, 19);
            this.rdNam.TabIndex = 5;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            //
            // rdNu (Tab: 2.6)
            //
            this.rdNu.AutoSize = true;
            this.rdNu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdNu.Location = new System.Drawing.Point(515, 54);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(41, 19);
            this.rdNu.TabIndex = 6;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            //
            // cboLop (Tab: 2.7)
            //
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Items.AddRange(new object[] {
            "CTK43",
            "CTK44",
            "CTK45",
            "CTK46"});
            this.cboLop.Location = new System.Drawing.Point(420, 81);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(255, 23);
            this.cboLop.TabIndex = 7;
            //
            // mtxtSoDT (Tab: 2.8)
            //
            this.mtxtSoDT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mtxtSoDT.Location = new System.Drawing.Point(420, 110);
            this.mtxtSoDT.Mask = "000.000.0000";
            this.mtxtSoDT.Name = "mtxtSoDT";
            this.mtxtSoDT.Size = new System.Drawing.Size(255, 23);
            this.mtxtSoDT.TabIndex = 8;
            //
            // btnChonHinh (Tab: 2.9)
            //
            this.btnChonHinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChonHinh.Location = new System.Drawing.Point(585, 138);
            this.btnChonHinh.Name = "btnChonHinh";
            this.btnChonHinh.Size = new System.Drawing.Size(90, 26);
            this.btnChonHinh.TabIndex = 9;
            this.btnChonHinh.Text = "Chọn hình";
            this.btnChonHinh.UseVisualStyleBackColor = true;
            this.btnChonHinh.Click += new System.EventHandler(this.btnChonHinh_Click);
            //
            // btnMacDinh (Tab: 2.10)
            //
            this.btnMacDinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMacDinh.Location = new System.Drawing.Point(365, 172);
            this.btnMacDinh.Name = "btnMacDinh";
            this.btnMacDinh.Size = new System.Drawing.Size(95, 28);
            this.btnMacDinh.TabIndex = 10;
            this.btnMacDinh.Text = "Mặc định";
            this.btnMacDinh.UseVisualStyleBackColor = true;
            this.btnMacDinh.Click += new System.EventHandler(this.btnMacDinh_Click);
            //
            // btnLuu (Tab: 2.11)
            //
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLuu.Location = new System.Drawing.Point(475, 172);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(95, 28);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            //
            // btnThoat (Tab: 2.12)
            //
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnThoat.Location = new System.Drawing.Point(585, 172);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(95, 28);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            //
            // txtHinh (Tab: 2.13)
            //
            this.txtHinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHinh.Location = new System.Drawing.Point(75, 140);
            this.txtHinh.Name = "txtHinh";
            this.txtHinh.ReadOnly = true;
            this.txtHinh.Size = new System.Drawing.Size(495, 23);
            this.txtHinh.TabIndex = 13;
            //
            // lblMSSV
            //
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Location = new System.Drawing.Point(15, 26);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(43, 15);
            this.lblMSSV.TabIndex = 14;
            this.lblMSSV.Text = "MSSV";
            //
            // lblNgaySinh
            //
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(335, 26);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(60, 15);
            this.lblNgaySinh.TabIndex = 15;
            this.lblNgaySinh.Text = "Ngày sinh";
            //
            // lblHoTen
            //
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 55);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(58, 15);
            this.lblHoTen.TabIndex = 16;
            this.lblHoTen.Text = "Họ và tên";
            //
            // lblPhai
            //
            this.lblPhai.AutoSize = true;
            this.lblPhai.Location = new System.Drawing.Point(335, 55);
            this.lblPhai.Name = "lblPhai";
            this.lblPhai.Size = new System.Drawing.Size(30, 15);
            this.lblPhai.TabIndex = 17;
            this.lblPhai.Text = "Phái";
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 84);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 15);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";
            //
            // lblLop
            //
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(335, 84);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(27, 15);
            this.lblLop.TabIndex = 19;
            this.lblLop.Text = "Lớp";
            //
            // lblDiaChi
            //
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(15, 113);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(43, 15);
            this.lblDiaChi.TabIndex = 20;
            this.lblDiaChi.Text = "Địa chỉ";
            //
            // lblSoDT
            //
            this.lblSoDT.AutoSize = true;
            this.lblSoDT.Location = new System.Drawing.Point(335, 113);
            this.lblSoDT.Name = "lblSoDT";
            this.lblSoDT.Size = new System.Drawing.Size(76, 15);
            this.lblSoDT.TabIndex = 21;
            this.lblSoDT.Text = "Số điện thoại";
            //
            // lblHinh
            //
            this.lblHinh.AutoSize = true;
            this.lblHinh.Location = new System.Drawing.Point(15, 143);
            this.lblHinh.Name = "lblHinh";
            this.lblHinh.Size = new System.Drawing.Size(33, 15);
            this.lblHinh.TabIndex = 22;
            this.lblHinh.Text = "Hình";
            //
            // frmSinhVien
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.gbDSSV);
            this.Controls.Add(this.pbHinh);
            this.Controls.Add(this.gbTTSV);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thông tin sinh viên khoa CNTT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSinhVien_FormClosing);
            this.Load += new System.EventHandler(this.frmSinhVien_Load);
            this.gbDSSV.ResumeLayout(false);
            this.ctxListView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHinh)).EndInit();
            this.gbTTSV.ResumeLayout(false);
            this.gbTTSV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDSSV;
        private System.Windows.Forms.ListView lvSinhVien;
        private System.Windows.Forms.ColumnHeader colMSSV;
        private System.Windows.Forms.ColumnHeader colHoTen;
        private System.Windows.Forms.ColumnHeader colPhai;
        private System.Windows.Forms.ColumnHeader colNgaySinh;
        private System.Windows.Forms.ColumnHeader colLop;
        private System.Windows.Forms.ColumnHeader colSoDT;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colDiaChi;
        private System.Windows.Forms.ColumnHeader colHinh;
        private System.Windows.Forms.PictureBox pbHinh;
        private System.Windows.Forms.GroupBox gbTTSV;
        private System.Windows.Forms.MaskedTextBox mtxtMaSo;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.MaskedTextBox mtxtSoDT;
        private System.Windows.Forms.Button btnChonHinh;
        private System.Windows.Forms.Button btnMacDinh;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtHinh;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblPhai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblSoDT;
        private System.Windows.Forms.Label lblHinh;
        private System.Windows.Forms.ContextMenuStrip ctxListView;
        private System.Windows.Forms.ToolStripMenuItem mnuXoa;
        private System.Windows.Forms.ToolStripMenuItem mnuTaiLai;
    }
}
