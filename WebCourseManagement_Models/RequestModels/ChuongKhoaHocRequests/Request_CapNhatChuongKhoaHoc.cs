using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.ChuongKhoaHocRequests
{
    public class Request_CapNhatChuongKhoaHoc
    {
        public int ChuongKhoaHocId { get; set; }
        public int KhoaHocId { get; set; }
        public string TenChuong { get; set; }
    }
}
