using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.KhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IKhoaHocService
    {
        Task<ResponseObject<DataResponseKhoaHoc>> ThemKhoaHoc(int nguoiTaoId, Request_ThemKhoaHoc request);
        Task<ResponseObject<DataResponseKhoaHoc>> SuaThongTinKhoaHoc(int nguoiSuaId, Request_CapNhatThongTinKhoaHoc request);
        Task<string> XoaKhoaHoc(int khoaHocId);
        Task<DataResponseKhoaHoc> GetKhoaHocById(int khoaHocId);
    }
}
