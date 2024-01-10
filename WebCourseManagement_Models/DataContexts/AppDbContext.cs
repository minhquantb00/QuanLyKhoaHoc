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
        public DbSet<Blog> blogs { get; set; }
        public DbSet<ChuongKhoaHoc> chuongKhoaHocs { get; set; }
        public DbSet<ChuyenNganh> chuyenNganhs { get; set; }
        public DbSet<CodeDaNgonNgu> codeDaNgonNgus { get; set; }
        public DbSet<DanhHieu> danhHieus { get; set; }
        public DbSet<DanhHieuNguoiDung> danhHieuNguoiDungs { get; set; }
        public DbSet<DanhMucNguoiDung> danhMucNguoiDungs { get; set; }
        public DbSet<DatCauHoi> datCauHois { get; set; }
        public DbSet<DiemKiemTraBaiHocCuaNguoiDung> diemKiemTraBaiHocCuaNguoiDungs { get; set; }
        public DbSet<HoanThanhThucHanh> hoanThanhThucHanhs { get; set; }
        public DbSet<HoanThanhTraLoiCauHoi> hoanThanhTraLoiCauHois { get; set; }
        public DbSet<KhoaHoc> khoaHocs { get; set; }
        public DbSet<KhoaHocCuaNguoiDung> khoaHocCuaNguoiDungs { get; set; }
        public DbSet<KinhNghiem> kinhNghiems { get; set; }
        public DbSet<KinhNghiemHocTap> kinhNghiemHocTaps { get; set; }
        public DbSet<LienHe> lienHes { get; set; }
        public DbSet<LoaiBaiHoc> loaiBaiHocs { get; set; }
        public DbSet<LoaiBaoCao> loaiBaoCaos { get; set; }
        public DbSet<LoaiBlog> loaiBlogs { get; set; }
        public DbSet<LoaiKhoaHoc> loaiKhoaHocs { get; set; }
        public DbSet<LoaiTruongHoc> loaiTruongHocs { get; set; }
        public DbSet<NgonNgu> ngonNgus { get; set; }
        public DbSet<NguoiDung> nguoiDungs { get; set; }
        public DbSet<NguoiDungGhiChuBaiHoc> nguoiDungGhiChus { get; set; }
        public DbSet<NguoiDungThichBaiViet> nguoiDungThichBaiViets { get; set; }
        public DbSet<NguoiDungThichBinhLuanBaiHoc> nguoiDungThichBinhLuanBaiHocs { get; set; }
        public DbSet<NguoiDungThichBinhLuanBaiViet> nguoiDungThichBinhLuanBaiViets { get; set; }
        public DbSet<NoiDungTrangChu> noiDungTrangChus { get; set; }
        public DbSet<PhanHoc> phanHocs { get; set; }
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
        public DbSet<TrangThaiBlog> trangThaiBlogs { get; set; }
        public DbSet<TrangThaiKhoaHoc> trangThaiKhoaHocs { get; set; }
        public DbSet<TrangThaiNguoiDung> trangThaiNguoiDungs { get; set; }
        public DbSet<TruongHoc> truongHocs { get; set; }
        public DbSet<VideoBaiGiang> videoBaiGiangs { get; set; }
        public DbSet<VideoHoanThanh> videoHoanThanhs { get; set; }
        public DbSet<XacNhanEmail> xacNhanEmails { get; set; }
        public DbSet<XaPhuong> xaPhuongs { get; set; }
    }
}
