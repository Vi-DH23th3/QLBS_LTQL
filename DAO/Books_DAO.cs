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
                                JOIN nxb n ON b.manxb = n.manxb";
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
                                where tg.tentacgia like N'%{0}%'", tentg);
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
                                    where tl.tentheloai like N'%{0}%'",tl);
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
                                    where b.tensach like N'%{0}%'", tensach);
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
        public static List<Books_DTO>TimTheoMaSach(string ms)
        {
            string sTruyVan = string.Format(@"select b.masach, b.tensach, tg.tentacgia, tl.tentheloai,n.tennxb, b.sachtk, b.giatien
                                    from books b
                                    join tacgia tg on b.matacgia=tg.matacgia
                                    join theloai tl on b.matheloai=tl.matheloai
                                    join nxb n on b.manxb=n.manxb
                                    where b.masach=N'{0}'", ms);
            conn = DataProvider.MoKetNoi();
            DataTable dt=DataProvider.TruyVanLayDuLieu(sTruyVan,conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Books_DTO> lst= new List<Books_DTO>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Books_DTO b= new Books_DTO();
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
        public bool KiemTraMaSach(string masach)
        {
            string sTruyVan = string.Format(@"select count(*) from books where masach=@masach");
                      
            conn = DataProvider.MoKetNoi();
            SqlCommand cmd = new SqlCommand(sTruyVan, conn);
            cmd.Parameters.AddWithValue("@masach", masach); //truyền dữ liệu mã sách từ GUI,BUS vào masach trong csdl

            int count = (int)cmd.ExecuteScalar();
            DataProvider.DongKetNoi(conn);
            return count > 0; //true có tồn tại mã sách trên, count=0:false
              
        }
        public bool ThemSach(Books_DTO sach)
        {
            string sql = string.Format(@"insert into books values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}', N'{6}')",
               sach.SMaSach, sach.STenSach, sach.SMaTG, sach.SMaTheLoai, sach.SMaNXB, sach.DGiaTien, sach.SSachTK);

            conn = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, conn);
            DataProvider.DongKetNoi(conn);
            return kq;
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
    }
}
