namespace Lab3_QuanLySinhVien
{
    partial class frmTimKiem
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
            this.gbDieuKien = new System.Windows.Forms.GroupBox();
            this.chkLop = new System.Windows.Forms.CheckBox();
            this.chkTen = new System.Windows.Forms.CheckBox();
            this.chkMSSV = new System.Windows.Forms.CheckBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoaTrang = new System.Windows.Forms.Button();
            this.gbKetQua = new System.Windows.Forms.GroupBox();
            this.lvKetQua = new System.Windows.Forms.ListView();
            this.colMSSV = new System.Windows.Forms.ColumnHeader();
            this.colHoTenLot = new System.Windows.Forms.ColumnHeader();
            this.colTen = new System.Windows.Forms.ColumnHeader();
            this.colNgaySinh = new System.Windows.Forms.ColumnHeader();
            this.colLop = new System.Windows.Forms.ColumnHeader();
            this.colCMND = new System.Windows.Forms.ColumnHeader();
            this.colSoDT = new System.Windows.Forms.ColumnHeader();
            this.colDiaChi = new System.Windows.Forms.ColumnHeader();
            this.lblTongKetQua = new System.Windows.Forms.Label();
            this.gbDieuKien.SuspendLayout();
            this.gbKetQua.SuspendLayout();
            this.SuspendLayout();
            //
            // gbDieuKien
            //
            this.gbDieuKien.Controls.Add(this.chkLop);
            this.gbDieuKien.Controls.Add(this.chkTen);
            this.gbDieuKien.Controls.Add(this.chkMSSV);
            this.gbDieuKien.Controls.Add(this.cboLop);
            this.gbDieuKien.Controls.Add(this.txtHoTen);
            this.gbDieuKien.Controls.Add(this.txtMSSV);
            this.gbDieuKien.Controls.Add(this.lblLop);
            this.gbDieuKien.Controls.Add(this.lblHoTen);
            this.gbDieuKien.Controls.Add(this.lblMSSV);
            this.gbDieuKien.Location = new System.Drawing.Point(12, 12);
            this.gbDieuKien.Name = "gbDieuKien";
            this.gbDieuKien.Size = new System.Drawing.Size(600, 130);
            this.gbDieuKien.TabIndex = 0;
            this.gbDieuKien.TabStop = false;
            this.gbDieuKien.Text = "Nhập điều kiện tìm kiếm (theo MSSV / Tên / Lớp)";
            //
            // chkLop
            //
            this.chkLop.AutoSize = true;
            this.chkLop.Location = new System.Drawing.Point(450, 92);
            this.chkLop.Name = "chkLop";
            this.chkLop.Size = new System.Drawing.Size(125, 19);
            this.chkLop.TabIndex = 8;
            this.chkLop.Text = "Tìm chính xác Lớp";
            this.chkLop.UseVisualStyleBackColor = true;
            //
            // chkTen
            //
            this.chkTen.AutoSize = true;
            this.chkTen.Checked = true;
            this.chkTen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTen.Location = new System.Drawing.Point(450, 60);
            this.chkTen.Name = "chkTen";
            this.chkTen.Size = new System.Drawing.Size(126, 19);
            this.chkTen.TabIndex = 7;
            this.chkTen.Text = "Tìm theo Họ / Tên";
            this.chkTen.UseVisualStyleBackColor = true;
            //
            // chkMSSV
            //
            this.chkMSSV.AutoSize = true;
            this.chkMSSV.Checked = true;
            this.chkMSSV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMSSV.Location = new System.Drawing.Point(450, 27);
            this.chkMSSV.Name = "chkMSSV";
            this.chkMSSV.Size = new System.Drawing.Size(107, 19);
            this.chkMSSV.TabIndex = 6;
            this.chkMSSV.Text = "Tìm theo MSSV";
            this.chkMSSV.UseVisualStyleBackColor = true;
            //
            // cboLop
            //
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(120, 89);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(310, 23);
            this.cboLop.TabIndex = 5;
            //
            // txtHoTen
            //
            this.txtHoTen.Location = new System.Drawing.Point(120, 57);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(310, 23);
            this.txtHoTen.TabIndex = 4;
            //
            // txtMSSV
            //
            this.txtMSSV.Location = new System.Drawing.Point(120, 25);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(310, 23);
            this.txtMSSV.TabIndex = 3;
            //
            // lblLop
            //
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(20, 92);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(30, 15);
            this.lblLop.TabIndex = 2;
            this.lblLop.Text = "Lớp:";
            //
            // lblHoTen
            //
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(20, 60);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(61, 15);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ và tên:";
            //
            // lblMSSV
            //
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Location = new System.Drawing.Point(20, 28);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(43, 15);
            this.lblMSSV.TabIndex = 0;
            this.lblMSSV.Text = "MSSV:";
            //
            // btnTim
            //
            this.btnTim.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTim.Location = new System.Drawing.Point(630, 22);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(120, 32);
            this.btnTim.TabIndex = 1;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            //
            // btnThoat
            //
            this.btnThoat.Location = new System.Drawing.Point(630, 98);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 32);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Đóng";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            //
            // btnXoaTrang
            //
            this.btnXoaTrang.Location = new System.Drawing.Point(630, 60);
            this.btnXoaTrang.Name = "btnXoaTrang";
            this.btnXoaTrang.Size = new System.Drawing.Size(120, 32);
            this.btnXoaTrang.TabIndex = 3;
            this.btnXoaTrang.Text = "Xóa điều kiện";
            this.btnXoaTrang.UseVisualStyleBackColor = true;
            this.btnXoaTrang.Click += new System.EventHandler(this.btnXoaTrang_Click);
            //
            // gbKetQua
            //
            this.gbKetQua.Controls.Add(this.lvKetQua);
            this.gbKetQua.Location = new System.Drawing.Point(12, 148);
            this.gbKetQua.Name = "gbKetQua";
            this.gbKetQua.Size = new System.Drawing.Size(738, 260);
            this.gbKetQua.TabIndex = 4;
            this.gbKetQua.TabStop = false;
            this.gbKetQua.Text = "Kết quả tìm kiếm";
            //
            // lvKetQua
            //
            this.lvKetQua.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMSSV,
            this.colHoTenLot,
            this.colTen,
            this.colNgaySinh,
            this.colLop,
            this.colCMND,
            this.colSoDT,
            this.colDiaChi});
            this.lvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvKetQua.FullRowSelect = true;
            this.lvKetQua.GridLines = true;
            this.lvKetQua.Location = new System.Drawing.Point(3, 19);
            this.lvKetQua.Name = "lvKetQua";
            this.lvKetQua.Size = new System.Drawing.Size(732, 238);
            this.lvKetQua.TabIndex = 0;
            this.lvKetQua.UseCompatibleStateImageBehavior = false;
            this.lvKetQua.View = System.Windows.Forms.View.Details;
            this.lvKetQua.DoubleClick += new System.EventHandler(this.lvKetQua_DoubleClick);
            //
            // colMSSV
            //
            this.colMSSV.Text = "MSSV";
            this.colMSSV.Width = 70;
            //
            // colHoTenLot
            //
            this.colHoTenLot.Text = "Họ và tên lót";
            this.colHoTenLot.Width = 120;
            //
            // colTen
            //
            this.colTen.Text = "Tên";
            this.colTen.Width = 60;
            //
            // colNgaySinh
            //
            this.colNgaySinh.Text = "Ngày sinh";
            this.colNgaySinh.Width = 80;
            //
            // colLop
            //
            this.colLop.Text = "Lớp";
            this.colLop.Width = 65;
            //
            // colCMND
            //
            this.colCMND.Text = "Số CMND";
            this.colCMND.Width = 85;
            //
            // colSoDT
            //
            this.colSoDT.Text = "Số điện thoại";
            this.colSoDT.Width = 95;
            //
            // colDiaChi
            //
            this.colDiaChi.Text = "Địa chỉ liên lạc";
            this.colDiaChi.Width = 140;
            //
            // lblTongKetQua
            //
            this.lblTongKetQua.AutoSize = true;
            this.lblTongKetQua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblTongKetQua.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTongKetQua.Location = new System.Drawing.Point(15, 415);
            this.lblTongKetQua.Name = "lblTongKetQua";
            this.lblTongKetQua.Size = new System.Drawing.Size(262, 15);
            this.lblTongKetQua.TabIndex = 5;
            this.lblTongKetQua.Text = "* Gợi ý: Nhấp đúp vào sinh viên để chọn về Form chính";
            //
            // frmTimKiem
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 440);
            this.Controls.Add(this.lblTongKetQua);
            this.Controls.Add(this.gbKetQua);
            this.Controls.Add(this.btnXoaTrang);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.gbDieuKien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm sinh viên";
            this.Load += new System.EventHandler(this.frmTimKiem_Load);
            this.gbDieuKien.ResumeLayout(false);
            this.gbDieuKien.PerformLayout();
            this.gbKetQua.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox gbDieuKien;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.CheckBox chkLop;
        private System.Windows.Forms.CheckBox chkTen;
        private System.Windows.Forms.CheckBox chkMSSV;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoaTrang;
        private System.Windows.Forms.GroupBox gbKetQua;
        private System.Windows.Forms.ListView lvKetQua;
        private System.Windows.Forms.ColumnHeader colMSSV;
        private System.Windows.Forms.ColumnHeader colHoTenLot;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colNgaySinh;
        private System.Windows.Forms.ColumnHeader colLop;
        private System.Windows.Forms.ColumnHeader colCMND;
        private System.Windows.Forms.ColumnHeader colSoDT;
        private System.Windows.Forms.ColumnHeader colDiaChi;
        private System.Windows.Forms.Label lblTongKetQua;
    }
}
