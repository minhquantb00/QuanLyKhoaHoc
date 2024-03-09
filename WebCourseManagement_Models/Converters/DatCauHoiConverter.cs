using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataDatCauHoi;

namespace WebCourseManagement_Models.Converters
{
    public class DatCauHoiConverter
    {
        private readonly AppDbContext _context;
        private readonly CauTraLoiConverter _converter;
        private readonly NguoiDungConverter _nguoiDungConverter;
        public DatCauHoiConverter(AppDbContext context, CauTraLoiConverter converter, NguoiDungConverter nguoiDungConverter)
        {
            _context = context;
            _converter = converter;
            _nguoiDungConverter = nguoiDungConverter;
        }
        public DataResponseDatCauHoi EntityToDTO(DatCauHoi datCauHoi)
        {
            return new DataResponseDatCauHoi
            {
                CauTraLoi = datCauHoi.CauTraLoi,
                Id = datCauHoi.Id,
                SoCauTraLoi = datCauHoi.SoCauTraLoi,
                CauTraLois = _context.cauTraLois.Where(x => x.CauHoiId == datCauHoi.Id).Select(x => _converter.EntityToDTO(x))
            };
        }
    }
}
