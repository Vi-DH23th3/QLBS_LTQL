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
    public partial class frm_SuaDonHang : Form
    {
        private int madonhang;
        public frm_SuaDonHang(int madh)
        {
            InitializeComponent();
            this.madonhang = madh;
        }
        public void HienThiChiTietDHLenDatagridview(int madonhang)
        {
            List<ChiTietBanSach_DTO> lst = ChiTietBanSach_BUS.LayChiTietBanSach(madonhang);

            if (lst == null || lst.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu chi tiết đơn hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Cập nhật lại DataGridView
            dgChiTietDonHang.DataSource = null;  // Xóa nguồn dữ liệu cũ 
            dgChiTietDonHang.DataSource = lst;

            dgChiTietDonHang.Columns["IMaDonHang"].HeaderText = "Mã đơn hàng";
            dgChiTietDonHang.Columns["STenSach"].HeaderText = "Tên sách";
            dgChiTietDonHang.Columns["DGiaBan"].HeaderText = "Giá bán";
            dgChiTietDonHang.Columns["ISoLuong"].HeaderText = "Số lượng";

            dgChiTietDonHang.Columns["IMaDonHang"].Width = 80;
            dgChiTietDonHang.Columns["STenSach"].Width = 300;
            dgChiTietDonHang.Columns["DGiaBan"].Width = 200;
            dgChiTietDonHang.Columns["ISoLuong"].Width = 110;

            dgChiTietDonHang.Columns["IMaSach"].Visible = false;
        }


        private void frm_SuaDonHang_Load(object sender, EventArgs e)
        {
            HienThiChiTietDHLenDatagridview(madonhang);
        }

        private void dgChiTietDonHang_Click(object sender, EventArgs e)
        {
            DataGridViewRow r=dgChiTietDonHang.SelectedRows[0];
            txtTenSach.Text = r.Cells["STenSach"].Value.ToString();
            txtSoLuong.Text = r.Cells["ISoLuong"].Value.ToString();
            txtGiaBan.Text = r.Cells["DGiaBan"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSoLuong.Text))
                {
                    MessageBox.Show("Hãy nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int madonhang = int.Parse(dgChiTietDonHang.CurrentRow.Cells["IMaDonHang"].Value.ToString());
                int soluongMoi = int.Parse(txtSoLuong.Text);
                decimal giaban = decimal.Parse(dgChiTietDonHang.CurrentRow.Cells["DGiaBan"].Value.ToString());
                int masach = int.Parse(dgChiTietDonHang.CurrentRow.Cells["IMaSach"].Value.ToString());
                if (masach == 0)
                {
                    MessageBox.Show("Mã sách không hợp lệ (masach = 0). Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ChiTietBanSach_BUS.SuaSoLuong(madonhang, soluongMoi, giaban, masach))
                {
                    MessageBox.Show("Sửa số lượng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiChiTietDHLenDatagridview(madonhang);
                }
                else
                {
                    MessageBox.Show("Sửa số lượng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi: " + ex);
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
