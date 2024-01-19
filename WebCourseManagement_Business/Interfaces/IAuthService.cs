using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.RequestModels.AuthRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseObject<DataResponseNguoiDung>> DangKyTaiKhoan(Request_DangKy request);
        Task<ResponseObject<DataResponseToken>> DangNhap(Request_DangNhap request);
        Task<ResponseObject<DataResponseNguoiDung>> XacNhanDangKyTaiKhoan(Request_XacNhanDangKyTaiKhoan request);
        DataResponseToken GenerateAccessToken(NguoiDung nguoiDung);
        ResponseObject<DataResponseToken> RenewAccessToken(Request_RenewToken request);
    }
}
