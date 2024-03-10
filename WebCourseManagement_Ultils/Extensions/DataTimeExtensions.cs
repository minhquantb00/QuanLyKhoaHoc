﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Ultils.Extensions
{
    public static class DataTimeExtensions
    {
        public static long GetTimeStamp(this DateTime date)
        {
            return (long)(date.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds;
        }
    }
}
