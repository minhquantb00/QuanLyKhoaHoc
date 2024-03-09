using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataCauTraLoi;

namespace WebCourseManagement_Models.Converters
{
    public class CauTraLoiConverter
    {
        private readonly NguoiDungConverter _converter;
        public CauTraLoiConverter(NguoiDungConverter converter)
        {
            _converter = converter;
        }
        public DataResponseCauTraLoi EntityToDTO(CauTraLoi cauTraLoi)
        {
            return new DataResponseCauTraLoi
            {
                CauTraLoiChiTiet = cauTraLoi.CauTraLoiChiTiet,
                Id = cauTraLoi.Id,
                NguoiTraLoi = _converter.EntityToDTO(cauTraLoi.NguoiTraLoi),
                ThoiGianTraLoi = cauTraLoi.ThoiGianTraLoi
            };
        }
    }
}
