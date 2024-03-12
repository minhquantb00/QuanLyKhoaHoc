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
using WebCourseManagement_Models.RequestModels.NguoiDungThichBinhLuanBaiHocRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDungThichBinhLuanBaiHoc;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Implements
{
    public class ThichBinhLuanBaiHocService : IThichBinhLuanBaiHocService
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungThichBinhLuanBaihocConverter _converter;
        private readonly ResponseObject<DataResponseNguoiDungThichBinhLuanBaiHoc> _responseObject;
        public ThichBinhLuanBaiHocService(AppDbContext context, NguoiDungThichBinhLuanBaihocConverter converter, ResponseObject<DataResponseNguoiDungThichBinhLuanBaiHoc> responseObject)
        {
            _context = context;
            _converter = converter;
            _responseObject = responseObject;
        }

        public async Task<string> ThichBinhLuanBaiHoc(int nguoiDungId, Request_ThichBinhLuanBaiHoc request)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
            var binhLuan = await _context.binhLuanBaiHocs.SingleOrDefaultAsync(x => x.Id == request.BinhLuanBaiHocId);
            if(binhLuan == null)
            {
                return "Bình luận không tồn tại";
            }
            var nguoiLike = await _context.nguoiDungThichBinhLuanBaiHocs.SingleOrDefaultAsync(x => x.NguoiDungThichBinhLuanId == nguoiDungId && x.BinhLuanBaiHocId == binhLuan.Id);
            if (binhLuan != null)
            {
                _context.nguoiDungThichBinhLuanBaiHocs.Remove(nguoiLike);
                _context.SaveChanges();
            }
            else
            {
                NguoiDungThichBinhLuanBaiHoc item = new NguoiDungThichBinhLuanBaiHoc
                {
                    BinhLuanBaiHocId = request.BinhLuanBaiHocId,
                    DaThich = true,
                    NguoiDungThichBinhLuanId = nguoiDungId,
                    ThoiGianThich = DateTime.Now
                };
                _context.nguoiDungThichBinhLuanBaiHocs.Add(item);
                _context.SaveChanges();
            }
            
            binhLuan.SoLuotThich = _context.nguoiDungThichBinhLuanBaiHocs.Count(x => x.BinhLuanBaiHocId == request.BinhLuanBaiHocId);
            _context.SaveChanges();
            return "Bạn đã thích bình luận bài học";
        }
    }
}
