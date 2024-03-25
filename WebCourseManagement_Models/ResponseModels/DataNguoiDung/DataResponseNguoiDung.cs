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
        public string? GioiThieuBanThan { get; set; }
        public string? MoTaBanThan { get; set; }
        public string? ChungNhan { get; set; }
        public string? BietDanh { get; set; }
        public string? LinkYoutube { get; set; }
        public string? LinkFacebook { get; set; }
        public string? LinkInstagram { get; set; }
        public string TenTrangThaiTaiKhoan { get; set; }
        public string DaKhoaChua { get; set; }
        public int? SoLanViPham { get; set; }
        public string IsActive { get; set; }
    }
}
