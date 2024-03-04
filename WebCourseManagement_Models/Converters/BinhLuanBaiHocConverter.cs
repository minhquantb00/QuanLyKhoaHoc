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
        private readonly BaiHocConverter _baiHocConverter;
        public BinhLuanBaiHocConverter(AppDbContext context, NguoiDungConverter nguoiDungConverter, BaiHocConverter baiHocConverter)
        {
            _context = context;
            _nguoiDungConverter = nguoiDungConverter;
            _baiHocConverter = baiHocConverter;
        }

        public DataResponseBinhLuanBaiHoc EntityToDTO(BinhLuanBaiHoc binhLuanBaiHoc)
        {
            return new DataResponseBinhLuanBaiHoc
            {
                DuongDanAnhBinhLuan = binhLuanBaiHoc.DuongDanAnhBinhLuan,
                BinhLuan = binhLuanBaiHoc.BinhLuan,
                BinhLuanGocId = binhLuanBaiHoc.BinhLuanGocId,
                DataResponseBaiHoc = _baiHocConverter.EntityToDTO(binhLuanBaiHoc.BaiHoc),
                DataResponseNguoiDung = _nguoiDungConverter.EntityToDTO(binhLuanBaiHoc.NguoiDung),
                SoLuotBinhLuanTraLoi = binhLuanBaiHoc.SoLuotBinhLuanTraLoi,
                SoLuotLike = binhLuanBaiHoc.SoLuotLike,
                ThoiGianCapNhat = binhLuanBaiHoc.ThoiGianCapNhat,
                ThoiGianTao = binhLuanBaiHoc.ThoiGianTao,
                ThoiGianXoa = binhLuanBaiHoc.ThoiGianXoa
            };
        }
    }
}
