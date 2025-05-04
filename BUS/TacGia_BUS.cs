using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class TacGia_BUS
    {
        private TacGia_DAO dao=new TacGia_DAO();
        public static List<TacGia_DTO> LayDSTG()
        {
            return TacGia_DAO.LayTG();
        }
        public string TimMaTheoTenTG(string tentg)
        {
            return dao.TimMaTheoTenTG(tentg);
        }
    }
}
