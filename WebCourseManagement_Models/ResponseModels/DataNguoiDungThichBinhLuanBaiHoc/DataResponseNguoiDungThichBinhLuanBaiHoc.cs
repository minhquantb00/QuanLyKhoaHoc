using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataNguoiDungThichBinhLuanBaiHoc
{
    public class DataResponseNguoiDungThichBinhLuanBaiHoc : DataResponseBase
    {
        public DataResponseNguoiDung NguoiDungThichBinhLuan { get; set; }
        public DateTime ThoiGianThich { get; set; }
        public DateTime? ThoiGianBoThich { get; set; }
    }
}
