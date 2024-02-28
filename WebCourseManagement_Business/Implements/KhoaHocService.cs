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
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.RequestModels.KhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandleImage;

namespace WebCourseManagement_Business.Implements
{
    public class KhoaHocService : IKhoaHocService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseKhoaHoc> _responseObject;
        private readonly KhoaHocConverter _converter;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public KhoaHocService(AppDbContext context, ResponseObject<DataResponseKhoaHoc> responseObject, KhoaHocConverter converter, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _responseObject = responseObject;
            _converter = converter;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseObject<DataResponseKhoaHoc>> SuaThongTinKhoaHoc(int nguoiSuaId, Request_CapNhatThongTinKhoaHoc request)
        {
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == request.KhoaHocId);
            if (khoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy khóa học", null);
            }
            if (!_context.loaiKhoaHocs.Any(x => x.Id == request.LoaiKhoaHocId))
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Loại khóa học không tồn tại", null);
            }
            if (nguoiSuaId != khoaHoc.NguoiTaoId)
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Bạn không có quyền sửa thông tin khóa học", null);
            }
            khoaHoc.NguoiTaoId = nguoiSuaId;
            khoaHoc.MoTa = request.MoTa;
            khoaHoc.NgayCapNhat = DateTime.Now;
            khoaHoc.AnhKhoaHoc = await HandleUploadImage.UpdateFile(khoaHoc.AnhKhoaHoc, request.AnhKhoaHoc);
            khoaHoc.GiaKhoaHoc = request.GiaKhoaHoc;
            khoaHoc.LinkVideoGioiThieu = request.LinkVideoGioiThieu;
            khoaHoc.LoaiKhoaHocId = request.LoaiKhoaHocId;
            khoaHoc.TenKhoaHoc = request.TenKhoaHoc;
            _context.khoaHocs.Update(khoaHoc);
            await _context.SaveChangesAsync();
            return _responseObject.ResponseSuccess("Cập nhật thông tin khóa học thành công", _converter.EntityToDTO(khoaHoc));
        }

        public async Task<ResponseObject<DataResponseKhoaHoc>> ThemKhoaHoc(int nguoiTaoId, Request_ThemKhoaHoc request)
        {
            var loaiKhoaHoc = await _context.loaiKhoaHocs.SingleOrDefaultAsync(x => x.Id == request.LoaiKhoaHocId);
            if (loaiKhoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy loại khóa học", null);
            }
            KhoaHoc khoaHoc = new KhoaHoc
            {
                AnhKhoaHoc = await HandleUploadImage.Upfile(request.AnhKhoaHoc),
                GiaKhoaHoc = request.GiaKhoaHoc,
                LinkVideoGioiThieu = request.LinkVideoGioiThieu,
                LoaiKhoaHocId = request.LoaiKhoaHocId,
                MoTa = request.MoTa,
                NgayTao = DateTime.Now,
                NguoiTaoId = nguoiTaoId,
                SoBaiHoc = 0,
                SoChuong = 0,
                SoHocVienDaHoanThanh = 0,
                SoNguoiDangKyKhoaHoc = 0,
                TenKhoaHoc = request.TenKhoaHoc,
                TongThoiGianBaiHoc = 0,
                TrangThaiKhoaHocId = 1,
                IsActive = true
            };
            await _context.khoaHocs.AddAsync(khoaHoc);
            await _context.SaveChangesAsync();
            return _responseObject.ResponseSuccess("Thêm khóa học thành công", _converter.EntityToDTO(khoaHoc));
        }

        public async Task<string> XoaKhoaHoc(int khoaHocId)
        {
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == khoaHocId);

            var currentUser = _httpContextAccessor.HttpContext.User;

            if (!currentUser.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("Người dùng không được xác thực hoặc không được xác định");
            }

            if (!currentUser.IsInRole("Admin") && !currentUser.IsInRole("Mod"))
            {
                throw new UnauthorizedAccessException("Người dùng không có quyền sử dụng chức năng này");
            }
            if (khoaHoc == null)
            {
                return "Khóa học không tồn tại";
            }
            khoaHoc.IsActive = false;
            await _context.SaveChangesAsync();
            return "Xóa khóa học thành công";
        }
    }
}
