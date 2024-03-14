using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.RequestModels.BaiVietRequests
{
    public class Request_TaoBinhLuanBaiViet
    {
        public int BaiVietId { get; set; }
        public string NoiDungBinhLuan { get; set; }
    }
}
