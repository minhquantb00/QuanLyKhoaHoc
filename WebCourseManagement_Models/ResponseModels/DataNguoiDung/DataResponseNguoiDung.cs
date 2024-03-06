using WebCourseManagement_Commons.Enumerates;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.ResponseModels.DataNguoiDung
{
    public class DataResponseNguoiDung : DataResponseBase
    {
        public string TaiKhoan { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string? AnhDaiDien { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string? DiaChi { get; set; }
    }
}
