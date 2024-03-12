using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.RequestModels.AuthRequests
{
    public class Request_DangKy
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime? NgaySinh { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Enums.GioiTinh GioiTinh { get; set; }
    }
}
