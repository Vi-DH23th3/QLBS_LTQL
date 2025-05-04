using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TheLoai_DTO
    {
        private string sMaTheLoai;
        private string sTenTheLoai;

        public string SMaTheLoai { get => sMaTheLoai; set => sMaTheLoai = value; }
        public string STenTheLoai { get => sTenTheLoai; set => sTenTheLoai = value; }
    }
}
