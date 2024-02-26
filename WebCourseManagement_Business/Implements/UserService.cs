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
using WebCourseManagement_Models.RequestModels.InputRequests;
using WebCourseManagement_Models.RequestModels.UserRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Implements
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungConverter _converter;
        private readonly ResponseObject<DataResponseNguoiDung> _responseObject;
        public UserService(AppDbContext context, NguoiDungConverter converter, ResponseObject<DataResponseNguoiDung> responseObject)
        {
            _context = context;
            _converter = converter;
            _responseObject = responseObject;
        }

        public Task<ResponseObject<DataResponseNguoiDung>> CapNhatThongTinNguoiDung(Request_CapNhatThongTinNguoiDung request)
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<DataResponseNguoiDung>> GetAlls(InputUser input, int pageSize, int pageNumber)
        {
            var query = await _context.nguoiDungs.Where(x => x.TrangThaiNguoiDungId == 2 && x.DaKhoa == false).ToListAsync();
            if (!string.IsNullOrEmpty(input.HoVaTen))
            {
                query = query.Where(x => x.HoVaTen.ToLower().Contains(input.HoVaTen.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(input.Email))
            {
                query = query.Where(x => x.Email.ToLower().Equals(input.Email.ToLower())).ToList();
            }
            if(!string.IsNullOrEmpty(input.SoDienThoai))
            {
                query = query.Where(x => x.SoDienThoai.Equals(input.SoDienThoai)).ToList();
            }
            if (input.QuyenHanId.HasValue)
            {
                query = query.Where(x => x.QuyenHanId == input.QuyenHanId).ToList();
            }
            var result = Pagination.GetPagedData(query.Select(x => _converter.EntityToDTO(x)).AsQueryable(), pageSize, pageNumber);
            return result;
        }

        public async Task<ResponseObject<DataResponseNguoiDung>> GetUserById(int nguoiDungId)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId && x.TrangThaiNguoiDungId == 2 && x.DaKhoa == false);
            if(nguoiDung == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Người dùng không tồn tại", null);
            }
            return _responseObject.ResponseSuccess("Lấy dữ liệu thành công", _converter.EntityToDTO(nguoiDung));
        }
    }
}
