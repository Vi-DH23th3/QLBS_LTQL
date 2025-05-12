using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang_DTO
    {

        private int iMaKH;
        private string sTenKH;
        private string sSDT;
        private string sDiaChi;
        private string sEmail;
        private int iDaXoa;

        public int IMaKH { get => iMaKH; set => iMaKH = value; }
        public string STenKH { get => sTenKH; set => sTenKH = value; }
        public string SSDT { get => sSDT; set => sSDT = value; }
        public string SDiaChi { get => sDiaChi; set => sDiaChi = value; }
        public string SEmail { get => sEmail; set => sEmail = value; }
        public int IDaXoa { get => iDaXoa; set => iDaXoa = value; }
    }
}
