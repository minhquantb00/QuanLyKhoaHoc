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
        private readonly KhoaHocConverter _khoaHocConverter;
        public ChuongHocConverter(AppDbContext context, KhoaHocConverter khoaHocConverter)
        {
            _context = context;
            _khoaHocConverter = khoaHocConverter;
        }
        public DataResponseChuongHoc EntityToDTO(ChuongKhoaHoc chuongKhoaHoc)
        {
            return new DataResponseChuongHoc
            {
                DataKhoaHoc = _khoaHocConverter.EntityToDTO(chuongKhoaHoc.KhoaHoc),
                SoBaiHocTrongChuong = chuongKhoaHoc.SoBaiHocTrongChuong,
                TenChuong = chuongKhoaHoc.TenChuong,
                ThoiGianTao = chuongKhoaHoc.ThoiGianTao,
                TongThoiGianHoc1Chuong = chuongKhoaHoc.TongThoiGianHoc1Chuong,
                Id = chuongKhoaHoc.Id
            };
        }
    }
}
