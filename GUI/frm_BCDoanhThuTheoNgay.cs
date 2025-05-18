using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frm_BCDoanhThuTheoNgay : Form
    {
        public frm_BCDoanhThuTheoNgay()
        {
            InitializeComponent();
        }

        private void frm_BCDoanhThuTheoNgay_Load(object sender, EventArgs e)
        {
            try
            {
                qlBanHangDTOBindingSource.DataSource = QlBanHang_BUS.ThongKeTheoNgay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex);
            }
            
            this.reportViewer1.RefreshReport();
        }

        private void btnLocNgay_Click(object sender, EventArgs e)
        {
            DateTime tungay = dtpTuNgay.Value.Date;
            DateTime denngay = dtpDenNgay.Value.Date;

            if (tungay > denngay)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<QlBanHang_DTO> ds = QlBanHang_BUS.TimDonHangTheoNgay(tungay, denngay);
            if (ds != null && ds.Count > 0)
            {
                qlBanHangDTOBindingSource.DataSource = ds;
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Không tìm thấy đơn hàng nào trong khoảng thời gian đã chọn.", "Thông báo");
            }
        }
    }
}
