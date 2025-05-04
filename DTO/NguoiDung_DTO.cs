using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDung_DTO
    {
        private string sTaiKhoan;
        private string sMatKhau;
        private int iQuyen;

        public string STaiKhoan { get => sTaiKhoan; set => sTaiKhoan = value; }
        public string SMatKhau { get => sMatKhau; set => sMatKhau = value; }
        public int IQuyen { get => iQuyen; set => iQuyen = value; }
    }
}
