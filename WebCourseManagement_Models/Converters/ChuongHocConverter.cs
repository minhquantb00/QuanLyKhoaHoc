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
        public ChuongHocConverter(AppDbContext context)
        {
            _context = context;
        }
        public DataResponseChuongHoc EntityToDTO(ChuongKhoaHoc chuongKhoaHoc)
        {
            return new DataResponseChuongHoc
            {
                SoBaiHocTrongChuong = chuongKhoaHoc.SoBaiHocTrongChuong,
                TenChuong = chuongKhoaHoc.TenChuong,
                ThoiGianTao = chuongKhoaHoc.ThoiGianTao,
                TongThoiGianHoc1Chuong = chuongKhoaHoc.TongThoiGianHoc1Chuong,
                Id = chuongKhoaHoc.Id
            };
        }
    }
}
