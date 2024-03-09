using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.KhoaHocRequests
{
    public class Request_SuaThongTinKhoaHoc
    {
        public int KhoaHocId { get; set; }
        public string TieuDeKhoaHoc { get; set; }
        public string MoTaKhoaHoc { get; set; }
        public decimal GiaKhoaHoc { get; set; }
        public IFormFile AnhKhoaHoc { get; set; }
        public int LoaiKhoaHocId { get; set; }
    }
}
