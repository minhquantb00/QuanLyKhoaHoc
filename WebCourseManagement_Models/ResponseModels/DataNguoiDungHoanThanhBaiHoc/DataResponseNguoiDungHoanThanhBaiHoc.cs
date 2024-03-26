using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataNguoiDungHoanThanhBaiHoc
{
    public class DataResponseNguoiDungHoanThanhBaiHoc : DataResponseBase
    {
        public DataResponseNguoiDung NguoiDung { get; set; }
        public DataResponseBaiHoc BaiHoc { get; set; }
        public DateTime ThoiGianMoBaiHoc { get; set; }
        public string DaHoanThanh { get; set; }
        public DateTime? ThoiGianHoanThanh { get; set; }
    }
}
