using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;
using Microsoft.Reporting.WinForms;

namespace GUI
{
    public partial class frm_bcHoaDon : Form
    {
        private int madh;
        private int makh;
        private int manv;

        public frm_bcHoaDon(int madonhang, int makh, int manv)
        {
            InitializeComponent();
            this.madh = madonhang;
            this.makh = makh;
            this.manv = manv;
        }

        private void frm_bcHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                var khach = KhachHang_BUS.TimKHTheoMa(makh);
                var nhanvien = NhanVien_BUS.TimTheoMaNV(manv);

                string tenKH = khach.STenKH;
                string tenNV = nhanvien.STenNV;

                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("TenKhachHang", tenKH),
                    new ReportParameter("TenNhanVien", tenNV),
                    new ReportParameter("MaHoaDon", madh.ToString()),
                    new ReportParameter("NgayLap", DateTime.Now.ToString("dd/MM/yyyy")), 
                    new ReportParameter("TongTien", TinhTongTien()) 
                };
                chiTietBanSachDTOBindingSource.DataSource = ChiTietBanSach_BUS.LayChiTietBanSach(madh);

                // Gán tham số cho báo cáo
                reportViewer1.LocalReport.SetParameters(parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            // Refresh báo cáo để cập nhật
            this.reportViewer1.RefreshReport();
        }

        private string TinhTongTien()
        {
            var chiTietBanSachList = ChiTietBanSach_BUS.LayChiTietBanSach(madh);
            decimal tongtien = 0;

            // Tính tổng tiền dựa trên danh sách chi tiết đơn hàng
            foreach (var item in chiTietBanSachList)
            {
                tongtien += item.ThanhTien;
            }

            return tongtien.ToString(); 
        }
    }
}
