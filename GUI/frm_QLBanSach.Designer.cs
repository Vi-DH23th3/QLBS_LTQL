namespace GUI
{
    partial class frm_QLBanSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgDSDonHang = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgChiTietDonHang = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLocNgay = new System.Windows.Forms.Button();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnXoaDSBan = new System.Windows.Forms.Button();
            this.btnSuaChiTietHoaDon = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLocNV = new System.Windows.Forms.Button();
            this.btnLocKH = new System.Windows.Forms.Button();
            this.cmbTenNV = new System.Windows.Forms.ComboBox();
            this.cmbTenKH = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDSDonHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgChiTietDonHang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgDSDonHang
            // 
            this.dgDSDonHang.BackgroundColor = System.Drawing.Color.White;
            this.dgDSDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDSDonHang.Location = new System.Drawing.Point(34, 270);
            this.dgDSDonHang.Name = "dgDSDonHang";
            this.dgDSDonHang.RowHeadersWidth = 51;
            this.dgDSDonHang.RowTemplate.Height = 24;
            this.dgDSDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDSDonHang.Size = new System.Drawing.Size(655, 255);
            this.dgDSDonHang.TabIndex = 0;
            this.dgDSDonHang.Click += new System.EventHandler(this.dgDSDonHang_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(560, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ ĐƠN HÀNG";
            // 
            // dgChiTietDonHang
            // 
            this.dgChiTietDonHang.BackgroundColor = System.Drawing.Color.White;
            this.dgChiTietDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgChiTietDonHang.Location = new System.Drawing.Point(744, 270);
            this.dgChiTietDonHang.Name = "dgChiTietDonHang";
            this.dgChiTietDonHang.RowHeadersWidth = 51;
            this.dgChiTietDonHang.RowTemplate.Height = 24;
            this.dgChiTietDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgChiTietDonHang.Size = new System.Drawing.Size(655, 255);
            this.dgChiTietDonHang.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thông tin các đơn hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(740, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chi tiết đơn hàng";
            // 
            // btnLocNgay
            // 
            this.btnLocNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocNgay.Location = new System.Drawing.Point(208, 76);
            this.btnLocNgay.Name = "btnLocNgay";
            this.btnLocNgay.Size = new System.Drawing.Size(103, 38);
            this.btnLocNgay.TabIndex = 5;
            this.btnLocNgay.Text = "Lọc ngày";
            this.btnLocNgay.UseVisualStyleBackColor = true;
            this.btnLocNgay.Click += new System.EventHandler(this.btnLocNgay_Click);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(113, 30);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(121, 28);
            this.dtpTuNgay.TabIndex = 6;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(345, 30);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(138, 28);
            this.dtpDenNgay.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Đến ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Từ ngày";
            // 
            // btnXoaDSBan
            // 
            this.btnXoaDSBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDSBan.Location = new System.Drawing.Point(540, 223);
            this.btnXoaDSBan.Name = "btnXoaDSBan";
            this.btnXoaDSBan.Size = new System.Drawing.Size(143, 33);
            this.btnXoaDSBan.TabIndex = 9;
            this.btnXoaDSBan.Text = "Xóa đơn hàng";
            this.btnXoaDSBan.UseVisualStyleBackColor = true;
            this.btnXoaDSBan.Click += new System.EventHandler(this.btnXoaDSBan_Click);
            // 
            // btnSuaChiTietHoaDon
            // 
            this.btnSuaChiTietHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaChiTietHoaDon.Location = new System.Drawing.Point(1246, 220);
            this.btnSuaChiTietHoaDon.Name = "btnSuaChiTietHoaDon";
            this.btnSuaChiTietHoaDon.Size = new System.Drawing.Size(153, 33);
            this.btnSuaChiTietHoaDon.TabIndex = 9;
            this.btnSuaChiTietHoaDon.Text = "Sửa chi tiết đơn hàng";
            this.btnSuaChiTietHoaDon.UseVisualStyleBackColor = true;
            this.btnSuaChiTietHoaDon.Click += new System.EventHandler(this.btnSuaChiTietHoaDon_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLocNV);
            this.groupBox1.Controls.Add(this.btnLocKH);
            this.groupBox1.Controls.Add(this.cmbTenNV);
            this.groupBox1.Controls.Add(this.cmbTenKH);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnLocNgay);
            this.groupBox1.Controls.Add(this.dtpTuNgay);
            this.groupBox1.Controls.Add(this.dtpDenNgay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(34, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1365, 120);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnLocNV
            // 
            this.btnLocNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocNV.Location = new System.Drawing.Point(1058, 67);
            this.btnLocNV.Name = "btnLocNV";
            this.btnLocNV.Size = new System.Drawing.Size(149, 38);
            this.btnLocNV.TabIndex = 14;
            this.btnLocNV.Text = "Lọc nhân viên";
            this.btnLocNV.UseVisualStyleBackColor = true;
            this.btnLocNV.Click += new System.EventHandler(this.btnLocNV_Click);
            // 
            // btnLocKH
            // 
            this.btnLocKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocKH.Location = new System.Drawing.Point(602, 67);
            this.btnLocKH.Name = "btnLocKH";
            this.btnLocKH.Size = new System.Drawing.Size(156, 38);
            this.btnLocKH.TabIndex = 13;
            this.btnLocKH.Text = "Lọc khách hàng";
            this.btnLocKH.UseVisualStyleBackColor = true;
            this.btnLocKH.Click += new System.EventHandler(this.btnLocKH_Click);
            // 
            // cmbTenNV
            // 
            this.cmbTenNV.FormattingEnabled = true;
            this.cmbTenNV.Location = new System.Drawing.Point(1033, 30);
            this.cmbTenNV.Name = "cmbTenNV";
            this.cmbTenNV.Size = new System.Drawing.Size(270, 28);
            this.cmbTenNV.TabIndex = 12;
            // 
            // cmbTenKH
            // 
            this.cmbTenKH.FormattingEnabled = true;
            this.cmbTenKH.Location = new System.Drawing.Point(637, 33);
            this.cmbTenKH.Name = "cmbTenKH";
            this.cmbTenKH.Size = new System.Drawing.Size(271, 28);
            this.cmbTenKH.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Tên khách hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(914, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tên nhân viên";
            // 
            // frm_QLBanSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1424, 534);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSuaChiTietHoaDon);
            this.Controls.Add(this.btnXoaDSBan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgChiTietDonHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgDSDonHang);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_QLBanSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bán sách";
            this.Load += new System.EventHandler(this.frm_BanSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDSDonHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgChiTietDonHang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDSDonHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgChiTietDonHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLocNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXoaDSBan;
        private System.Windows.Forms.Button btnSuaChiTietHoaDon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTenKH;
        private System.Windows.Forms.Button btnLocNV;
        private System.Windows.Forms.Button btnLocKH;
        private System.Windows.Forms.ComboBox cmbTenNV;
    }
}