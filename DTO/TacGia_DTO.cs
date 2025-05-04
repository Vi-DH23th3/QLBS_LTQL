using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TacGia_DTO
    {
        private string sMaTG;
        private string sTenTacGia;

        public string SMaTG { get => sMaTG; set => sMaTG = value; }
        public string STenTacGia { get => sTenTacGia; set => sTenTacGia = value; }
    }
}
