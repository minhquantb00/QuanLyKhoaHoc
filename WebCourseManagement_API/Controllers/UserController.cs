using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.BaiHocRequests;
using WebCourseManagement_Models.RequestModels.ChuongHocRequests;
using WebCourseManagement_Models.RequestModels.InputRequests;
using WebCourseManagement_Models.RequestModels.KhoaHocRequests;
using WebCourseManagement_Models.RequestModels.NguoiDungRequests;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataChuongHoc;
using WebCourseManagement_Models.ResponseModels.DataHoaDon;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.ResponseModels.DataLoaiKhoaHoc;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILoaiKhoaHocService _loaiKhoaHocService;
        private readonly IKhoaHocService _khoaHocService;
        private readonly IChuongHocService _chuongHocService;
        private readonly IBaiHocService _baiHocService;
        private readonly IVNPayService _vnpayService;
        public UserController(IUserService userService, ILoaiKhoaHocService loaiKhoaHocService, IKhoaHocService khoaHocService, IChuongHocService chuongHocService, IBaiHocService baiHocService, IVNPayService vnpayService)
        {
            _userService = userService;
            _loaiKhoaHocService = loaiKhoaHocService;
            _khoaHocService = khoaHocService;
            _chuongHocService = chuongHocService;
            _baiHocService = baiHocService;
            _vnpayService = vnpayService;
        }
        [HttpGet("GetAllsNguoiDung")]
        public async Task<IActionResult> GetAllsNguoiDung(int pageSize = 10, int pageNumber = 1)
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
        [Consumes(contentType: "multipart/form-data")]
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
        [HttpGet("GetAllsLoaiKhoaHoc")]
        public async Task<IActionResult> GetAllsLoaiKhoaHoc(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _loaiKhoaHocService.GetAlls(pageSize, pageNumber));
        }
        [HttpGet("GetAllsKhoaHoc")]
        public async Task<IActionResult> GetAllsKhoaHoc(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _khoaHocService.GetAlls(pageSize, pageNumber));
        }
        [HttpGet("GetKhoaHocById/{khoaHocId}")]
        public async Task<IActionResult> GetKhoaHocById([FromRoute] int khoaHocId)
        {
            return Ok(await _khoaHocService.GetKhoaHocById(khoaHocId));
        }
        [HttpPost("ThemKhoaHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> ThemKhoaHoc([FromForm] Request_ThemKhoaHoc request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _khoaHocService.ThemKhoaHoc(id, request));
        }
        [HttpPut("SuaThongTinKhoaHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> SuaThongTinKhoaHoc([FromForm] Request_SuaThongTinKhoaHoc request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _khoaHocService.SuaThongTinKhoaHoc(id, request));
        }
        [HttpDelete("XoaKhoaHoc/{khoaHocId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> XoaKhoaHoc([FromRoute] int khoaHocId)
        {
            return Ok(await _khoaHocService.XoaKhoaHoc(khoaHocId));
        }
        [HttpDelete("XoaChuongHoc/{chuongHocId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> XoaChuongHoc([FromRoute] int chuongHocId)
        {
            return Ok(await _chuongHocService.XoaChuongHoc(chuongHocId));
        }
        [HttpPost("ThemChuongHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ThemChuongHoc([FromBody]Request_ThemChuongHoc request)
        {
            return Ok(await _chuongHocService.ThemChuongHoc(request));
        }
        [HttpPut("SuaThongTinChuongHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SuaThongTinChuongHoc([FromBody] Request_SuaThongTinChuongHoc request)
        {
            return Ok(await _chuongHocService.SuaThongTinChuongHoc(request)); 
        }
        [HttpGet("GetChuongHocById/{chuongHocId}")]
        public async Task<IActionResult> GetChuongHocById([FromRoute] int chuongHocId)
        {
            return Ok(await _chuongHocService.GetChuongHocById(chuongHocId));
        }
        [HttpGet("GetAlls")]
        public async Task<IActionResult> GetAllsChuongHoc(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _chuongHocService.GetAlls(pageSize, pageNumber));
        }
        [HttpDelete("XoaBaiHoc/{baiHocId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> XoaBaiHoc([FromRoute] int baiHocId)
        {
            return Ok(await _baiHocService.XoaBaiHoc(baiHocId));
        }
        [HttpPut("SuaThongTinBaiHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SuaThongTinBaiHoc([FromBody] Request_CapNhatThongTinBaiHoc request)
        {
            return Ok(await _baiHocService.SuaThongTinBaiHoc(request));
        }
        [HttpPost("ThemBaiHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ThemBaiHoc([FromBody] Request_ThemBaiHoc request)
        {
            return Ok(await _baiHocService.ThemBaiHoc(request));
        }
        [HttpGet("GetBaiHocById/{baiHocId}")]
        public async Task<IActionResult> GetBaiHocById([FromRoute] int baiHocId)
        {
            return Ok(await _baiHocService.GetBaiHocById(baiHocId));
        }
        [HttpGet("GetAllsBaiHoc")]
        public async Task<IActionResult> GetAllsBaiHoc([FromQuery] InputBaiHoc input, int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _baiHocService.GetAlls(input, pageSize, pageNumber));
        }
        [HttpPost("DangKyKhoaHoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DangKyKhoaHoc([FromBody] Request_DangKyKhoaHoc request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _khoaHocService.DangKyKhoaHoc(id, request));
        }
        [HttpPost("TaoDuongDanThanhToan/{hoaDonId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> TaoDuongDanThanhToan([FromRoute] int hoaDonId)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _vnpayService.TaoDuongDanThanhToan(hoaDonId, HttpContext, id));
        }
        [HttpGet("Return")]
        public async Task<IActionResult> Return()
        {
            var vnpayData = HttpContext.Request.Query;

            return Ok(await _vnpayService.VNPayReturn(vnpayData));
        }
    }
}
