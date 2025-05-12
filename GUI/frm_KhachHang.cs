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
    public partial class frm_KhachHang : Form
    {
        private NguoiDung_DTO NguoiDung;
        public frm_KhachHang(NguoiDung_DTO nguoiDung)
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
                    btnXoaKH.Visible = false;
            }
        }
        public void HienThiDSKH()
        {
            List<KhachHang_DTO> lst=KhachHang_BUS.LayDSKH();
            dgDSKhachHang.DataSource = lst;

            dgDSKhachHang.Columns["IMaKH"].HeaderText = "Mã khách hàng";
            dgDSKhachHang.Columns["STenKH"].HeaderText = "Ten khách hàng";
            dgDSKhachHang.Columns["SSDT"].HeaderText = "Số điện thoại";
            dgDSKhachHang.Columns["SDiaChi"].HeaderText = "Địa chỉ";
            dgDSKhachHang.Columns["SEmail"].HeaderText = "Email";

            dgDSKhachHang.Columns["IMaKH"].Width = 70;
            dgDSKhachHang.Columns["STenKH"].Width = 200;
            dgDSKhachHang.Columns["SSDT"].Width = 130;
            dgDSKhachHang.Columns["SDiaChi"].Width = 180;
            dgDSKhachHang.Columns["SEmail"].Width = 140;

            dgDSKhachHang.Columns["IDaXoa"].Visible = false;
        }
        public bool KiemTraRong()
        {
            if (string.IsNullOrEmpty(txtTenKH.Text) &&
               string.IsNullOrEmpty(txtDiaChi.Text) &&
               string.IsNullOrEmpty(txtEmail.Text) &&
               string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông bái");
                return false;
            }
            if (txtSDT.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải có 10 số");
                return false;
            }
            return true;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            HienThiDSKH();
            PhanQuyen();
        }

        private void dgDSKhachHang_Click(object sender, EventArgs e)
        {
            DataGridViewRow r=dgDSKhachHang.SelectedRows[0];
            txtTenKH.Text = r.Cells["STenKH"].Value.ToString();
            txtDiaChi.Text = r.Cells["SDiaChi"].Value.ToString();
            txtSDT.Text= r.Cells["SSDT"].Value.ToString();
            txtEmail.Text= r.Cells["SEmail"].Value.ToString();
        }

        private void btnTimMaKH_Click(object sender, EventArgs e)
        {
            try
            {
                int makh=int.Parse(txtNhapTimKH.Text); 
                if (string.IsNullOrEmpty(txtNhapTimKH.Text))
                {
                    MessageBox.Show("Hãy nhập vào ô tìm kiếm","Thông báo");
                    txtNhapTimKH.Focus();
                }
                KhachHang_DTO kh = KhachHang_BUS.TimKHTheoMa(makh);
                if(kh==null)
                {
                    MessageBox.Show("Không tìm thấy", "Thông báo");
                }
                dgDSKhachHang.DataSource = new List<KhachHang_DTO> { kh }; //DataGridView yêu cầu DataSource phải là một dạng danh sách
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi tìm mã khách hàng: " + ex);
            }
        }

        private void btnTimTenKH_Click(object sender, EventArgs e)
        {
            try
            {
                string tenkh = txtNhapTimKH.Text;
                if (string.IsNullOrEmpty(txtNhapTimKH.Text.Trim()))
                {
                    MessageBox.Show("Hãy nhập vào ô tìm kiếm", "Thông báo");
                    txtNhapTimKH.Focus();
                }
                List<KhachHang_DTO> lstKH = KhachHang_BUS.TimKHTheoTen(tenkh);
                if (lstKH == null)
                {
                    MessageBox.Show("Không tìm thấy", "Thông báo");
                }
                dgDSKhachHang.DataSource=lstKH;
             }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm tên khách hàng: " + ex);
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraRong())
                {
                    MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
                    return;
                }
                KhachHang_DTO kh = new KhachHang_DTO();
                {
                    kh.STenKH = txtTenKH.Text.Trim();
                    kh.SDiaChi = txtDiaChi.Text.Trim();
                    kh.SSDT = txtSDT.Text;
                    kh.SEmail = txtEmail.Text.Trim();
                }
                if (KhachHang_BUS.ThemKhachHang(kh))
                {
                    MessageBox.Show("Thêm khách hàng thành công", "Thông báo");
                    HienThiDSKH();
                }
                else
                {
                    MessageBox.Show("Không thể thêm khách hàng", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khách hàng: " + ex);
            }
            
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraRong())
                {
                    MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
                    return;
                }
                int makh = int.Parse(dgDSKhachHang.CurrentRow.Cells["IMaKH"].Value.ToString());
                KhachHang_DTO kh = new KhachHang_DTO();
                {
                    kh.IMaKH=makh;
                    kh.STenKH = txtTenKH.Text.Trim();
                    kh.SDiaChi = txtDiaChi.Text.Trim();
                    kh.SSDT = txtSDT.Text;
                    kh.SEmail = txtEmail.Text.Trim();
                }
                if (KhachHang_BUS.SuaKhachHang(kh))
                {
                    MessageBox.Show("Sửa thông tin khách hàng thành công", "Thông báo");
                    HienThiDSKH();
                }
                else
                {
                    MessageBox.Show("Không thể sửa thông tin khách hàng", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa khách hàng: " + ex);
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraRong())
                {
                    MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
                    return;
                }
                int makh = int.Parse(dgDSKhachHang.CurrentRow.Cells["IMaKH"].Value.ToString());

                DialogResult traloi=MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng này?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (KhachHang_BUS.XoaKhachHang(makh))
                    {
                        MessageBox.Show("Xóa khách hàng thành công", "Thông báo");
                        HienThiDSKH();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa khách hàng", "Thông báo");
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa khách hàng: " + ex);
            }
        }
    }
}
