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
        public frm_dmBooks()
        {
            InitializeComponent();
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

            dgDSBook.Columns["SMaSach"].Width = 100;
            dgDSBook.Columns["STenSach"].Width = 300;
            dgDSBook.Columns["STenTacGia"].Width = 200;
            dgDSBook.Columns["STenNXB"].Width = 150;
            dgDSBook.Columns["STheLoai"].Width = 150;
            dgDSBook.Columns["SSachTK"].Width = 80;
            dgDSBook.Columns["DGiaTien"].Width = 150;

            dgDSBook.Columns["SMaTG"].Visible = false;
            dgDSBook.Columns["SMaNXB"].Visible = false;
            dgDSBook.Columns["SMaTheLoai"].Visible = false;

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
            grbTGTLMoi.Visible = false;
            HienThiBookLenDataGrid();
            HienThiNXBLenCombobox();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tg=txtNhapTim.Text;
            
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
            string ms = txtNhapTim.Text;
            List<Books_DTO> lst=Books_BUS.TimTheoMaSach(ms);
            if(lst==null)
            {
                MessageBox.Show("Không tìm thấy");
                return;
            }    
            dgDSBook.DataSource = lst;
        }

        private void btnTimTS_Click(object sender, EventArgs e)
        {
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
            txtMaSach.Text = r.Cells["SMaSach"].Value.ToString();
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
                Application.Exit();
            }
            
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            try
            {
                HienThiTextBoxNhapTLTG();
                Books_BUS books = new Books_BUS();
                Books_DTO sach = new Books_DTO();
                
                {
                    sach.SMaSach = txtMaSach.Text;
                    sach.STenSach = txtTenSach.Text;
                    sach.STenTacGia = txtTacGia.Text;
                    sach.STheLoai = txtTheLoai.Text;
                    sach.STenNXB = cmbNXB.SelectedIndex.ToString();
                    sach.SSachTK = int.Parse(txtSoLuong.Text);
                    sach.DGiaTien = decimal.Parse(txtGiaTien.Text);
                    sach.SMaTG = txtMaTGMoi.Text;
                    sach.SMaTheLoai = txtMaTLMoi.Text;
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
                MessageBox.Show("Lỗi: " + ex);
            }
            
            
        }
        public void HienThiTextBoxNhapTLTG()
        {
            TacGia_BUS tacGia_BUS = new TacGia_BUS();
            TheLoai_BUS theLoai_BUS = new TheLoai_BUS();
            string matg = tacGia_BUS.TimMaTheoTenTG(txtTheLoai.Text);
            string matl = theLoai_BUS.TimTenTLTheoMaTL(txtTheLoai.Text);
            if (!string.IsNullOrEmpty(matl) && !string.IsNullOrEmpty(matg))
            {
                grbTGTLMoi.Visible = true;
                if (string.IsNullOrEmpty(matl) && !string.IsNullOrEmpty(matg))
                {
                    txtMaTLMoi.Visible = false;
                }
                else
                {
                    txtMaTGMoi.Visible = false;
                }    
            }
              
        }
    }
}
