using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data.SqlClient;
namespace BUS
{
    public class QlBanHang_BUS
    {
        public static List<QlBanHang_DTO> LayDSQlBanHang()
        {
            return QlBanHang_DAO.LayDSQlBanHang();
        }
        public static List<QlBanHang_DTO> TimDonHangTheoNgay(DateTime tungay, DateTime denngay)
        {
            return QlBanHang_DAO.TimDonHangTheoNgay(tungay, denngay);
        }
        public static int ThemVaoBangQLBH(int makh, int manv, DateTime ngayban, decimal tongtien)
        {
            return QlBanHang_DAO.ThemVaoBangQLBH(makh, manv, ngayban, tongtien);
        }
        public static bool XoaDonHang(int madh)
        {
            return QlBanHang_DAO.XoaDonHang(madh);
        }
        public static List<QlBanHang_DTO> TimDonHangTheoKH(int makh)
        {
            return QlBanHang_DAO.TimDonHangTheoKH(makh);
        }
        public static List<QlBanHang_DTO> TimDonHangTheoNV(int manv)
        {
            return QlBanHang_DAO.TimDonHangTheoNV(manv);
        }
        public static List<QlBanHang_DTO> ThongKeTheoNgay()
        {
            return QlBanHang_DAO.ThongKeTheoNgay();
        }
    }
}
