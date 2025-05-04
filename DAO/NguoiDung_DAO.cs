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
    public class NguoiDung_DAO
    {
        public static SqlConnection con;

        public static NguoiDung_DTO LayNguoiDung(string sten, string smatkhau)
        {
            string sTruyVan = string.Format(@"select * from TaiKhoan where taikhoan=N'{0}' and matkhau=N'{1}'", sten, smatkhau);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NguoiDung_DTO lstNhanVien = new NguoiDung_DTO();

            NguoiDung_DTO tk = new NguoiDung_DTO();
            tk.STaiKhoan = dt.Rows[0]["taikhoan"].ToString();
            tk.SMatKhau = dt.Rows[0]["matkhau"].ToString();
            tk.IQuyen = int.Parse(dt.Rows[0]["quyen"].ToString());

            DataProvider.DongKetNoi(con);
            return tk;
        }
    }
}
