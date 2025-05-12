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
    public class TheLoai_DAO
    {
        static SqlConnection conn;
        
        public static List<TheLoai_DTO> LayDSTheLoai()
        {
            string sTruyVan = @"select * from theloai";
            conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if(dt.Rows.Count ==0 )
            {
                return null;
            } 
            List<TheLoai_DTO> lstTheLoai=new List<TheLoai_DTO>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                TheLoai_DTO tl=new TheLoai_DTO();
                tl.SMaTheLoai = dt.Rows[i]["matheloai"].ToString();
                tl.STenTheLoai = dt.Rows[i]["tentheloai"].ToString();

                lstTheLoai.Add(tl);
            }    
            DataProvider.DongKetNoi(conn);
            return lstTheLoai;
        }
        public string TimMaTheoTenTheLoai(string tentl)
        {
            string sql = @"select matheloai from theloai where tentheloai=@tentl";
            conn= DataProvider.MoKetNoi();
            SqlCommand cmd=new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tentl", tentl.Trim());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count==0)
            {
                return null;
            }
            DataProvider.DongKetNoi(conn);
            string matl = dt.Rows[0]["matheloai"].ToString();
            return matl ;
        }
        public bool ThemTheLoai(TheLoai_DTO theloai)
        {
            try
            {
                string sql = @"insert into theloai( tentheloai) values( @tentheloai)";
                conn = DataProvider.MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@tentheloai", theloai.STenTheLoai.Trim());

                cmd.ExecuteNonQuery();
                
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception("DAO - ThemTheLoai: " + ex.Message);
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }
    }
}
