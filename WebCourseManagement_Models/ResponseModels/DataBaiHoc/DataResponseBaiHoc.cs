using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataDatCauHoi;
using WebCourseManagement_Models.ResponseModels.DataThucHanh;

namespace WebCourseManagement_Models.ResponseModels.DataBaiHoc
{
    public class DataResponseBaiHoc :DataResponseBase
    {
        public string TenBaiHoc { get; set; }
        public string MoTaBaiHoc { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public string VideoBaiHoc { get; set; }
        public int ThoiLuongVideo { get; set; }
        public  IQueryable<DataResponseDatCauHoi>? DatCauHois { get; set; }
        public  IQueryable<DataResponseBinhLuanBaiHoc> BinhLuanBaiHocs { get; set; }
        public  IQueryable<DataResponseThucHanh> ThucHanhs { get; set; }
    }
}
