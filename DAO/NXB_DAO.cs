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
    public class NXB_DAO
    {
        static SqlConnection conn;
        public static List<NXB_DTO> LayDSNXB()
        {
            string sTruyVan = @"select * from nxb";
            conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NXB_DTO> lstNXB = new List<NXB_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NXB_DTO nxb=new NXB_DTO();
                nxb.SMaNXB = dt.Rows[i]["manxb"].ToString();
                nxb.STenNXB = dt.Rows[i]["tennxb"].ToString();

                lstNXB.Add(nxb);
            }
            DataProvider.DongKetNoi(conn);
            return lstNXB;
        }
    }
}
