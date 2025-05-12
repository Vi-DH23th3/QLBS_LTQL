using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietBanSach_DTO
    {
        private int iMaDonHang;
        private int iMaSach;
        private string sTenSach;
        private decimal dGiaBan;
        private int iSoLuong;

        public int IMaDonHang { get => iMaDonHang; set => iMaDonHang = value; }
        public int IMaSach { get => iMaSach; set => iMaSach = value; }
        public string STenSach { get => sTenSach; set => sTenSach = value; }
        public decimal DGiaBan { get => dGiaBan; set => dGiaBan = value; }
        public int ISoLuong { get => iSoLuong; set => iSoLuong = value; }
    }
}
