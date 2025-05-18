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
        public static NguoiDung_DTO NguoiDung;
        frm_DangNhap fDN;

        private void HienThiMenu()
        {
            toolStripMenuItemSach.Visible = false;
            toolStripMenuItemQLBS.Visible = false;
            toolStripMenuItemHoaDon.Visible = false;
            toolStripMenuItemThongKe.Visible = false;
            toolStripMenuItem2.Visible = false;
            đăngXuấtToolStripMenuItem.Visible = false;
            btnBanSach.Visible = false;
            btnSach.Visible = false;
            btnHoaDon.Visible = false;
            btnKhachHang.Visible = false;
            btnNhanVien.Visible = false;
            btnDangXuat.Visible = false;
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
                        toolStripMenuItemSach.Visible = true;
                        toolStripMenuItemQLBS.Visible = true;
                        toolStripMenuItemHoaDon.Visible = true;
                        toolStripMenuItemThongKe.Visible = true;
                        toolStripMenuItem2.Visible = true;
                        đăngXuấtToolStripMenuItem.Visible = true;
                        btnBanSach.Visible = true;
                        btnSach.Visible = true;
                        btnHoaDon.Visible = true;
                        btnKhachHang.Visible = true;
                        btnNhanVien.Visible = true;
                        btnDangXuat.Visible = true;

                        break;
                    case 2:
                        toolStripMenuItemSach.Visible = true;
                        toolStripMenuItemQLBS.Visible = true;
                        toolStripMenuItemHoaDon.Visible = true;
                        toolStripMenuItemThongKe.Visible = true;
                        toolStripMenuItem2.Visible = true;
                        đăngXuấtToolStripMenuItem.Visible = true;
                        btnBanSach.Visible = true;
                        btnSach.Visible = true;
                        btnHoaDon.Visible = true;
                        btnKhachHang.Visible = true;
                        btnDangXuat.Visible = true;
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
            frm_dmBooks frm_DmBooks = new frm_dmBooks(NguoiDung);
            frm_DmBooks.ShowDialog();
        }
        public void MoFormQLBanSach()
        {
            frm_QLBanSach frm_QLBanSach = new frm_QLBanSach(NguoiDung);
            frm_QLBanSach.ShowDialog(); 
        }
        public void MoFormHD()
        {
            frm_HoaDon frm_HoaDon = new frm_HoaDon();
            frm_HoaDon.ShowDialog();
        }
        public void MoFormKhachHang()
        {
            frm_KhachHang frm_kh = new frm_KhachHang(NguoiDung);
            frm_kh.ShowDialog();
        }
        public void MoFormNhanVien()
        {
            frm_NhanVien frm_nv = new frm_NhanVien();
            frm_nv.ShowDialog();
        }
        private void toolStripMenuItemSach_Click(object sender, EventArgs e)
        {
            MoFormSach();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            MoFormSach();
        }

        private void btnBanSach_Click(object sender, EventArgs e)
        {
            MoFormQLBanSach();
        }

        private void toolStripMenuItemQLBS_Click(object sender, EventArgs e)
        {
            MoFormQLBanSach();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            MoFormHD();
        }

        private void toolStripMenuItemHoaDon_Click(object sender, EventArgs e)
        {
            MoFormHD();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            MoFormKhachHang();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            MoFormNhanVien();
        }

        private void toolStripMenuItemTKTheoNgay_Click(object sender, EventArgs e)
        {
            frm_BCDoanhThuTheoNgay frm_bc = new frm_BCDoanhThuTheoNgay();
            frm_bc.ShowDialog();
        }

        private void ToolStripMenuItemSBC_Click(object sender, EventArgs e)
        {
            frm_bcSachBanChay frm=new frm_bcSachBanChay();
            frm.ShowDialog();
        }
    }
}
