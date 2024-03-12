using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.BinhLuanBaiHocRequest
{
    public class Request_TraLoiBinhLuan
    {
        public int BaiHocId { get; set; }
        public string NoiDungBinhLuan { get; set; }
        public int BinhLuanGocId { get; set; }
    }
}
