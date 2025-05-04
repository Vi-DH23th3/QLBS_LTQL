using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class NXB_BUS
    {
        public static List<NXB_DTO> LayDSNXB()
        {
            return NXB_DAO.LayDSNXB();
        }
    }
}
