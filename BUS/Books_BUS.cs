using System;
using System.Collections.Generic;
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
        public static List<Books_DTO>TimTheoMaSach(string ms)
        {
            return Books_DAO.TimTheoMaSach(ms);
        }
        public bool KiemTravaThemSach(Books_DTO sach)
        {
            try
            {
                if (!books_DAO.KiemTraMaSach(sach.SMaSach))
                {
                    // Tìm mã tác giả theo tên
                    string matg = TacGia_DAO.TimMaTheoTenTG(sach.STenTacGia);

                    // Nếu mã tác giả chưa tồn tại (tức là tên tác giả chưa có trong CSDL)
                    if (string.IsNullOrEmpty(matg))
                    {
                        tg_dto.SMaTG = sach.SMaTG; // Lấy từ txtMaTGMoi.Text: mã tác giả mới
                        tg_dto.STenTacGia = sach.STenTacGia;

                        if (!TacGia_DAO.ThemTacGia(tg_dto))
                        {
                            return false; // Không thêm được tác giả mới
                        }
                        matg = sach.SMaTG; // Gán lại mã vừa thêm thành công: Vì nếu thêm thành công thì lấy mã mới thêm vào bảng books
                    }
                    string matl = theLoai_DAO.TimMaTheoTenTheLoai(sach.STheLoai);
                    if (string.IsNullOrEmpty(matl))
                    {
                        theLoai_DTO.SMaTheLoai = sach.SMaTheLoai;
                        theLoai_DTO.STenTheLoai = sach.STheLoai;
                        if (!theLoai_DAO.ThemTheLoai(theLoai_DTO))
                        {
                            return false;
                        }
                        matl = sach.SMaTheLoai;
                    }
                    sach.SMaTheLoai = matl;
                    sach.SMaTG = matg; //nếu mã đã tồn tại thì lấy mã đã tìm được từ tên tác giả: thêm vào bảng books
                    return books_DAO.ThemSach(sach);
                }
                else
                {

                    books_DAO.ThemSoLuong(sach.SMaSach, sach.SSachTK);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
           
            
        }
    }
}
