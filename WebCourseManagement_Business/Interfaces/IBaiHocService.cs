using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.BaiHocRequests;
using WebCourseManagement_Models.RequestModels.InputRequests;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataNguoiDungHoanThanhBaiHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IBaiHocService
    {
        Task<ResponseObject<DataResponseBaiHoc>> ThemBaiHoc(Request_ThemBaiHoc request);
        Task<ResponseObject<DataResponseBaiHoc>> SuaThongTinBaiHoc(Request_CapNhatThongTinBaiHoc request);
        Task<string> XoaBaiHoc(int baiHocId);
        Task<ResponseObject<DataResponseBaiHoc>> GetBaiHocById(int baiHocId);
        Task<PageResult<DataResponseBaiHoc>> GetAlls(InputBaiHoc input, int pageSize, int pageNumber);
        Task<ResponseObject<DataResponseNguoiDungHoanThanhBaiHoc>> CapNhatTrangThaiBaiHocCuaNguoiDung(int nguoiDungHoanThanhBaiHocId);
    }
}
