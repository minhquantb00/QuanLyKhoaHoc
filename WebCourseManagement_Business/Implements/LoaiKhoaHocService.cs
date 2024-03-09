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
using WebCourseManagement_Models.RequestModels.LoaiKhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataLoaiKhoaHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Implements
{
    public class LoaiKhoaHocService : ILoaiKhoaHocService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseLoaiKhoaHoc> _responseObject;
        private readonly LoaiKhoaHocConverter _converter;
        public LoaiKhoaHocService(AppDbContext context, LoaiKhoaHocConverter converter, ResponseObject<DataResponseLoaiKhoaHoc> responseObject)
        {
            _context = context;
            _responseObject = responseObject;
            _converter = converter;
        }
        public async Task<ResponseObject<DataResponseLoaiKhoaHoc>> CapNhatThongTinLoaiKhoaHoc(Request_SuaLoaiKhoaHoc request)
        {
            var loaiKhoaHoc = await _context.loaiKhoaHocs.SingleOrDefaultAsync(x => x.Id == request.LoaiKhoaHocId);
            if(loaiKhoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy loại khóa học", null);
            }
            if (string.IsNullOrWhiteSpace(request.TenLoaiKhoaHoc))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đầy đủ thông tin", null);
            }
            loaiKhoaHoc.TenLoaiKhoaHoc = request.TenLoaiKhoaHoc;
            _context.SaveChanges();
            return _responseObject.ResponseSuccess("Cập nhật thông tin loại khóa học thành công", _converter.EntityToDTO(loaiKhoaHoc));
        }

        public async Task<PageResult<DataResponseLoaiKhoaHoc>> GetAlls(int pageSize, int pageNumber)
        {
            var query = _context.loaiKhoaHocs.AsQueryable();
            var result = Pagination.GetPagedData(query.Select(x => _converter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<ResponseObject<DataResponseLoaiKhoaHoc>> ThemLoaiKhoaHoc(Request_ThemLoaiKhoaHoc request)
        {
            if (string.IsNullOrWhiteSpace(request.TenLoaiKhoaHoc))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đầy đủ thông tin", null);
            }
            LoaiKhoaHoc loaiKhoaHoc = new LoaiKhoaHoc
            {
                TenLoaiKhoaHoc = request.TenLoaiKhoaHoc
            };
            _context.loaiKhoaHocs.Add(loaiKhoaHoc);
            _context.SaveChanges();
            return _responseObject.ResponseSuccess("Thêm loại khóa học thành công", _converter.EntityToDTO(loaiKhoaHoc));
        }

        public async Task<string> XoaLoaiKhoaHoc(int loaiKhoaHocId)
        {
            var loaiKhoaHoc = await _context.loaiKhoaHocs.SingleOrDefaultAsync(x => x.Id == loaiKhoaHocId);
            if(loaiKhoaHoc == null)
            {
                return "Loại khóa học không tồn tại";
            }
            _context.loaiKhoaHocs.Remove(loaiKhoaHoc);
            _context.SaveChanges();
            return "Xóa loại khóa học thành công";
        }
    }
}
