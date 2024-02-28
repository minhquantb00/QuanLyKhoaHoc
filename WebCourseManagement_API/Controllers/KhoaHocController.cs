using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.KhoaHocRequests;

namespace WebCourseManagement_API.Controllers
{
    [Route("api/khoahoc")]
    [ApiController]
    public class KhoaHocController : ControllerBase
    {
        private readonly IKhoaHocService _khoaHocService;
        public KhoaHocController(IKhoaHocService khoaHocService)
        {
            _khoaHocService = khoaHocService;
        }
        [HttpPost("ThemKhoaHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ThemKhoaHoc([FromForm] Request_ThemKhoaHoc request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _khoaHocService.ThemKhoaHoc(id, request));
        }
        [HttpPut("CapNhatThongTinKhoaHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CapNhatThongTinKhoaHoc([FromForm] Request_CapNhatThongTinKhoaHoc request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _khoaHocService.SuaThongTinKhoaHoc(id, request));
        }
        [HttpDelete("XoaKhoaHoc/{khoaHocId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> XoaKhoaHoc([FromRoute]int khoaHocId)
        {
            return Ok(await _khoaHocService.XoaKhoaHoc(khoaHocId));
        }
        [HttpGet("GetKhoaHocById/{id}")]
        public async Task<IActionResult> GetKhoaHocById([FromRoute] int id)
        {
            return Ok(await _khoaHocService.GetKhoaHocById(id));
        }
    }
}
