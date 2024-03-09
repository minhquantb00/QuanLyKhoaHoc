using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataCauTraLoi;

namespace WebCourseManagement_Models.ResponseModels.DataDatCauHoi
{
    public class DataResponseDatCauHoi : DataResponseBase
    {
        public string CauTraLoi { get; set; }
        public int SoCauTraLoi { get; set; }
        public IQueryable<DataResponseCauTraLoi> CauTraLois { get; set; }
    }
}
