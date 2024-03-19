using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;

namespace WebCourseManagement_Models.Entities
{
    public class NguoiDung : BaseEntity
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string? AnhDaiDien { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int QuyenHanId { get; set; }
        public string? GioiThieuBanThan { get; set; }
        public string? MoTaBanThan { get; set; }
        public string? ChungNhan { get;set; }
        public string? BietDanh { get; set; }
        public string? LinkYoutube { get; set; }
        public string? LinkFacebook { get; set; }
        public string? LinkInstagram { get; set; }
        public virtual QuyenHan? QuyenHan { get; set; }
        public Enums.GioiTinh GioiTinh { get; set; }
        public int TrangThaiNguoiDungId { get; set; }
        public virtual TrangThaiNguoiDung? TrangThaiNguoiDung { get; set; }
        public int? XaPhuongId { get; set; }
        public virtual XaPhuong? XaPhuong { get; set; }
        public int? QuanHuyenId { get; set; }
        public virtual QuanHuyen? QuanHuyen { get; set; }
        public int? TinhThanhId { get; set; }
        public virtual TinhThanh TinhThanh { get; set; }
        public string? DiaChi { get; set; }
        public bool? DaKhoa { get; set; } = false;
        public DateTime? ThoiGianKhoa { get; set; }
        public DateTime? ThoiGianMoKhoa { get; set; }
        public int? SoLanViPham { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<ThongBao>? ThongBaos { get; set; }
        public virtual ICollection<KhoaHocCuaNguoiDung>? KhoaHocCuaNguoiDungs { get; set; }
        public virtual ICollection<BaiViet>? BaiViets { get; set; }
        public virtual ICollection<BaoCao>? BaoCaos { get; set; }
        public virtual ICollection<HoanThanhThucHanh>? HoanThanhThucHanhs { get; set; }
        public virtual ICollection<LienHeAdmin>? LienHeAdmins { get; set; }
        public virtual ICollection<NguoiDungThichBaiViet>? NguoiDungThichBaiViets { get; set; }
        public virtual ICollection<NguoiDungThichBinhLuanBaiHoc>? NguoiDungThichBinhLuanBaiHocs { get; set; }
        public virtual ICollection<NguoiDungThichBinhLuanBaiViet>? NguoiDungThichBinhLuanBaiViets { get; set; }
        public virtual ICollection<BinhLuanBaiHoc>? BinhLuanBaiHocs { get; set; }
        public virtual ICollection<BinhLuanBaiViet>? BinhLuanBaiViets { get; set; }
        public virtual ICollection<CauTraLoi>? CauTraLois { get; set; }
    }
}
