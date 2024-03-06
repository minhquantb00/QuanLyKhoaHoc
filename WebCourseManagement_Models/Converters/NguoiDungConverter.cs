using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.Converters
{
    public class NguoiDungConverter
    {
        public DataResponseNguoiDung EntityToDTO(NguoiDung nguoiDung)
        {
            return new DataResponseNguoiDung
            {
                AnhDaiDien = nguoiDung.AnhDaiDien,
                DiaChi = nguoiDung.DiaChi,
                Email = nguoiDung.Email,
                GioiTinh = nguoiDung.GioiTinh.ToString(),
                HoVaTen = nguoiDung.HoVaTen,
                Id = nguoiDung.Id,
                NgaySinh = nguoiDung.NgaySinh,
                SoDienThoai = nguoiDung.SoDienThoai,
                TaiKhoan = nguoiDung.TaiKhoan
            };
        }
    }
}
