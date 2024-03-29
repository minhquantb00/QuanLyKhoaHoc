﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.RequestModels.ChuongHocRequests
{
    public class Request_ThemChuongHoc
    {
        public string TenChuong { get; set; }
        public int KhoaHocId { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? AnhChuongHoc { get; set; }
    }
}
