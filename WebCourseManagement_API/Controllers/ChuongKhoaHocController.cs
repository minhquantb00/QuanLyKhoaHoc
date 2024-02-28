using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.ChuongKhoaHocRequests;

namespace WebCourseManagement_API.Controllers
{
    [Route("api/chuongkhoahoc")]
    [ApiController]
    public class ChuongKhoaHocController : ControllerBase
    {
        private readonly IChuongKhoaHocService _chuongKhoaHocService;
        public ChuongKhoaHocController(IChuongKhoaHocService chuongKhoaHocService)
        {
            _chuongKhoaHocService = chuongKhoaHocService;
        }
        [HttpPost("ThemChuongKhoaHoc")]
        public async Task<IActionResult> ThemChuongKhoaHoc(Request_ThemChuongKhoaHoc request)
        {
            return Ok(await _chuongKhoaHocService.ThemChuongHoc(request));
        }
        [HttpPut("SuaChuongHoc")]
        public async Task<IActionResult> SuaChuongHoc(Request_CapNhatChuongKhoaHoc request)
        {
            return Ok(await _chuongKhoaHocService.SuaChuongHoc(request));
        }
        [HttpDelete("SuaChuongHoc/{chuongHocId}")]
        public async Task<IActionResult> XoaChuongHoc([FromRoute] int chuongHocId)
        {
            return Ok(await _chuongKhoaHocService.XoaChuongHoc(chuongHocId));
        }

        [HttpGet("GetChuongHocById/{id}")]
        public async Task<IActionResult> GetChuongHocById([FromRoute] int id)
        {
            return Ok(await _chuongKhoaHocService.GetChuongHocById(id));
        }
        [HttpGet("GetChuongHocByKhoaHoc/{id}")]
        public async Task<IActionResult> GetChuongHocByKhoaHoc([FromRoute] int id, int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _chuongKhoaHocService.GetChuongHocById(id));
        }
    }
}
