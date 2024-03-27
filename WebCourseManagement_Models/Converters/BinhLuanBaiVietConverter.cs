using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiViet;
using WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc;

namespace WebCourseManagement_Models.Converters
{
    public class BinhLuanBaiVietConverter
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungConverter _nguoiDungConverter;
        private readonly NguoiDungThichBinhLuanBaiVietConverter _converter;
        public BinhLuanBaiVietConverter(AppDbContext context, NguoiDungConverter nguoiDungConverter, NguoiDungThichBinhLuanBaiVietConverter converter)
        {
            _context = context;
            _nguoiDungConverter = nguoiDungConverter;
            _converter = converter;
        }
        public DataResponseBinhLuanBaiViet EntityToDTO(BinhLuanBaiViet binhLuanBaiViet)
        {
            return new DataResponseBinhLuanBaiViet
            {
                NoiDungBinhLuan = binhLuanBaiViet.NoiDungBinhLuan,
                Id = binhLuanBaiViet.Id,
                NguoiBinhLuan = _nguoiDungConverter.EntityToDTO(_context.nguoiDungs.SingleOrDefault(x => x.Id == binhLuanBaiViet.NguoiBinhLuanId)),
                SoLuotThich = binhLuanBaiViet.SoLuotThich,
                SoLuotTraLoiBinhLuan = binhLuanBaiViet.SoLuotTraLoiBinhLuan,
                ThoiGianTao = binhLuanBaiViet.ThoiGianTao,
                ThoiGianCapNhat = binhLuanBaiViet.ThoiGianCapNhat,
                NguoiDungThichBinhLuanBaiViets = _context.nguoiDungThichBinhLuanBaiViets.Where(x => x.BinhLuanBaiVietId == binhLuanBaiViet.Id).Select(x => _converter.EntityToDTO(x))
            };
        }
    }
}
