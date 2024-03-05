using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.BinhLuanBaiHocRequests;
using WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IBinhLuanBaiHocService
    {
        Task<ResponseObject<DataResponseBinhLuanBaiHoc>> ThemBinhLuanBaiHoc(int nguoiDungId, Request_ThemBinhLuanBaiHoc request);
        Task<ResponseObject<DataResponseBinhLuanBaiHoc>> SuaBinhLuanBaiHoc(int nguoiDungId, Request_SuaBinhLuanBaiHoc request);
        Task<string> XoaBinhLuanBaiHoc(int binhLuanId);
        Task<PageResult<DataResponseBinhLuanBaiHoc>> GetAllBinhLuanTraLoi(int binhLuanId, int pageSize, int pageNumber);
        Task<ResponseObject<DataResponseBinhLuanBaiHoc>> TraLoiBinhLuan(int nguoiDungId, Request_TraLoiBinhLuan request);
    }
}
