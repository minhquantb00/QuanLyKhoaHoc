using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiViet;
using WebCourseManagement_Models.ResponseModels.DataNguoiDungThichBinhLuanBaiHoc;

namespace WebCourseManagement_Models.Converters
{
    public class NguoiDungThichBinhLuanBaiVietConverter
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungConverter _converter;
        public NguoiDungThichBinhLuanBaiVietConverter(AppDbContext context, NguoiDungConverter converter)
        {
            _context = context;
            _converter = converter;
        }
        public DataResponseNguoiDungThichBinhLuanBaiViet EntityToDTO(NguoiDungThichBinhLuanBaiViet nguoiDungThichBinhLuanBaiViet)
        {
            return new DataResponseNguoiDungThichBinhLuanBaiViet
            {
                Id = nguoiDungThichBinhLuanBaiViet.Id,
                NguoiDungThichBinhLuan = _converter.EntityToDTO(nguoiDungThichBinhLuanBaiViet.NguoiDungThichBinhLuan),
                ThoiGianThich = nguoiDungThichBinhLuanBaiViet.ThoiGianThich
            };
        }
    }
}
