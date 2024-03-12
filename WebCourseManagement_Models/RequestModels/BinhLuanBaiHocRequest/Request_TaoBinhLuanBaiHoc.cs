using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.RequestModels.BinhLuanBaiHocRequest
{
    public class Request_TaoBinhLuanBaiHoc
    {
        public int BaiHocId { get; set; }
        public string NoiDungBinhLuan { get; set; }
    }
}
