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
    public class Books_DAO
    {
        static SqlConnection conn;
        public static List<Books_DTO> LayDSBook()
        {
            string sTruyVan = @"SELECT b.masach, b.tensach, tg.tentacgia, tl.tentheloai, n.tennxb, b.sachtk, b.giatien
                                FROM books b
                                JOIN tacgia tg ON b.matacgia = tg.matacgia
                                JOIN theloai tl ON b.matheloai = tl.matheloai
                                JOIN nxb n ON b.manxb = n.manxb
                                where b.daxoa=0";
            conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Books_DTO> lst = new List<Books_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Books_DTO b = new Books_DTO();
                b.SMaSach = dt.Rows[i]["masach"].ToString();
                b.STenSach = dt.Rows[i]["tensach"].ToString();
                b.STenTacGia = dt.Rows[i]["tentacgia"].ToString();
                b.STenNXB = dt.Rows[i]["tennxb"].ToString();
                b.STheLoai = dt.Rows[i]["tentheloai"].ToString();
                b.SSachTK = int.Parse(dt.Rows[i]["sachtk"].ToString());
                b.DGiaTien = decimal.Parse(dt.Rows[i]["giatien"].ToString());
                lst.Add(b);
            }
            DataProvider.DongKetNoi(conn);
            return lst;
        }
        public static List<Books_DTO> TimTheoTacGia(string tentg)
        {
            string sTruyVan = string.Format(@"SELECT b.masach, b.tensach, tg.tentacgia, tl.tentheloai, n.tennxb, b.sachtk, b.giatien
                                FROM books b
                                JOIN tacgia tg ON b.matacgia = tg.matacgia
                                JOIN theloai tl ON b.matheloai = tl.matheloai
                                JOIN nxb n ON b.manxb = n.manxb
                                where tg.tentacgia like N'%{0}%' and b.daxoa=0", tentg);
            conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Books_DTO> lst = new List<Books_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Books_DTO b = new Books_DTO();
                b.SMaSach = dt.Rows[i]["masach"].ToString();
                b.STenSach = dt.Rows[i]["tensach"].ToString();
                b.STenTacGia = dt.Rows[i]["tentacgia"].ToString();
                b.STenNXB = dt.Rows[i]["tennxb"].ToString();
                b.STheLoai = dt.Rows[i]["tentheloai"].ToString();
                b.SSachTK = int.Parse(dt.Rows[i]["sachtk"].ToString());
                b.DGiaTien = decimal.Parse(dt.Rows[i]["giatien"].ToString());
                lst.Add(b);
            }
            DataProvider.DongKetNoi(conn);
            return lst;
        }
        public static List<Books_DTO> TimTheoTheLoai(string tl)
        {
            string sTruyVan = string.Format(@"select b.masach, b.tensach, tg.tentacgia, tl.tentheloai,n.tennxb, b.sachtk, b.giatien
                                    from books b
                                    join tacgia tg on b.matacgia=tg.matacgia
                                    join theloai tl on b.matheloai=tl.matheloai
                                    join nxb n on b.manxb=n.manxb
                                    where tl.tentheloai like N'%{0}%' and b.daxoa=0",tl);
            conn = DataProvider.MoKetNoi();
            DataTable dt=DataProvider.TruyVanLayDuLieu(sTruyVan,conn);
            if(dt.Rows.Count == 0 ) 
            {
                return null;    
            }
            List<Books_DTO> lst = new List<Books_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Books_DTO b = new Books_DTO();
                b.SMaSach = dt.Rows[i]["masach"].ToString();
                b.STenSach = dt.Rows[i]["tensach"].ToString();
                b.STenTacGia = dt.Rows[i]["tentacgia"].ToString();
                b.STenNXB = dt.Rows[i]["tennxb"].ToString();
                b.STheLoai = dt.Rows[i]["tentheloai"].ToString();
                b.SSachTK = int.Parse(dt.Rows[i]["sachtk"].ToString());
                b.DGiaTien = decimal.Parse(dt.Rows[i]["giatien"].ToString());
                lst.Add(b);
            }
            DataProvider.DongKetNoi(conn);
            return lst;
        }
        public static List<Books_DTO> TimTheoTenSach(string tensach)
        {
            string sTruyVan = string.Format(@"select b.masach, b.tensach, tg.tentacgia, tl.tentheloai,n.tennxb, b.sachtk,b.giatien
                                    from books b
                                    join tacgia tg on b.matacgia=tg.matacgia
                                    join theloai tl on b.matheloai=tl.matheloai
                                    join nxb n on b.manxb=n.manxb
                                    where b.tensach like N'%{0}%' and b.daxoa=0", tensach);
            conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Books_DTO> lst = new List<Books_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Books_DTO b = new Books_DTO();
                b.SMaSach = dt.Rows[i]["masach"].ToString();
                b.STenSach = dt.Rows[i]["tensach"].ToString();
                b.STenTacGia = dt.Rows[i]["tentacgia"].ToString();
                b.STenNXB = dt.Rows[i]["tennxb"].ToString();
                b.STheLoai = dt.Rows[i]["tentheloai"].ToString();
                b.SSachTK = int.Parse(dt.Rows[i]["sachtk"].ToString());
                b.DGiaTien = decimal.Parse(dt.Rows[i]["giatien"].ToString());
                lst.Add(b);
            }
            DataProvider.DongKetNoi(conn);
            return lst;
        }
        public static Books_DTO TimTheoMaSach(string ms)
        {
            try
            {
                string sTruyVan = string.Format(@"select b.masach, b.tensach, tg.tentacgia, tl.tentheloai,n.tennxb, b.sachtk, b.giatien
                                    from books b
                                    join tacgia tg on b.matacgia=tg.matacgia
                                    join theloai tl on b.matheloai=tl.matheloai
                                    join nxb n on b.manxb=n.manxb
                                    where b.masach=N'{0}' and b.daxoa=0", ms);
                conn = DataProvider.MoKetNoi();
                DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0]; //một hàng dữ liệu từ DataTable
                Books_DTO b = new Books_DTO();
                    b.SMaSach = dr["masach"].ToString();
                    b.STenSach = dr["tensach"].ToString();
                    b.STenTacGia =dr["tentacgia"].ToString();
                    b.STenNXB = dr["tennxb"].ToString();
                    b.STheLoai = dr["tentheloai"].ToString();
                    b.SSachTK = int.Parse(dr["sachtk"].ToString());
                    b.DGiaTien = decimal.Parse(dr["giatien"].ToString());

                return b;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Tìm sách theo mã: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public string KiemTraSach(string tensach)
        {
            string sTruyVan = @"select masach from books where tensach=@tensach";
                      
            conn = DataProvider.MoKetNoi();
            SqlCommand cmd = new SqlCommand(sTruyVan, conn);
            cmd.Parameters.AddWithValue("@tensach", tensach); //truyền dữ liệu mã sách từ GUI,BUS vào csdl

            DataTable dt = DataProvider.TruyVanLayDLCoCmd(cmd);

            if (dt.Rows.Count == 0)
            {
                return null;
            }    
            string masach = dt.Rows[0]["masach"].ToString();
            DataProvider.DongKetNoi(conn);
            return masach; 
        }
        public bool ThemSach(Books_DTO sach)
        {
            try
            {
                string sql = @"insert into books( tensach, matacgia, matheloai, manxb, giatien, sachtk) 
                       values ( @tensach, @matacgia, @matheloai, @manxb, @giatien, @sachtk)";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@tensach", sach.STenSach);
                cmd.Parameters.AddWithValue("@matacgia", sach.SMaTG);
                cmd.Parameters.AddWithValue("@matheloai", sach.SMaTheLoai);
                cmd.Parameters.AddWithValue("@manxb", sach.SMaNXB);
                cmd.Parameters.AddWithValue("@giatien", sach.DGiaTien);
                cmd.Parameters.AddWithValue("@sachtk", sach.SSachTK);

                int kq = cmd.ExecuteNonQuery();
                return kq > 0;
            }
            catch (Exception ex)
            {
                
                throw new Exception("DAO - ThemSach: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }

        public bool ThemSoLuong(string masach, int soluong)
        {
            string sql = @"update books set sachtk = sachtk + @soluong where masach=@masach";
            conn= DataProvider.MoKetNoi();

            SqlCommand cmd=new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@masach", masach);
            cmd.Parameters.AddWithValue("@soluong", soluong);

            int kq = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
            DataProvider.DongKetNoi(conn);

            return kq > 0;
        }
        public bool SuaSach(Books_DTO sach)
        {
            try
            {
                string sql = @"update books set tensach=@tensach, matacgia=@matacgia, manxb=@manxb, matheloai=@matheloai, sachtk=@sachtk, giatien=@giatien
                                where masach=@masach AND daxoa = 0 ";
                conn = DataProvider.MoKetNoi();

                SqlCommand cmd= new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@masach", sach.SMaSach);
                cmd.Parameters.AddWithValue("@tensach",sach.STenSach);
                cmd.Parameters.AddWithValue("@matacgia", sach.SMaTG);
                cmd.Parameters.AddWithValue("@matheloai", sach.SMaTheLoai);
                cmd.Parameters.AddWithValue("@manxb", sach.SMaNXB);
                cmd.Parameters.AddWithValue("@giatien", sach.DGiaTien);
                cmd.Parameters.AddWithValue("@sachtk", sach.SSachTK);
                int kq = cmd.ExecuteNonQuery();
                return kq > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Sửa sách" + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        //Kiểm tra số lượng tồn kho trước khi thêm vào chi tiết hóa đơn
        public int LaySoLuong(string masach)
        {
            try
            {
                string sql = @"select sachtk from books where masach=@masach";
                conn = DataProvider.MoKetNoi();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@masach", masach);

                object soluong = cmd.ExecuteScalar(); //trả về object đối tượng đầu tiên, 1 ô duy nhất
                DataProvider.DongKetNoi(conn);

                if (soluong != null)
                    return Convert.ToInt32(soluong);
                else
                    return -1;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Lấy số lượng" + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }

        }
        public bool XoaSach(string masach)
        {
            try
            {
                string sql = @"update books set daxoa=1 where masach=@masach";
                conn = DataProvider.MoKetNoi();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@masach", masach);

                int kq = cmd.ExecuteNonQuery();
                return kq > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Xóa sách" + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
        public static bool CapNhatTonKho(int ms, int soluong)
        {
            try
            {
                string sql = @"update books set sachtk=sachtk-@soluong where masach=@masach";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd=new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@soluong", soluong);
                cmd.Parameters.AddWithValue("@masach", ms);
                int kq= cmd.ExecuteNonQuery();
                return kq > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("DAO - Cập nhật tồn kho" + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
    }
}
