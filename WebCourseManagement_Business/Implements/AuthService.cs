using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Commons.DefaultConstants;
using WebCourseManagement_Models.Converters;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.RequestModels.AuthRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories;
using BcryptNet = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;

namespace WebCourseManagement_Business.Implements
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseNguoiDung> _responseObject;
        private readonly ResponseObject<DataResponseToken> _responseTokenObject;
        private readonly NguoiDungConverter _converter;
        private readonly IConfiguration _configuration;
        public AuthService(AppDbContext context, 
                           ResponseObject<DataResponseNguoiDung> responseObject, 
                           ResponseObject<DataResponseToken> responseTokenObject, 
                           NguoiDungConverter converter,
                           IConfiguration configuration)
        {
            _context = context;
            _responseObject = responseObject;
            _responseTokenObject = responseTokenObject;
            _converter = converter;
            _configuration = configuration;
        }
        #region Đăng ký và xác thực đăng ký tài khoản
        public async Task<ResponseObject<DataResponseNguoiDung>> DangKyTaiKhoan(Request_DangKy request)
        {
            if(string.IsNullOrEmpty(request.HoVaTen)
               ||string.IsNullOrEmpty(request.TenTaiKhoan)
               || string.IsNullOrEmpty(request.SoDienThoai)
               || string.IsNullOrEmpty(request.MatKhau)
               || string.IsNullOrEmpty(request.Email))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, Constants.ExceptionMessage.REQUEST_TO_FILL_INFORMATION, null);
            }
            if (!Utilities.IsValidEmail(request.Email))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, Constants.ExceptionMessage.INVALID_EMAIL, null);
            }
            if (!Utilities.IsValidPhoneNumber(request.SoDienThoai))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, Constants.ExceptionMessage.INVALID_PHONE_NUMBER, null);
            }
            if (!Utilities.PasswordValid(request.MatKhau))

            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, Constants.ExceptionMessage.INVALID_PASSWORD, null);
            }
            if(_context.nguoiDungs.Any(x => x.TenTaiKhoan.Equals(request.TenTaiKhoan)))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, Constants.ExceptionMessage.ALREADY_ACCOUNT_NAME_EXISTED, null);
            }
            if (_context.nguoiDungs.Any(x => x.Email.Equals(request.Email)))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, Constants.ExceptionMessage.ALREADY_EMAIL_EXISTED, null);
            }
            try
            {
                NguoiDung nguoiDung = new NguoiDung
                {
                    AnhDaiDien = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZ2IRUIqIOAKar3LaLJely1iMXS4HFfouBrg&usqp=CAU",
                    DaKhoa = false,
                    Email = request.Email,
                    GioiTinh = request.GioiTinh,
                    HoVaTen = request.HoVaTen,
                    MatKhau = BcryptNet.HashPassword(request.MatKhau),
                    NgaySinh = request.NgaySinh,
                    QuyenHanId = 3,
                    SoDienThoai = request.SoDienThoai,
                    TenTaiKhoan = request.TenTaiKhoan,
                    ThoiGianTao = DateTime.Now,
                    TrangThaiNguoiDungId = 1
                };
                await _context.nguoiDungs.AddAsync(nguoiDung);
                await _context.SaveChangesAsync();
                XacNhanEmail xacNhanEmail = new XacNhanEmail
                {
                    DaXacNhan = false,
                    MaXacNhan = "MyBugs_" + GenerateCodeActive().ToString(),
                    NguoiDungId = nguoiDung.Id,
                    ThoiGianHetHan = DateTime.Now.AddMinutes(15)
                };
                await _context.xacNhanEmails.AddAsync(xacNhanEmail);
                await _context.SaveChangesAsync();
                string message = SendEmail(new EmailTo
                {
                    To = request.Email,
                    Subject = Constants.ExceptionMessage.SUBJECT_EMAIL,
                    Content = $"Mã kích hoạt của bạn là: {xacNhanEmail.MaXacNhan}, mã này có hiệu lực là 15 phút"
                });
                return _responseObject.ResponseSuccess(Constants.ExceptionMessage.REGISTER_SUCCESS, _converter.EntityToDTO(nguoiDung));
            }catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
        public async Task<ResponseObject<DataResponseNguoiDung>> XacNhanDangKyTaiKhoan(Request_XacNhanDangKyTaiKhoan request)
        {
            XacNhanEmail xacNhanEmail = _context.xacNhanEmails.Where(x => x.MaXacNhan.Equals(request.MaXacNhan)).FirstOrDefault();
            if(xacNhanEmail == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Mã xác nhận không chính xác", null);
            }
            if(xacNhanEmail.ThoiGianHetHan < DateTime.Now)
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Mã xác nhận hết hạn", null);
            }
            NguoiDung nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == xacNhanEmail.NguoiDungId);
            nguoiDung.TrangThaiNguoiDungId = 2;
            _context.xacNhanEmails.Remove(xacNhanEmail);
            _context.nguoiDungs.Update(nguoiDung);
            await _context.SaveChangesAsync();
            return _responseObject.ResponseSuccess(Constants.ExceptionMessage.VERIFIED, _converter.EntityToDTO(nguoiDung));
        }
        #endregion
        #region Xử lý vấn đề liên quan đến gửi email

        public string SendEmail(EmailTo emailTo)
        {
            if (!Utilities.IsValidEmail(emailTo.To))
            {
                return "Định dạng email không hợp lệ";
            }
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("minhquantb00@gmail.com", "jvztzxbtyugsiaea"),
                EnableSsl = true
            };
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress("minhquantb00@gmail.com");
                message.To.Add(emailTo.To);
                message.Subject = emailTo.Subject;
                message.Body = emailTo.Content;
                message.IsBodyHtml = true;
                smtpClient.Send(message);

                return "Xác nhận gửi email thành công, lấy mã để xác thực";
            }
            catch (Exception ex)
            {
                return "Lỗi khi gửi email: " + ex.Message;
            }
        }
        private int GenerateCodeActive()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }


        #endregion
        #region Đăng nhập
        public async Task<ResponseObject<DataResponseToken>> DangNhap(Request_DangNhap request)
        {
            if (string.IsNullOrEmpty(request.TenTaiKhoan) || string.IsNullOrEmpty(request.MatKhau))
            {
                return _responseTokenObject.ResponseError(StatusCodes.Status400BadRequest, Constants.ExceptionMessage.REQUEST_TO_FILL_INFORMATION, null);
            }
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.TenTaiKhoan.Equals(request.TenTaiKhoan));
            if(nguoiDung == null)
            {
                return _responseTokenObject.ResponseError(StatusCodes.Status400BadRequest, "Tên tài khoản không chính xác", null);
            }
            bool checkMatKhau = BcryptNet.Verify(request.MatKhau, nguoiDung.MatKhau);
            if (!checkMatKhau)
            {
                return _responseTokenObject.ResponseError(StatusCodes.Status400BadRequest, "Mật khẩu không chính xác", null);
            }
            return _responseTokenObject.ResponseSuccess("Đăng nhập tài khoản thành công", GenerateAccessToken(nguoiDung));

        }
        public DataResponseToken GenerateAccessToken(NguoiDung nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_configuration.GetSection(Constants.AppSettingKeys.AUTH_SECRET).Value!);
            var role = _context.quyenHans.SingleOrDefault(x => x.Id == nguoiDung.QuyenHanId);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim("Id", nguoiDung.Id.ToString()),
                    new Claim("TenTaiKhoan", nguoiDung.TenTaiKhoan),
                    new Claim("Email", nguoiDung.Email),
                    new Claim(ClaimTypes.Role, role?.MaQuyen ?? "")
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            RefreshToken rf = new RefreshToken
            {
                NguoiDungId = nguoiDung.Id,
                ThoiGianHetHan = DateTime.Now.AddHours(10),
                Token = refreshToken
            };
            _context.refreshTokens.Add(rf);
            _context.SaveChanges();
            DataResponseToken data = new DataResponseToken
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                DataResponseNguoiDung = _converter.EntityToDTO(nguoiDung)
            };
            return data;
        }
        public string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
        #endregion
        #region Renew Access Token
        public ResponseObject<DataResponseToken> RenewAccessToken(Request_RenewToken request)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var secretKey = _configuration.GetSection(Constants.AppSettingKeys.AUTH_SECRET).Value;

                var tokenValidation = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey))
                };

                var tokenAuthentication = jwtTokenHandler.ValidateToken(request.AccessToken, tokenValidation, out var validatedToken);
                if (!(validatedToken is JwtSecurityToken jwtSecurityToken) || jwtSecurityToken.Header.Alg != SecurityAlgorithms.HmacSha256)
                {
                    return _responseTokenObject.ResponseError(StatusCodes.Status400BadRequest, "Token không hợp lệ", null);
                }
                var refreshToken = _context.refreshTokens.SingleOrDefault(x => x.Token.Equals(request.RefreshToken));
                if (refreshToken == null)
                {
                    return _responseTokenObject.ResponseError(StatusCodes.Status404NotFound, "RefreshToken không tồn tại trong database", null);
                }
                if (refreshToken.ThoiGianHetHan < DateTime.Now)
                {
                    return _responseTokenObject.ResponseError(StatusCodes.Status401Unauthorized, "RefreshToken đã hết hạn", null);
                }
                var user = _context.nguoiDungs.SingleOrDefault(x => x.Id == refreshToken.NguoiDungId);
                if (user == null)
                {
                    return _responseTokenObject.ResponseError(StatusCodes.Status404NotFound, "Người dùng không tồn tại", null);
                }
                var newToken = GenerateAccessToken(user);
                return _responseTokenObject.ResponseSuccess("Token đã được làm mới thành công", newToken);
            }
            catch (SecurityTokenValidationException ex)
            {
                return _responseTokenObject.ResponseError(StatusCodes.Status400BadRequest, "Lỗi xác thực token: " + ex.Message, null);
            }
            catch (Exception ex)
            {
                return _responseTokenObject.ResponseError(StatusCodes.Status500InternalServerError, "Lỗi không xác định: " + ex.Message, null);
            }
        }
        #endregion
        #region Đổi mật khẩu
        public async Task<string> DoiMatKhau(int nguoiDungId, Request_DoiMatKhau request)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
            bool checkMatKhauCu = BcryptNet.Verify(request.MatKhauCu, nguoiDung.MatKhau);
            if (!checkMatKhauCu)
            {
                return "Mật khẩu không chính xác";
            }
            if(string.IsNullOrEmpty(request.MatKhauCu) || string.IsNullOrEmpty(request.MatKhauMoi))
            {
                return "Vui lòng điền đầy đủ thông tin";
            }
            if (!request.MatKhauMoi.Equals(request.XacNhanMatKhauMoi))
            {
                return "Mật khẩu không trùng khớp";
            }
            nguoiDung.MatKhau = BcryptNet.HashPassword(request.MatKhauMoi);
            await _context.SaveChangesAsync();
            return "Đổi mật khẩu thành công";
        }
        #endregion
        #region Xác nhận quên mật khẩu
        public async Task<string> XacNhanQuenMatKhau(Request_XacNhanQuenMatKhau request)
        {
            NguoiDung nguoiDung = await _context.nguoiDungs.FirstOrDefaultAsync(x => x.Email.Equals(request.Email));
            if (nguoiDung is null)
            {
                return "Email không tồn tại trong hệ thống";
            }
            else
            {
                var confirms = _context.xacNhanEmails.Where(x => x.NguoiDungId == nguoiDung.Id).ToList();
                _context.xacNhanEmails.RemoveRange(confirms);
                await _context.SaveChangesAsync();
                XacNhanEmail xacNhanEmail = new XacNhanEmail
                {
                    NguoiDungId = nguoiDung.Id,
                    DaXacNhan = false,
                    ThoiGianHetHan = DateTime.Now.AddMinutes(15),
                    MaXacNhan = "MyBugs" + "_" + GenerateCodeActive().ToString()
                };
                await _context.xacNhanEmails.AddAsync(xacNhanEmail);
                await _context.SaveChangesAsync();
                string message = SendEmail(new EmailTo
                {
                    To = request.Email,
                    Subject = "Nhận mã xác nhận để tạo mật khẩu mới từ đây: ",
                    Content = $"Mã kích hoạt của bạn là: {xacNhanEmail.MaXacNhan}, mã này sẽ hết hạn sau 4 tiếng"
                });
                return "Gửi mã xác nhận về email thành công, vui lòng kiểm tra email";
            }
        }
        #endregion
        #region Tạo mật khẩu mới
        public async Task<ResponseObject<DataResponseNguoiDung>> TaoMatKhauMoi(Request_TaoMatKhauMoi request)
        {
            XacNhanEmail xacNhanEmail = await _context.xacNhanEmails.SingleOrDefaultAsync(x => x.MaXacNhan.Equals(request.MaXacNhan));
            if(xacNhanEmail is null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Mã xác nhận không hợp lệ! Vui lòng kiểm tra lại", null);
            }
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == xacNhanEmail.NguoiDungId);
            if(nguoiDung is null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Người dùng không tồn tại", null);
            }
            if(xacNhanEmail.ThoiGianHetHan < DateTime.Now)
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Mã xác nhận đã hết hạn", null);
            }
            if (!request.MatKhauMoi.Equals(request.XacNhanMatKhauMoi))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Mật khẩu không trùng khớp", null);
            }
            nguoiDung.MatKhau = BcryptNet.HashPassword(request.MatKhauMoi);
            _context.nguoiDungs.Update(nguoiDung);
            _context.xacNhanEmails.Remove(xacNhanEmail);
            await _context.SaveChangesAsync();
            return _responseObject.ResponseSuccess("Tạo mật khẩu mới thành công", _converter.EntityToDTO(nguoiDung));
        }
        #endregion
    }
}
