using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.InputRequests;
using WebCourseManagement_Models.RequestModels.UserRequests;

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
        public async Task<IActionResult> GetAlls([FromQuery] InputUser input, int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _userService.GetAlls(input, pageSize, pageNumber));
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            return Ok(await _userService.GetUserById(id));
        }
        [HttpPut("CapNhatThongTinNguoiDung")]
        public async Task<IActionResult> CapNhatThongTinNguoiDung([FromForm] Request_CapNhatThongTinNguoiDung request)
        {
            return Ok(await _userService.CapNhatThongTinNguoiDung(request));
        }
        [HttpDelete("XoaNguoiDung/{id}")]
        public async Task<IActionResult> XoaNguoiDung([FromRoute] int id)
        {
            return Ok(await _userService.XoaNguoiDung(id));
        }
    }
}
