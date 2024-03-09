using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;

namespace WebCourseManagement_Models.ResponseModels.DataChuongHoc
{
    public class DataResponseChuongHoc : DataResponseBase
    {
        public string TenChuong { get; set; }
        public int TongThoiGianHocTrongChuong { get; set; }
        public int SoBaiHocTrongChuong { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public IQueryable<DataResponseBaiHoc> BaiHocs { get; set; }
    }
}
