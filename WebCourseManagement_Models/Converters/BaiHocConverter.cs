using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;

namespace WebCourseManagement_Models.Converters
{
    public class BaiHocConverter
    {
        private readonly AppDbContext _context;
        private readonly DatCauHoiConverter _converter;
        private readonly ThucHanhConverter _thucHanhConverter;
        private readonly BinhLuanBaiHocConverter _binhLuanBaiHocConverter;
        public BaiHocConverter(AppDbContext context, DatCauHoiConverter converter, ThucHanhConverter thucHanhConverter, BinhLuanBaiHocConverter binhLuanBaiHocConverter)
        {
            _context = context;
            _converter = converter;
            _thucHanhConverter = thucHanhConverter;
            _binhLuanBaiHocConverter = binhLuanBaiHocConverter;
        }
        public DataResponseBaiHoc EntityToDTO(BaiHoc baiHoc)
        {
            return new DataResponseBaiHoc
            {
                Id = baiHoc.Id,
                MoTaBaiHoc = baiHoc.MoTaBaiHoc,
                TenBaiHoc = baiHoc.TenBaiHoc,
                ThoiGianCapNhat = baiHoc.ThoiGianCapNhat,
                ThoiGianTao = baiHoc.ThoiGianTao,
                ThoiLuongVideo = baiHoc.ThoiLuongVideo,
                VideoBaiHoc = baiHoc.VideoBaiHoc,
                BinhLuanBaiHocs = _context.binhLuanBaiHocs.Where(x => x.BaiHocId == baiHoc.Id).Select(x => _binhLuanBaiHocConverter.EntityToDTO(x)),
                DatCauHois = _context.datCauHois.Where(x => x.BaiHocId == baiHoc.Id).Select(x => _converter.EntityToDTO(x)),
                ThucHanhs = _context.thucHanhs.Where(x => x.BaiHocId == baiHoc.Id).Select(x => _thucHanhConverter.EntityToDTO(x))
            };
        }
    }
}
