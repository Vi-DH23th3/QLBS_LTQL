namespace GUI
{
    partial class frm_BCDoanhThuTheoNgay
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.qlBanHangDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.qlBanSachDataSet1 = new GUI.qlBanSachDataSet();
            this.quanlybansachDataSet1 = new GUI.QuanlybansachDataSet1();
            this.qlbanhangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qlbanhangTableAdapter = new GUI.QuanlybansachDataSet1TableAdapters.qlbanhangTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLocNgay = new System.Windows.Forms.Button();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.qlBanHangDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlBanSachDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlybansachDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlbanhangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // qlBanHangDTOBindingSource
            // 
            this.qlBanHangDTOBindingSource.DataSource = typeof(DTO.QlBanHang_DTO);
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.qlBanHangDTOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.ReportDTNgay.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 154);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(897, 512);
            this.reportViewer1.TabIndex = 0;
            // 
            // qlBanSachDataSet1
            // 
            this.qlBanSachDataSet1.DataSetName = "qlBanSachDataSet";
            this.qlBanSachDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quanlybansachDataSet1
            // 
            this.quanlybansachDataSet1.DataSetName = "QuanlybansachDataSet1";
            this.quanlybansachDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qlbanhangBindingSource
            // 
            this.qlbanhangBindingSource.DataMember = "qlbanhang";
            this.qlbanhangBindingSource.DataSource = this.quanlybansachDataSet1;
            // 
            // qlbanhangTableAdapter
            // 
            this.qlbanhangTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(305, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "THỐNG KÊ THEO NGÀY";
            // 
            // btnLocNgay
            // 
            this.btnLocNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocNgay.Location = new System.Drawing.Point(388, 110);
            this.btnLocNgay.Name = "btnLocNgay";
            this.btnLocNgay.Size = new System.Drawing.Size(103, 38);
            this.btnLocNgay.TabIndex = 9;
            this.btnLocNgay.Text = "Lọc ngày";
            this.btnLocNgay.UseVisualStyleBackColor = true;
            this.btnLocNgay.Click += new System.EventHandler(this.btnLocNgay_Click);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(283, 64);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(136, 30);
            this.dtpTuNgay.TabIndex = 10;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(525, 64);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(138, 30);
            this.dtpDenNgay.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "Từ ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "Đến ngày";
            // 
            // frm_BCDoanhThuTheoNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(921, 678);
            this.Controls.Add(this.btnLocNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_BCDoanhThuTheoNgay";
            this.Text = "frm_BCDoanhThuTheoNgay";
            this.Load += new System.EventHandler(this.frm_BCDoanhThuTheoNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qlBanHangDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlBanSachDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlybansachDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlbanhangBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private qlBanSachDataSet qlBanSachDataSet1;
        private QuanlybansachDataSet1 quanlybansachDataSet1;
        private System.Windows.Forms.BindingSource qlbanhangBindingSource;
        private QuanlybansachDataSet1TableAdapters.qlbanhangTableAdapter qlbanhangTableAdapter;
        private System.Windows.Forms.BindingSource qlBanHangDTOBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLocNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}