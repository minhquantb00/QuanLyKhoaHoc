using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;

namespace WebCourseManagement_Models.Converters
{
    public class KhoaHocConverter
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungConverter _converter;
        private readonly ChuongHocConverter _chuongHocConverter;
        public KhoaHocConverter(AppDbContext context, NguoiDungConverter converter, ChuongHocConverter chuongHocConverter)
        {
            _context = context;
            _converter = converter;
            _chuongHocConverter = chuongHocConverter;
        }
        public DataResponseKhoaHoc EntityToDTO(KhoaHoc khoaHoc)
        {

            return new DataResponseKhoaHoc()
            {
                AnhKhoaHoc = khoaHoc.AnhKhoaHoc,
                GiaKhoaHoc = khoaHoc.GiaKhoaHoc,
                LinkVideoGioiThieu = khoaHoc.LinkVideoGioiThieu,
                MoTa = khoaHoc.MoTa,
                NgayCapNhat = khoaHoc.NgayCapNhat,
                NgayTao = khoaHoc.NgayTao,
                SoBaiHoc = khoaHoc.SoBaiHoc,
                SoChuong = khoaHoc.SoChuong,
                SoHocVienDaHoanThanh = khoaHoc.SoHocVienDaHoanThanh,
                SoNguoiDangKyKhoaHoc = khoaHoc.SoNguoiDangKyKhoaHoc,
                TenKhoaHoc = khoaHoc.TenKhoaHoc,
                TenLoaiKhoaHoc = _context.loaiBaiHocs.SingleOrDefault(x => x.Id == khoaHoc.LoaiKhoaHocId)?.TenLoai,
                TongThoiGianBaiHoc = khoaHoc.TongThoiGianBaiHoc,
                Id = khoaHoc.Id,
                DataResponseChuongHocs = _context.chuongKhoaHocs.Where(x => x.KhoaHocId == khoaHoc.Id).Select(x => _chuongHocConverter.EntityToDTO(x))
            };
        }

    }
}
