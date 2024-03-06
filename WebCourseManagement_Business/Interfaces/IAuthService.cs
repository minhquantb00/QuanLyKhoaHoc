using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.AuthRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseObject<DataResponseNguoiDung>> DangKy(Request_DangKy request);
        Task<ResponseObject<DataResponseToken>> DangNhap(Request_DangNhap request);
        Task<ResponseObject<DataResponseNguoiDung>> XacNhanDangKyTaiKhoan(Request_XacNhanDangKyTaiKhoan request);
        Task<string> XacNhanQuenMatKhau(Request_XacNhanQuenMatKhau request);
        Task<string> TaoMatKhauMoi(Request_TaoMatKhauMoi request);
        Task<string> DoiMatKhau(Request_DoiMatKhau request);
        Task<ResponseObject<DataResponseToken>> RenewAccessToken(Request_RenewToken request);
    }
}
