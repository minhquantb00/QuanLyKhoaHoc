using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.LoaiKhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataLoaiKhoaHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Interfaces
{
    public interface ILoaiKhoaHocService
    {
        Task<ResponseObject<DataResponseLoaiKhoaHoc>> ThemLoaiKhoaHoc(Request_ThemLoaiKhoaHoc request);
        Task<ResponseObject<DataResponseLoaiKhoaHoc>> CapNhatThongTinLoaiKhoaHoc(Request_SuaLoaiKhoaHoc request);
        Task<string> XoaLoaiKhoaHoc(int loaiKhoaHocId);
        Task<PageResult<DataResponseLoaiKhoaHoc>> GetAlls(int pageSize, int pageNumber);
    }
}
