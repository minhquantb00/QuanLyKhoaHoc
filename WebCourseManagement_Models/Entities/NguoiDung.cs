
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;

namespace WebCourseManagement_Models.Entities
{
    public class NguoiDung : BaseEntity
    {
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string? AnhDaiDien { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime NgaySinh { get; set; }
        public int QuyenHanId { get; set; }
        public virtual QuyenHan? QuyenHan { get; set; }
        public Enums.GioiTinh GioiTinh { get; set; }
        public int TrangThaiNguoiDungId { get; set; }
        public virtual TrangThaiNguoiDung? TrangThaiNguoiDung { get; set; }
        public int? XaPhuongId { get; set; }
        public virtual XaPhuong? XaPhuong { get; set; }
        public int? QuanHuyenId { get; set; }
        public virtual QuanHuyen? QuanHuyen { get; set; }
        public int? TinhThanhId { get; set; }
        public virtual TinhThanh? TinhThanh { get; set; }
        public int? DanhMucNguoiDungId { get; set; }
        public virtual DanhMucNguoiDung? DanhMucNguoiDung { get; set; }
        public string? DiaChi { get; set; }
        public bool? DaKhoa { get; set; }
        public DateTime? ThoiGianKhoa { get; set; }
        public DateTime? ThoiGianMoKhoa { get; set; }
        public int? SoLanViPham { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
