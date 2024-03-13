using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.Converters;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.RequestModels.BaiVietRequests;
using WebCourseManagement_Models.ResponseModels.DataBaiViet;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Implements
{
    public class BaiVietService : IBaiVietService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseBaiViet> _responseObject;
        private readonly BaiVietConverter _baiVietConverter;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaiVietService(AppDbContext context, ResponseObject<DataResponseBaiViet> responseObject, BaiVietConverter baiVietConverter, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _responseObject = responseObject;
            _baiVietConverter = baiVietConverter;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<PageResult<DataResponseBaiViet>> GetAlls(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataResponseBaiViet>> GetBaiVietById(int baiVietId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataResponseBaiViet>> SuaBaiViet(int nguoiDungId, Request_SuaBaiViet request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataResponseBaiViet>> TaoBaiViet(int nguoiDungId, Request_TaoBaiViet request)
        {
            throw new NotImplementedException();
        }

        public Task<string> XoaBaiViet(int baiVietId)
        {
            throw new NotImplementedException();
        }
    }
}
