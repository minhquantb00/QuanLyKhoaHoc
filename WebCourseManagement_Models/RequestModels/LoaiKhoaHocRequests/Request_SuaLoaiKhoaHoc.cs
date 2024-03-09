using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.LoaiKhoaHocRequests
{
    public class Request_SuaLoaiKhoaHoc
    {
        public int LoaiKhoaHocId { get; set; }
        public string TenLoaiKhoaHoc {  get; set; }
    }
}
