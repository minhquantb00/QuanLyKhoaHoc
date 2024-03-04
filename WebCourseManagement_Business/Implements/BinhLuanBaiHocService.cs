using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.Converters;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.RequestModels.BinhLuanBaiHocRequests;
using WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Implements
{
    public class BinhLuanBaiHocService : IBinhLuanBaiHocService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseBinhLuanBaiHoc> _responseObject;
        private readonly BinhLuanBaiHocConverter _converter;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BinhLuanBaiHocService(AppDbContext context, ResponseObject<DataResponseBinhLuanBaiHoc> responseObject, BinhLuanBaiHocConverter converter, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _responseObject = responseObject;
            _converter = converter;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PageResult<DataResponseBinhLuanBaiHoc>> GetAllBinhLuanTraLoi(int binhLuanId, int pageSize, int pageNumber)
        {
            var query = _context.binhLuanBaiHocs.Where(x => x.Id == binhLuanId).AsQueryable();
            var result = Pagination.GetPagedData(query.Select(x => _converter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<ResponseObject<DataResponseBinhLuanBaiHoc>> SuaBinhLuanBaiHoc(int nguoiDungId, Request_SuaBinhLuanBaiHoc request)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
            var binhLuan = await _context.binhLuanBaiHocs.SingleOrDefaultAsync(x => x.Id == request.BinhLuanId);
            if(binhLuan == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Bình luận không tồn tại", null);
            }
            if(binhLuan.NguoiDungId != nguoiDungId)
            {
                return _responseObject.ResponseError(StatusCodes.Status403Forbidden, "Bạn không có quyền sửa bình luận này", null);
            }
            binhLuan.DuongDanAnhBinhLuan = request.DuongDanAnhBinhLuan;
            binhLuan.BinhLuan = request.BinhLuan;
            _context.binhLuanBaiHocs.Update(binhLuan);
            await _context.SaveChangesAsync();
            return _responseObject.ResponseSuccess("Sửa bình luận thành công", _converter.EntityToDTO(binhLuan));
        }

        public async Task<ResponseObject<DataResponseBinhLuanBaiHoc>> ThemBinhLuanBaiHoc(int nguoiDungId, Request_ThemBinhLuanBaiHoc request)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
            BinhLuanBaiHoc binhLuanBaiHoc = new BinhLuanBaiHoc
            {
                DuongDanAnhBinhLuan = request.DuongDanAnhBinhLuan,
                IsActive = true,
                BaiHocId = request.BaiHocId,
                BinhLuan = request.BinhLuan,
                NguoiDungId = nguoiDungId,
                SoLuotBinhLuanTraLoi = 0,
                SoLuotLike = 0,
                ThoiGianTao = DateTime.Now,
                TrangThaiBinhLuanId = 1
            };
            await _context.nguoiDungs.AddAsync(nguoiDung);
            await _context.SaveChangesAsync();
            return _responseObject.ResponseSuccess("Thêm bình luận bài học thành công", _converter.EntityToDTO(binhLuanBaiHoc));
        }

        public async Task<string> XoaBinhLuanBaiHoc(int binhLuanId)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            var binhLuan = await _context.binhLuanBaiHocs.SingleOrDefaultAsync(x => x.Id == binhLuanId);
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                return "Người dùng chưa được xác thực";
            }
            if(!currentUser.IsInRole("Admin") && !currentUser.IsInRole("Mod") && binhLuan.NguoiDungId != int.Parse(userId))
            {
                return "Người dùng không có quyền thực hiện chức năng này";
            }
            _context.binhLuanBaiHocs.Remove(binhLuan);
            await _context.SaveChangesAsync();
            return "Xóa bình luận thành công";
        }
    }
}
