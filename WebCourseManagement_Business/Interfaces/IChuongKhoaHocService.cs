using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.ChuongKhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataChuongHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IChuongKhoaHocService
    {
        Task<ResponseObject<DataResponseChuongHoc>> ThemChuongHoc(Request_ThemChuongKhoaHoc request);
        Task<ResponseObject<DataResponseChuongHoc>> SuaChuongHoc(Request_CapNhatChuongKhoaHoc request);
        Task<string> XoaChuongHoc(int chuongHocId); 
        Task<DataResponseChuongHoc> GetChuongHocById(int id);
        Task<PageResult<DataResponseChuongHoc>> GetChuongHocByKhoaHoc(int khoaHocId, int pageSize, int pageNumber);
    }
}
