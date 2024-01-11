using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.AuthRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("DangKy")]
        public async Task<IActionResult> DangKy([FromForm] Request_DangKy request)
        {
            var result = await _authService.DangKyTaiKhoan(request);
            switch (result.Status)
            {
                case 200:
                    return Ok(result);
                case 404:
                    return NotFound(result);
                case 400:
                    return BadRequest(result);
                case 403:
                    return Unauthorized(result);
                default:
                    return StatusCode(500, result);
            }
        }
        [HttpPost("XacNhanDangKyTaiKhoan")]
        public async Task<IActionResult> XacNhanDangKyTaiKhoan([FromBody] Request_XacNhanDangKyTaiKhoan request)
        {
            var result = await _authService.XacNhanDangKyTaiKhoan(request);
            switch (result.Status)
            {
                case 200:
                    return Ok(result);
                case 404:
                    return NotFound(result);
                case 400:
                    return BadRequest(result);
                case 403:
                    return Unauthorized(result);
                default:
                    return StatusCode(500, result);
            }
        }
        [HttpPost("DangNhap")]
        public async Task<IActionResult> DangNhap([FromBody] Request_DangNhap request)
        {
            var result = await _authService.DangNhap(request);
            switch (result.Status)
            {
                case 200:
                    return Ok(result);
                case 404:
                    return NotFound(result);
                case 400:
                    return BadRequest(result);
                case 403:
                    return Unauthorized(result);
                default:
                    return StatusCode(500, result);
            }
        }
    }
}
