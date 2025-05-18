using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frm_HoaDon : Form
    {
        private NguoiDung_DTO NguoiDung;
        
        decimal tongtien = 0;
        public frm_HoaDon()
        {
            InitializeComponent();
        }
        public void HienThiTenSachLenCombobox()
        {
            cmbTenSach.DataSource = Books_BUS.LayDSBook();
            cmbTenSach.DisplayMember = "STenSach";
            cmbTenSach.ValueMember = "SMaSach";
        }
        public void HienThiNVLenCombobox()
        {
            cmbTenNV.DataSource=NhanVien_BUS.LayDSNhanVien();
            cmbTenNV.DisplayMember = "STenNV";
            cmbTenNV.ValueMember = "IMaNV";
        }
        public void HienThiKHLenCombobox()
        {
            cmbTenKH.DataSource = KhachHang_BUS.LayDSKH();
            cmbTenKH.DisplayMember = "STenKH";
            cmbTenKH.ValueMember = "IMaKH";
        }
        private void KhoiTaoChiTietGrid()
        {
            dgChiTietHD.AutoGenerateColumns = false; //tạo cột thủ công, chỉ hiển thị những cột được định nghĩa

            // Mã sách 
            dgChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã sách",
                DataPropertyName = "masach",
                Name = "masach",
                Width = 80
            });

            // Tên sách
            dgChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên sách",
                DataPropertyName = "tensach",
                Name = "tensach",
                Width = 300
            });

            // Giá bán
            dgChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giá bán",
                DataPropertyName = "giaban",
                Name = "giaban",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // Số lượng
            dgChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số lượng",
                DataPropertyName = "soluong",
                Name = "soluong",
                Width = 150
            });

            // Thành tiền 
            dgChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thành tiền",
                DataPropertyName = "thanhtien",
                Name = "thanhtien",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
        }

        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            HienThiKHLenCombobox();
            HienThiNVLenCombobox();
            HienThiTenSachLenCombobox();
            KhoiTaoChiTietGrid();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frm_KhachHang frm_kh=new frm_KhachHang(NguoiDung);
            frm_kh.ShowDialog();

            HienThiKHLenCombobox();
            this.Show();
        }
        //Khi thay đổi tên sách thì sẽ hiện giá tiền tương ứng
        private void cmbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            Books_DTO b= cmbTenSach.SelectedItem as Books_DTO;
            if (b != null)
            {
                txtGiaBan.Text=b.DGiaTien.ToString();
            }
        }
        //Thoát
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnXoaChiTietHD_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi = MessageBox.Show("Bạn chắc chắn muốn xóa đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi != DialogResult.Yes)
                    return;
                foreach (DataGridViewRow row in dgChiTietHD.SelectedRows)
                {
                    decimal thanhtien = Convert.ToDecimal(row.Cells["thanhtien"].Value);
                    tongtien -= thanhtien;
                    
                        dgChiTietHD.Rows.Remove(row); 
                }
                txtTongTien.Text = tongtien.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa chi tiết hóa đơn: " + ex);
            }
        }
        public bool KiemTraRong()
        {
            if(cmbTenSach.SelectedItem == null &&
                cmbTenNV.SelectedItem == null &&
                cmbTenKH.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn đầy đủ thông tin", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Hãy nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }  
            return true;
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            try
            {
                Books_BUS books_BUS = new Books_BUS();
                string masach = cmbTenSach.SelectedValue.ToString();
                int soluong=int.Parse(txtSoLuong.Text);
                //Kiểm tra tồn kho
                int tonkho = books_BUS.LaySoLuong(masach);
                if (soluong > tonkho)
                {
                    MessageBox.Show("Số lượng sách trong kho không đủ", "Thông báo");
                    return;
                } 
                else
                {
                    decimal giaban = decimal.Parse(txtGiaBan.Text);
                    decimal thanhtien = soluong * giaban;


                    if (cmbTenSach.SelectedIndex != -1)
                    {
                        Books_DTO b = cmbTenSach.SelectedItem as Books_DTO;
                        if (b != null)
                        {
                            DataGridViewRow row = new DataGridViewRow();

                            row.Cells.Add(new DataGridViewTextBoxCell { Value = b.SMaSach });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = b.STenSach });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = b.DGiaTien });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = soluong });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = thanhtien });

                            dgChiTietHD.Rows.Add(row);

                            tongtien += thanhtien;
                        }
                    }
                    txtTongTien.Text = tongtien.ToString();
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm chi tiết hóa đơn: " + ex);
            }
        }

        private void btnSuaCTHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgChiTietHD.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng cần sửa.");
                    return;
                }

                // Lấy dòng đang được chọn
                DataGridViewRow selectedRow = dgChiTietHD.SelectedRows[0];

                // Lấy lại thông tin từ giao diện: truy vấn biến trong dto
                Books_DTO sach = cmbTenSach.SelectedItem as Books_DTO;
                if (sach == null)
                {
                    MessageBox.Show("Vui lòng chọn sách.");
                    return;
                }

                int soluong = int.Parse(txtSoLuong.Text);
                decimal giaban = decimal.Parse(txtGiaBan.Text);
                decimal thanhtien = soluong * giaban;

                selectedRow.Cells["masach"].Value = sach.SMaSach;
                selectedRow.Cells["tensach"].Value = sach.STenSach;
                selectedRow.Cells["giaban"].Value = giaban;
                selectedRow.Cells["soluong"].Value = soluong;
                selectedRow.Cells["thanhtien"].Value = thanhtien;

                // Tính lại tổng tiền
                decimal tongtien = 0;
                foreach (DataGridViewRow row in dgChiTietHD.Rows)
                {
                    if (row.Cells["thanhtien"].Value != null)
                        tongtien += Convert.ToDecimal(row.Cells["thanhtien"].Value);
                }

                txtTongTien.Text = tongtien.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa chi tiết hóa đơn: " + ex);
            }
        }

        private void dgChiTietHD_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgChiTietHD.SelectedRows[0];
            txtSoLuong.Text = r.Cells["soluong"].Value.ToString();
            txtGiaBan.Text = r.Cells["giaban"].Value.ToString();
            int masach= int.Parse(r.Cells["masach"].Value.ToString());
            foreach(Books_DTO book in cmbTenSach.Items)
            {
                if (book.SMaSach == masach.ToString())
                {
                    cmbTenSach.SelectedItem = book;
                    break;
                }
            }    
        }
        private void btnLuuHD_Click(object sender, EventArgs e)
        {

            try
            {

                int makh = (cmbTenKH.SelectedItem as KhachHang_DTO).IMaKH;
                int manv = (cmbTenNV.SelectedItem as NhanVien_DTO).IMaNV;
                DateTime ngayban = DateTime.Now;
                decimal tongtien = decimal.Parse(txtTongTien.Text);

                int madonhang = QlBanHang_BUS.ThemVaoBangQLBH(makh, manv, ngayban, tongtien);
                foreach(DataGridViewRow r in dgChiTietHD.Rows)
                {
                    if (r.IsNewRow) continue; //bỏ qua dòng rỗng
                    int masach = Convert.ToInt32(r.Cells["masach"].Value);
                    decimal giaban = Convert.ToDecimal(r.Cells["giaban"].Value);
                    int soluong = Convert.ToInt32(r.Cells["soluong"].Value);

                   
                    ChiTietBanSach_BUS.ThemVaoBangCTBS(madonhang, masach, giaban, soluong);
                    Books_BUS.CapNhatTonKho(masach,soluong);
                }

                MessageBox.Show("Hóa đơn đã lưu thành công. Chuẩn bị xuất...");
                frm_bcHoaDon frm = new frm_bcHoaDon(madonhang, makh, manv);  
                frm.ShowDialog();
                this.ResetText();
                dgChiTietHD.Rows.Clear();

                txtSoLuong.Text = "";
                txtTongTien.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu hóa đơn: " + ex.Message);
            }
        }
    }
}
