using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chuyenNganhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuyenNganh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chuyenNganhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "danhHieus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanhHieu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danhHieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "danhMucNguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danhMucNguoiDungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiBaiHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiBaiHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiBaoCaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiBaoCao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiBaoCaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiBlog = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiBlogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiKhoaHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiKhoaHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiTruongHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiTruongHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ngonNgus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNgonNgu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ngonNgus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "noiDungTrangChus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slide1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slide2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slide3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slide4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slide5 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_noiDungTrangChus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "quyenHans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenQuyenHan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quyenHans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tinhThanhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTinhThanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTinhThanhEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tinhThanhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trangThaiBaiHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trangThaiBaiHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trangThaiBaiViets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trangThaiBaiViets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trangThaiBinhLuans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trangThaiBinhLuans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trangThaiBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThaiBlog = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trangThaiBlogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trangThaiKhoaHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trangThaiKhoaHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trangThaiNguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trangThaiNguoiDungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "truongHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTruongHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiTruongHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_truongHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_truongHocs_loaiTruongHocs_LoaiTruongHocId",
                        column: x => x.LoaiTruongHocId,
                        principalTable: "loaiTruongHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quanHuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenQuanHuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenQuanHuyenEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhThanhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quanHuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quanHuyens_tinhThanhs_TinhThanhId",
                        column: x => x.TinhThanhId,
                        principalTable: "tinhThanhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "khoaHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhKhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoBaiHoc = table.Column<int>(type: "int", nullable: false),
                    SoChuong = table.Column<int>(type: "int", nullable: false),
                    GiaKhoaHoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TongThoiGianBaiHoc = table.Column<int>(type: "int", nullable: false),
                    SoNguoiDangKyKhoaHoc = table.Column<int>(type: "int", nullable: false),
                    SoHocVienDaHoanThanh = table.Column<int>(type: "int", nullable: false),
                    TrangThaiKhoaHocId = table.Column<int>(type: "int", nullable: false),
                    LoaiKhoaHocId = table.Column<int>(type: "int", nullable: false),
                    LinkVideoGioiThieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoaHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_khoaHocs_loaiKhoaHocs_LoaiKhoaHocId",
                        column: x => x.LoaiKhoaHocId,
                        principalTable: "loaiKhoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoaHocs_trangThaiKhoaHocs_TrangThaiKhoaHocId",
                        column: x => x.TrangThaiKhoaHocId,
                        principalTable: "trangThaiKhoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "xaPhuongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenXaPhuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenXaPhuongEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanHuyenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xaPhuongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_xaPhuongs_quanHuyens_QuanHuyenId",
                        column: x => x.QuanHuyenId,
                        principalTable: "quanHuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chuongKhoaHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoaHocId = table.Column<int>(type: "int", nullable: false),
                    TenChuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongThoiGianHoc1Chuong = table.Column<int>(type: "int", nullable: false),
                    SoBaiHocTrongChuong = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chuongKhoaHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chuongKhoaHocs_khoaHocs_KhoaHocId",
                        column: x => x.KhoaHocId,
                        principalTable: "khoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuyenHanId = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: true),
                    TrangThaiNguoiDungId = table.Column<int>(type: "int", nullable: false),
                    XaPhuongId = table.Column<int>(type: "int", nullable: true),
                    QuanHuyenId = table.Column<int>(type: "int", nullable: true),
                    TinhThanhId = table.Column<int>(type: "int", nullable: true),
                    DanhMucNguoiDungId = table.Column<int>(type: "int", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaKhoa = table.Column<bool>(type: "bit", nullable: true),
                    ThoiGianKhoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianMoKhoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLanViPham = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoiDungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nguoiDungs_danhMucNguoiDungs_DanhMucNguoiDungId",
                        column: x => x.DanhMucNguoiDungId,
                        principalTable: "danhMucNguoiDungs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_nguoiDungs_quanHuyens_QuanHuyenId",
                        column: x => x.QuanHuyenId,
                        principalTable: "quanHuyens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_nguoiDungs_quyenHans_QuyenHanId",
                        column: x => x.QuyenHanId,
                        principalTable: "quyenHans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nguoiDungs_tinhThanhs_TinhThanhId",
                        column: x => x.TinhThanhId,
                        principalTable: "tinhThanhs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_nguoiDungs_trangThaiNguoiDungs_TrangThaiNguoiDungId",
                        column: x => x.TrangThaiNguoiDungId,
                        principalTable: "trangThaiNguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nguoiDungs_xaPhuongs_XaPhuongId",
                        column: x => x.XaPhuongId,
                        principalTable: "xaPhuongs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "baiHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBaiHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTaBaiHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoaiBaiHocId = table.Column<int>(type: "int", nullable: false),
                    ChuongKhoaHocId = table.Column<int>(type: "int", nullable: false),
                    ThoiLuongVideo = table.Column<int>(type: "int", nullable: false),
                    TrangThaiBaiHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baiHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_baiHocs_chuongKhoaHocs_ChuongKhoaHocId",
                        column: x => x.ChuongKhoaHocId,
                        principalTable: "chuongKhoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_baiHocs_loaiBaiHocs_LoaiBaiHocId",
                        column: x => x.LoaiBaiHocId,
                        principalTable: "loaiBaiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_baiHocs_trangThaiBaiHocs_TrangThaiBaiHocId",
                        column: x => x.TrangThaiBaiHocId,
                        principalTable: "trangThaiBaiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "baiViets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTaBaiViet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhBaiViet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiDungTaoBaiId = table.Column<int>(type: "int", nullable: false),
                    DuLieuBaiViet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLuongThich = table.Column<int>(type: "int", nullable: false),
                    SoLuotBinhLuan = table.Column<int>(type: "int", nullable: false),
                    TrangThaiBaiVietId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baiViets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_baiViets_nguoiDungs_NguoiDungTaoBaiId",
                        column: x => x.NguoiDungTaoBaiId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_baiViets_trangThaiBaiViets_TrangThaiBaiVietId",
                        column: x => x.TrangThaiBaiVietId,
                        principalTable: "trangThaiBaiViets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "baoCaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungGuiId = table.Column<int>(type: "int", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    NguoiViPhamId = table.Column<int>(type: "int", nullable: false),
                    DaXacMinh = table.Column<bool>(type: "bit", nullable: false),
                    ThoiGianGuiBaoCao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianXacMinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaViPham = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BinhLuanId = table.Column<int>(type: "int", nullable: false),
                    LoaiBaoCaoId = table.Column<int>(type: "int", nullable: false),
                    LoaiBinhLuan = table.Column<int>(type: "int", nullable: true),
                    NguoiDungXacMinhId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baoCaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_baoCaos_loaiBaoCaos_LoaiBaoCaoId",
                        column: x => x.LoaiBaoCaoId,
                        principalTable: "loaiBaoCaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_baoCaos_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuotThich = table.Column<int>(type: "int", nullable: false),
                    SoLuotBinhLuan = table.Column<int>(type: "int", nullable: false),
                    AnhBlog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkBlog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieuDeBlog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThaiBlogId = table.Column<int>(type: "int", nullable: false),
                    LoaiBlogId = table.Column<int>(type: "int", nullable: false),
                    NguoiDangBaiId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogs_loaiBlogs_LoaiBlogId",
                        column: x => x.LoaiBlogId,
                        principalTable: "loaiBlogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blogs_nguoiDungs_NguoiDangBaiId",
                        column: x => x.NguoiDangBaiId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blogs_trangThaiBlogs_TrangThaiBlogId",
                        column: x => x.TrangThaiBlogId,
                        principalTable: "trangThaiBlogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "danhHieuNguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    DanhHieuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danhHieuNguoiDungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_danhHieuNguoiDungs_danhHieus_DanhHieuId",
                        column: x => x.DanhHieuId,
                        principalTable: "danhHieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_danhHieuNguoiDungs_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kinhNghiemHocTaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    TruongHocId = table.Column<int>(type: "int", nullable: false),
                    ChuyenNganhId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kinhNghiemHocTaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kinhNghiemHocTaps_chuyenNganhs_ChuyenNganhId",
                        column: x => x.ChuyenNganhId,
                        principalTable: "chuyenNganhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_kinhNghiemHocTaps_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_kinhNghiemHocTaps_truongHocs_TruongHocId",
                        column: x => x.TruongHocId,
                        principalTable: "truongHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kinhNghiems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    ChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kinhNghiems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kinhNghiems_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lienHes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiLienHe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaLienHe = table.Column<bool>(type: "bit", nullable: false),
                    ThoiGianGuiYeuCau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiLienHeId = table.Column<int>(type: "int", nullable: true),
                    ThoiGianLienHe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DanhGiaTheoSao = table.Column<int>(type: "int", nullable: true),
                    NoiDungDanhGia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lienHes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lienHes_nguoiDungs_NguoiLienHeId",
                        column: x => x.NguoiLienHeId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "refreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianHetHan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refreshTokens_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "thongBaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    NguoiDungGuiThongBaoId = table.Column<int>(type: "int", nullable: true),
                    DaXem = table.Column<bool>(type: "bit", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeThongThongBao = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongBaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thongBaos_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "thongBaoTrangChus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongBaoTrangChus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thongBaoTrangChus_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "xacNhanEmails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaXacNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaXacNhan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xacNhanEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_xacNhanEmails_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "binhLuanBaiHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaiHocId = table.Column<int>(type: "int", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: true),
                    BinhLuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuongDanAnhBinhLuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BinhLuanGocId = table.Column<int>(type: "int", nullable: true),
                    SoLuotLike = table.Column<int>(type: "int", nullable: false),
                    SoLuotBinhLuanTraLoi = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThaiBinhLuanId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_binhLuanBaiHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_binhLuanBaiHocs_baiHocs_BaiHocId",
                        column: x => x.BaiHocId,
                        principalTable: "baiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_binhLuanBaiHocs_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_binhLuanBaiHocs_trangThaiBinhLuans_TrangThaiBinhLuanId",
                        column: x => x.TrangThaiBinhLuanId,
                        principalTable: "trangThaiBinhLuans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "datCauHois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaiHocId = table.Column<int>(type: "int", nullable: false),
                    CauHoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CauTraLoiA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CauTraLoiB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CauTraLoiC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CauTraLoiD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoCauTraLoi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datCauHois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_datCauHois_baiHocs_BaiHocId",
                        column: x => x.BaiHocId,
                        principalTable: "baiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "diemKiemTraBaiHocCuaNguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    BaiHocId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianMoBaiHoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaHoanThanh = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diemKiemTraBaiHocCuaNguoiDungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_diemKiemTraBaiHocCuaNguoiDungs_baiHocs_BaiHocId",
                        column: x => x.BaiHocId,
                        principalTable: "baiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_diemKiemTraBaiHocCuaNguoiDungs_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "khoaHocCuaNguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: true),
                    KhoaHocId = table.Column<int>(type: "int", nullable: true),
                    DaHoanThanh = table.Column<bool>(type: "bit", nullable: false),
                    ThoiGianDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianHocLanCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhanTramHoanThanh = table.Column<double>(type: "float", nullable: false),
                    TienDoBaiHocId = table.Column<int>(type: "int", nullable: true),
                    BaiHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoaHocCuaNguoiDungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_khoaHocCuaNguoiDungs_baiHocs_BaiHocId",
                        column: x => x.BaiHocId,
                        principalTable: "baiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoaHocCuaNguoiDungs_khoaHocs_KhoaHocId",
                        column: x => x.KhoaHocId,
                        principalTable: "khoaHocs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_khoaHocCuaNguoiDungs_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "phanHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChuongKhoaHocId = table.Column<int>(type: "int", nullable: false),
                    BaiHocId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianThemBaiHocVaoPhanHoc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phanHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phanHocs_baiHocs_BaiHocId",
                        column: x => x.BaiHocId,
                        principalTable: "baiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_phanHocs_chuongKhoaHocs_ChuongKhoaHocId",
                        column: x => x.ChuongKhoaHocId,
                        principalTable: "chuongKhoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "thucHanhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChiTietVanDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeKhoiDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallTestCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeDauVao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MongDoiDauRa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaiThich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoiY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaiHocId = table.Column<int>(type: "int", nullable: false),
                    HoTroDaNgonNgu = table.Column<bool>(type: "bit", nullable: true),
                    NgonNguMacDinhId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thucHanhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thucHanhs_baiHocs_BaiHocId",
                        column: x => x.BaiHocId,
                        principalTable: "baiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_thucHanhs_ngonNgus_NgonNguMacDinhId",
                        column: x => x.NgonNguMacDinhId,
                        principalTable: "ngonNgus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "videoBaiGiangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaiHocId = table.Column<int>(type: "int", nullable: false),
                    LinkBaiHoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videoBaiGiangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_videoBaiGiangs_baiHocs_BaiHocId",
                        column: x => x.BaiHocId,
                        principalTable: "baiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "binhLuanBaiViets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaiVietId = table.Column<int>(type: "int", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: true),
                    BinhLuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuongDanAnhBinhLuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BinhLuanGocId = table.Column<int>(type: "int", nullable: true),
                    SoLuotLike = table.Column<int>(type: "int", nullable: false),
                    SoLuotBinhLuanTraLoi = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThaiBinhLuanId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_binhLuanBaiViets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_binhLuanBaiViets_baiViets_BaiVietId",
                        column: x => x.BaiVietId,
                        principalTable: "baiViets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_binhLuanBaiViets_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_binhLuanBaiViets_trangThaiBinhLuans_TrangThaiBinhLuanId",
                        column: x => x.TrangThaiBinhLuanId,
                        principalTable: "trangThaiBinhLuans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nguoiDungThichBaiViets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    BaiVietId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianThich = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoiDungThichBaiViets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nguoiDungThichBaiViets_baiViets_BaiVietId",
                        column: x => x.BaiVietId,
                        principalTable: "baiViets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nguoiDungThichBaiViets_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nguoiDungThichBinhLuanBaiHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    BinhLuanBaiHocId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoiDungThichBinhLuanBaiHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nguoiDungThichBinhLuanBaiHocs_binhLuanBaiHocs_BinhLuanBaiHocId",
                        column: x => x.BinhLuanBaiHocId,
                        principalTable: "binhLuanBaiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nguoiDungThichBinhLuanBaiHocs_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hoanThanhTraLoiCauHois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CauHoiId = table.Column<int>(type: "int", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    CauTraLoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianHoanThanh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoanThanhTraLoiCauHois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoanThanhTraLoiCauHois_datCauHois_CauHoiId",
                        column: x => x.CauHoiId,
                        principalTable: "datCauHois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hoanThanhTraLoiCauHois_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nguoiDungGhiChus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiemKiemTraBaiHocId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianGhiChu = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoiDungGhiChus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nguoiDungGhiChus_diemKiemTraBaiHocCuaNguoiDungs_DiemKiemTraBaiHocId",
                        column: x => x.DiemKiemTraBaiHocId,
                        principalTable: "diemKiemTraBaiHocCuaNguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "codeDaNgonNgus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeKhoiDau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallTestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgonNguId = table.Column<int>(type: "int", nullable: false),
                    ThucHanhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_codeDaNgonNgus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_codeDaNgonNgus_ngonNgus_NgonNguId",
                        column: x => x.NgonNguId,
                        principalTable: "ngonNgus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_codeDaNgonNgus_thucHanhs_ThucHanhId",
                        column: x => x.ThucHanhId,
                        principalTable: "thucHanhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hoanThanhThucHanhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    BaiHocThucHanhId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianHoanThanh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgonNguId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoanThanhThucHanhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoanThanhThucHanhs_ngonNgus_NgonNguId",
                        column: x => x.NgonNguId,
                        principalTable: "ngonNgus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_hoanThanhThucHanhs_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hoanThanhThucHanhs_thucHanhs_BaiHocThucHanhId",
                        column: x => x.BaiHocThucHanhId,
                        principalTable: "thucHanhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "testCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThucHanhId = table.Column<int>(type: "int", nullable: false),
                    ChiTietDauVao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeDauVao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MongDoiDauRa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoaTestCase = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_testCases_thucHanhs_ThucHanhId",
                        column: x => x.ThucHanhId,
                        principalTable: "thucHanhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "videoHoanThanhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoBaiGiangId = table.Column<int>(type: "int", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianHoanThanh = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videoHoanThanhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_videoHoanThanhs_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_videoHoanThanhs_videoBaiGiangs_VideoBaiGiangId",
                        column: x => x.VideoBaiGiangId,
                        principalTable: "videoBaiGiangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nguoiDungThichBinhLuanBaiViets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    BinhLuanBaiVietId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoiDungThichBinhLuanBaiViets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nguoiDungThichBinhLuanBaiViets_binhLuanBaiViets_BinhLuanBaiVietId",
                        column: x => x.BinhLuanBaiVietId,
                        principalTable: "binhLuanBaiViets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nguoiDungThichBinhLuanBaiViets_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_baiHocs_ChuongKhoaHocId",
                table: "baiHocs",
                column: "ChuongKhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_baiHocs_LoaiBaiHocId",
                table: "baiHocs",
                column: "LoaiBaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_baiHocs_TrangThaiBaiHocId",
                table: "baiHocs",
                column: "TrangThaiBaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_baiViets_NguoiDungTaoBaiId",
                table: "baiViets",
                column: "NguoiDungTaoBaiId");

            migrationBuilder.CreateIndex(
                name: "IX_baiViets_TrangThaiBaiVietId",
                table: "baiViets",
                column: "TrangThaiBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_baoCaos_LoaiBaoCaoId",
                table: "baoCaos",
                column: "LoaiBaoCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_baoCaos_NguoiDungId",
                table: "baoCaos",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiHocs_BaiHocId",
                table: "binhLuanBaiHocs",
                column: "BaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiHocs_NguoiDungId",
                table: "binhLuanBaiHocs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiHocs_TrangThaiBinhLuanId",
                table: "binhLuanBaiHocs",
                column: "TrangThaiBinhLuanId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiViets_BaiVietId",
                table: "binhLuanBaiViets",
                column: "BaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiViets_NguoiDungId",
                table: "binhLuanBaiViets",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiViets_TrangThaiBinhLuanId",
                table: "binhLuanBaiViets",
                column: "TrangThaiBinhLuanId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_LoaiBlogId",
                table: "blogs",
                column: "LoaiBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_NguoiDangBaiId",
                table: "blogs",
                column: "NguoiDangBaiId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_TrangThaiBlogId",
                table: "blogs",
                column: "TrangThaiBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_chuongKhoaHocs_KhoaHocId",
                table: "chuongKhoaHocs",
                column: "KhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_codeDaNgonNgus_NgonNguId",
                table: "codeDaNgonNgus",
                column: "NgonNguId");

            migrationBuilder.CreateIndex(
                name: "IX_codeDaNgonNgus_ThucHanhId",
                table: "codeDaNgonNgus",
                column: "ThucHanhId");

            migrationBuilder.CreateIndex(
                name: "IX_danhHieuNguoiDungs_DanhHieuId",
                table: "danhHieuNguoiDungs",
                column: "DanhHieuId");

            migrationBuilder.CreateIndex(
                name: "IX_danhHieuNguoiDungs_NguoiDungId",
                table: "danhHieuNguoiDungs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_datCauHois_BaiHocId",
                table: "datCauHois",
                column: "BaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_diemKiemTraBaiHocCuaNguoiDungs_BaiHocId",
                table: "diemKiemTraBaiHocCuaNguoiDungs",
                column: "BaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_diemKiemTraBaiHocCuaNguoiDungs_NguoiDungId",
                table: "diemKiemTraBaiHocCuaNguoiDungs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_hoanThanhThucHanhs_BaiHocThucHanhId",
                table: "hoanThanhThucHanhs",
                column: "BaiHocThucHanhId");

            migrationBuilder.CreateIndex(
                name: "IX_hoanThanhThucHanhs_NgonNguId",
                table: "hoanThanhThucHanhs",
                column: "NgonNguId");

            migrationBuilder.CreateIndex(
                name: "IX_hoanThanhThucHanhs_NguoiDungId",
                table: "hoanThanhThucHanhs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_hoanThanhTraLoiCauHois_CauHoiId",
                table: "hoanThanhTraLoiCauHois",
                column: "CauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_hoanThanhTraLoiCauHois_NguoiDungId",
                table: "hoanThanhTraLoiCauHois",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_khoaHocCuaNguoiDungs_BaiHocId",
                table: "khoaHocCuaNguoiDungs",
                column: "BaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_khoaHocCuaNguoiDungs_KhoaHocId",
                table: "khoaHocCuaNguoiDungs",
                column: "KhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_khoaHocCuaNguoiDungs_NguoiDungId",
                table: "khoaHocCuaNguoiDungs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_khoaHocs_LoaiKhoaHocId",
                table: "khoaHocs",
                column: "LoaiKhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_khoaHocs_TrangThaiKhoaHocId",
                table: "khoaHocs",
                column: "TrangThaiKhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_kinhNghiemHocTaps_ChuyenNganhId",
                table: "kinhNghiemHocTaps",
                column: "ChuyenNganhId");

            migrationBuilder.CreateIndex(
                name: "IX_kinhNghiemHocTaps_NguoiDungId",
                table: "kinhNghiemHocTaps",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_kinhNghiemHocTaps_TruongHocId",
                table: "kinhNghiemHocTaps",
                column: "TruongHocId");

            migrationBuilder.CreateIndex(
                name: "IX_kinhNghiems_NguoiDungId",
                table: "kinhNghiems",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_lienHes_NguoiLienHeId",
                table: "lienHes",
                column: "NguoiLienHeId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungGhiChus_DiemKiemTraBaiHocId",
                table: "nguoiDungGhiChus",
                column: "DiemKiemTraBaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungs_DanhMucNguoiDungId",
                table: "nguoiDungs",
                column: "DanhMucNguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungs_QuanHuyenId",
                table: "nguoiDungs",
                column: "QuanHuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungs_QuyenHanId",
                table: "nguoiDungs",
                column: "QuyenHanId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungs_TinhThanhId",
                table: "nguoiDungs",
                column: "TinhThanhId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungs_TrangThaiNguoiDungId",
                table: "nguoiDungs",
                column: "TrangThaiNguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungs_XaPhuongId",
                table: "nguoiDungs",
                column: "XaPhuongId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungThichBaiViets_BaiVietId",
                table: "nguoiDungThichBaiViets",
                column: "BaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungThichBaiViets_NguoiDungId",
                table: "nguoiDungThichBaiViets",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungThichBinhLuanBaiHocs_BinhLuanBaiHocId",
                table: "nguoiDungThichBinhLuanBaiHocs",
                column: "BinhLuanBaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungThichBinhLuanBaiHocs_NguoiDungId",
                table: "nguoiDungThichBinhLuanBaiHocs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungThichBinhLuanBaiViets_BinhLuanBaiVietId",
                table: "nguoiDungThichBinhLuanBaiViets",
                column: "BinhLuanBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungThichBinhLuanBaiViets_NguoiDungId",
                table: "nguoiDungThichBinhLuanBaiViets",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_phanHocs_BaiHocId",
                table: "phanHocs",
                column: "BaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_phanHocs_ChuongKhoaHocId",
                table: "phanHocs",
                column: "ChuongKhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_quanHuyens_TinhThanhId",
                table: "quanHuyens",
                column: "TinhThanhId");

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_NguoiDungId",
                table: "refreshTokens",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_testCases_ThucHanhId",
                table: "testCases",
                column: "ThucHanhId");

            migrationBuilder.CreateIndex(
                name: "IX_thongBaos_NguoiDungId",
                table: "thongBaos",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_thongBaoTrangChus_NguoiDungId",
                table: "thongBaoTrangChus",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_thucHanhs_BaiHocId",
                table: "thucHanhs",
                column: "BaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_thucHanhs_NgonNguMacDinhId",
                table: "thucHanhs",
                column: "NgonNguMacDinhId");

            migrationBuilder.CreateIndex(
                name: "IX_truongHocs_LoaiTruongHocId",
                table: "truongHocs",
                column: "LoaiTruongHocId");

            migrationBuilder.CreateIndex(
                name: "IX_videoBaiGiangs_BaiHocId",
                table: "videoBaiGiangs",
                column: "BaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_videoHoanThanhs_NguoiDungId",
                table: "videoHoanThanhs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_videoHoanThanhs_VideoBaiGiangId",
                table: "videoHoanThanhs",
                column: "VideoBaiGiangId");

            migrationBuilder.CreateIndex(
                name: "IX_xacNhanEmails_NguoiDungId",
                table: "xacNhanEmails",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_xaPhuongs_QuanHuyenId",
                table: "xaPhuongs",
                column: "QuanHuyenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "baoCaos");

            migrationBuilder.DropTable(
                name: "blogs");

            migrationBuilder.DropTable(
                name: "codeDaNgonNgus");

            migrationBuilder.DropTable(
                name: "danhHieuNguoiDungs");

            migrationBuilder.DropTable(
                name: "hoanThanhThucHanhs");

            migrationBuilder.DropTable(
                name: "hoanThanhTraLoiCauHois");

            migrationBuilder.DropTable(
                name: "khoaHocCuaNguoiDungs");

            migrationBuilder.DropTable(
                name: "kinhNghiemHocTaps");

            migrationBuilder.DropTable(
                name: "kinhNghiems");

            migrationBuilder.DropTable(
                name: "lienHes");

            migrationBuilder.DropTable(
                name: "nguoiDungGhiChus");

            migrationBuilder.DropTable(
                name: "nguoiDungThichBaiViets");

            migrationBuilder.DropTable(
                name: "nguoiDungThichBinhLuanBaiHocs");

            migrationBuilder.DropTable(
                name: "nguoiDungThichBinhLuanBaiViets");

            migrationBuilder.DropTable(
                name: "noiDungTrangChus");

            migrationBuilder.DropTable(
                name: "phanHocs");

            migrationBuilder.DropTable(
                name: "refreshTokens");

            migrationBuilder.DropTable(
                name: "testCases");

            migrationBuilder.DropTable(
                name: "thongBaos");

            migrationBuilder.DropTable(
                name: "thongBaoTrangChus");

            migrationBuilder.DropTable(
                name: "videoHoanThanhs");

            migrationBuilder.DropTable(
                name: "xacNhanEmails");

            migrationBuilder.DropTable(
                name: "loaiBaoCaos");

            migrationBuilder.DropTable(
                name: "loaiBlogs");

            migrationBuilder.DropTable(
                name: "trangThaiBlogs");

            migrationBuilder.DropTable(
                name: "danhHieus");

            migrationBuilder.DropTable(
                name: "datCauHois");

            migrationBuilder.DropTable(
                name: "chuyenNganhs");

            migrationBuilder.DropTable(
                name: "truongHocs");

            migrationBuilder.DropTable(
                name: "diemKiemTraBaiHocCuaNguoiDungs");

            migrationBuilder.DropTable(
                name: "binhLuanBaiHocs");

            migrationBuilder.DropTable(
                name: "binhLuanBaiViets");

            migrationBuilder.DropTable(
                name: "thucHanhs");

            migrationBuilder.DropTable(
                name: "videoBaiGiangs");

            migrationBuilder.DropTable(
                name: "loaiTruongHocs");

            migrationBuilder.DropTable(
                name: "baiViets");

            migrationBuilder.DropTable(
                name: "trangThaiBinhLuans");

            migrationBuilder.DropTable(
                name: "ngonNgus");

            migrationBuilder.DropTable(
                name: "baiHocs");

            migrationBuilder.DropTable(
                name: "nguoiDungs");

            migrationBuilder.DropTable(
                name: "trangThaiBaiViets");

            migrationBuilder.DropTable(
                name: "chuongKhoaHocs");

            migrationBuilder.DropTable(
                name: "loaiBaiHocs");

            migrationBuilder.DropTable(
                name: "trangThaiBaiHocs");

            migrationBuilder.DropTable(
                name: "danhMucNguoiDungs");

            migrationBuilder.DropTable(
                name: "quyenHans");

            migrationBuilder.DropTable(
                name: "trangThaiNguoiDungs");

            migrationBuilder.DropTable(
                name: "xaPhuongs");

            migrationBuilder.DropTable(
                name: "khoaHocs");

            migrationBuilder.DropTable(
                name: "quanHuyens");

            migrationBuilder.DropTable(
                name: "loaiKhoaHocs");

            migrationBuilder.DropTable(
                name: "trangThaiKhoaHocs");

            migrationBuilder.DropTable(
                name: "tinhThanhs");
        }
    }
}
