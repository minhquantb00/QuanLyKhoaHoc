using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.BinhLuanBaiHocRequests
{
    public class Request_TraLoiBinhLuan
    {
        public int BinhLuanGocId { get; set; }
        public int BaiHocId { get; set; }
        public string? BinhLuan { get; set; }
        public string? DuongDanAnhBinhLuan { get; set; }
    }
}
