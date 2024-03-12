using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.RequestModels.NguoiDungRequests
{
    public class Request_CapNhatThongTinNguoiDung
    {
        public string? HoVaTen { get; set; }
        public string? Email { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? AnhDaiDien { get; set; }
        public string? SoDienThoai { get; set; }
        public DateTime? NgaySinh { get; set; }
        public Enums.GioiTinh GioiTinh { get; set; }
        public int? XaPhuongId { get; set; }
        public int? QuanHuyenId { get; set; }
        public int? TinhThanhId { get; set; }
    }
}
