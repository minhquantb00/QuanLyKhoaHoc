using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
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
                TaiKhoan = nguoiDung.TaiKhoan,
                BietDanh = nguoiDung.BietDanh,
                ChungNhan = nguoiDung.ChungNhan,
                GioiThieuBanThan = nguoiDung.GioiThieuBanThan,
                LinkFacebook = nguoiDung.LinkFacebook,
                LinkInstagram = nguoiDung.LinkInstagram,
                LinkYoutube = nguoiDung.LinkYoutube,
                MoTaBanThan = nguoiDung.MoTaBanThan,
                IsActive = nguoiDung.IsActive == true ? "Đã Active" : "Không Active",
                DaKhoaChua = nguoiDung.DaKhoa == true ? "Đã khóa" : "Chưa khóa",
                SoLanViPham = nguoiDung.SoLanViPham,
                TenTrangThaiTaiKhoan = nguoiDung.TrangThaiNguoiDungId == 1 ? "Chưa kích hoạt" : "Đã kích hoạt"
            };
        }
    }
}
