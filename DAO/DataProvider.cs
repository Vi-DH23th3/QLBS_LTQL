using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class DataProvider
    {
        public static SqlConnection MoKetNoi()
        {
            string s = @"Data Source=DESKTOP-EL1NO5U\SQLSERVER1;Initial Catalog=Quanlybansach;Integrated Security=True;Encrypt=False";
            SqlConnection ketnoi = new SqlConnection(s);
            ketnoi.Open();
            return ketnoi;
        }
        public static void DongKetNoi(SqlConnection ketnoi)
        {
            ketnoi.Close();
        }
        public static DataTable TruyVanLayDuLieu(string s, SqlConnection ketnoi)
        {
            SqlDataAdapter da = new SqlDataAdapter(s, ketnoi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static bool TruyVanKhongLayDuLieu(string s, SqlConnection ketnoi)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(s, ketnoi);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
