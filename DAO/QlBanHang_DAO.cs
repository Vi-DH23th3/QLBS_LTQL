using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class QlBanHang_DAO
    {
        static SqlConnection conn;
        public static List<QlBanHang_DTO> LayDSQlBanHang()
        {
            try
            {
                string sql = @"select qlbh.madonhang, kh.tenkh, nv.tennv, qlbh.ngayban, qlbh.tongtien
                            from qlbanhang qlbh
                            join khachhang kh on kh.makh=qlbh.makh
                            join nhanvien nv on nv.manv=qlbh.manv
                            where qlbh.daxoa=0";
                conn = DataProvider.MoKetNoi();
                DataTable dt=DataProvider.TruyVanLayDuLieu(sql,conn);
                if(dt.Rows.Count==0)
                {
                    return null;
                }    
                List<QlBanHang_DTO> lst=new List<QlBanHang_DTO> ();
                for(int i = 0;i < dt.Rows.Count; i++)
                {
                    QlBanHang_DTO qlbh=new QlBanHang_DTO();
                    qlbh.IMaDonHang = int.Parse(dt.Rows[i]["madonhang"].ToString());
                    qlbh.STenKH = dt.Rows[i]["tenkh"].ToString();
                    qlbh.STenNV = dt.Rows[i]["tennv"].ToString();
                    qlbh.DtNgayBan = DateTime.Parse(dt.Rows[i]["ngayban"].ToString());
                    qlbh.DTongTien = decimal.Parse(dt.Rows[i]["tongtien"].ToString());

                    lst.Add(qlbh);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO- lấy danh sách quản lý bán hàng: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static List<QlBanHang_DTO> TimDonHangTheoNV(int manv)
        {
            try
            {
                string sql = @"select qlbh.madonhang, kh.tenkh, nv.tennv, qlbh.ngayban, qlbh.tongtien
                            from qlbanhang qlbh
                            join khachhang kh on kh.makh=qlbh.makh
                            join nhanvien nv on nv.manv=qlbh.manv
                            where qlbh.daxoa=0 and qlbh.manv=@manv";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manv", manv);
                DataTable dt = DataProvider.TruyVanLayDLCoCmd(cmd);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                List<QlBanHang_DTO> lst = new List<QlBanHang_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    QlBanHang_DTO qlbh = new QlBanHang_DTO();
                    qlbh.IMaDonHang = int.Parse(dt.Rows[i]["madonhang"].ToString());
                    qlbh.STenKH = dt.Rows[i]["tenkh"].ToString();
                    qlbh.STenNV = dt.Rows[i]["tennv"].ToString();
                    qlbh.DtNgayBan = DateTime.Parse(dt.Rows[i]["ngayban"].ToString());
                    qlbh.DTongTien = decimal.Parse(dt.Rows[i]["tongtien"].ToString());

                    lst.Add(qlbh);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO- Tìm danh sách quản lý bán hàng theo nhân viên: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static List<QlBanHang_DTO> TimDonHangTheoKH(int makh)
        {
            try
            {
                string sql = @"select qlbh.madonhang, kh.tenkh, nv.tennv, qlbh.ngayban, qlbh.tongtien
                            from qlbanhang qlbh
                            join khachhang kh on kh.makh=qlbh.makh
                            join nhanvien nv on nv.manv=qlbh.manv
                            where qlbh.daxoa=0 and qlbh.makh=@makh";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@makh", makh);
                DataTable dt = DataProvider.TruyVanLayDLCoCmd(cmd);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                List<QlBanHang_DTO> lst = new List<QlBanHang_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    QlBanHang_DTO qlbh = new QlBanHang_DTO();
                    qlbh.IMaDonHang = int.Parse(dt.Rows[i]["madonhang"].ToString());
                    qlbh.STenKH = dt.Rows[i]["tenkh"].ToString();
                    qlbh.STenNV = dt.Rows[i]["tennv"].ToString();
                    qlbh.DtNgayBan = DateTime.Parse(dt.Rows[i]["ngayban"].ToString());
                    qlbh.DTongTien = decimal.Parse(dt.Rows[i]["tongtien"].ToString());

                    lst.Add(qlbh);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO- Tìm danh sách quản lý bán hàng theo khách hàng: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static List<QlBanHang_DTO> TimDonHangTheoNgay(DateTime tungay, DateTime denngay)
        {
            try
            {
                string sql = @"select qlbh.madonhang, kh.tenkh, nv.tennv, qlbh.ngayban, qlbh.tongtien
                            from qlbanhang qlbh
                            join khachhang kh on kh.makh=qlbh.makh
                            join nhanvien nv on nv.manv=qlbh.manv
                            where qlbh.daxoa=0 and qlbh.ngayban between @tungay and @denngay";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd=new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tungay", tungay);
                cmd.Parameters.AddWithValue("@denngay", denngay);
                DataTable dt = DataProvider.TruyVanLayDLCoCmd(cmd);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                List<QlBanHang_DTO> lst = new List<QlBanHang_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    QlBanHang_DTO qlbh = new QlBanHang_DTO();
                    qlbh.IMaDonHang = int.Parse(dt.Rows[i]["madonhang"].ToString());
                    qlbh.STenKH = dt.Rows[i]["tenkh"].ToString();
                    qlbh.STenNV = dt.Rows[i]["tennv"].ToString();
                    qlbh.DtNgayBan = DateTime.Parse(dt.Rows[i]["ngayban"].ToString());
                    qlbh.DTongTien = decimal.Parse(dt.Rows[i]["tongtien"].ToString());

                    lst.Add(qlbh);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO- Tìm danh sách quản lý bán hàng theo ngày: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static int ThemVaoBangQLBH(int makh, int manv, DateTime ngayban, decimal tongtien)
        {
            try
            {
                string sql = @"insert into qlbanhang(makh,manv,ngayban,tongtien) 
                               OUTPUT INSERTED.madonhang
                               values(@makh,@manv,@ngayban,@tongtien)";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@makh", makh);
                cmd.Parameters.AddWithValue("@manv", manv);
                cmd.Parameters.AddWithValue("@ngayban", ngayban);
                cmd.Parameters.AddWithValue("@tongtien", tongtien);

                object madonhang = cmd.ExecuteScalar();
                if (madonhang != null)
                {
                    return Convert.ToInt32(madonhang); // Trả về mã đơn hàng
                }
                else
                {
                    throw new Exception("Không thể lấy mã đơn hàng từ câu lệnh INSERT.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Thêm vào bảng quản lý bán hàng: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
             
        }
        public static bool XoaDonHang(int madh)
        {
            try
            {
                conn=DataProvider.MoKetNoi();
                string sql = @"update qlbanhang set daxoa=1 where madonhang=@madh";
                SqlCommand cmd=new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madh", madh);

                int kq = cmd.ExecuteNonQuery();
                return kq > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Xóa quản lý bán hàng: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static List<QlBanHang_DTO>ThongKeTheoNgay()
        {
            try
            {
                string sql = @"select ngayban, sum(tongtien) as tongtien 
                                from qlbanhang 
                                where daxoa=0 
                                group by ngayban 
                                order by ngayban";
                conn =DataProvider.MoKetNoi();
                DataTable dt = DataProvider.TruyVanLayDuLieu(sql, conn);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                List<QlBanHang_DTO> lst=new List<QlBanHang_DTO> ();
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    QlBanHang_DTO qlbh=new QlBanHang_DTO();
                    qlbh.DtNgayBan= DateTime.Parse(dt.Rows[i]["ngayban"].ToString());
                    qlbh.DTongTien = decimal.Parse(dt.Rows[i]["tongtien"].ToString());
                lst.Add(qlbh);
                }
                return lst;    
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Thống kê doanh thu theo ngày: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
    }
}
