using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class KhachHang_BUS
    {
        public static List<KhachHang_DTO> LayDSKH()
        {
            return KhachHang_DAO.LayDSKH();
        }
        public static KhachHang_DTO TimKHTheoMa(int makh)
        {
            return KhachHang_DAO.TimKHTheoMa(makh);
        }
        public static List<KhachHang_DTO> TimKHTheoTen(string tenkh)
        {
            return KhachHang_DAO.TimKHTheoTen(tenkh);
        }
        public static bool ThemKhachHang(KhachHang_DTO kh)
        {
            return KhachHang_DAO.ThemKhachHang(kh);
        }
        public static bool SuaKhachHang(KhachHang_DTO kh)
        {
            return KhachHang_DAO.SuaKhachHang(kh);
        }
        public static bool XoaKhachHang(int makh)
        {
            return KhachHang_DAO.XoaKhachHang(makh);
        }
    }
}
