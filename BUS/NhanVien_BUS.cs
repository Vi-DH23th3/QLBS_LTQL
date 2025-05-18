using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class NhanVien_BUS
    {
        public static List<NhanVien_DTO>LayDSNhanVien()
        {
            return NhanVien_DAO.LayDSNhanVien();
        }
        public static NhanVien_DTO TimTheoMaNV(int manv)
        {
            return NhanVien_DAO.TimTheoMaNV(manv);
        }
        public static List<NhanVien_DTO> TimNVTheoTen(string tennv)
        {
            return NhanVien_DAO.TimNVTheoTen(tennv);
        }
        public static bool ThemNhanVien(NhanVien_DTO nv)
        {
            try
            {
                if(NhanVien_DAO.ThemNhanVien(nv))
                {
                    return true;
                }    
                else
                {
                    return false;
                }    
            }
            catch (Exception ex)
            {
                throw new Exception("BUS - Thêm nhân viên: " + ex.Message);
            }
        }
        public static bool SuaNhanVien(NhanVien_DTO nv)
        {
            try
            {
                if (NhanVien_DAO.SuaNhanVien(nv))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BUS - Sua nhân viên: " + ex.Message);
            }
        }
        public static bool XoaNhanVien(int manv)
        {
            try
            {
                if (NhanVien_DAO.XoaNhanVien(manv))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BUS - Xóa nhân viên: " + ex.Message);
            }
        }
    }
}
