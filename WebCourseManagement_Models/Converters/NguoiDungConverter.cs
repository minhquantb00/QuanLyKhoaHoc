
using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _context;
        public NguoiDungConverter(AppDbContext context)
        {
            _context = context;
        }
        public DataResponseNguoiDung EntityToDTO(NguoiDung nguoiDung)
        {
            var nguoiDungItem = _context.nguoiDungs.Include(x => x.DanhMucNguoiDung)
                                                   .Include(x => x.QuanHuyen)
                                                   .Include(x => x.QuyenHan)
                                                   .Include(x => x.TinhThanh)
                                                   .Include(x => x.TrangThaiNguoiDung)
                                                   .Include(x => x.XaPhuong)
                                                   .AsNoTracking()
                                                   .SingleOrDefault(x => x.Id == nguoiDung.Id);
            return new DataResponseNguoiDung
            {
                Id = nguoiDung.Id,
                DiaChi = nguoiDung.DiaChi,
                GioiTinh = nguoiDung.GioiTinh,
                HoVaTen = nguoiDung.HoVaTen,
                NgaySinh = nguoiDung.NgaySinh,
                SoDienThoai = nguoiDung.SoDienThoai,
                TenDanhMuc = nguoiDung.DanhMucNguoiDung?.TenDanhMuc ?? "",
                TenQuanHuyen = nguoiDung.QuanHuyen?.TenQuanHuyen ?? "",
                TenQuyenHan = nguoiDung.QuyenHan?.TenQuyenHan ?? "",
                TenTaiKhoan = nguoiDung.TenTaiKhoan,
                TenTinhThanh = nguoiDung.TinhThanh?.TenTinhThanh ?? "",
                TenTrangThai = nguoiDung.TrangThaiNguoiDung?.TenTrangThai ?? "",
                TenXaPhuong = nguoiDung.XaPhuong?.TenXaPhuong ?? "",
                AnhDaiDien = nguoiDung.AnhDaiDien
            };
        }
    }
}
