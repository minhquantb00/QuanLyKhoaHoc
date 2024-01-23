﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebCourseManagement_Commons.Enumerates
{
    public class Enums
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum GioiTinh
        {
            Nam,
            Nu
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum LoaiComment
        {
            BaiViet,
            BaiHoc
        }
    }
}