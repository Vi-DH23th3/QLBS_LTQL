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
using Microsoft.Reporting.WinForms;

namespace GUI
{
    public partial class frm_bcSachBanChay : Form
    {
        public frm_bcSachBanChay()
        {
            InitializeComponent();
        }

        private void frm_bcSachBanChay_Load(object sender, EventArgs e)
        {
            try
            {
                chiTietBanSachDTOBindingSource.DataSource = ChiTietBanSach_BUS.ThongKeSachBanChay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex);
            }

            this.reportViewer2.RefreshReport();
        }
    }
}
