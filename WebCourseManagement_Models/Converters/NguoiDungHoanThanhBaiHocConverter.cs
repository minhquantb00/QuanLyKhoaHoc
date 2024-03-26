using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataNguoiDungHoanThanhBaiHoc;

namespace WebCourseManagement_Models.Converters
{
    public class NguoiDungHoanThanhBaiHocConverter
    {
        private readonly NguoiDungConverter _converter;
        private readonly BaiHocConverter _baiHocConverter;
        private readonly AppDbContext _context;
        public NguoiDungHoanThanhBaiHocConverter(NguoiDungConverter converter, BaiHocConverter baiHocConverter, AppDbContext context)
        {
            _converter = converter;
            _baiHocConverter = baiHocConverter;
            _context = context;
        }
        public DataResponseNguoiDungHoanThanhBaiHoc EntityToDTO(NguoiDungHoanThanhBaiHoc nguoiDung)
        {
            return new DataResponseNguoiDungHoanThanhBaiHoc
            {
                BaiHoc = _baiHocConverter.EntityToDTO(_context.baiHocs.SingleOrDefault(x => x.Id == nguoiDung.BaiHocId)),
                DaHoanThanh = nguoiDung.DaHoanThanh == true ? "Đã hoàn thành bài học" : "Chưa hoàn thành bài học",
                Id = nguoiDung.Id,
                NguoiDung = _converter.EntityToDTO(_context.nguoiDungs.SingleOrDefault(x => x.Id == nguoiDung.NguoiDungId)),
                ThoiGianMoBaiHoc = nguoiDung.ThoiGianMoBaiHoc,
                ThoiGianHoanThanh = nguoiDung.ThoiGianHoanThanh
            };
        }
    }
}
