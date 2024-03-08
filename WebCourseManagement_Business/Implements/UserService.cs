using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.Converters;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.RequestModels.NguoiDungRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandleImage;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Implements
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseNguoiDung> _responseObject;
        private readonly NguoiDungConverter _converter;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(AppDbContext context, ResponseObject<DataResponseNguoiDung> responseObject, NguoiDungConverter converter, IHttpContextAccessor httpContextAccessor, IAuthService authService)
        {
            _context = context;
            _responseObject = responseObject;
            _converter = converter;
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }

        public async Task<ResponseObject<DataResponseNguoiDung>> CapNhatThongTinNguoiDung(int nguoiDungId, Request_CapNhatThongTinNguoiDung request)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
            var xaPhuong = _context.xaPhuongs.SingleOrDefault(x => x.Id == request.XaPhuongId);
            var quanHuyen = _context.quanHuyens.SingleOrDefault(x => x.Id == request.QuanHuyenId);
            var tinhThanh = _context.tinhThanhs.SingleOrDefault(x => x.Id == request.TinhThanhId);
            nguoiDung.AnhDaiDien = await HandleUploadImage.Upfile(request.AnhDaiDien);
            nguoiDung.SoDienThoai = request.SoDienThoai;
            if(request.XaPhuongId.HasValue)
            {
                nguoiDung.XaPhuongId = request.XaPhuongId;
            }
            if (request.QuanHuyenId.HasValue)
            {
                nguoiDung.QuanHuyenId = request.QuanHuyenId;
            }
            if(request.TinhThanhId.HasValue)
            {
                nguoiDung.TinhThanhId = request.TinhThanhId;
            }
            nguoiDung.DiaChi = xaPhuong?.TenXaPhuong + " - " + quanHuyen?.TenQuanHuyen + " - " + tinhThanh?.TenTinhThanh ?? "";
            nguoiDung.HoVaTen = request.HoVaTen;
            nguoiDung.Email = request.Email;
            nguoiDung.GioiTinh = request.GioiTinh;
            _context.SaveChanges();
            return _responseObject.ResponseSuccess("Cập nhật thông tin thành công", _converter.EntityToDTO(nguoiDung));
        }

        public async Task<PageResult<DataResponseNguoiDung>> GetAlls(int pageSize, int pageNumber)
        {
            var query = _context.nguoiDungs.Where(x => x.IsActive == true && x.TrangThaiNguoiDungId == 2 && x.DaKhoa == false).AsQueryable();
            var result = Pagination.GetPagedData(query.Select(x => _converter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<ResponseObject<DataResponseNguoiDung>> GetNguoiDungById(int id)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == id && x.IsActive == true && x.TrangThaiNguoiDungId == 2 && x.DaKhoa == false);
            return _responseObject.ResponseSuccess("Lấy thông tin người dùng thành công", _converter.EntityToDTO(nguoiDung));
        }

        public async Task<string> KhoaTaiKhoanNguoiDung(int id)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == id && x.IsActive == true && x.DaKhoa == false && x.TrangThaiNguoiDungId == 2);
            var currentUser = _httpContextAccessor.HttpContext.User;
            var userId = currentUser.FindFirst("Id").Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                return "Tài khoản này chưa được xác thực! Vui lòng kiểm tra lại";
            }
            if(!currentUser.IsInRole("Admin") || !currentUser.IsInRole("Mod"))
            {
                return "Người dùng không có quyền sử dụng chức năng này";
            }
            nguoiDung.DaKhoa = true;
            nguoiDung.ThoiGianKhoa = DateTime.Now;
            _context.SaveChanges();
            string message = _authService.SendEmail(new WebCourseManagement_Repositories.EmailTo
            {
                To = nguoiDung.Email,
                Subject = "Thông báo khóa tài khoản: ",
                Content = "Tài khoản của bạn đã bị khóa bởi quản trị viên! Vui lòng liên hệ với bộ phận quản trị trang web MyBugs Course để mở lại <3"
            });
            return "Khóa tài khoản người dùng thành công";
        }

        public async Task<string> MoKhoaTaiKhanNguoiDung(int id)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == id && x.DaKhoa == true);
            var currentUser = _httpContextAccessor.HttpContext.User;
            if (!currentUser.Identity.IsAuthenticated)
            {
                return "Tài khoản này chưa được xác thực! Vui lòng kiểm tra lại";
            }
            if (!currentUser.IsInRole("Admin") || !currentUser.IsInRole("Mod"))
            {
                return "Người dùng không có quyền sử dụng chức năng này";
            }
            nguoiDung.DaKhoa = false;
            nguoiDung.ThoiGianMoKhoa = DateTime.Now;
            _context.SaveChanges();
            string message = _authService.SendEmail(new WebCourseManagement_Repositories.EmailTo
            {
                To = nguoiDung.Email,
                Subject = "Thông báo mở khóa tài khoản: ",
                Content = "Tài khoản của bạn đã được mở khóa trở lại! Từ bây giờ bạn đã có thể đăng nhập <3"
            });
            return "Mở khóa tài khoản thành công";
        }

        public async Task<string> NguoiDungXoaTaiKhoan(int id)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == id && x.IsActive == true && x.TrangThaiNguoiDungId == 2 && x.DaKhoa == false);
            nguoiDung.IsActive = false;
            _context.SaveChanges();
            return "Bạn đã xóa tài khoản thành công";
        }
    }
}
