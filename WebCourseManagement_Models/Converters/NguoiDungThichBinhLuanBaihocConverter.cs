using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataNguoiDungThichBinhLuanBaiHoc;

namespace WebCourseManagement_Models.Converters
{
    public class NguoiDungThichBinhLuanBaihocConverter
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungConverter _converter;
        public NguoiDungThichBinhLuanBaihocConverter(AppDbContext context, NguoiDungConverter converter)
        {
            _context = context;
            _converter = converter;
        }
        public DataResponseNguoiDungThichBinhLuanBaiHoc EntityToDTO(NguoiDungThichBinhLuanBaiHoc nguoiDungThichBinhLuanBaiHoc)
        {
            return new DataResponseNguoiDungThichBinhLuanBaiHoc
            {
                NguoiDungThichBinhLuan = _converter.EntityToDTO(nguoiDungThichBinhLuanBaiHoc.NguoiDungThichBinhLuan),
                ThoiGianThich = nguoiDungThichBinhLuanBaiHoc.ThoiGianThich,
                ThoiGianBoThich = nguoiDungThichBinhLuanBaiHoc.ThoiGianBoThich,
                Id = nguoiDungThichBinhLuanBaiHoc.Id
            };
        }
    }
}
