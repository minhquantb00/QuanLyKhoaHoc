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
        private readonly NguoiDungConverter _nguoiDungConverter;
        private readonly ChuongHocConverter _chuongHocConverter;
        public KhoaHocConverter(AppDbContext context, NguoiDungConverter nguoiDungConverter, ChuongHocConverter chuongHocConverter)
        {
            _context = context;
            _nguoiDungConverter = nguoiDungConverter;
            _chuongHocConverter = chuongHocConverter;
        }
        public DataResponseKhoaHoc EntityToDTO(KhoaHoc khoaHoc)
        {
            return new DataResponseKhoaHoc
            {
                AnhKhoaHoc = khoaHoc.AnhKhoaHoc,
                GiaKhoaHoc = khoaHoc.GiaKhoaHoc,
                Id = khoaHoc.Id,
                MoTaKhoaHoc = khoaHoc.MoTaKhoaHoc,
                NgayCapNhat = khoaHoc.NgayCapNhat,
                NgayTao = khoaHoc.NgayTao,
                NgayXoa = khoaHoc.NgayXoa,
                PhanTramGiamGia = khoaHoc.PhanTramGiamGia,
                NguoiTao = _nguoiDungConverter.EntityToDTO(_context.nguoiDungs.SingleOrDefault(x => x.Id == khoaHoc.NguoiTaoId)),
                SoHocVienDaHoanThanh = khoaHoc.SoHocVienDaHoanThanh,
                TieuDeKhoaHoc = khoaHoc.TieuDeKhoaHoc,
                TongThoiGianKhoaHoc = khoaHoc.TongThoiGianKhoaHoc,
                ChuongHocs = _context.chuongHocs.Where(x => x.KhoaHocId == khoaHoc.Id).Select(x => _chuongHocConverter.EntityToDTO(x)),
                GiaKhoaHocThucTe = khoaHoc.GiaKhoaHocThucTe
            };
        }
    }
}
