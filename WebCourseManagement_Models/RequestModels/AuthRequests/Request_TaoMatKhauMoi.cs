using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.AuthRequests
{
    public class Request_TaoMatKhauMoi
    {
        public string MaXacNhan { get; set; }   
        public string MatKhauMoi { get; set; }
        public string XacNhanMatKhauMoi { get; set; }
    }
}
