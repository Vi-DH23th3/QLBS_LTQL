using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class TacGia_DAO
    {
        static SqlConnection conn;
        public static List<TacGia_DTO> LayTG()
        {
            string sTruyVan = @"select * from tacgia";
            conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if(dt.Rows.Count == 0 )
            {
                return null;
            }    
            List<TacGia_DTO> lstTacGia= new List<TacGia_DTO>();
            for(int i=0; i<dt.Rows.Count; i++)
            {
                TacGia_DTO tg=new TacGia_DTO();
                tg.SMaTG = dt.Rows[i]["matacgia"].ToString();
                tg.STenTacGia = dt.Rows[i]["tentacgia"].ToString() ;

                lstTacGia.Add(tg);
            }    
            DataProvider.DongKetNoi(conn);
            return lstTacGia;
        }

        public bool ThemTacGia(TacGia_DTO tacgia)
        {
            try
            {
                string query = "INSERT INTO tacgia (tentacgia) VALUES (@tentacgia)";
                conn = DataProvider.MoKetNoi();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tentacgia", tacgia.STenTacGia.Trim());

                int rows = cmd.ExecuteNonQuery(); // Trả về số dòng thêm được
                return rows > 0;
            }
            catch (Exception ex)
            {
                // Ném lỗi để GUI hiển thị
                throw new Exception("DAO - ThemTacGia: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }

        public string TimMaTheoTenTG(string tentg)
        {
            string sql = "SELECT matacgia FROM tacgia WHERE tentacgia = @tentg";

            conn = DataProvider.MoKetNoi();

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@tentg", tentg.Trim());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataProvider.DongKetNoi(conn);

            if (dt.Rows.Count == 0)
                return null;
            string matg = dt.Rows[0]["matacgia"].ToString();
            return matg;
        }
    }
}
