﻿using Microsoft.AspNetCore.Http;
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
using WebCourseManagement_Models.RequestModels.BaiHocRequests;
using WebCourseManagement_Models.RequestModels.InputRequests;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Implements
{
    public class BaiHocService : IBaiHocService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseBaiHoc> _responseObject;
        private readonly BaiHocConverter _converter;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaiHocService(AppDbContext context, BaiHocConverter converter, ResponseObject<DataResponseBaiHoc> responseObject, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _responseObject = responseObject;
            _converter = converter;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<PageResult<DataResponseBaiHoc>> GetAlls(InputBaiHoc input, int pageSize, int pageNumber)
        {
            var query = _context.baiHocs.ToList();
            if(input.ChuongHocId.HasValue)
            {
                query = query.Where(x => x.ChuongHocId == input.ChuongHocId).ToList();
            }
            var result = Pagination.GetPagedData(query.Select(x => _converter.EntityToDTO(x)).AsQueryable(), pageSize, pageNumber);
            return result;
        }

        public async Task<ResponseObject<DataResponseBaiHoc>> GetBaiHocById(int baiHocId)
        {
            var baiHoc = await _context.baiHocs.SingleOrDefaultAsync(x => x.Id == baiHocId);
            if(baiHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy bài học", null);
            }
            return _responseObject.ResponseSuccess("Lấy dữ liệu thành công", _converter.EntityToDTO(baiHoc));
        }

        public async Task<ResponseObject<DataResponseBaiHoc>> ThemBaiHoc(Request_ThemBaiHoc request)
        {
            var chuongHoc = await _context.chuongHocs.SingleOrDefaultAsync(x => x.Id == request.ChuongHocId);
            var currentUser = _httpContextAccessor.HttpContext.User;
            var khoaHoc = _context.khoaHocs.SingleOrDefault(x => x.Id == chuongHoc.KhoaHocId);
            var userId = currentUser.FindFirst("Id").Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                return _responseObject.ResponseError(StatusCodes.Status401Unauthorized, "Người dùng chưa được xác thực", null);
            }
            if(khoaHoc.NguoiTaoId != int.Parse(userId))
            {
                return _responseObject.ResponseError(StatusCodes.Status403Forbidden, "Bạn không có quyền thực hiện chức năng này", null);
            }
            if(chuongHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy chương học", null);
            }
            BaiHoc baiHoc = new BaiHoc
            {
                ChuongHocId = request.ChuongHocId,
                MoTaBaiHoc = request.MoTaBaiHoc,
                TenBaiHoc = request.TenBaiHoc,
                ThoiGianTao = DateTime.Now,
                ThoiLuongVideo = request.ThoiLuongVideo,
                TrangThaiBaiHocId = 1,
                VideoBaiHoc = request.VideoBaiHoc
            };
            _context.baiHocs.Add(baiHoc);
            _context.SaveChanges();
            chuongHoc.SoBaiHocTrongChuong = _context.baiHocs.Count(x => x.ChuongHocId == request.ChuongHocId);
            chuongHoc.TongThoiGianHocTrongChuong += baiHoc.ThoiLuongVideo;
            _context.chuongHocs.Update(chuongHoc);
            _context.SaveChanges();
            khoaHoc.TongThoiGianKhoaHoc = chuongHoc.TongThoiGianHocTrongChuong;
            _context.SaveChanges();
            return _responseObject.ResponseSuccess("Thêm bài học thành công", _converter.EntityToDTO(baiHoc));
        }
        public async Task<ResponseObject<DataResponseBaiHoc>> SuaThongTinBaiHoc(Request_CapNhatThongTinBaiHoc request)
        {
            var chuongHoc = await _context.chuongHocs.SingleOrDefaultAsync(x => x.Id == request.ChuongHocId);
            var currentUser = _httpContextAccessor.HttpContext.User;
            
            var userId = currentUser.FindFirst("Id").Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                return _responseObject.ResponseError(StatusCodes.Status401Unauthorized, "Người dùng chưa được xác thực", null);
            }
            if (chuongHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy chương học", null);
            }
            var khoaHoc = _context.khoaHocs.SingleOrDefault(x => x.Id == chuongHoc.KhoaHocId);
            if (khoaHoc.NguoiTaoId != int.Parse(userId))
            {
                return _responseObject.ResponseError(StatusCodes.Status403Forbidden, "Bạn không có quyền thực hiện chức năng này", null);
            }
            var baiHoc = await _context.baiHocs.SingleOrDefaultAsync(x => x.Id  == request.BaiHocId);
            if(baiHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy bài học", null);
            }
            baiHoc.MoTaBaiHoc = request.MoTaBaiHoc;
            baiHoc.VideoBaiHoc = request.VideoBaiHoc;
            baiHoc.TenBaiHoc = request.TenBaiHoc;
            baiHoc.ChuongHocId = request.ChuongHocId;
            baiHoc.ThoiGianCapNhat = DateTime.Now;
            baiHoc.ThoiLuongVideo = request.ThoiLuongVideo;
            _context.baiHocs.Update(baiHoc);
            _context.SaveChanges();
            chuongHoc.SoBaiHocTrongChuong = _context.baiHocs.Count(x => x.ChuongHocId == request.ChuongHocId);
            chuongHoc.TongThoiGianHocTrongChuong += baiHoc.ThoiLuongVideo;
            _context.chuongHocs.Update(chuongHoc);
            _context.SaveChanges();
            khoaHoc.TongThoiGianKhoaHoc = chuongHoc.TongThoiGianHocTrongChuong;
            _context.SaveChanges();
            return _responseObject.ResponseSuccess("Cập nhật thông tin bài học thành công", _converter.EntityToDTO(baiHoc));
        }

        public async Task<string> XoaBaiHoc(int baiHocId)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            var baiHoc = await _context.baiHocs.SingleOrDefaultAsync(x => x.Id == baiHocId);
            var userId = currentUser.FindFirst("Id").Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                return "Người dùng chưa được xác thực";
            }
            if (baiHoc == null)
            {
                return "Không tìm thấy bài học";
            }
            var chuongHoc = baiHoc?.ChuongHoc;
            var khoaHoc = chuongHoc?.KhoaHoc;
            if (khoaHoc.NguoiTaoId != int.Parse(userId))
            {
                return "Bạn không có quyền thực hiện chức năng này";
            }
            int thoiLuong = baiHoc.ThoiLuongVideo;
            _context.baiHocs.Remove(baiHoc);
            _context.SaveChanges();
            chuongHoc.SoBaiHocTrongChuong = _context.baiHocs.Count(x => x.ChuongHocId == chuongHoc.Id);
            chuongHoc.TongThoiGianHocTrongChuong -= thoiLuong;
            _context.chuongHocs.Update(chuongHoc);
            _context.SaveChanges();
            khoaHoc.TongThoiGianKhoaHoc = chuongHoc.TongThoiGianHocTrongChuong;
            _context.SaveChanges();
            return "Xóa bài học thành công";
        }
    }
}
