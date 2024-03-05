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
using WebCourseManagement_Models.RequestModels.InputRequests;
using WebCourseManagement_Models.RequestModels.KhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandleImage;
using WebCourseManagement_Repositories.HandlePagination;

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

        public async Task<PageResult<DataResponseKhoaHoc>> GetAlls(InputKhoaHoc input, int pageSize, int pageNumber)
        {
            var query =  _context.khoaHocs.Include(x => x.LoaiKhoaHoc).AsNoTracking().AsQueryable();
            if (input.LoaiKhoaHocId.HasValue)
            {
                query = query.Where(x => x.LoaiKhoaHocId ==  input.LoaiKhoaHocId);
            }
            if (!string.IsNullOrWhiteSpace(input.TenKhoaHoc))
            {
                query = query.Where(x => x.TenKhoaHoc.ToLower().Contains(input.TenKhoaHoc.ToLower()));
            }
            if(input.GiaTu.HasValue && input.GiaDen.HasValue)
            {
                query = query.Where(x => x.GiaKhoaHoc >= input.GiaTu && x.GiaKhoaHoc <= input.GiaDen);
            }

            var result = Pagination.GetPagedData(query.Select(x => _converter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<DataResponseKhoaHoc> GetKhoaHocById(int khoaHocId)
        {
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == khoaHocId);
            return _converter.EntityToDTO(khoaHoc);
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
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiTaoId);
            if(loaiKhoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy loại khóa học", null);
            }
            if(nguoiDung == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Người dùng không tồn tại", null);
            }
            KhoaHoc khoaHoc = new KhoaHoc
            {
                AnhKhoaHoc = await HandleUploadImage.Upfile(request.AnhKhoaHoc),
                GiaKhoaHoc = request.GiaKhoaHoc,
                LinkVideoGioiThieu = request.LinkVideoGioiThieu,
                LoaiKhoaHocId = request.LoaiKhoaHocId,
                MoTa = request.MoTa,
                NgayTao = DateTime.Now,
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
            var userId = currentUser.FindFirst("Id")?.Value;

            if (!currentUser.Identity.IsAuthenticated)
            {
                return "Người dùng không được xác thực hoặc không được xác định";
            }

            if (!currentUser.IsInRole("Admin") && !currentUser.IsInRole("Mod"))
            {
                return "Người dùng không có quyền sử dụng chức năng này";
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
