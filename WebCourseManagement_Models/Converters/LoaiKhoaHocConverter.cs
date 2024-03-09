using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataLoaiKhoaHoc;

namespace WebCourseManagement_Models.Converters
{
    public class LoaiKhoaHocConverter
    {
        private readonly AppDbContext _context;
        private readonly KhoaHocConverter _converter;
        public LoaiKhoaHocConverter(AppDbContext context, KhoaHocConverter converter)
        {
            _context = context;
            _converter = converter;
        }
        public DataResponseLoaiKhoaHoc EntityToDTO(LoaiKhoaHoc loaiKhoaHoc)
        {
            return new DataResponseLoaiKhoaHoc
            {
                Id = loaiKhoaHoc.Id,
                TenLoaiKhoaHoc = loaiKhoaHoc.TenLoaiKhoaHoc,
                DataResponseKhoaHocs = _context.khoaHocs.Where(x => x.LoaiKhoaHocId == loaiKhoaHoc.Id).Select(x => _converter.EntityToDTO(x))
            };
        }
    }
}
