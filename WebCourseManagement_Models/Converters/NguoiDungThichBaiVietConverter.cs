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
    public class NguoiDungThichBaiVietConverter
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungConverter _converter;
        public NguoiDungThichBaiVietConverter(AppDbContext context, NguoiDungConverter converter)
        {
            _context = context;
            _converter = converter;
        }
        public DataResponseNguoiDungThichBaiViet EntityToDTO(NguoiDungThichBaiViet nguoiDungThichBaiViet)
        {
            return new DataResponseNguoiDungThichBaiViet
            {
                Id = nguoiDungThichBaiViet.Id,
                NguoiDung = _converter.EntityToDTO(_context.nguoiDungs.SingleOrDefault(x => x.Id == nguoiDungThichBaiViet.NguoiDungId)),
                ThoiGianThich = nguoiDungThichBaiViet.ThoiGianThich,
                DaThich = nguoiDungThichBaiViet.DaThich
            };
        }
    }
}
