using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.InputRequests;

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
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            return Ok(await _userService.GetUserById(id));
        }
    }
}
