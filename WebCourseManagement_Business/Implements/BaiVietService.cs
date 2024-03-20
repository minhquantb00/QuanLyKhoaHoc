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
using WebCourseManagement_Models.RequestModels.BaiVietRequests;
using WebCourseManagement_Models.RequestModels.InputRequests;
using WebCourseManagement_Models.ResponseModels.DataBaiViet;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandleImage;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Implements
{
    public class BaiVietService : IBaiVietService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseBaiViet> _responseObject;
        private readonly ResponseObject<DataResponseBinhLuanBaiViet> _responseObjectBinhLuan;
        private readonly BinhLuanBaiVietConverter _binhLuanBaiVietConverter;
        private readonly BaiVietConverter _baiVietConverter;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ResponseObject<DataResponseLoaiBaiViet> _responseObjectLoaiBaiViet;
        private readonly LoaiBaiVietConverter _loaiBaiVietConverter;
        public BaiVietService(AppDbContext context, ResponseObject<DataResponseBaiViet> responseObject, BaiVietConverter baiVietConverter, IHttpContextAccessor httpContextAccessor, ResponseObject<DataResponseBinhLuanBaiViet> responseObjectBinhLuan, BinhLuanBaiVietConverter binhLuanBaiVietConverter, ResponseObject<DataResponseLoaiBaiViet> responseObjectLoaiBaiViet, LoaiBaiVietConverter loaiBaiVietConverter)
        {
            _context = context;
            _responseObject = responseObject;
            _baiVietConverter = baiVietConverter;
            _httpContextAccessor = httpContextAccessor;
            _responseObjectBinhLuan = responseObjectBinhLuan;
            _binhLuanBaiVietConverter = binhLuanBaiVietConverter;
            _loaiBaiVietConverter = loaiBaiVietConverter;
            _responseObjectLoaiBaiViet = responseObjectLoaiBaiViet;

        }

        public async Task<PageResult<DataResponseBaiViet>> GetAlls(InputBaiViet input, int pageSize, int pageNumber)
        {
            var baiViet = _context.baiViets.Where(x => x.TrangThaiBaiVietId == 2).OrderByDescending(x => x.ThoiGianTao).AsQueryable();
            if (input.NguoiTaoId.HasValue)
            {
                baiViet = baiViet.Where(x => x.NguoiTaoBaiVietId == input.NguoiTaoId);
            }
            if(input.FromDate.HasValue && input.ToDate.HasValue)
            {
                baiViet = baiViet.Where(x => x.ThoiGianTao >= input.FromDate && x.ThoiGianTao <= input.ToDate);
            }
            if(input.FromDate.HasValue && !input.ToDate.HasValue)
            {
                baiViet = baiViet.Where(x => x.ThoiGianTao >= input.FromDate);
            }
            var result = Pagination.GetPagedData(baiViet.Select(x => _baiVietConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        

        public async Task<ResponseObject<DataResponseBaiViet>> GetBaiVietById(int baiVietId)
        {
            var baiViet = await _context.baiViets.SingleOrDefaultAsync(x => x.Id == baiVietId);
            if(baiViet == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Bài viết không tồn tại", null);
            }
            return _responseObject.ResponseSuccess("Lấy dữ liệu thành công", _baiVietConverter.EntityToDTO(baiViet));
        }

        

        public async Task<ResponseObject<DataResponseBaiViet>> SuaBaiViet(int nguoiDungId, Request_SuaBaiViet request)
        {
            try
            {
                var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
                var baiViet = await _context.baiViets.SingleOrDefaultAsync(x => x.Id == request.BaiVietId);
                if (baiViet == null)
                {
                    return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Bài viết không tồn tại", null);
                }
                if (nguoiDungId != baiViet.NguoiTaoBaiVietId)
                {
                    return _responseObject.ResponseError(StatusCodes.Status403Forbidden, "Bạn không có quyền thực hiện chức năng này", null);
                }
                baiViet.LoaiBaiVietId = request.LoaiBaiVietId;
                baiViet.MoTa = request.MoTa;
                baiViet.ThoiGianCapNhat = DateTime.Now;
                baiViet.AnhBaiViet = await HandleUploadImage.Upfile(request.AnhBaiViet);
                baiViet.TieuDe = request.TieuDe;
                baiViet.NguoiTaoBaiVietId = nguoiDungId;
                _context.SaveChanges();
                return _responseObject.ResponseSuccess("Cập nhật bài viết thành công", _baiVietConverter.EntityToDTO(baiViet));
            }catch(Exception ex)
            {
                return _responseObject.ResponseError(StatusCodes.Status500InternalServerError, ex.Message, null);
            }
        }

        

        public async Task<ResponseObject<DataResponseBaiViet>> TaoBaiViet(int nguoiDungId, Request_TaoBaiViet request)
        {
            try
            {
                var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
                if (string.IsNullOrWhiteSpace(request.TieuDe) || string.IsNullOrWhiteSpace(request.MoTa) || request.AnhBaiViet == null || request.LoaiBaiVietId == null)
                {
                    return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đầy đủ thông tin", null);
                }
                BaiViet baiViet = new BaiViet
                {
                    AnhBaiViet = await HandleUploadImage.Upfile(request.AnhBaiViet),
                    LoaiBaiVietId = request.LoaiBaiVietId,
                    MoTa = request.MoTa,
                    NguoiTaoBaiVietId = nguoiDungId,
                    SoLuotBinhLuan = 0,
                    SoLuotThich = 0,
                    ThoiGianTao = DateTime.Now,
                    TieuDe = request.TieuDe,
                    TrangThaiBaiVietId = 1
                };
                _context.baiViets.Add(baiViet);
                _context.SaveChanges();
                return _responseObject.ResponseSuccess("Tạo bài viết thành công", _baiVietConverter.EntityToDTO(baiViet));
            }catch(Exception ex)
            {
                return _responseObject.ResponseError(StatusCodes.Status500InternalServerError, ex.Message, null);
            }
        }

        

        public async Task<string> XoaBaiViet(int baiVietId)
        {
            try
            {
                var currentUser = _httpContextAccessor.HttpContext.User;
                var userId = currentUser.FindFirst("Id").Value;
                var baiViet = await _context.baiViets.SingleOrDefaultAsync(x => x.Id == baiVietId);
                if (baiViet == null)
                {
                    return "Bài viết không tồn tại";
                }
                if (baiViet.NguoiTaoBaiVietId != int.Parse(userId))
                {
                    return "Bạn không có quyền thực hiện chức năng này";
                }
                _context.baiViets.Remove(baiViet);
                _context.SaveChanges();
                return "Xóa bài viết thành công";
            }catch(Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        
        public async Task<ResponseObject<DataResponseBinhLuanBaiViet>> SuaBinhLuanBaiViet(int nguoiDungId, Request_SuaBinhLuanBaiViet request)
        {
            try
            {
                var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
                var binhLuan = await _context.binhLuanBaiViets.SingleOrDefaultAsync(x => x.Id == request.BinhLuanId);
                if (binhLuan == null)
                {
                    return _responseObjectBinhLuan.ResponseError(StatusCodes.Status404NotFound, "Bình luận không tồn tại", null);
                }
                if (string.IsNullOrWhiteSpace(request.NoiDungBinhLuan))
                {
                    return _responseObjectBinhLuan.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập bình luận", null);
                }
                if (nguoiDungId != binhLuan.NguoiBinhLuanId)
                {
                    return _responseObjectBinhLuan.ResponseError(StatusCodes.Status400BadRequest, "Bạn không có quyền sửa bình luận này", null);
                }
                binhLuan.NguoiBinhLuanId = nguoiDungId;
                binhLuan.NoiDungBinhLuan = request.NoiDungBinhLuan;
                binhLuan.ThoiGianCapNhat = DateTime.Now;
                _context.SaveChanges();
                return _responseObjectBinhLuan.ResponseSuccess("Sửa bình luận thành công", _binhLuanBaiVietConverter.EntityToDTO(binhLuan));
            }catch(Exception ex)
            {
                return _responseObjectBinhLuan.ResponseError(StatusCodes.Status500InternalServerError, ex.Message, null);
            }
        }
        public async Task<ResponseObject<DataResponseBinhLuanBaiViet>> TaoBinhLuanBaiViet(int nguoiDungId, Request_TaoBinhLuanBaiViet request)
        {
            try
            {
                var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
                if (string.IsNullOrWhiteSpace(request.NoiDungBinhLuan))
                {
                    return _responseObjectBinhLuan.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập bình luận", null);
                }
                BinhLuanBaiViet binhLuan = new BinhLuanBaiViet
                {
                    IsActive = true,
                    BaiVietId = request.BaiVietId,
                    NguoiBinhLuanId = nguoiDungId,
                    NoiDungBinhLuan = request.NoiDungBinhLuan,
                    SoLuotThich = 0,
                    SoLuotTraLoiBinhLuan = 0,
                    ThoiGianTao = DateTime.Now,
                    TrangThaiBinhLuanId = 1
                };
                _context.binhLuanBaiViets.Add(binhLuan);
                _context.SaveChanges();
                return _responseObjectBinhLuan.ResponseSuccess("Tạo bình luận thành công", _binhLuanBaiVietConverter.EntityToDTO(binhLuan));
            }catch(Exception ex)
            {
                return _responseObjectBinhLuan.ResponseError(StatusCodes.Status500InternalServerError, ex.Message, null);
            }
        }

        public async Task<ResponseObject<DataResponseBinhLuanBaiViet>> TraLoiBinhLuanBaiViet(int nguoiDungId, Request_TraLoiBinhLuanBaiViet request)
        {
            try
            {
                var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
                var binhLuanGoc = await _context.binhLuanBaiHocs.SingleOrDefaultAsync(x => x.Id == request.BinhLuanGocId);
                if (binhLuanGoc == null)
                {
                    return _responseObjectBinhLuan.ResponseError(StatusCodes.Status404NotFound, "Bình luận không tồn tại", null);
                }
                if (string.IsNullOrWhiteSpace(request.NoiDungBinhLuan))
                {
                    return _responseObjectBinhLuan.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập bình luận", null);
                }
                BinhLuanBaiViet binhLuan = new BinhLuanBaiViet
                {
                    IsActive = true,
                    BaiVietId = request.BaiHocId,
                    NguoiBinhLuanId = nguoiDungId,
                    NoiDungBinhLuan = request.NoiDungBinhLuan,
                    SoLuotThich = 0,
                    SoLuotTraLoiBinhLuan = 0,
                    ThoiGianTao = DateTime.Now,
                    TrangThaiBinhLuanId = 1,
                    BinhLuanGocId = request.BinhLuanGocId
                };
                _context.binhLuanBaiViets.Add(binhLuan);
                _context.SaveChanges();
                return _responseObjectBinhLuan.ResponseSuccess("Trả lời bình luận thành công", _binhLuanBaiVietConverter.EntityToDTO(binhLuan));
            }
            catch(Exception ex)
            {
                return _responseObjectBinhLuan.ResponseError(StatusCodes.Status500InternalServerError, ex.Message, null);
            }
        }

        public async Task<string> XoaBinhLuan(int binhLuanId)
        {
            try
            {
                var binhLuan = await _context.binhLuanBaiViets.SingleOrDefaultAsync(x => x.Id == binhLuanId);
                var currentUser = _httpContextAccessor.HttpContext.User;
                var userId = currentUser.FindFirst("Id").Value;
                if (binhLuan == null)
                {
                    return "Bình luận không tồn tại";
                }
                if (binhLuan.NguoiBinhLuanId != int.Parse(userId))
                {
                    return "Bạn không có quyền xóa bình luận này";
                }
                binhLuan.TrangThaiBinhLuanId = 2;
                binhLuan.IsActive = false;
                binhLuan.ThoiGianXoa = DateTime.Now;
                _context.SaveChanges();
                return "Xóa bình luận thành công";
            }catch(Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<string> DuyetBaiViet(int baiVietId)
        {
            try
            {
                var currentUser = _httpContextAccessor.HttpContext.User;
                if (!currentUser.Identity.IsAuthenticated)
                {
                    return "Người dùng chưa được xác thực";
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    return "Bạn không có quyền thực hiện chức năng này";
                }
                var baiViet = await _context.baiViets.SingleOrDefaultAsync(x => x.Id == baiVietId);
                if (baiViet == null)
                {
                    return "Bài viết không tồn tại";
                }
                if(baiViet.TrangThaiBaiVietId == 2)
                {
                    return "Bài viết đã được phê duyệt từ trước";
                }
                baiViet.TrangThaiBaiVietId = 2;
                _context.SaveChanges();
                return "Duyệt bài viết thành công";
            }catch(Exception ex)
            {
                return "Error: " + ex.Message;
            }

        }

        public async Task<ResponseObject<DataResponseLoaiBaiViet>> ThemLoaiBaiViet(Request_ThemLoaiBaiViet request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.TenLoaiBaiViet))
                {
                    return _responseObjectLoaiBaiViet.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền thông tin", null);
                }
                LoaiBaiViet loaiBaiViet = new LoaiBaiViet
                {
                    TenLoaiBaiViet = request.TenLoaiBaiViet
                };
                _context.loaiBaiViets.Add(loaiBaiViet);
                _context.SaveChanges();
                return _responseObjectLoaiBaiViet.ResponseSuccess("Thêm loại bài viết thành công", _loaiBaiVietConverter.EntityToDTO(loaiBaiViet));
            }catch(Exception ex)
            {
                return _responseObjectLoaiBaiViet.ResponseError(StatusCodes.Status500InternalServerError, ex.Message, null);
            }
        }
    }
}
