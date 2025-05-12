using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Books_DTO
    {
        private string sMaSach;
        private string sTenSach;
        
        private int sSachTK;
        private string sTenTacGia;
        private string sTenNXB;
        private string sTheLoai;
        private decimal dGiaTien;

        private string sMaTG;
        private string sMaNXB;
        private string sMaTheLoai;

        private int iDaXoa;

        public string SMaSach { get => sMaSach; set => sMaSach = value; }
        public string STenSach { get => sTenSach; set => sTenSach = value; }
        
        public int SSachTK { get => sSachTK; set => sSachTK = value; }
        public string STenTacGia { get => sTenTacGia; set => sTenTacGia = value; }
        public string STenNXB { get => sTenNXB; set => sTenNXB = value; }
        public string STheLoai { get => sTheLoai; set => sTheLoai = value; }

        public string SMaTG { get => sMaTG; set => sMaTG = value; }
        public string SMaNXB { get => sMaNXB; set => sMaNXB = value; }
        public string SMaTheLoai { get => sMaTheLoai; set => sMaTheLoai = value; }
       
        public decimal DGiaTien { get => dGiaTien; set => dGiaTien = value; }
        public int IDaXoa { get => iDaXoa; set => iDaXoa = value; }
    }
}
