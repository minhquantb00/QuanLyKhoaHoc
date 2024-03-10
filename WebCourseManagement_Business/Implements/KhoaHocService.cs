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
using WebCourseManagement_Models.ResponseModels.DataHoaDon;
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
        private readonly ResponseObject<DataResponseHoaDon> _responseObjectHoaDon;
        private readonly HoaDonConverter _hoaDonConverter;
        public KhoaHocService(AppDbContext context, KhoaHocConverter converter, ResponseObject<DataResponseKhoaHoc> responseObject, IHttpContextAccessor httpContextAccessor, HoaDonConverter hoaDonConverter, ResponseObject<DataResponseHoaDon> responseObjectHoaDon)
        {
            _context = context;
            _responseObject = responseObject;
            _converter = converter;
            _httpContextAccessor = httpContextAccessor;
            _hoaDonConverter = hoaDonConverter;
            _responseObjectHoaDon = responseObjectHoaDon;
        }
        public async Task<PageResult<DataResponseKhoaHoc>> GetAlls(int pageSize, int pageNumber)
        {
            var query = _context.khoaHocs.Select(x => _converter.EntityToDTO(x));
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }

        public async Task<ResponseObject<DataResponseKhoaHoc>> GetKhoaHocById(int khoaHocId)
        {
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id  == khoaHocId);
            if (khoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy khóa học", null);
            }
            return _responseObject.ResponseSuccess("Lấy dữ liệu thành công", _converter.EntityToDTO(khoaHoc));
        }

        public async Task<ResponseObject<DataResponseKhoaHoc>> ThemKhoaHoc(int nguoiTaoId, Request_ThemKhoaHoc request)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiTaoId);
            var loaiKhoaHoc = await _context.loaiKhoaHocs.SingleOrDefaultAsync(x => x.Id == request.LoaiKhoaHocId);
            if(loaiKhoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy loại khóa học", null);
            }
            KhoaHoc khoaHoc = new KhoaHoc
            {
                AnhKhoaHoc = await HandleUploadImage.Upfile(request.AnhKhoaHoc),
                IsActive = true,
                DaXoa = false,
                GiaKhoaHoc = request.GiaKhoaHoc,
                LoaiKhoaHocId = request.LoaiKhoaHocId,
                PhanTramGiamGia = request.PhanTramGiamGia == 0 ? 0 : request.PhanTramGiamGia,
                GiaKhoaHocThucTe = request.PhanTramGiamGia == 0 ? request.GiaKhoaHoc : request.GiaKhoaHoc * request.PhanTramGiamGia,
                MoTaKhoaHoc = request.MoTaKhoaHoc,
                NgayTao = DateTime.Now,
                NguoiTaoId = nguoiTaoId,
                SoHocVienDaHoanThanh = 0,
                TieuDeKhoaHoc = request.TieuDeKhoaHoc,
                TongThoiGianKhoaHoc = 0
            };
            _context.khoaHocs.Add(khoaHoc);
            _context.SaveChanges();
            return _responseObject.ResponseSuccess("Thêm khóa học thành công", _converter.EntityToDTO(khoaHoc));
        }
        public async Task<ResponseObject<DataResponseKhoaHoc>> SuaThongTinKhoaHoc(int nguoiSuaId, Request_SuaThongTinKhoaHoc request)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiSuaId);
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == request.KhoaHocId);
            var loaiKhoaHoc = await _context.loaiKhoaHocs.SingleOrDefaultAsync(x => x.Id == request.LoaiKhoaHocId);
            if(khoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy khóa học", null);
            }
            if(loaiKhoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy loại khóa học", null);
            }
            if(nguoiSuaId != khoaHoc.NguoiTaoId)
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Bạn không có quyền thực hiện chức năng này", null);
            }
            khoaHoc.MoTaKhoaHoc = request.MoTaKhoaHoc;
            khoaHoc.AnhKhoaHoc = await HandleUploadImage.Upfile(request.AnhKhoaHoc);
            khoaHoc.NgayCapNhat = DateTime.Now;
            khoaHoc.GiaKhoaHocThucTe = request.PhanTramGiamGia == 0 ? request.GiaKhoaHoc : request.GiaKhoaHoc * request.PhanTramGiamGia;
            khoaHoc.PhanTramGiamGia = request.PhanTramGiamGia == 0 ? 0 : request.PhanTramGiamGia;
            khoaHoc.GiaKhoaHoc = request.GiaKhoaHoc;
            khoaHoc.LoaiKhoaHocId = request.LoaiKhoaHocId;
            khoaHoc.TieuDeKhoaHoc = request.TieuDeKhoaHoc;
            _context.SaveChanges();
            return _responseObject.ResponseSuccess("Cập nhật thông tin khóa học thành công", _converter.EntityToDTO(khoaHoc));
        }


        public async Task<string> XoaKhoaHoc(int khoaHocId)
        {
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == khoaHocId);
            var currentUser = _httpContextAccessor.HttpContext.User;
            var userId = currentUser.FindFirst("Id").Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                return "Người dùng chưa được xác thực";
            }
            if(khoaHoc == null)
            {
                return "Khóa học không tồn tại";
            }
            if(int.Parse(userId) != khoaHoc.NguoiTaoId)
            {
                return "Bạn không có quyền thực hiện chức năng này";
            }
            _context.khoaHocs.Remove(khoaHoc);
            _context.SaveChanges();
            return "Xóa khóa học thành công";
        }

        public async Task<ResponseObject<DataResponseHoaDon>> DangKyKhoaHoc(int nguoiDungId, Request_DangKyKhoaHoc request)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == request.KhoaHocId);
            if(khoaHoc == null)
            {
                return _responseObjectHoaDon.ResponseError(StatusCodes.Status404NotFound, "Khóa học không tồn tại", null);
            }
            HoaDonDangKy hoaDon = new HoaDonDangKy
            {
                KhoaHocId = request.KhoaHocId,
                MaGiaoDich = "MyBugs_" + DateTime.Now.Ticks.ToString() + new Random().Next(10000,99999).ToString(),
                NguoiDungId = nguoiDungId,
                ThoiGianTao = DateTime.Now,
                TongTien = khoaHoc.GiaKhoaHocThucTe,
                TrangThaiHoaDonId = 1
            };
            _context.hoaDonDangKies.Add(hoaDon);
            _context.SaveChanges();
            return _responseObjectHoaDon.ResponseSuccess("Đã hoàn tất yêu cầu đăng ký khóa học! Vui lòng thanh toán", _hoaDonConverter.EntityToDTO(hoaDon));
        }
    }
}
