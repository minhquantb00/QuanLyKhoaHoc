using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataChuongHoc;

namespace WebCourseManagement_Models.ResponseModels.DataBaiHoc
{
    public class DataResponseBaiHoc
    {
        public string TenBaiHoc { get; set; }
        public string MoTaBaiHoc { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public int ThoiLuongVideo { get; set; }
        public DataResponseChuongHoc DataResponseChuongHoc { get; set; }
    }
}
