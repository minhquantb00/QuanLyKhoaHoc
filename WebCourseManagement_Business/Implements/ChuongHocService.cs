using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.ChuongHocRequests;
using WebCourseManagement_Models.ResponseModels.DataChuongHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Implements
{
    public class ChuongHocService : IChuongHocService
    {
        public Task<PageResult<DataResponseChuongHoc>> GetAlls(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataResponseChuongHoc>> GetChuongHocById(int chuongHocId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataResponseChuongHoc>> SuaThongTinChuongHoc(Request_SuaThongTinChuongHoc request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataResponseChuongHoc>> ThemChuongHoc(Request_ThemChuongHoc request)
        {
            throw new NotImplementedException();
        }

        public Task<string> XoaChuongHoc(int chuongHocId)
        {
            throw new NotImplementedException();
        }
    }
}
