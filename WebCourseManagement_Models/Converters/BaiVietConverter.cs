using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiViet;

namespace WebCourseManagement_Models.Converters
{
    public class BaiVietConverter
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungThichBaiVietConverter _converter;
        private readonly BinhLuanBaiVietConverter _binhLuanBaiVietConverter;
        private readonly NguoiDungConverter _nguoiDungConverter;
        public BaiVietConverter(AppDbContext context, NguoiDungThichBaiVietConverter converter, BinhLuanBaiVietConverter binhLuanBaiVietConverter, NguoiDungConverter nguoiDungConverter)
        {
            _context = context;
            _converter = converter;
            _binhLuanBaiVietConverter = binhLuanBaiVietConverter;
            _nguoiDungConverter = nguoiDungConverter;
        }
        public DataResponseBaiViet EntityToDTO(BaiViet baiViet)
        {
            return new DataResponseBaiViet
            {
                AnhBaiViet = baiViet.AnhBaiViet,
                BinhLuanBaiViets = _context.binhLuanBaiViets.Where(x => x.BaiVietId == baiViet.Id).Select(x => _binhLuanBaiVietConverter.EntityToDTO(x)),
                Id = baiViet.Id,
                MoTa = baiViet.MoTa,
                NguoiDungThichBaiViets = _context.nguoiDungThichBaiViets.Where(x => x.BaiVietId == baiViet.Id).Select(x => _converter.EntityToDTO(x)),
                NguoiTaoBaiViet = _nguoiDungConverter.EntityToDTO(baiViet.NguoiTaoBaiViet),
                SoLuotBinhLuan = baiViet.SoLuotBinhLuan,
                SoLuotThich = baiViet.SoLuotThich,
                ThoiGianCapNhat = baiViet.ThoiGianCapNhat,
                ThoiGianTao = baiViet.ThoiGianTao,
                ThoiGianXoa = baiViet.ThoiGianXoa,
                TieuDe = baiViet.TieuDe
            };
        }
    }
}
