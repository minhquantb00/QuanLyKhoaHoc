using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataCauTraLoi
{
    public class DataResponseCauTraLoi : DataResponseBase
    {
        public DataResponseNguoiDung NguoiTraLoi { get; set; }
        public string CauTraLoiChiTiet { get; set; }
        public DateTime ThoiGianTraLoi { get; set; }
    }
}
