using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class Books_BUS
    {
        private Books_DAO books_DAO= new Books_DAO();
        private TacGia_DAO TacGia_DAO = new TacGia_DAO();
        private TacGia_DTO tg_dto= new TacGia_DTO();
        private TheLoai_DAO theLoai_DAO = new TheLoai_DAO();
        private TheLoai_DTO theLoai_DTO = new TheLoai_DTO();
        public static List<Books_DTO> LayDSBook()
        {
            return Books_DAO.LayDSBook();
        }
        public static List<Books_DTO>TimTheoTacGia(string tentg)
        {
            return Books_DAO.TimTheoTacGia(tentg);
        }
        public static List<Books_DTO>TimTheoTheLoai(string tl)
        {
            return Books_DAO.TimTheoTheLoai(tl);
        }
        public static List<Books_DTO>TimTheoTenSach(string nxb)
        {
            return Books_DAO.TimTheoTenSach(nxb);
        }
        public static Books_DTO TimTheoMaSach(string ms)
        {
            return Books_DAO.TimTheoMaSach(ms);
        }
        public int LaySoLuong(string masach)
        {
            return books_DAO.LaySoLuong(masach);
        }
        public bool KiemTravaThemSach(Books_DTO sach)
        {
            try
            {
                string masach = books_DAO.KiemTraSach(sach.STenSach);
                if (string.IsNullOrEmpty(masach))
                {
                    // Tìm mã tác giả theo tên
                    string matg = TacGia_DAO.TimMaTheoTenTG(sach.STenTacGia);

                    // Nếu mã tác giả chưa tồn tại 
                    if (string.IsNullOrEmpty(matg))
                    {
                        tg_dto.STenTacGia=sach.STenTacGia;
                        if (!TacGia_DAO.ThemTacGia(tg_dto))
                        {
                            return false; // Không thêm được tác giả mới
                        }
                        matg = TacGia_DAO.TimMaTheoTenTG(sach.STenTacGia); 
                    }
                    string matl = theLoai_DAO.TimMaTheoTenTheLoai(sach.STheLoai);
                    if (string.IsNullOrEmpty(matl))
                    {
                       
                        theLoai_DTO.STenTheLoai = sach.STheLoai;
                        if (!theLoai_DAO.ThemTheLoai(theLoai_DTO))
                        {
                            return false;
                        }
                        matl = theLoai_DAO.TimMaTheoTenTheLoai(sach.STheLoai);
                    }
                    sach.SMaTheLoai = matl;
                    sach.SMaTG = matg; //nếu mã đã tồn tại thì lấy mã đã tìm được từ tên tác giả: thêm vào bảng books
                    return books_DAO.ThemSach(sach);
                }
                else
                {
                    sach.SMaSach = masach;

                    books_DAO.ThemSoLuong(sach.SMaSach, sach.SSachTK);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BUS: " + ex.Message);
            } 
        }
        public bool SuaSach(Books_DTO sach)
        {
            try
            {
                string matg = TacGia_DAO.TimMaTheoTenTG(sach.STenTacGia);
                string matl = theLoai_DAO.TimMaTheoTenTheLoai(sach.STheLoai);
                sach.SMaTG = matg;
                sach.SMaTheLoai= matl;
                if (books_DAO.SuaSach(sach))
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
                throw new Exception("BUS - Sửa sách: " + ex.Message);
            }
        }
        public bool XoaSach(string ms)
        {
            return books_DAO.XoaSach(ms);
        }
        public static bool CapNhatTonKho(int ms, int soluong)
        {
            return Books_DAO.CapNhatTonKho(ms,soluong);
        }

    }
}
