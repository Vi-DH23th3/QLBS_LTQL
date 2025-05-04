namespace GUI
{
    partial class frm_dmBooks
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
            this.components = new System.ComponentModel.Container();
            this.dgDSBook = new System.Windows.Forms.DataGridView();
            this.btnTim = new System.Windows.Forms.Button();
            this.qlBanSachDataSet = new GUI.qlBanSachDataSet();
            this.qlBanSachDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTimMS = new System.Windows.Forms.Button();
            this.btnTimTL = new System.Windows.Forms.Button();
            this.btnTimTS = new System.Windows.Forms.Button();
            this.txtNhapTim = new System.Windows.Forms.TextBox();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSuaSach = new System.Windows.Forms.Button();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbNXB = new System.Windows.Forms.ComboBox();
            this.txtTheLoai = new System.Windows.Forms.TextBox();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grbTGTLMoi = new System.Windows.Forms.GroupBox();
            this.txtMaTLMoi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaTGMoi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnTimMaTG = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDSBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlBanSachDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlBanSachDataSetBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbTGTLMoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgDSBook
            // 
            this.dgDSBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDSBook.Location = new System.Drawing.Point(21, 403);
            this.dgDSBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgDSBook.Name = "dgDSBook";
            this.dgDSBook.RowHeadersWidth = 51;
            this.dgDSBook.RowTemplate.Height = 24;
            this.dgDSBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDSBook.Size = new System.Drawing.Size(1138, 245);
            this.dgDSBook.TabIndex = 0;
            this.dgDSBook.Click += new System.EventHandler(this.dgDSBook_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(668, 35);
            this.btnTim.Margin = new System.Windows.Forms.Padding(2);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(99, 26);
            this.btnTim.TabIndex = 5;
            this.btnTim.Text = "Tác giả";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // qlBanSachDataSet
            // 
            this.qlBanSachDataSet.DataSetName = "qlBanSachDataSet";
            this.qlBanSachDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qlBanSachDataSetBindingSource
            // 
            this.qlBanSachDataSetBindingSource.DataSource = this.qlBanSachDataSet;
            this.qlBanSachDataSetBindingSource.Position = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnTimMS);
            this.groupBox2.Controls.Add(this.btnTim);
            this.groupBox2.Controls.Add(this.btnTimTL);
            this.groupBox2.Controls.Add(this.btnTimTS);
            this.groupBox2.Controls.Add(this.txtNhapTim);
            this.groupBox2.Location = new System.Drawing.Point(21, 308);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(789, 80);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Nhập:";
            // 
            // btnTimMS
            // 
            this.btnTimMS.Location = new System.Drawing.Point(338, 35);
            this.btnTimMS.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimMS.Name = "btnTimMS";
            this.btnTimMS.Size = new System.Drawing.Size(92, 26);
            this.btnTimMS.TabIndex = 5;
            this.btnTimMS.Text = "Mã sách";
            this.btnTimMS.UseVisualStyleBackColor = true;
            this.btnTimMS.Click += new System.EventHandler(this.btnTimMS_Click);
            // 
            // btnTimTL
            // 
            this.btnTimTL.Location = new System.Drawing.Point(556, 35);
            this.btnTimTL.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimTL.Name = "btnTimTL";
            this.btnTimTL.Size = new System.Drawing.Size(92, 26);
            this.btnTimTL.TabIndex = 5;
            this.btnTimTL.Text = "Thể loại";
            this.btnTimTL.UseVisualStyleBackColor = true;
            this.btnTimTL.Click += new System.EventHandler(this.btnTimTL_Click);
            // 
            // btnTimTS
            // 
            this.btnTimTS.Location = new System.Drawing.Point(448, 35);
            this.btnTimTS.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimTS.Name = "btnTimTS";
            this.btnTimTS.Size = new System.Drawing.Size(92, 26);
            this.btnTimTS.TabIndex = 5;
            this.btnTimTS.Text = "Tên sách";
            this.btnTimTS.UseVisualStyleBackColor = true;
            this.btnTimTS.Click += new System.EventHandler(this.btnTimTS_Click);
            // 
            // txtNhapTim
            // 
            this.txtNhapTim.Location = new System.Drawing.Point(98, 35);
            this.txtNhapTim.Margin = new System.Windows.Forms.Padding(2);
            this.txtNhapTim.Name = "txtNhapTim";
            this.txtNhapTim.Size = new System.Drawing.Size(216, 28);
            this.txtNhapTim.TabIndex = 4;
            // 
            // btnThemSach
            // 
            this.btnThemSach.Location = new System.Drawing.Point(890, 239);
            this.btnThemSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(82, 34);
            this.btnThemSach.TabIndex = 10;
            this.btnThemSach.Text = "Thêm";
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(422, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "QUẢN LÝ SÁCH";
            // 
            // btnSuaSach
            // 
            this.btnSuaSach.Location = new System.Drawing.Point(998, 239);
            this.btnSuaSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnSuaSach.Name = "btnSuaSach";
            this.btnSuaSach.Size = new System.Drawing.Size(82, 34);
            this.btnSuaSach.TabIndex = 10;
            this.btnSuaSach.Text = "Sửa";
            this.btnSuaSach.UseVisualStyleBackColor = true;
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.Location = new System.Drawing.Point(890, 297);
            this.btnXoaSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(82, 32);
            this.btnXoaSach.TabIndex = 12;
            this.btnXoaSach.Text = "Xóa";
            this.btnXoaSach.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(998, 297);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(82, 32);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tên sách";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Số lượng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(492, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Giá tiền";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbNXB);
            this.groupBox1.Controls.Add(this.txtTheLoai);
            this.groupBox1.Controls.Add(this.txtGiaTien);
            this.groupBox1.Controls.Add(this.txtTenSach);
            this.groupBox1.Controls.Add(this.txtMaSach);
            this.groupBox1.Controls.Add(this.txtTacGia);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(21, 59);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1138, 171);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sách";
            // 
            // cmbNXB
            // 
            this.cmbNXB.FormattingEnabled = true;
            this.cmbNXB.Location = new System.Drawing.Point(448, 111);
            this.cmbNXB.Name = "cmbNXB";
            this.cmbNXB.Size = new System.Drawing.Size(260, 28);
            this.cmbNXB.TabIndex = 16;
            // 
            // txtTheLoai
            // 
            this.txtTheLoai.Location = new System.Drawing.Point(843, 109);
            this.txtTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.txtTheLoai.Name = "txtTheLoai";
            this.txtTheLoai.Size = new System.Drawing.Size(246, 28);
            this.txtTheLoai.TabIndex = 15;
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.Location = new System.Drawing.Point(582, 47);
            this.txtGiaTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.Size = new System.Drawing.Size(126, 28);
            this.txtGiaTien.TabIndex = 15;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(109, 110);
            this.txtTenSach.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(246, 28);
            this.txtTenSach.TabIndex = 15;
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(109, 47);
            this.txtMaSach.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(114, 28);
            this.txtMaSach.TabIndex = 15;
            // 
            // txtTacGia
            // 
            this.txtTacGia.Location = new System.Drawing.Point(843, 52);
            this.txtTacGia.Margin = new System.Windows.Forms.Padding(2);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(246, 28);
            this.txtTacGia.TabIndex = 15;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(338, 50);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(119, 28);
            this.txtSoLuong.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(750, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tác giả";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(753, 116);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Thể loại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(386, 117);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "NXB";
            // 
            // grbTGTLMoi
            // 
            this.grbTGTLMoi.Controls.Add(this.txtMaTLMoi);
            this.grbTGTLMoi.Controls.Add(this.label11);
            this.grbTGTLMoi.Controls.Add(this.txtMaTGMoi);
            this.grbTGTLMoi.Controls.Add(this.label10);
            this.grbTGTLMoi.Location = new System.Drawing.Point(21, 239);
            this.grbTGTLMoi.Name = "grbTGTLMoi";
            this.grbTGTLMoi.Size = new System.Drawing.Size(789, 64);
            this.grbTGTLMoi.TabIndex = 16;
            this.grbTGTLMoi.TabStop = false;
            this.grbTGTLMoi.Text = "Tác giả và thể loại";
            // 
            // txtMaTLMoi
            // 
            this.txtMaTLMoi.Location = new System.Drawing.Point(521, 25);
            this.txtMaTLMoi.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaTLMoi.Name = "txtMaTLMoi";
            this.txtMaTLMoi.Size = new System.Drawing.Size(246, 28);
            this.txtMaTLMoi.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(386, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Mã thể loại mới";
            // 
            // txtMaTGMoi
            // 
            this.txtMaTGMoi.Location = new System.Drawing.Point(142, 26);
            this.txtMaTGMoi.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaTGMoi.Name = "txtMaTGMoi";
            this.txtMaTGMoi.Size = new System.Drawing.Size(240, 28);
            this.txtMaTGMoi.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Mã tác giả mới";
            // 
            // btnTimMaTG
            // 
            this.btnTimMaTG.Location = new System.Drawing.Point(1104, 239);
            this.btnTimMaTG.Name = "btnTimMaTG";
            this.btnTimMaTG.Size = new System.Drawing.Size(75, 34);
            this.btnTimMaTG.TabIndex = 17;
            this.btnTimMaTG.Text = "Tìm";
            this.btnTimMaTG.UseVisualStyleBackColor = true;
            // 
            // frm_dmBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 661);
            this.Controls.Add(this.btnTimMaTG);
            this.Controls.Add(this.grbTGTLMoi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoaSach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSuaSach);
            this.Controls.Add(this.btnThemSach);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgDSBook);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_dmBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm_dmBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDSBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlBanSachDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlBanSachDataSetBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbTGTLMoi.ResumeLayout(false);
            this.grbTGTLMoi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDSBook;
        private System.Windows.Forms.Button btnTim;
        private qlBanSachDataSet qlBanSachDataSet;
        private System.Windows.Forms.BindingSource qlBanSachDataSetBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimMS;
        private System.Windows.Forms.Button btnTimTS;
        private System.Windows.Forms.TextBox txtNhapTim;
        private System.Windows.Forms.Button btnTimTL;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSuaSach;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGiaTien;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTheLoai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbNXB;
        private System.Windows.Forms.GroupBox grbTGTLMoi;
        private System.Windows.Forms.TextBox txtMaTLMoi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaTGMoi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnTimMaTG;
    }
}

