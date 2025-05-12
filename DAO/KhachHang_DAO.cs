using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class KhachHang_DAO
    {
        static SqlConnection conn;
        public static List<KhachHang_DTO> LayDSKH()
        {
            try
            {
                string sql = @"select * from khachhang where daxoa=0";
                conn = DataProvider.MoKetNoi();
                DataTable dt=DataProvider.TruyVanLayDuLieu(sql, conn);
                if(dt.Rows.Count == 0 )
                {
                    return null;
                }   
                List<KhachHang_DTO> lst=new List<KhachHang_DTO> ();
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    KhachHang_DTO kh=new KhachHang_DTO();
                    kh.IMaKH = int.Parse(dt.Rows[i]["makh"].ToString());
                    kh.STenKH = dt.Rows[i]["tenkh"].ToString();
                    kh.SSDT = dt.Rows[i]["sodienthoai"].ToString();
                    kh.SDiaChi = dt.Rows[i]["diachi"].ToString();
                    kh.SEmail = dt.Rows[i]["email"].ToString();

                    lst.Add(kh);
                }    
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - lấy danh sách khách hang: "+ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static KhachHang_DTO TimKHTheoMa(int makh)
        {
            try
            {
                string sql = @"select * from khachhang where makh=@makh and daxoa=0";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd=new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@makh", makh);
                DataTable dt = DataProvider.TruyVanLayDLCoCmd(cmd);
                if (dt.Rows.Count == 0) 
                {
                    return null;
                }
                DataRow dr=dt.Rows[0];
                KhachHang_DTO kh=new KhachHang_DTO();
                kh.IMaKH = int.Parse(dr["makh"].ToString());
                kh.STenKH = dr["tenkh"].ToString();
                kh.SSDT = dr["sodienthoai"].ToString();
                kh.SDiaChi = dr["diachi"].ToString();
                kh.SEmail = dr["email"].ToString();

                return kh;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Tìm khách hàng theo mã: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static List<KhachHang_DTO>TimKHTheoTen(string tenkh)
        {
            try
            {
                string sql = @"select * from khachhang where daxoa=0 and tenkh like @tenkh";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tenkh", "%"+tenkh+"%");
                DataTable dt = DataProvider.TruyVanLayDLCoCmd(cmd);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                List<KhachHang_DTO> lst = new List<KhachHang_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    KhachHang_DTO kh = new KhachHang_DTO();
                    kh.IMaKH = int.Parse(dt.Rows[i]["makh"].ToString());
                    kh.STenKH = dt.Rows[i]["tenkh"].ToString();
                    kh.SSDT = dt.Rows[i]["sodienthoai"].ToString();
                    kh.SDiaChi = dt.Rows[i]["diachi"].ToString();
                    kh.SEmail = dt.Rows[i]["email"].ToString();

                    lst.Add(kh);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Tìm khách hàng theo tên: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static bool ThemKhachHang(KhachHang_DTO kh)
        {
            try
            {
                string sql = @"insert into khachhang(tenkh, sodienthoai, diachi,email) values(@tenkh, @sodienthoai, @diachi, @email)";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tenkh", kh.STenKH);
                cmd.Parameters.AddWithValue("@sodienthoai", kh.SSDT);
                cmd.Parameters.AddWithValue("@diachi", kh.SDiaChi);
                cmd.Parameters.AddWithValue("@email", kh.SEmail);

                int kq = cmd.ExecuteNonQuery();
                return kq > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Thêm khách hàng: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static bool SuaKhachHang(KhachHang_DTO kh)
        {
            try
            {
                string sql = @"update khachhang set tenkh=@tenkh, sodienthoai=@sodienthoai, diachi=@diachi, email=@email
                                where makh=@makh and daxoa=0";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@makh", kh.IMaKH);
                cmd.Parameters.AddWithValue("@tenkh", kh.STenKH);
                cmd.Parameters.AddWithValue("@sodienthoai", kh.SSDT);
                cmd.Parameters.AddWithValue("@diachi", kh.SDiaChi);
                cmd.Parameters.AddWithValue("@email", kh.SEmail);

                int kq = cmd.ExecuteNonQuery();
                return kq > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Sửa khách hàng: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static bool XoaKhachHang(int makh)
        {
            try
            {
                string sql = @"update khachhang set daxoa=1 where makh=@makh ";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@makh", makh);

                int kq = cmd.ExecuteNonQuery();
                return kq > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Xóa khách hàng: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
    }
}
