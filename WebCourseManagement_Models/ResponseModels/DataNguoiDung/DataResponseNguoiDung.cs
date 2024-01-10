
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;

namespace WebCourseManagement_Models.ResponseModels.DataNguoiDung
{
    public class DataResponseNguoiDung : DataResponseBase
    {
        public string TenTaiKhoan { get; set; }
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string AnhDaiDien { get; set; }
        public string Email { get; set; }
        public string TenQuyenHan { get; set; }
        public Enums.GioiTinh GioiTinh { get; set; }
        public string TenTrangThai { get; set; }
        public string TenXaPhuong { get; set; }
        public string TenQuanHuyen { get; set; }
        public string TenTinhThanh { get; set; }
        public string TenDanhMuc { get; set; }
        public string DiaChi { get; set; }
    }
}
