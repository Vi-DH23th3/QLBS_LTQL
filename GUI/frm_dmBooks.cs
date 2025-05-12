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
    public partial class frm_dmBooks : Form
    {
        private NguoiDung_DTO NguoiDung;
        public frm_dmBooks( NguoiDung_DTO nguoiDung)
        {
            InitializeComponent();
            this.NguoiDung = nguoiDung;
        }
        private Books_BUS books_BUS=new Books_BUS();
        
        public void PhanQuyen()
        {
            if (NguoiDung != null)
            {
                int iQuyen = NguoiDung.IQuyen;
                if(iQuyen ==2)
                    btnXoaSach.Visible = false;
            }
        }
        private void HienThiBookLenDataGrid()
        {
            List<Books_DTO> lstBook = Books_BUS.LayDSBook();
            dgDSBook.DataSource = lstBook;
            dgDSBook.Columns["SMaSach"].HeaderText = "Mã sách";
            dgDSBook.Columns["STenSach"].HeaderText = "Tên sách";
            dgDSBook.Columns["STenTacGia"].HeaderText = "Tác giả";
            dgDSBook.Columns["STenNXB"].HeaderText = "NXB";
            dgDSBook.Columns["STheLoai"].HeaderText = "Thể loại";
            dgDSBook.Columns["SSachTK"].HeaderText = "Số lượng";
            dgDSBook.Columns["DGiaTien"].HeaderText = "Giá tiền";

            dgDSBook.Columns["SMaSach"].Width = 50;
            dgDSBook.Columns["STenSach"].Width = 300;
            dgDSBook.Columns["STenTacGia"].Width = 200;
            dgDSBook.Columns["STenNXB"].Width = 150;
            dgDSBook.Columns["STheLoai"].Width = 150;
            dgDSBook.Columns["SSachTK"].Width = 80;
            dgDSBook.Columns["DGiaTien"].Width = 150;

            dgDSBook.Columns["SMaTG"].Visible = false;
            dgDSBook.Columns["SMaNXB"].Visible = false;
            dgDSBook.Columns["SMaTheLoai"].Visible = false;
            dgDSBook.Columns["IDaXoa"].Visible=false;

        }
        private void HienThiNXBLenCombobox()
        {
            List<NXB_DTO> lstNXB = NXB_BUS.LayDSNXB();
            cmbNXB.DataSource= lstNXB;
            cmbNXB.DisplayMember = "STenNXB";
            cmbNXB.ValueMember = "SMaNXB";
        }
        
        private void frm_dmBooks_Load(object sender, EventArgs e)
        {
            HienThiBookLenDataGrid();
            HienThiNXBLenCombobox();
            PhanQuyen();
        }
        //Tìm theo tác giả
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNhapTim.Text))
            {
                MessageBox.Show("Hãy nhập vào ô tìm kiếm", "Thông báo");
                return; 
            }
            string tg = txtNhapTim.Text;

            List<Books_DTO> lsttg = Books_BUS.TimTheoTacGia(tg);
            if (lsttg == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgDSBook.DataSource = lsttg;
        }

        private void btnTimMS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNhapTim.Text))
            {
                MessageBox.Show("Hãy nhập vào ô tìm kiếm", "Thông báo");
                return;
            }
            string ms = txtNhapTim.Text;
            Books_DTO book=Books_BUS.TimTheoMaSach(ms);
            if(book == null)
            {
                MessageBox.Show("Không tìm thấy");
                return;
            }    
            dgDSBook.DataSource = new List<Books_DTO> { book };
        }

        private void btnTimTS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNhapTim.Text))
            {
                MessageBox.Show("Hãy nhập vào ô tìm kiếm", "Thông báo");
                return;
            }
            string ts = txtNhapTim.Text;

            List<Books_DTO> lstts = Books_BUS.TimTheoTenSach(ts);
            if (lstts == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgDSBook.DataSource = lstts;
        }
        private void btnTimTL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNhapTim.Text))
            {
                MessageBox.Show("Hãy nhập vào ô tìm kiếm", "Thông báo");
                return;
            }
            string tl = txtNhapTim.Text;

            List<Books_DTO> lsttl = Books_BUS.TimTheoTheLoai(tl);
            if (lsttl == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgDSBook.DataSource = lsttl;
        }

        private void dgDSBook_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgDSBook.SelectedRows[0];
            txtTenSach.Text = r.Cells["STenSach"].Value.ToString();
            int soLuong;
            if (!int.TryParse(r.Cells["SSachTK"].Value?.ToString(), out soLuong))
                soLuong = 0;
            txtSoLuong.Text = soLuong.ToString();
            txtGiaTien.Text = r.Cells["DGiaTien"].Value.ToString();
            txtTacGia.Text = r.Cells["STenTacGia"].Value.ToString();
            txtTheLoai.Text = r.Cells["STheLoai"].Value.ToString();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi= MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi==DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraRong())
                    return;
                Books_BUS books = new Books_BUS();
                Books_DTO sach = new Books_DTO();
                
                {
                    sach.STenSach = txtTenSach.Text;
                    sach.STenTacGia = txtTacGia.Text;
                    sach.STheLoai = txtTheLoai.Text;
                    sach.SMaNXB = cmbNXB.SelectedValue.ToString();
                    sach.SSachTK = int.Parse(txtSoLuong.Text);
                    sach.DGiaTien = decimal.Parse(txtGiaTien.Text);
                }
                
                bool kt = books.KiemTravaThemSach(sach);
                if (kt == false)
                {
                    MessageBox.Show("Thêm sách không thành công");
                }
                else
                {
                    MessageBox.Show("Thêm sách thành công");
                    HienThiBookLenDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message + "\n" + ex.StackTrace);
            }


        }
        public bool KiemTraRong()
        {
           
            if(string.IsNullOrEmpty(txtTenSach.Text) && 
                string.IsNullOrEmpty(txtTacGia.Text) && 
                string.IsNullOrEmpty(txtTheLoai.Text) && 
                string.IsNullOrEmpty(txtSoLuong.Text) && 
                (cmbNXB.SelectedItem == null))  // Kiểm tra ComboBox
            {               
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }
            int soLuong;
            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)  // Kiểm tra nếu không phải số hoặc số < 0
            {
                MessageBox.Show("Số lượng phải là một số hợp lệ và lớn hơn 0.");
                return false;
            }
            return true;
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraRong())  
                    return;

                Books_DTO sach= new Books_DTO();
                string masach = dgDSBook.CurrentRow.Cells["SMaSach"].Value.ToString();
                sach.SMaSach=masach;
                sach.STenSach = txtTenSach.Text;
                sach.STenTacGia = txtTacGia.Text;
                sach.STheLoai = txtTheLoai.Text;
                sach.SMaNXB = cmbNXB.SelectedValue.ToString();
                sach.SSachTK = int.Parse(txtSoLuong.Text);
                sach.DGiaTien = decimal.Parse(txtGiaTien.Text);
                bool kq = books_BUS.SuaSach(sach);
                if(kq==true)
                {
                    MessageBox.Show("Sửa thông tin sách thành công");
                    HienThiBookLenDataGrid();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin thất bại");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex);
            }

        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            try
            {
                string masach = dgDSBook.CurrentRow.Cells["SMasach"].Value.ToString();
                string thongBao;
                Books_DTO sach= new Books_DTO();
                sach.SMaSach = masach;
                sach.SSachTK = int.Parse(txtSoLuong.Text);               
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (books_BUS.XoaSach(sach, out thongBao))
                    {
                        MessageBox.Show(thongBao, "Thông báo");
                        HienThiBookLenDataGrid(); 
                    }
                    else
                    {
                        MessageBox.Show(thongBao, "Lỗi");
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
