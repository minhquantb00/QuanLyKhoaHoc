using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataBaiViet
{
    public class DataResponseNguoiDungThichBaiViet : DataResponseBase
    {
        public DataResponseNguoiDung? NguoiDung { get; set; }
        public DateTime ThoiGianThich { get; set; }
        public bool? DaThich { get; set; }
    }
}
