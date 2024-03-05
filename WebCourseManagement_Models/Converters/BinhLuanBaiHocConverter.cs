using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc;

namespace WebCourseManagement_Models.Converters
{
    public class BinhLuanBaiHocConverter
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungConverter _nguoiDungConverter;
        public BinhLuanBaiHocConverter(AppDbContext context, NguoiDungConverter nguoiDungConverter)
        {
            _context = context;
            _nguoiDungConverter = nguoiDungConverter;
        }

        public DataResponseBinhLuanBaiHoc EntityToDTO(BinhLuanBaiHoc binhLuanBaiHoc)
        {
            var binhLuanItem = _context.binhLuanBaiHocs.Include(x => x.NguoiDung).SingleOrDefault(x => x.Id == binhLuanBaiHoc.Id);
            return new DataResponseBinhLuanBaiHoc
            {
                DuongDanAnhBinhLuan = binhLuanBaiHoc.DuongDanAnhBinhLuan,
                BinhLuan = binhLuanBaiHoc.BinhLuan,
                BinhLuanGocId = binhLuanBaiHoc.BinhLuanGocId,
                DataResponseNguoiDung = _nguoiDungConverter.EntityToDTO(binhLuanItem.NguoiDung),
                SoLuotBinhLuanTraLoi = binhLuanBaiHoc.SoLuotBinhLuanTraLoi,
                SoLuotLike = binhLuanBaiHoc.SoLuotLike,
                ThoiGianCapNhat = binhLuanBaiHoc.ThoiGianCapNhat,
                ThoiGianTao = binhLuanBaiHoc.ThoiGianTao,
                ThoiGianXoa = binhLuanBaiHoc.ThoiGianXoa
            };
        }
    }
}
