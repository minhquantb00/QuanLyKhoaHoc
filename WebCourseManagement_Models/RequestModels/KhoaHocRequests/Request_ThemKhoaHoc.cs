using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.RequestModels.KhoaHocRequests
{
    public class Request_ThemKhoaHoc
    {
        public string TieuDeKhoaHoc { get; set; }
        public string MoTaKhoaHoc { get; set; }
        public decimal GiaKhoaHoc { get; set; }
        public IFormFile AnhKhoaHoc { get; set; }
        public int LoaiKhoaHocId { get; set; }
    }
}
