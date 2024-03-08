using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.NguoiDungRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAlls")]
        public async Task<IActionResult> GetAlls(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _userService.GetAlls(pageSize, pageNumber));
        }

        [HttpGet("GetNguoiDungById/{id}")]
        public async Task<IActionResult> GetNguoiDungById([FromRoute] int id)
        {
            return Ok(await _userService.GetNguoiDungById(id));
        }
        [HttpPut("CapNhatThongTinNguoiDung")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CapNhatThongTinNguoiDung([FromForm]Request_CapNhatThongTinNguoiDung request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _userService.CapNhatThongTinNguoiDung(id, request));
        }
        [HttpDelete("NguoiDungXoaTaiKhoan")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> NguoiDungXoaTaiKhoan()
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _userService.NguoiDungXoaTaiKhoan(id));
        }
    }
}
