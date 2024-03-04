
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.BaiHocRequets;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IBaiHocService
    {
        Task<ResponseObject<DataResponseBaiHoc>> ThemBaiHoc(Request_ThemBaiHoc request);
        Task<ResponseObject<DataResponseBaiHoc>> SuaThongTinBaiHoc(Request_SuaThongTinBaiHoc request);
        Task<string> XoaBaiHoc(int baiHocId);
    }
}
