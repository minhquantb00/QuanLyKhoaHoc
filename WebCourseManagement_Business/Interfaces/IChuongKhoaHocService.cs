using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.ChuongKhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataChuongHoc;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IChuongKhoaHocService
    {
        Task<ResponseObject<DataResponseChuongHoc>> ThemChuongHoc(Request_ThemChuongKhoaHoc request);
    }
}
