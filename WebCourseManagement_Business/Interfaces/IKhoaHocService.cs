using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.KhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataHoaDon;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IKhoaHocService
    {
        Task<ResponseObject<DataResponseKhoaHoc>> ThemKhoaHoc(int nguoiTaoId, Request_ThemKhoaHoc request);
        Task<ResponseObject<DataResponseKhoaHoc>> SuaThongTinKhoaHoc(int nguoiSuaId, Request_SuaThongTinKhoaHoc request);
        Task<string> XoaKhoaHoc(int khoaHocId);
        Task<ResponseObject<DataResponseKhoaHoc>> GetKhoaHocById(int khoaHocId);
        Task<PageResult<DataResponseKhoaHoc>> GetAlls(int pageSize, int pageNumber);
        Task<ResponseObject<DataResponseHoaDon>> DangKyKhoaHoc(int nguoiDungId, Request_DangKyKhoaHoc request);
        Task<IQueryable<DataResponseKhoaHoc>> GetAllsKhoahoc();
    }
}
