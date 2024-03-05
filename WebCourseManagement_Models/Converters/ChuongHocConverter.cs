using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataChuongHoc;

namespace WebCourseManagement_Models.Converters
{
    public class ChuongHocConverter
    {
        private readonly AppDbContext _context;
        private readonly BaiHocConverter _baiHocConverter;
        public ChuongHocConverter(AppDbContext context, BaiHocConverter baiHocConverter)
        {
            _context = context;
            _baiHocConverter = baiHocConverter;
        }
        public DataResponseChuongHoc EntityToDTO(ChuongKhoaHoc chuongKhoaHoc)
        {
            var chuongHocItem = _context.chuongKhoaHocs.Include(x => x.BaiHocs).SingleOrDefault(x => x.Id == chuongKhoaHoc.Id);
            return new DataResponseChuongHoc
            {
                SoBaiHocTrongChuong = chuongKhoaHoc.SoBaiHocTrongChuong,
                TenChuong = chuongKhoaHoc.TenChuong,
                ThoiGianTao = chuongKhoaHoc.ThoiGianTao,
                TongThoiGianHoc1Chuong = chuongKhoaHoc.TongThoiGianHoc1Chuong,
                Id = chuongKhoaHoc.Id,
                DataResponseBaiHocs = chuongHocItem.BaiHocs.Select(x => _baiHocConverter.EntityToDTO(x)).AsQueryable()
            };
        }
    }
}
