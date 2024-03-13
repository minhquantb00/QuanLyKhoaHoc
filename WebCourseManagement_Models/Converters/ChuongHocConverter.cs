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
        private readonly BaiHocConverter _converter;
        public ChuongHocConverter(AppDbContext context, BaiHocConverter converter)
        {
            _context = context;
            _converter = converter;
        }
        public DataResponseChuongHoc EntityToDTO(ChuongHoc chuongHoc)
        {
            return new DataResponseChuongHoc
            {
                Id = chuongHoc.Id,
                SoBaiHocTrongChuong = chuongHoc.SoBaiHocTrongChuong,
                TenChuong = chuongHoc.TenChuong,
                ThoiGianCapNhat = chuongHoc.ThoiGianCapNhat,
                ThoiGianTao = chuongHoc.ThoiGianTao,
                TongThoiGianHocTrongChuong = chuongHoc.TongThoiGianHocTrongChuong,
                AnhChuongHoc = chuongHoc.AnhChuongHoc,
                BaiHocs = _context.baiHocs.Where(x => x.ChuongHocId == chuongHoc.Id).Select(x => _converter.EntityToDTO(x))
            };
        }
    }
}
