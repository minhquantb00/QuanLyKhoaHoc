using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.BaiVietRequests;
using WebCourseManagement_Models.RequestModels.BannerRequest;
using WebCourseManagement_Models.RequestModels.LoaiKhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataBanner;
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
        private readonly IBaiVietService _baivietService;
        private readonly IBannerService _bannerService;
        public AdminController(IUserService userService, ILoaiKhoaHocService loaiKhoaHocService, IBaiVietService baiVietService, IBannerService bannerService)
        {
            _userService = userService;
            _loaiKhoaHocService = loaiKhoaHocService;
            _baivietService = baiVietService;
            _bannerService = bannerService;
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
        [HttpPut("DuyetBaiViet/{baiVietId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DuyetBaiViet([FromRoute] int baiVietId)
        {
            return Ok(await _baivietService.DuyetBaiViet(baiVietId));
        }
        [HttpPost("TaoBanner")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> TaoBanner([FromForm] Request_TaoBanner request)
        {
            return Ok(await _bannerService.TaoBanner(request));
        }
        [HttpPost("ThemLoaiBaiViet")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ThemLoaiBaiViet([FromBody] Request_ThemLoaiBaiViet request)
        {
            return Ok(await _baivietService.ThemLoaiBaiViet(request));
        }
    }
}
