
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.Converters;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.RequestModels.BaiHocRequets;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Implements
{
    public class BaiHocService : IBaiHocService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseBaiHoc> _responseObject;
        private readonly BaiHocConverter _converter;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaiHocService(AppDbContext context, ResponseObject<DataResponseBaiHoc> responseObject, BaiHocConverter converter, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _responseObject = responseObject;
            _converter = converter;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<ResponseObject<DataResponseBaiHoc>> SuaThongTinBaiHoc(Request_SuaThongTinBaiHoc request)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            var chuongHoc = await _context.chuongKhoaHocs.SingleOrDefaultAsync(x => x.Id == request.ChuongKhoaHocId);
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == chuongHoc.KhoaHocId);
            var baiHoc = await _context.baiHocs.SingleOrDefaultAsync(x => x.Id == request.BaiHocId);
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                return _responseObject.ResponseError(StatusCodes.Status401Unauthorized, "Người dùng chưa được xác thực", null);
            }
            if (khoaHoc.NguoiTaoId != int.Parse(userId))
            {
                return _responseObject.ResponseError(StatusCodes.Status403Forbidden, "Người dùng không đủ quyền để thực hiện chức năng này", null);
            }
            if (chuongHoc is null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Chương học không tồn tại", null);
            }
            if(baiHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy bài học", null);
            }
            baiHoc.MoTaBaiHoc = request.MoTaBaiHoc;
            baiHoc.TenBaiHoc = request.TenBaiHoc;
            baiHoc.ChuongKhoaHocId = request.ChuongKhoaHocId;
            baiHoc.ThoiGianCapNhat = DateTime.Now;
            baiHoc.LoaiBaiHocId = request.LoaiBaiHocId;
            baiHoc.TrangThaiBaiHocId = 1;
            baiHoc.ThoiLuongVideo = request.ThoiLuongVideo;
            await _context.SaveChangesAsync();
            return _responseObject.ResponseSuccess("Cập nhật thông tin bài học thành công", null);
        }

        public async Task<ResponseObject<DataResponseBaiHoc>> ThemBaiHoc(Request_ThemBaiHoc request)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            var chuongHoc = await _context.chuongKhoaHocs.SingleOrDefaultAsync(x => x.Id == request.ChuongKhoaHocId);
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == chuongHoc.KhoaHocId);
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                return _responseObject.ResponseError(StatusCodes.Status401Unauthorized, "Người dùng chưa được xác thực", null);
            }
            if (khoaHoc.NguoiTaoId != int.Parse(userId))
            {
                return _responseObject.ResponseError(StatusCodes.Status403Forbidden, "Người dùng không đủ quyền để thực hiện chức năng này", null);
            }
            if (chuongHoc is null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Chương học không tồn tại", null);
            }
            BaiHoc baiHoc = new BaiHoc
            {
                ChuongKhoaHocId = request.ChuongKhoaHocId,
                LoaiBaiHocId = request.LoaiBaiHocId,
                MoTaBaiHoc = request.MoTaBaiHoc,
                TenBaiHoc = request.TenBaiHoc,
                ThoiGianTao = DateTime.Now,
                TrangThaiBaiHocId = 1,
                ThoiLuongVideo = request.ThoiLuongVideo
            };
            await _context.baiHocs.AddAsync(baiHoc);
            await _context.SaveChangesAsync();
            return _responseObject.ResponseSuccess("Thêm bài học thành công", _converter.EntityToDTO(baiHoc));
        }

        public async Task<string> XoaBaiHoc(int baiHocId)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var baiHoc = await _context.baiHocs.SingleOrDefaultAsync(x => x.Id == baiHocId);
            var chuongHoc = baiHoc.ChuongKhoaHoc;
            var khoaHoc = chuongHoc.KhoaHoc;
            if (!currentUser.Identity.IsAuthenticated)
            {
                return "Người dùng chưa được xác thực";
            }
            if(khoaHoc.NguoiTaoId != int.Parse(userId))
            {
                return "Người dùng không có quyền thực hiện chức năng này";
            }
            _context.baiHocs.Remove(baiHoc);
            await _context.SaveChangesAsync();
            return "Xóa bài học thành công";
        }
    }
}
