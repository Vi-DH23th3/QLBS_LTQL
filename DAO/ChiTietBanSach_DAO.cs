using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace DAO
{
    public class ChiTietBanSach_DAO
    {
        static SqlConnection conn;
        public static List<ChiTietBanSach_DTO> LayChiTietBS(int madonhang)
        {
            try
            {
                string sql = @"select ctbs.madonhang, b.masach, b.tensach, ctbs.giaban, ctbs.soluong
                               from chitiet_bansach ctbs
                               join books b on b.masach=ctbs.masach
                               where ctbs.madonhang=@madonhang";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madonhang",madonhang);
                
                DataTable dt=DataProvider.TruyVanLayDLCoCmd(cmd);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                List<ChiTietBanSach_DTO> lst = new List<ChiTietBanSach_DTO>();
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    ChiTietBanSach_DTO ctbs=new ChiTietBanSach_DTO();
                    ctbs.IMaDonHang = int.Parse(dt.Rows[i]["madonhang"].ToString());
                    ctbs.IMaSach = int.Parse(dt.Rows[i]["masach"].ToString());
                    ctbs.STenSach = dt.Rows[i]["tensach"].ToString();
                    ctbs.DGiaBan = decimal.Parse(dt.Rows[i]["giaban"].ToString());
                    ctbs.ISoLuong = int.Parse(dt.Rows[i]["soluong"].ToString());

                    lst.Add(ctbs);
                }    
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Lấy chi tiết bán sách: "+ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static void ThemVaoBangCTBS(int madonhang, int masach, decimal giaban, int soluong)
        {
            try
            {
                string sql = "INSERT INTO chitiet_bansach (madonhang, masach, giaban, soluong) VALUES (@madonhang, @masach, @giaban, @soluong)";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madonhang", madonhang);
                cmd.Parameters.AddWithValue("@masach", masach);
                cmd.Parameters.AddWithValue("@giaban", giaban);
                cmd.Parameters.AddWithValue("@soluong", soluong);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Thêm vào bảng chi tiết bán sách: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        //sửa số lượng và cập nhật lại tổng tiền, form sửa đơn hàng
        public static bool SuaSoLuong(int madonhang, int soluongMoi, decimal giaban, int masach)
        {
            conn = DataProvider.MoKetNoi();
            SqlTransaction transaction = null;
            try
            {
                transaction = conn.BeginTransaction();

                // Cập nhật số lượng trong bảng chi tiết bán sách
                string suaSoLuong = "update chitiet_bansach set soluong = @soluong WHERE madonhang = @madonhang AND masach = @masach";
                SqlCommand cmdUpdate = new SqlCommand(suaSoLuong, conn, transaction);
                cmdUpdate.Parameters.AddWithValue("@soluong", soluongMoi);
                cmdUpdate.Parameters.AddWithValue("@madonhang", madonhang);
                cmdUpdate.Parameters.AddWithValue("@masach", masach);

                int kq = cmdUpdate.ExecuteNonQuery();
                if (kq == 0)
                {
                    throw new Exception("Không có bản ghi nào bị ảnh hưởng.");
                }

                // Tính lại tổng tiền của đơn hàng
                string tongTien = @"select sum(soluong * giaban) 
                        from chitiet_bansach 
                        where madonhang = @madonhang";
                SqlCommand cmdTongTien = new SqlCommand(tongTien, conn, transaction);
                cmdTongTien.Parameters.AddWithValue("@madonhang", madonhang);

                decimal tongTienMoi = (decimal)cmdTongTien.ExecuteScalar();

                // Cập nhật tổng tiền trong bảng quản lý bán hàng
                string capNhatTongTien = "update qlbanhang set tongtien = @tongtien WHERE madonhang = @madonhang";
                SqlCommand cmdUpdateTongTien = new SqlCommand(capNhatTongTien, conn, transaction);
                cmdUpdateTongTien.Parameters.AddWithValue("@tongtien", tongTienMoi);
                cmdUpdateTongTien.Parameters.AddWithValue("@madonhang", madonhang);
                cmdUpdateTongTien.ExecuteNonQuery();

                // Commit giao dịch
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw new Exception("DAO - sửa số lượng:" + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
       public static List<ChiTietBanSach_DTO> ThongKeSachBanChay()
        {
            try
            {
                string sql = @"select TOP 5 ctbs.masach, b.tensach, sum(ctbs.soluong) as SoLuongBan
                               from chitiet_bansach ctbs
                               join books b on b.masach=ctbs.masach
                               group by ctbs.masach, b.tensach
                               order by SoLuongBan DESC";
                conn = DataProvider.MoKetNoi();
                DataTable dt = DataProvider.TruyVanLayDuLieu(sql, conn);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                List<ChiTietBanSach_DTO> lst = new List<ChiTietBanSach_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChiTietBanSach_DTO ct = new ChiTietBanSach_DTO();
                    ct.IMaSach = int.Parse(dt.Rows[i]["masach"].ToString());
                    ct.STenSach = dt.Rows[i]["tensach"].ToString();
                    ct.ISoLuong = int.Parse(dt.Rows[i]["SoLuongBan"].ToString());
                    lst.Add(ct);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Lỗi thống kê sách bán chạy:" + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
    }
}
