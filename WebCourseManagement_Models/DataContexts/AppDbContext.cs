using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public AppDbContext() { }
        public DbSet<BaiHoc> baiHocs { get; set; }
        public DbSet<BaiViet> baiViets { get; set; }
        public DbSet<BaoCao> baoCaos { get; set; }
        public DbSet<BinhLuanBaiHoc> binhLuanBaiHocs { get; set; }
        public DbSet<BinhLuanBaiViet> binhLuanBaiViets { get; set; }
        public DbSet<ChuongHoc> chuongHocs { get; set; }
        public DbSet<CodeDaNgonNgu> codeDaNgonNgus { get; set; }
        public DbSet<DatCauHoi> datCauHois { get; set; }
        public DbSet<HoanThanhThucHanh> hoanThanhThucHanhs { get; set; }
        public DbSet<CauTraLoi> cauTraLois { get; set; }
        public DbSet<KhoaHoc> khoaHocs { get; set; }
        public DbSet<KhoaHocCuaNguoiDung> khoaHocCuaNguoiDungs { get; set; }
        public DbSet<LienHeAdmin> lienHeAdmins { get; set; }
        public DbSet<LoaiBaoCao> loaiBaoCaos { get; set; }
        public DbSet<LoaiKhoaHoc> loaiKhoaHocs { get; set; }
        public DbSet<NgonNgu> ngonNgus { get; set; }
        public DbSet<NguoiDung> nguoiDungs { get; set; }
        public DbSet<NguoiDungThichBaiViet> nguoiDungThichBaiViets { get; set; }
        public DbSet<NguoiDungThichBinhLuanBaiHoc> nguoiDungThichBinhLuanBaiHocs { get; set; }
        public DbSet<NguoiDungThichBinhLuanBaiViet> nguoiDungThichBinhLuanBaiViets { get; set; }
        public DbSet<QuanHuyen> quanHuyens { get; set; }
        public DbSet<QuyenHan> quyenHans { get; set; }
        public DbSet<RefreshToken> refreshTokens { get; set; }
        public DbSet<TestCase> testCases { get; set; }
        public DbSet<ThongBao> thongBaos { get; set; }
        public DbSet<ThongBaoTrangChu> thongBaoTrangChus { get; set; }
        public DbSet<ThucHanh> thucHanhs { get; set; }
        public DbSet<TinhThanh> tinhThanhs { get; set; }
        public DbSet<TrangThaiBaiHoc> trangThaiBaiHocs { get; set; }
        public DbSet<TrangThaiBaiViet> trangThaiBaiViets { get; set; }
        public DbSet<TrangThaiBinhLuan> trangThaiBinhLuans { get; set; }
        public DbSet<TrangThaiNguoiDung> trangThaiNguoiDungs { get; set; }
        public DbSet<XacNhanEmail> xacNhanEmails { get; set; }
        public DbSet<XaPhuong> xaPhuongs { get; set; }
        public DbSet<Banner> banners { get; set; }
        public DbSet<DanhGia> danhGias { get; set; }
        public DbSet<LoaiBaiViet> loaiBaiViets { get; set; }
        public DbSet<HoaDonDangKy> hoaDonDangKies { get; set; }
        public DbSet<TrangThaiHoaDon> trangThaiHoaDons { get; set; }
        public DbSet<LoaiVanDe> loaiVanDes { get; set; }
        public DbSet<NguoiDungHoanThanhBaiHoc> nguoiDungHoanThanhBaiHocs { get; set; }
        public DbSet<ChinhSachVaQuyenRiengTu> chinhSachVaQuyenRiengTus { get; set; }
    }
}
