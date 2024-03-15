using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.LoaiKhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataLoaiKhoaHoc;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILoaiKhoaHocService _loaiKhoaHocService;
        public AdminController(IUserService userService, ILoaiKhoaHocService loaiKhoaHocService)
        {
            _userService = userService;
            _loaiKhoaHocService = loaiKhoaHocService;
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
        [HttpPost("ThemLoaiKhoaHoc")]
        [Authorize(Roles = "Admin, Mod")]
        public async Task<IActionResult> ThemLoaiKhoaHoc([FromBody] Request_ThemLoaiKhoaHoc request)
        {
            return Ok(await _loaiKhoaHocService.ThemLoaiKhoaHoc(request));
        }
        [HttpPut("CapNhatThongTinLoaiKhoaHoc")]
        [Authorize(Roles = "Admin, Mod")]
        public async Task<IActionResult> CapNhatThongTinLoaiKhoaHoc([FromBody] Request_SuaLoaiKhoaHoc request)
        {
            return Ok(await _loaiKhoaHocService.CapNhatThongTinLoaiKhoaHoc(request));
        }
        [HttpDelete("XoaLoaiKhoaHoc/{loaiKhoaHocId}")]
        [Authorize(Roles = "Admin, Mod")]
        public async Task<IActionResult> XoaLoaiKhoaHoc([FromRoute] int loaiKhoaHocId)
        {
            return Ok(await _loaiKhoaHocService.XoaLoaiKhoaHoc(loaiKhoaHocId));
        }
        
    }
}
