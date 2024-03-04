using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.RequestModels.BinhLuanBaiHocRequests
{
    public class Request_SuaBinhLuanBaiHoc
    {
        public int BinhLuanId { get; set; }
        public string? BinhLuan { get; set; }
        public string? DuongDanAnhBinhLuan { get; set; }
    }
}
