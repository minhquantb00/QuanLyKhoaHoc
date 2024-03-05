using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.BinhLuanBaiHocRequests;

namespace WebCourseManagement_API.Controllers
{
    [Route("api/binhluanbaihoc")]
    [ApiController]
    public class BinhLuanBaiHocController : ControllerBase
    {
        private readonly IBinhLuanBaiHocService _binhLuanBaiHocService;
        public BinhLuanBaiHocController(IBinhLuanBaiHocService binhLuanBaiHocService)
        {
            _binhLuanBaiHocService = binhLuanBaiHocService;
        }
        [HttpPost("ThemBinhLuanBaiHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ThemBinhLuanBaiHoc([FromBody] Request_ThemBinhLuanBaiHoc request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _binhLuanBaiHocService.ThemBinhLuanBaiHoc(id, request));
        }
        [HttpPost("TraLoiBinhLuan")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> TraLoiBinhLuan([FromBody] Request_TraLoiBinhLuan request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _binhLuanBaiHocService.TraLoiBinhLuan(id, request));
        }
        [HttpPut("SuaBinhLuanBaiHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SuaBinhLuanBaiHoc([FromBody] Request_SuaBinhLuanBaiHoc request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _binhLuanBaiHocService.SuaBinhLuanBaiHoc(id, request));
        }
        [HttpDelete("XoaBinhLuanBaiHoc")]
        public async Task<IActionResult> XoaBinhLuanBaiHoc([FromRoute] int binhLuanId)
        {
            return Ok(await _binhLuanBaiHocService.XoaBinhLuanBaiHoc(binhLuanId));
        }
        [HttpGet("GetAllBinhLuanTraLoi")]
        public async Task<IActionResult> GetAllBinhLuanTraLoi(int binhLuanId, int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _binhLuanBaiHocService.GetAllBinhLuanTraLoi(binhLuanId, pageSize, pageNumber));
        }
    }
}
