using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataHoaDon
{
    public class DataResponseHoaDon : DataResponseBase
    {
        public decimal? TongTien { get; set; }
        public string MaGiaoDich { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DataResponseNguoiDung NguoiDung { get; set; }
        public DataResponseKhoaHoc KhoaHoc { get; set; }
        public string TenTrangThai { get; set; }
    }
}
