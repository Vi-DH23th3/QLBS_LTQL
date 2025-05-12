using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QlBanHang_DTO
    {
        private int iMaDonHang;
        private int iMaKH;
        private string sTenKH;
        private int iMaNV;
        private string sTenNV;
        private DateTime dtNgayBan;
        private decimal dTongTien;
        private int iDaXoa;

        public int IMaDonHang { get => iMaDonHang; set => iMaDonHang = value; }
        public int IMaKH { get => iMaKH; set => iMaKH = value; }
        public string STenKH { get => sTenKH; set => sTenKH = value; }
        public int IMaNV { get => iMaNV; set => iMaNV = value; }
        public string STenNV { get => sTenNV; set => sTenNV = value; }
        public DateTime DtNgayBan { get => dtNgayBan; set => dtNgayBan = value; }
        public decimal DTongTien { get => dTongTien; set => dTongTien = value; }
        public int IDaXoa { get => iDaXoa; set => iDaXoa = value; }

    }
}
