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
    public partial class frm_QLBanSach : Form
    {
        private NguoiDung_DTO NguoiDung;
        public frm_QLBanSach(NguoiDung_DTO nguoiDung)
        {
            InitializeComponent();
            this.NguoiDung = nguoiDung;
        }
        public void PhanQuyen()
        {
            if (NguoiDung != null)
            {
                int iQuyen = NguoiDung.IQuyen;
                if (iQuyen == 2)
                     btnXoaDSBan.Visible = false;
            }
        }
        private void DinhDangDataGridViewDonHang()
        {
            dgDSDonHang.Columns["IMaDonHang"].HeaderText = "Mã đơn hàng";
            dgDSDonHang.Columns["STenKH"].HeaderText = "Tên khách hàng";
            dgDSDonHang.Columns["STenNV"].HeaderText = "Tên nhân viên";
            dgDSDonHang.Columns["DtNgayBan"].HeaderText = "Ngày bán";
            dgDSDonHang.Columns["DTongTien"].HeaderText = "Tổng tiền";

            dgDSDonHang.Columns["IMaDonHang"].Width = 100;
            dgDSDonHang.Columns["STenKH"].Width = 150;
            dgDSDonHang.Columns["STenNV"].Width = 150;
            dgDSDonHang.Columns["DtNgayBan"].Width = 100;
            dgDSDonHang.Columns["DTongTien"].Width = 100;

            dgDSDonHang.Columns["IMaKH"].Visible = false;
            dgDSDonHang.Columns["IMaNV"].Visible = false;
            dgDSDonHang.Columns["IDaXoa"].Visible = false;
        }
        public void HienThiQlDonHangLenDatagridview()
        {
            List<QlBanHang_DTO> lst = QlBanHang_BUS.LayDSQlBanHang();
            dgDSDonHang.DataSource = lst;
            DinhDangDataGridViewDonHang();
        }
        public void HienThiChiTietDHLenDatagridview()
        {
            int madh=int.Parse(dgDSDonHang.CurrentRow.Cells["IMaDonHang"].Value.ToString());
            List<ChiTietBanSach_DTO> lst = ChiTietBanSach_BUS.LayChiTietBanSach(madh);
            dgChiTietDonHang.DataSource = lst;
            dgChiTietDonHang.Columns["STenSach"].HeaderText = "Tên sách";
            dgChiTietDonHang.Columns["DGiaBan"].HeaderText = "Giá bán";
            dgChiTietDonHang.Columns["ISoLuong"].HeaderText = "Số lượng";

            dgChiTietDonHang.Columns["STenSach"].Width = 300;
            dgChiTietDonHang.Columns["DGiaBan"].Width = 200;
            dgChiTietDonHang.Columns["ISoLuong"].Width = 110;

            dgChiTietDonHang.Columns["IMaDonHang"].Visible = false;
            dgChiTietDonHang.Columns["IMaSach"].Visible = false;
        }
        public void HienThiNVLenCombobox()
        {
            cmbTenNV.DataSource = NhanVien_BUS.LayDSNhanVien();
            cmbTenNV.DisplayMember = "STenNV";
            cmbTenNV.ValueMember = "IMaNV";
        }
        public void HienThiKHLenCombobox()
        {
            cmbTenKH.DataSource = KhachHang_BUS.LayDSKH();
            cmbTenKH.DisplayMember = "STenKH";
            cmbTenKH.ValueMember = "IMaKH";
        }
        private void frm_BanSach_Load(object sender, EventArgs e)
        {
            
            HienThiQlDonHangLenDatagridview();
            HienThiKHLenCombobox();
            HienThiNVLenCombobox();
        }

        private void dgDSDonHang_Click(object sender, EventArgs e)
        {
            HienThiChiTietDHLenDatagridview();
            PhanQuyen();
        }
      
        private void btnLocNgay_Click(object sender, EventArgs e)
        {
            DateTime tungay=dtpTuNgay.Value.Date;
            DateTime denngay=dtpDenNgay.Value.Date;

            if(tungay>denngay)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            List<QlBanHang_DTO> ds = QlBanHang_BUS.TimDonHangTheoNgay(tungay, denngay);
            if (ds != null && ds.Count > 0)
            {
                dgDSDonHang.DataSource = ds;
                DinhDangDataGridViewDonHang();
            }
            else
            {
                MessageBox.Show("Không tìm thấy đơn hàng nào trong khoảng thời gian đã chọn.", "Thông báo");
            }   
        }

        private void btnSuaChiTietHoaDon_Click(object sender, EventArgs e)
        {
            if (dgDSDonHang.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn đơn hàng ở bảng thông tin các đơn hàng", "Thông báo");
                return; 
            }
            this.Enabled = false;
            
            int madh = int.Parse(dgDSDonHang.CurrentRow.Cells["IMaDonHang"].Value.ToString());
            frm_SuaDonHang frm_SuaDonHang = new frm_SuaDonHang(madh);
            frm_SuaDonHang.FormClosed += (s, args) =>
            {
                this.Enabled = true; 
                this.BringToFront(); //Đảm bảo form nằm phía ttuowcs
                HienThiChiTietDHLenDatagridview();
                HienThiQlDonHangLenDatagridview();
            };

            frm_SuaDonHang.Show();
            //frm_SuaDonHang.ShowDialog();

            HienThiChiTietDHLenDatagridview();
            HienThiQlDonHangLenDatagridview();
        }

        private void btnXoaDSBan_Click(object sender, EventArgs e)
        {
            try
            {
                int madonhang = int.Parse(dgDSDonHang.CurrentRow.Cells["IMaDonHang"].Value.ToString());
                DialogResult traloi = MessageBox.Show("Bạn chắc chắn muốn xóa đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (QlBanHang_BUS.XoaDonHang(madonhang))
                    {
                        MessageBox.Show("Xóa đơn hàng thành công", "Thông báo");
                        HienThiQlDonHangLenDatagridview();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa đơn hàng", "Thông báo");
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        private void btnLocKH_Click(object sender, EventArgs e)
        {
            try
            {
                
                KhachHang_DTO kh=cmbTenKH.SelectedItem as KhachHang_DTO;
                if (kh != null)
                {
                    int makh = int.Parse(cmbTenKH.SelectedValue.ToString());
                    List<QlBanHang_DTO> lsst=QlBanHang_BUS.TimDonHangTheoKH(makh);
                    if (lsst != null && lsst.Count > 0)
                    {
                        dgDSDonHang.DataSource = lsst;
                        DinhDangDataGridViewDonHang();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo");
                    }    
                }
                else
                {
                    MessageBox.Show("Hãy chọn khách hàng cần tìm", "Thông báo");
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        private void btnLocNV_Click(object sender, EventArgs e)
        {
            try
            {

                NhanVien_DTO nv=cmbTenNV.SelectedItem as NhanVien_DTO;
                if (nv != null)
                {
                    int manv = int.Parse(cmbTenNV.SelectedValue.ToString());
                    List<QlBanHang_DTO> lst=QlBanHang_BUS.TimDonHangTheoNV(manv);
                    if (lst != null && lst.Count > 0)
                    {
                        dgDSDonHang.DataSource = lst;
                        DinhDangDataGridViewDonHang();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn nhân viên cần tìm", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }
    }
}
