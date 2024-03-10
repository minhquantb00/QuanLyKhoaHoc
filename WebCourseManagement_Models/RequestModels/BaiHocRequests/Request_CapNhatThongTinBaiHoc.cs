using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.BaiHocRequests
{
    public class Request_CapNhatThongTinBaiHoc
    {
        public int BaiHocId { get; set; }
        public string TenBaiHoc { get; set; }
        public string MoTaBaiHoc { get; set; }
        public int ChuongHocId { get; set; }
        public string VideoBaiHoc { get; set; }
        public int ThoiLuongVideo { get; set; }
    }
}
