﻿using Microsoft.AspNetCore.Http;
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
using WebCourseManagement_Models.RequestModels.ChuongKhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataChuongHoc;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Implements
{
    public class ChuongKhoaHocService : IChuongKhoaHocService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseChuongHoc> _responseObject;
        private readonly ChuongHocConverter _converter;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ChuongKhoaHocService(AppDbContext context, ResponseObject<DataResponseChuongHoc> responseObject, ChuongHocConverter converter, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _responseObject = responseObject;
            _converter = converter;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseObject<DataResponseChuongHoc>> ThemChuongHoc(Request_ThemChuongKhoaHoc request)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == request.KhoaHocId);
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
               return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Người dùng không được xác thực hoặc không được xác định", null);
            }
            if(khoaHoc.NguoiTaoId != int.Parse(userId))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Người dùng không có quyền sử dụng chức năng này", null);
            }

            if(khoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Khóa học không tồn tại", null);
            }

            ChuongKhoaHoc chuongKhoaHoc = new ChuongKhoaHoc
            {
                KhoaHocId = request.KhoaHocId,
                SoBaiHocTrongChuong = 0,
                TenChuong = request.TenChuong,
                ThoiGianTao = DateTime.Now,
                TongThoiGianHoc1Chuong = 0
            };
            await _context.chuongKhoaHocs.AddAsync(chuongKhoaHoc);
            await _context.SaveChangesAsync();
            return _responseObject.ResponseSuccess("Thêm chương học thành công", _converter.EntityToDTO(chuongKhoaHoc));
        }
    }
}
