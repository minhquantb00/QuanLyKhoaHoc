
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.BaiHocRequests;
﻿using WebCourseManagement_Models.RequestModels.BaiHocRequets;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;
using WebCourseManagement_Models.Responses;
using Request_SuaThongTinBaiHoc = WebCourseManagement_Models.RequestModels.BaiHocRequets.Request_SuaThongTinBaiHoc;
using Request_ThemBaiHoc = WebCourseManagement_Models.RequestModels.BaiHocRequets.Request_ThemBaiHoc;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IBaiHocService
    {
        Task<ResponseObject<DataResponseBaiHoc>> ThemBaiHoc(Request_ThemBaiHoc request);
        Task<ResponseObject<DataResponseBaiHoc>> SuaThongTinBaiHoc(Request_SuaThongTinBaiHoc request);
        Task<string> XoaBaiHoc(int baiHocId);
    }
}
