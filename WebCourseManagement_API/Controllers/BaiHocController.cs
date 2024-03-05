using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.BaiHocRequets;

namespace WebCourseManagement_API.Controllers
{
    [Route("api/baihoc")]
    [ApiController]
    public class BaiHocController : ControllerBase
    {
        private readonly IBaiHocService _baiHocService;
        public BaiHocController(IBaiHocService baiHocService)
        {
            _baiHocService = baiHocService;
        }
        [HttpPost("ThemBaiHoc")]
        public async Task<IActionResult> ThemBaiHoc([FromBody] Request_ThemBaiHoc request)
        {
            return Ok(await _baiHocService.ThemBaiHoc(request));
        }
        [HttpPut("SuaThongTinBaiHoc")]
        public async Task<IActionResult> SuaThongTinBaiHoc([FromBody] Request_SuaThongTinBaiHoc request)
        {
            return Ok(await _baiHocService.SuaThongTinBaiHoc(request));
        }
        [HttpDelete("XoaBaiHoc/{baiHocId}")]
        public async Task<IActionResult> XoaBaiHoc([FromRoute] int baiHocId)
        {
            return Ok(await _baiHocService.XoaBaiHoc(baiHocId));
        }
    }
}
