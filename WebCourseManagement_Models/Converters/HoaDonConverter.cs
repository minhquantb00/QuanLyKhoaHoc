using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataHoaDon;

namespace WebCourseManagement_Models.Converters
{
    public class HoaDonConverter
    {
        private readonly AppDbContext _context;
        private readonly KhoaHocConverter _khoaHocConverter;
        private readonly NguoiDungConverter _nguoiDungConverter;
        public HoaDonConverter(AppDbContext context, KhoaHocConverter khoaHocConverter, NguoiDungConverter nguoiDungConverter)
        {
            _context = context;
            _khoaHocConverter = khoaHocConverter;
            _nguoiDungConverter = nguoiDungConverter;
        }
        public DataResponseHoaDon EntityToDTO(HoaDonDangKy hoaDonDangKy)
        {
            return new DataResponseHoaDon
            {
                Id = hoaDonDangKy.Id,
                KhoaHoc = _khoaHocConverter.EntityToDTO(_context.khoaHocs.SingleOrDefault(x => x.Id == hoaDonDangKy.KhoaHocId)),
                MaGiaoDich = hoaDonDangKy.MaGiaoDich,
                NguoiDung = _nguoiDungConverter.EntityToDTO(_context.nguoiDungs.SingleOrDefault(x => x.Id == hoaDonDangKy.NguoiDungId)),
                TenTrangThai = _context.trangThaiHoaDons.SingleOrDefault(x => x.Id == hoaDonDangKy.TrangThaiHoaDonId).TenTrangThai,
                ThoiGianTao = hoaDonDangKy.ThoiGianTao,
                TongTien = hoaDonDangKy.TongTien
            };
        }
    }
}
