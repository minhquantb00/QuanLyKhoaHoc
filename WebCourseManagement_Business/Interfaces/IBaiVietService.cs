﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.BaiVietRequests;
using WebCourseManagement_Models.ResponseModels.DataBaiViet;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IBaiVietService
    {
        Task<ResponseObject<DataResponseBaiViet>> TaoBaiViet(int nguoiDungId, Request_TaoBaiViet request);
        Task<ResponseObject<DataResponseBaiViet>> SuaBaiViet(int nguoiDungId, Request_SuaBaiViet request);
        Task<string> XoaBaiViet(int baiVietId);
        Task<ResponseObject<DataResponseBaiViet>> GetBaiVietById(int baiVietId);
        Task<PageResult<DataResponseBaiViet>> GetAlls(int pageSize, int pageNumber);
    }
}