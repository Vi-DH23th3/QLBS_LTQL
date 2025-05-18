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
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    public partial class frm_NhanVien : Form
    {
        public frm_NhanVien()
        {
            InitializeComponent();
        }
        public void HienThiLenDataGridView()
        {
            try
            {
                List<NhanVien_DTO> lst = NhanVien_BUS.LayDSNhanVien();
                dgDSNhanVien.DataSource = lst;
                dgDSNhanVien.Columns["IMaNV"].HeaderText = "Mã nhân viên";
                dgDSNhanVien.Columns["STenNV"].HeaderText = "Tên nhân viên";
                dgDSNhanVien.Columns["DtNgaySinh"].HeaderText = "Ngày sinh";
                dgDSNhanVien.Columns["SGioiTinh"].HeaderText = "Giới tính";
                dgDSNhanVien.Columns["SDiaChi"].HeaderText = "Địa chỉ";
                dgDSNhanVien.Columns["SSDT"].HeaderText = "Số điện thoại";
                dgDSNhanVien.Columns["SEmail"].HeaderText = "Email";

                dgDSNhanVien.Columns["IMaNV"].Width = 60;
                dgDSNhanVien.Columns["STenNV"].Width = 200;
                dgDSNhanVien.Columns["DtNgaySinh"].Width = 100;
                dgDSNhanVien.Columns["SGioiTinh"].Width = 150;
                dgDSNhanVien.Columns["SDiaChi"].Width = 200;
                dgDSNhanVien.Columns["SSDT"].Width = 120;
                dgDSNhanVien.Columns["SEmail"].Width = 200;

                dgDSNhanVien.Columns["IDaXoa"].Visible= false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            HienThiLenDataGridView();
        }

        private void dgDSNhanVien_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgDSNhanVien.SelectedRows[0];
            txtTenNV.Text = r.Cells["STenNV"].Value.ToString();
            dtNgaySinh.Text = r.Cells["DtNgaySinh"].Value.ToString();
            if (r.Cells["SGioiTinh"].Value.ToString()=="Nam")
            {
                radNam.Checked=true;
            }    
            else
            {
                radNu.Checked=true;
            }
            txtDiaChi.Text = r.Cells["SDiaChi"].Value.ToString();
            txtSDT.Text = r.Cells["SSDT"].Value.ToString();
            txtEmail.Text = r.Cells["SEmail"].Value.ToString();
        }

        private void btnTimMaNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(btnTimMaNV.Text))
            {
                MessageBox.Show("Hãy nhập vào ô tìm kiếm","Thông báo");
                return;
            }
            int manv=int.Parse(txtNhapTimNV.Text);
            //List<NhanVien_DTO> lst = NhanVien_BUS.TimNVTheoMa(manv);
            NhanVien_DTO nv=NhanVien_BUS.TimTheoMaNV(manv);
            if (nv == null)
            {
                MessageBox.Show("Không tìm thấy","Thông báo");
                return;
            }
            dgDSNhanVien.DataSource = new List<NhanVien_DTO> { nv }; ;
        }

        private void btnTimTenNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(btnTimMaNV.Text))
            {
                MessageBox.Show("Hãy nhập vào ô tìm kiếm","Thông báo");
                return;
            }
            string tennv = txtNhapTimNV.Text;
            List<NhanVien_DTO> lst = NhanVien_BUS.TimNVTheoTen(tennv);
            if(lst == null)
            {
                MessageBox.Show("Không tìm thấy", "Thông báo");
                return;
            }    
            dgDSNhanVien.DataSource=lst;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi=MessageBox.Show("Bạn chắc chắn muốn thoát","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) 
            {
                this.Close();
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraRong())
                    return;
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.STenNV = txtTenNV.Text;
                nv.DtNgaySinh = DateTime.Parse(dtNgaySinh.Text);
                if (radNam.Checked == true)
                {
                    nv.SGioiTinh = "Nam";
                }
                else
                {
                    nv.SGioiTinh = "Nữ";
                }
                nv.SDiaChi = txtDiaChi.Text;
                nv.SSDT = txtSDT.Text;
                nv.SEmail = txtEmail.Text;
                if(NhanVien_BUS.ThemNhanVien(nv))
                {
                    MessageBox.Show("Thêm nhân viên thành công");
                    HienThiLenDataGridView();
                }    
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại");
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
            
        }
        public bool KiemTraRong()
        {
            if(string.IsNullOrEmpty(txtTenNV.Text) &&
               string.IsNullOrEmpty(txtDiaChi.Text) && 
               string.IsNullOrEmpty(txtEmail.Text) && 
               string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông bái");
                return false;
            }    
            if(txtSDT.Text.Length <10)
            {
                MessageBox.Show("Số điện thoại phải có 10 số");
                return false;
            }    
            return true;
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraRong())
                    return;
                int manv = int.Parse(dgDSNhanVien.CurrentRow.Cells["IMaNV"].Value.ToString());
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.IMaNV=manv;
                nv.STenNV = txtTenNV.Text;
                nv.DtNgaySinh = DateTime.Parse(dtNgaySinh.Text);
                if (radNam.Checked == true)
                {
                    nv.SGioiTinh = "Nam";
                }
                else
                {
                    nv.SGioiTinh = "Nữ";
                }
                nv.SDiaChi = txtDiaChi.Text;
                nv.SSDT = txtSDT.Text;
                nv.SEmail = txtEmail.Text;
                if (NhanVien_BUS.SuaNhanVien(nv))
                {
                    MessageBox.Show("Sửa thông tin nhân viên thành công");
                    HienThiLenDataGridView();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin nhân viên thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                int manv = int.Parse(dgDSNhanVien.CurrentRow.Cells["IMaNV"].Value.ToString());
                DialogResult traloi;
                traloi=MessageBox.Show("Bạn chắc chắn muốn xóa?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (NhanVien_BUS.XoaNhanVien(manv))
                    {
                        MessageBox.Show("Xóa nhân viên thành công");
                        HienThiLenDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn đã hủy thao tác xóa.");
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }
    }
}
