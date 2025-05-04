using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class TheLoai_BUS
    {
        private TheLoai_DAO theLoai_DAO=new TheLoai_DAO();
        public static List<TheLoai_DTO>LayDSTheLoai()
        {
            return TheLoai_DAO.LayDSTheLoai();
        }
        public string TimTenTLTheoMaTL(string tentl)
        {
            return theLoai_DAO.TimMaTheoTenTheLoai(tentl);
        }
    }
}
