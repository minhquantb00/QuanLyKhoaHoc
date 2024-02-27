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
        public KhoaHocService(AppDbContext context, ResponseObject<DataResponseKhoaHoc> responseObject, KhoaHocConverter converter)
        {
            _context = context;
            _responseObject = responseObject;
            _converter = converter;
        }

        public async Task<ResponseObject<DataResponseKhoaHoc>> ThemKhoaHoc(int nguoiTaoId, Request_ThemKhoaHoc request)
        {
            var loaiKhoaHoc = await _context.loaiKhoaHocs.SingleOrDefaultAsync(x => x.Id == request.LoaiKhoaHocId);
            if(loaiKhoaHoc == null)
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
                TrangThaiKhoaHocId = 1
            };
            await _context.khoaHocs.AddAsync(khoaHoc);
            await _context.SaveChangesAsync();
            return _responseObject.ResponseSuccess("Thêm khóa học thành công", _converter.EntityToDTO(khoaHoc));
        }
    }
}
