﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.InputRequests
{
    public class InputKhoaHoc
    {
        public int? LoaiKhoaHocId { get; set; }
        public string? TenKhoaHoc { get; set; }
        public int? NguoiTaoId { get; set; }
        public decimal? GiaTu { get; set; }
        public decimal? GiaDen { get; set; }
    }
}