using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.Converters;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.RequestModels.AuthRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Implements
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseNguoiDung> _responseObject;
        private readonly ResponseObject<DataResponseToken> _responseTokenObject;
        private readonly NguoiDungConverter _converter;
        public AuthService(AppDbContext context, ResponseObject<DataResponseNguoiDung> responseObject, ResponseObject<DataResponseToken> responseTokenObject, NguoiDungConverter converter)
        {
            _context = context;
            _responseObject = responseObject;
            _responseTokenObject = responseTokenObject;
            _converter = converter;
        }

        public Task<ResponseObject<DataResponseNguoiDung>> DangKy(Request_DangKy request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataResponseToken>> DangNhap(Request_DangNhap request)
        {
            throw new NotImplementedException();
        }

        public Task<string> DoiMatKhau(Request_DoiMatKhau request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataResponseToken>> RenewAccessToken(Request_RenewToken request)
        {
            throw new NotImplementedException();
        }

        public Task<string> TaoMatKhauMoi(Request_TaoMatKhauMoi request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataResponseNguoiDung>> XacNhanDangKyTaiKhoan(Request_XacNhanDangKyTaiKhoan request)
        {
            throw new NotImplementedException();
        }

        public Task<string> XacNhanQuenMatKhau(Request_XacNhanQuenMatKhau request)
        {
            throw new NotImplementedException();
        }
    }
}
