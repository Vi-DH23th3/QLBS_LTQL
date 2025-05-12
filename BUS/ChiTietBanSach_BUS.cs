using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ChiTietBanSach_BUS
    {
        public static List<ChiTietBanSach_DTO>LayChiTietBanSach(int madonhang)
        {
            return ChiTietBanSach_DAO.LayChiTietBS(madonhang);
        }
        public static void ThemVaoBangCTBS(int madonhang, int masach, decimal giaban, int soluong)
        {
            ChiTietBanSach_DAO.ThemVaoBangCTBS(madonhang, masach, giaban, soluong);
        }
        public static bool SuaSoLuong(int madonhang, int soluongMoi, decimal giaban, int masach)
        {
            return ChiTietBanSach_DAO.SuaSoLuong(madonhang, soluongMoi, giaban, masach);
        }
    }
}
