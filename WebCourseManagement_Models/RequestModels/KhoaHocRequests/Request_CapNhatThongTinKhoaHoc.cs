﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.KhoaHocRequests
{
    public class Request_CapNhatThongTinKhoaHoc
    {
        public int KhoaHocId { get; set; }
        public string TenKhoaHoc { get; set; }
        public string MoTa { get; set; }
        public IFormFile AnhKhoaHoc { get; set; }
        public decimal GiaKhoaHoc { get; set; }
        public int LoaiKhoaHocId { get; set; }
        public string? LinkVideoGioiThieu { get; set; }
    }
}