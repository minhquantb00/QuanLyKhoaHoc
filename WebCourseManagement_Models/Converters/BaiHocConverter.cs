using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;

namespace WebCourseManagement_Models.Converters
{
    public class BaiHocConverter
    {
        private readonly AppDbContext _context;
        private readonly BinhLuanBaiHocConverter _binhLuanBaiHocConverter;
        public BaiHocConverter(AppDbContext context, BinhLuanBaiHocConverter binhLuanBaiHocConverter)
        {
            _context = context;
            _binhLuanBaiHocConverter = binhLuanBaiHocConverter;
        }
        public DataResponseBaiHoc EntityToDTO(BaiHoc baiHoc)
        {
            return new DataResponseBaiHoc()
            {
                MoTaBaiHoc = baiHoc.MoTaBaiHoc,
                TenBaiHoc = baiHoc.TenBaiHoc,
                ThoiGianCapNhat = baiHoc.ThoiGianCapNhat,
                ThoiGianTao = baiHoc.ThoiGianTao,
                ThoiLuongVideo = baiHoc.ThoiLuongVideo,
                DataResponseBinhLuanBaiHocs = baiHoc.BinhLuanBaiHocs.Select(x => _binhLuanBaiHocConverter.EntityToDTO(x)).AsQueryable(),
            };
        }
    }
}
