using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        private int iMaNV;
        private string sTenNV;
        private DateTime dtNgaySinh;
        private string sGioiTinh;
        private string sDiaChi;
        private string sSDT;
        private string sEmail;
        private int iDaXoa;

        public int IMaNV { get => iMaNV; set => iMaNV = value; }
        public string STenNV { get => sTenNV; set => sTenNV = value; }
        public DateTime DtNgaySinh { get => dtNgaySinh; set => dtNgaySinh = value; }
        public string SGioiTinh { get => sGioiTinh; set => sGioiTinh = value; }
        public string SDiaChi { get => sDiaChi; set => sDiaChi = value; }
        public string SSDT { get => sSDT; set => sSDT = value; }
        public string SEmail { get => sEmail; set => sEmail = value; }
        public int IDaXoa { get => iDaXoa; set => iDaXoa = value; }

    }
}
