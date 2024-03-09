using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc;

namespace WebCourseManagement_Models.Converters
{
    public class BinhLuanBaiHocConverter
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungConverter _nguoiDungConverter;
        private readonly NguoiDungThichBinhLuanBaihocConverter _nguoiDungThichBinhLuanBaiHocConverter;
        public BinhLuanBaiHocConverter(AppDbContext context, NguoiDungConverter nguoiDungConverter, NguoiDungThichBinhLuanBaihocConverter nguoiDungThichBinhLuanBaiHocConverter)
        {
            _context = context;
            _nguoiDungConverter = nguoiDungConverter;
            _nguoiDungThichBinhLuanBaiHocConverter = nguoiDungThichBinhLuanBaiHocConverter;
        }
        public DataResponseBinhLuanBaiHoc EntityToDTO(BinhLuanBaiHoc binhLuanBaiHoc)
        {
            return new DataResponseBinhLuanBaiHoc
            {
                DuongDanAnhBinhLuan = binhLuanBaiHoc.DuongDanAnhBinhLuan,
                BinhLuanGocId = binhLuanBaiHoc.BinhLuanGocId,
                Id = binhLuanBaiHoc.Id,
                NguoiBinhLuan = _nguoiDungConverter.EntityToDTO(binhLuanBaiHoc.NguoiBinhLuan),
                SoLuotThich = binhLuanBaiHoc.SoLuotThich,
                SoLuotTraLoiBinhLuan = binhLuanBaiHoc.SoLuotTraLoiBinhLuan,
                ThoiGianTao = binhLuanBaiHoc.ThoiGianTao,
                ThoiGianCapNhat = binhLuanBaiHoc.ThoiGianCapNhat,
                ThoiGianXoa = binhLuanBaiHoc.ThoiGianXoa,
                NguoiDungThichBinhLuanBaiHocs = _context.nguoiDungThichBinhLuanBaiHocs.Where(x => x.BinhLuanBaiHocId == binhLuanBaiHoc.Id).Select(x => _nguoiDungThichBinhLuanBaiHocConverter.EntityToDTO(x))
            };
        }
    }
}
