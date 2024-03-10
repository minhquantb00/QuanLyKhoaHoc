using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.RequestModels.BaiHocRequests
{
    public class Request_ThemBaiHoc
    {
        public string TenBaiHoc { get; set; }
        public string MoTaBaiHoc { get; set; }
        public int ChuongHocId { get; set; }
        public string VideoBaiHoc { get; set; }
        public int ThoiLuongVideo { get; set; }
    }
}
