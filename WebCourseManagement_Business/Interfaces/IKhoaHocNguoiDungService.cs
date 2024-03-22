using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.KhoaHocNguoiDungRequests;
using WebCourseManagement_Models.ResponseModels.DataKhoaHocCuaNguoiDung;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IKhoaHocNguoiDungService
    {
        Task<ResponseObject<DataResponseKhoaHocCuaNguoiDung>> DanhGiaKhoaHoc(Request_DanhGiaKhoaHoc request);
    }
}
