using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.ChuongHocRequests;
using WebCourseManagement_Models.ResponseModels.DataChuongHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IChuongHocService
    {
        Task<ResponseObject<DataResponseChuongHoc>> ThemChuongHoc(Request_ThemChuongHoc request);
        Task<ResponseObject<DataResponseChuongHoc>> SuaThongTinChuongHoc(Request_SuaThongTinChuongHoc request);
        Task<string> XoaChuongHoc(int chuongHocId);
        Task<PageResult<DataResponseChuongHoc>> GetAlls(int pageSize, int pageNumber);
        Task<ResponseObject<DataResponseChuongHoc>> GetChuongHocById(int chuongHocId);
    }
}
