using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Implements
{
    public class OAuthService : IOAuthService
    {
        private readonly ResponseObject<DataResponseToken> _responseObject;
        private readonly ILogger<OAuthService> _logger;
        private readonly IAuthService _authService;
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseToken> _responseTokenObject;
        public OAuthService(ResponseObject<DataResponseToken> responseObject, 
                            ILogger<OAuthService> logger, 
                            IAuthService authService, 
                            AppDbContext context, 
                            ResponseObject<DataResponseToken> responseTokenObject)
        {
            _responseObject = responseObject;
            _logger = logger;
            _authService = authService;
            _context = context;
            _responseTokenObject = responseTokenObject;
        }

        public async Task<ResponseObject<DataResponseToken>> ValidateGoogleToken(string token)
        {
            try
            {
                var opt = new GoogleOptions();
                var test = new Microsoft.AspNetCore.Authentication.Google.GoogleHandler()

                string googleApiInformation = "https://www.googleapis.com/oauth2/v3/userinfo";
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await httpClient.GetAsync(googleApiInformation);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    DataGoogleResponse customObject = System.Text.Json.JsonSerializer.Deserialize<DataGoogleResponse>(jsonResponse);

                    NguoiDung nguoiDung = _context.nguoiDungs.SingleOrDefault(x => x.Email.Equals(customObject.email));
                    _logger.LogInformation("MyBugs_" + customObject.email);
                    if(nguoiDung == null)
                    {
                        nguoiDung = new NguoiDung
                        {
                            Email = customObject.email,
                            ThoiGianTao = DateTime.Now,
                            MatKhau = "",
                            TenTaiKhoan = "",
                            SoDienThoai = "",
                            DaKhoa = false,
                            GioiTinh = customObject.GioiTinh,
                            DiaChi = ""
                        };
                    }
                    nguoiDung.HoVaTen = customObject.HoVaTen;
                    nguoiDung.AnhDaiDien = customObject.Image;
                    _context.SaveChanges();
                    DataResponseToken data = _authService.GenerateAccessToken(nguoiDung);
                    return _responseTokenObject.ResponseSuccess("Thành công", data);
                }
                else
                {
                    await Console.Out.WriteLineAsync("Yêu cầu không được thực hiện: " + response.StatusCode);
                    return _responseObject.ResponseError(StatusCodes.Status401Unauthorized, "Lỗi", null);
                }
            }catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return _responseObject.ResponseError(StatusCodes.Status401Unauthorized, ex.Message, null);
            }
        }
    }
}
