
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.Converters;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.RequestModels.BaiHocRequests;
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

        public  Task<ResponseObject<DataResponseBaiHoc>> SuaThongTinBaiHoc(Request_SuaThongTinBaiHoc request)
        {
            throw new NotImplementedException();
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

        public Task<string> XoaBaiHoc(int baiHocId)
        {
            throw new NotImplementedException();
        }
    }
}
