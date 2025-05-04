using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frm_TrangChu : Form
    {
        public frm_TrangChu()
        {
            InitializeComponent();
        }
        public bool bDangNhap;
        public NguoiDung_DTO NguoiDung;
        frm_DangNhap fDN;

        private void HienThiMenu()
        {
            toolStripMenuItemSach.Enabled = false;
            toolStripMenuItemNhapSach.Enabled = false;
            toolStripMenuItemBanSach.Enabled = false;
            toolStripMenuItemThongKe.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled=false;
            btnBanSach.Enabled=false;
            btnSach.Enabled=false;
            btnNhapSach.Enabled = false;
            btnKhachHang.Enabled = false;
            btnNhanVien.Enabled = false;
            btnThongKe.Enabled = false;
            btnDangXuat.Enabled = false;
            // Hiển thị thông tin đăng nhập lên thanh trạng thái
            if (bDangNhap == true)
            {
                sttTTNguoiDung.Text = "Người dùng: " + NguoiDung.STaiKhoan;
                statusStrip2.Text = "Thời gian: " + DateTime.Now;
                                   
                int iQuyen;
                if (NguoiDung == null)
                {
                    iQuyen = 0;
                }
                else
                {
                    iQuyen = int.Parse(NguoiDung.IQuyen.ToString());
                }
                switch (iQuyen)
                {
                    case 1:
                        toolStripMenuItemSach.Enabled = true;
                        toolStripMenuItemNhapSach.Enabled = true;
                        toolStripMenuItemBanSach.Enabled = true;
                        toolStripMenuItemThongKe.Enabled= true;
                        đăngXuấtToolStripMenuItem.Enabled = true;
                        btnBanSach.Enabled = true;
                        btnSach.Enabled = true;
                        btnNhapSach.Enabled = true;
                        btnKhachHang.Enabled = true;
                        btnNhanVien.Enabled = true;
                        btnThongKe.Enabled = true;
                        btnDangXuat.Enabled= true;

                        break;
                    case 2:
                        toolStripMenuItemSach.Enabled = true;
                        toolStripMenuItemNhapSach.Enabled = true;
                        toolStripMenuItemBanSach.Enabled = true;
                        đăngXuấtToolStripMenuItem.Enabled = true;
                        btnBanSach.Enabled = true;
                        btnSach.Enabled = true;
                        btnNhapSach.Enabled = true;
                        btnDangXuat.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                sttTTNguoiDung.Text = "Chưa đăng nhập";
                statusStrip2.Text = "";
            }
        }
        public void DangXuat()
        {
            foreach(Form f in this.MdiChildren)
            {
                if(!f.IsDisposed)
                    f.Close();  
            }
            bDangNhap = false;
            HienThiMenu();
        }
        private void frm_TrangChu_Load(object sender, EventArgs e)
        {
            HienThiMenu();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangXuat();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fDN = new frm_DangNhap();
                var result = fDN.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string sTen = fDN.txtTk.Text;
                    string sMK = fDN.txtMK.Text;

                    NguoiDung = NguoiDung_BUS.LayNguoiDung(sTen, sMK);
                    if (NguoiDung != null)
                    {
                        bDangNhap = true;
                        MessageBox.Show("Đăng nhập thành công!");
                    }
                    else
                    {
                        bDangNhap = false;
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                    }
                }
                else
                {
                    MessageBox.Show("Người dùng đã hủy đăng nhập.");
                }
                HienThiMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message);
            }
        }
        public void MoFormSach()
        {
            frm_dmBooks frm_DmBooks = new frm_dmBooks();
            frm_DmBooks.ShowDialog();
        }

        private void toolStripMenuItemSach_Click(object sender, EventArgs e)
        {
            MoFormSach();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            MoFormSach();
        }
    }
}
