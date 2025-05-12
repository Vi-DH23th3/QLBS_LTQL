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
    public class NhanVien_DAO
    {
        static SqlConnection conn;
        public static List<NhanVien_DTO> LayDSNhanVien()
        {

            try
            {
                string sql = @"select * from nhanvien where daxoa=0";
                conn = DataProvider.MoKetNoi();
                DataTable dt=DataProvider.TruyVanLayDuLieu(sql, conn);
                if (dt.Rows.Count == 0) 
                {
                    return null;
                }
                List<NhanVien_DTO> lst=new List<NhanVien_DTO> ();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NhanVien_DTO nv=new NhanVien_DTO();
                    nv.IMaNV = int.Parse(dt.Rows[i]["manv"].ToString());
                    nv.STenNV = dt.Rows[i]["tennv"].ToString();
                    nv.DtNgaySinh = DateTime.Parse(dt.Rows[i]["ngaysinh"].ToString());
                    nv.SGioiTinh = dt.Rows[i]["gioitinh"].ToString();
                    nv.SDiaChi = dt.Rows[i]["diachi"].ToString();
                    nv.SSDT = dt.Rows[i]["sodienthoai"].ToString();
                    nv.SEmail = dt.Rows[i]["email"].ToString();

                    lst.Add(nv);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Lấy danh sách nhân viên: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static List<NhanVien_DTO>TimTheoMaNV(int manv)
        {
            try
            {
                string sql = @"select * from nhanvien where manv=@manv";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd=new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manv",manv);

                DataTable dt = DataProvider.TruyVanLayDLCoCmd(cmd);
                if (dt.Rows.Count == 0) 
                {
                    return null;
                }
                List<NhanVien_DTO> lst = new List<NhanVien_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NhanVien_DTO nv = new NhanVien_DTO();
                    nv.IMaNV = int.Parse(dt.Rows[i]["manv"].ToString());
                    nv.STenNV = dt.Rows[i]["tennv"].ToString();
                    nv.DtNgaySinh = DateTime.Parse(dt.Rows[i]["ngaysinh"].ToString());
                    nv.SGioiTinh = dt.Rows[i]["gioitinh"].ToString();
                    nv.SDiaChi = dt.Rows[i]["diachi"].ToString();
                    nv.SSDT = dt.Rows[i]["sodienthoai"].ToString();
                    nv.SEmail = dt.Rows[i]["email"].ToString();

                    lst.Add(nv);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Tìm theo mã nhân viên: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static List<NhanVien_DTO>TimNVTheoTen(string tennv)
        {
            try
            {
                string sql = @"select * from nhanvien where tennv like @tennv";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tennv", "%" + tennv + "%");

                DataTable dt = DataProvider.TruyVanLayDLCoCmd(cmd);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                List<NhanVien_DTO> lst = new List<NhanVien_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NhanVien_DTO nv = new NhanVien_DTO();
                    nv.IMaNV = int.Parse(dt.Rows[i]["manv"].ToString());
                    nv.STenNV = dt.Rows[i]["tennv"].ToString();
                    nv.DtNgaySinh = DateTime.Parse(dt.Rows[i]["ngaysinh"].ToString());
                    nv.SGioiTinh = dt.Rows[i]["gioitinh"].ToString();
                    nv.SDiaChi = dt.Rows[i]["diachi"].ToString();
                    nv.SSDT = dt.Rows[i]["sodienthoai"].ToString();
                    nv.SEmail = dt.Rows[i]["email"].ToString();

                    lst.Add(nv);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Tìm theo mã nhân viên: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static bool ThemNhanVien(NhanVien_DTO nv)
        {
            try
            {
                string sql = @"insert into nhanvien(tennv, ngaysinh, gioitinh, diachi, sodienthoai, email) 
                                values(@tennv, @ngaysinh, @gioitinh, @diachi, @sodienthoai, @email)";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tennv",nv.STenNV);
                cmd.Parameters.AddWithValue("@ngaysinh",nv.DtNgaySinh);
                cmd.Parameters.AddWithValue("@gioitinh",nv.SGioiTinh);
                cmd.Parameters.AddWithValue("@diachi",nv.SDiaChi);
                cmd.Parameters.AddWithValue("@sodienthoai",nv.SSDT);
                cmd.Parameters.AddWithValue("@email",nv.SEmail);

                int kq=cmd.ExecuteNonQuery();

                return kq > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Thêm nhân viên: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static bool SuaNhanVien(NhanVien_DTO nv)
        {
            try
            {
                string sql = @"update nhanvien set tennv=@tennv, ngaysinh=@ngaysinh, gioitinh=@gioitinh, diachi=@diachi, sodienthoai=@sodienthoai, email=@email
                              where manv=@manv and daxoa=0";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manv",nv.IMaNV);
                cmd.Parameters.AddWithValue("@tennv", nv.STenNV);
                cmd.Parameters.AddWithValue("@ngaysinh", nv.DtNgaySinh);
                cmd.Parameters.AddWithValue("@gioitinh", nv.SGioiTinh);
                cmd.Parameters.AddWithValue("@diachi", nv.SDiaChi);
                cmd.Parameters.AddWithValue("@sodienthoai", nv.SSDT);
                cmd.Parameters.AddWithValue("@email", nv.SEmail);

                int kq = cmd.ExecuteNonQuery();

                return kq > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Sửa nhân viên: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static bool XoaNhanVien(int manv)
        {
            try
            {
                string sql = @"update nhanvien set daxoa=1 where manv=@manv";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manv", manv);


                int kq = cmd.ExecuteNonQuery();

                return kq > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Xóa nhân viên: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
    }
}
