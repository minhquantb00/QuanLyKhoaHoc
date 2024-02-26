using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.RequestModels.UserRequests
{
    public class Request_CapNhatThongTinNguoiDung
    {
        public int NguoiDungId { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public IFormFile? AnhDaiDien { get; set; }
        public DateTime NgaySinh { get; set; }
        public Enums.GioiTinh GioiTinh { get; set; }
        public int? XaPhuongId { get; set; }
        public int? QuanHuyenId { get; set; }
        public int? TinhThanhId { get; set; }
        public string? DiaChi { get; set; }
    }
}
