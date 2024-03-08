using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;

namespace WebCourseManagement_API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPut("KhoaTaiKhoanNguoiDung/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> KhoaTaiKhoanNguoiDung([FromRoute] int id)
        {
            return Ok(await _userService.KhoaTaiKhoanNguoiDung(id));
        }
        [HttpPut("MoKhoaTaiKhanNguoiDung/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> MoKhoaTaiKhanNguoiDung([FromRoute] int id)
        {
            return Ok(await _userService.MoKhoaTaiKhanNguoiDung(id));
        }
    }
}
