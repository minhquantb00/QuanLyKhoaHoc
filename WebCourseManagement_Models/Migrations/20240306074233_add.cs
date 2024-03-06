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
                name: "banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnhBanner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "danhGias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoSao = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danhGias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiBaiViets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiBaiViet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiBaiViets", x => x.Id);
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
                name: "loaiKhoaHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiKhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiKhoaHocs", x => x.Id);
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
                name: "quyenHans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuyenHan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenQuyenHan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quyenHans", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "tinhThanhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhThanh = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "khoaHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDeKhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTaKhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaKhoaHoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnhKhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TongThoiGianKhoaHoc = table.Column<int>(type: "int", nullable: false),
                    SoHocVienDaHoanThanh = table.Column<int>(type: "int", nullable: false),
                    NguoiTaoId = table.Column<int>(type: "int", nullable: false),
                    LoaiKhoaHocId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "quanHuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuanHuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "chuongHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongThoiGianHocTrongChuong = table.Column<int>(type: "int", nullable: false),
                    SoBaiHocTrongChuong = table.Column<int>(type: "int", nullable: false),
                    KhoaHocId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chuongHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chuongHocs_khoaHocs_KhoaHocId",
                        column: x => x.KhoaHocId,
                        principalTable: "khoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "xaPhuongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenXaPhuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "baiHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBaiHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTaBaiHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChuongHocId = table.Column<int>(type: "int", nullable: false),
                    VideoBaiHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiLuongVideo = table.Column<int>(type: "int", nullable: false),
                    TrangThaiBaiHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baiHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_baiHocs_chuongHocs_ChuongHocId",
                        column: x => x.ChuongHocId,
                        principalTable: "chuongHocs",
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
                name: "nguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuyenHanId = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    TrangThaiNguoiDungId = table.Column<int>(type: "int", nullable: false),
                    XaPhuongId = table.Column<int>(type: "int", nullable: true),
                    QuanHuyenId = table.Column<int>(type: "int", nullable: true),
                    TinhThanhId = table.Column<int>(type: "int", nullable: true),
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
                name: "datCauHois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaiHocId = table.Column<int>(type: "int", nullable: false),
                    CauTraLoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "thucHanhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeBai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChiTietDeBai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeKhoiDau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallTestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeDauVao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MongDoiDauRa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaiThich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoiY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaiHocId = table.Column<int>(type: "int", nullable: false),
                    HoTroDaNgonNgu = table.Column<bool>(type: "bit", nullable: true),
                    NgonNguMacDinhId = table.Column<int>(type: "int", nullable: false)
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
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiBaiVietId = table.Column<int>(type: "int", nullable: false),
                    AnhBaiViet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoBaiVietId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLuotThich = table.Column<int>(type: "int", nullable: false),
                    SoLuotBinhLuan = table.Column<int>(type: "int", nullable: false),
                    LoaiBaiVietId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baiViets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_baiViets_loaiBaiViets_LoaiBaiVietId",
                        column: x => x.LoaiBaiVietId,
                        principalTable: "loaiBaiViets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_baiViets_nguoiDungs_NguoiTaoBaiVietId",
                        column: x => x.NguoiTaoBaiVietId,
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
                    NguoiGuiBaoCaoId = table.Column<int>(type: "int", nullable: false),
                    NguoiViPhamId = table.Column<int>(type: "int", nullable: false),
                    DaXacMinh = table.Column<bool>(type: "bit", nullable: true),
                    ThoiGianGuiBaoCao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianXacMinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaViPham = table.Column<bool>(type: "bit", nullable: true),
                    GhiChuBaoCao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiBaoCaoId = table.Column<int>(type: "int", nullable: false),
                    BinhLuanId = table.Column<int>(type: "int", nullable: false),
                    LoaiBinhLuan = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_baoCaos_nguoiDungs_NguoiGuiBaoCaoId",
                        column: x => x.NguoiGuiBaoCaoId,
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
                    NguoiBinhLuanId = table.Column<int>(type: "int", nullable: false),
                    DuongDanAnhBinhLuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BinhLuanGocId = table.Column<int>(type: "int", nullable: true),
                    SoLuotThich = table.Column<int>(type: "int", nullable: false),
                    SoLuotTraLoiBinhLuan = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_binhLuanBaiHocs_nguoiDungs_NguoiBinhLuanId",
                        column: x => x.NguoiBinhLuanId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_binhLuanBaiHocs_trangThaiBinhLuans_TrangThaiBinhLuanId",
                        column: x => x.TrangThaiBinhLuanId,
                        principalTable: "trangThaiBinhLuans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "khoaHocCuaNguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    KhoaHocId = table.Column<int>(type: "int", nullable: false),
                    DaHoanThanh = table.Column<bool>(type: "bit", nullable: true),
                    PhanTramHoanThanh = table.Column<double>(type: "float", nullable: false),
                    ThoiGianDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaiHocHienTaiId = table.Column<int>(type: "int", nullable: false),
                    DanhGiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoaHocCuaNguoiDungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_khoaHocCuaNguoiDungs_baiHocs_BaiHocHienTaiId",
                        column: x => x.BaiHocHienTaiId,
                        principalTable: "baiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoaHocCuaNguoiDungs_danhGias_DanhGiaId",
                        column: x => x.DanhGiaId,
                        principalTable: "danhGias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoaHocCuaNguoiDungs_khoaHocs_KhoaHocId",
                        column: x => x.KhoaHocId,
                        principalTable: "khoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoaHocCuaNguoiDungs_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lienHeAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiLienHe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiLienHeId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianLienHe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaLienHe = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lienHeAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lienHeAdmins_nguoiDungs_NguoiLienHeId",
                        column: x => x.NguoiLienHeId,
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
                    NguoiDungGuiThongBaoId = table.Column<int>(type: "int", nullable: false),
                    DaXemThongBao = table.Column<bool>(type: "bit", nullable: false),
                    NoiDungThongBao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianThongBao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkThongBao = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianThongBao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnhThongBao = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "cauTraLois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CauHoiId = table.Column<int>(type: "int", nullable: false),
                    NguoiTraLoiId = table.Column<int>(type: "int", nullable: false),
                    CauTraLoiChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianTraLoi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cauTraLois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cauTraLois_datCauHois_CauHoiId",
                        column: x => x.CauHoiId,
                        principalTable: "datCauHois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cauTraLois_nguoiDungs_NguoiTraLoiId",
                        column: x => x.NguoiTraLoiId,
                        principalTable: "nguoiDungs",
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
                    ThucHanhId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianHoanThanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgonNguId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoanThanhThucHanhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoanThanhThucHanhs_ngonNgus_NgonNguId",
                        column: x => x.NgonNguId,
                        principalTable: "ngonNgus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hoanThanhThucHanhs_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hoanThanhThucHanhs_thucHanhs_ThucHanhId",
                        column: x => x.ThucHanhId,
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
                    ChiTietDauVao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeDauVao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MongDoiDauRa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoaTestCase = table.Column<bool>(type: "bit", nullable: true)
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
                name: "binhLuanBaiViets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaiVietId = table.Column<int>(type: "int", nullable: false),
                    NguoiBinhLuanId = table.Column<int>(type: "int", nullable: false),
                    NoiDungBinhLuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuongDanAnhBinhLuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BinhLuanGocId = table.Column<int>(type: "int", nullable: true),
                    SoLuotThich = table.Column<int>(type: "int", nullable: false),
                    SoLuotTraLoiBinhLuan = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_binhLuanBaiViets_nguoiDungs_NguoiBinhLuanId",
                        column: x => x.NguoiBinhLuanId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    ThoiGianBoThich = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaThich = table.Column<bool>(type: "bit", nullable: true)
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
                    NguoiDungThichBinhLuanId = table.Column<int>(type: "int", nullable: false),
                    BinhLuanBaiHocId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianThich = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianBoThich = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaThich = table.Column<bool>(type: "bit", nullable: true)
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
                        name: "FK_nguoiDungThichBinhLuanBaiHocs_nguoiDungs_NguoiDungThichBinhLuanId",
                        column: x => x.NguoiDungThichBinhLuanId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nguoiDungThichBinhLuanBaiViets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungThichBinhLuanId = table.Column<int>(type: "int", nullable: false),
                    BinhLuanBaiVietId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianThich = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianBoThich = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaThich = table.Column<bool>(type: "bit", nullable: true)
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
                        name: "FK_nguoiDungThichBinhLuanBaiViets_nguoiDungs_NguoiDungThichBinhLuanId",
                        column: x => x.NguoiDungThichBinhLuanId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_baiHocs_ChuongHocId",
                table: "baiHocs",
                column: "ChuongHocId");

            migrationBuilder.CreateIndex(
                name: "IX_baiHocs_TrangThaiBaiHocId",
                table: "baiHocs",
                column: "TrangThaiBaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_baiViets_LoaiBaiVietId",
                table: "baiViets",
                column: "LoaiBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_baiViets_NguoiTaoBaiVietId",
                table: "baiViets",
                column: "NguoiTaoBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_baiViets_TrangThaiBaiVietId",
                table: "baiViets",
                column: "TrangThaiBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_baoCaos_LoaiBaoCaoId",
                table: "baoCaos",
                column: "LoaiBaoCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_baoCaos_NguoiGuiBaoCaoId",
                table: "baoCaos",
                column: "NguoiGuiBaoCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiHocs_BaiHocId",
                table: "binhLuanBaiHocs",
                column: "BaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiHocs_NguoiBinhLuanId",
                table: "binhLuanBaiHocs",
                column: "NguoiBinhLuanId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiHocs_TrangThaiBinhLuanId",
                table: "binhLuanBaiHocs",
                column: "TrangThaiBinhLuanId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiViets_BaiVietId",
                table: "binhLuanBaiViets",
                column: "BaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiViets_NguoiBinhLuanId",
                table: "binhLuanBaiViets",
                column: "NguoiBinhLuanId");

            migrationBuilder.CreateIndex(
                name: "IX_binhLuanBaiViets_TrangThaiBinhLuanId",
                table: "binhLuanBaiViets",
                column: "TrangThaiBinhLuanId");

            migrationBuilder.CreateIndex(
                name: "IX_cauTraLois_CauHoiId",
                table: "cauTraLois",
                column: "CauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_cauTraLois_NguoiTraLoiId",
                table: "cauTraLois",
                column: "NguoiTraLoiId");

            migrationBuilder.CreateIndex(
                name: "IX_chuongHocs_KhoaHocId",
                table: "chuongHocs",
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
                name: "IX_datCauHois_BaiHocId",
                table: "datCauHois",
                column: "BaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_hoanThanhThucHanhs_NgonNguId",
                table: "hoanThanhThucHanhs",
                column: "NgonNguId");

            migrationBuilder.CreateIndex(
                name: "IX_hoanThanhThucHanhs_NguoiDungId",
                table: "hoanThanhThucHanhs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_hoanThanhThucHanhs_ThucHanhId",
                table: "hoanThanhThucHanhs",
                column: "ThucHanhId");

            migrationBuilder.CreateIndex(
                name: "IX_khoaHocCuaNguoiDungs_BaiHocHienTaiId",
                table: "khoaHocCuaNguoiDungs",
                column: "BaiHocHienTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_khoaHocCuaNguoiDungs_DanhGiaId",
                table: "khoaHocCuaNguoiDungs",
                column: "DanhGiaId");

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
                name: "IX_lienHeAdmins_NguoiLienHeId",
                table: "lienHeAdmins",
                column: "NguoiLienHeId");

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
                name: "IX_nguoiDungThichBinhLuanBaiHocs_NguoiDungThichBinhLuanId",
                table: "nguoiDungThichBinhLuanBaiHocs",
                column: "NguoiDungThichBinhLuanId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungThichBinhLuanBaiViets_BinhLuanBaiVietId",
                table: "nguoiDungThichBinhLuanBaiViets",
                column: "BinhLuanBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungThichBinhLuanBaiViets_NguoiDungThichBinhLuanId",
                table: "nguoiDungThichBinhLuanBaiViets",
                column: "NguoiDungThichBinhLuanId");

            migrationBuilder.CreateIndex(
                name: "IX_quanHuyens_TinhThanhId",
                table: "quanHuyens",
                column: "TinhThanhId");

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
                name: "IX_xaPhuongs_QuanHuyenId",
                table: "xaPhuongs",
                column: "QuanHuyenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banners");

            migrationBuilder.DropTable(
                name: "baoCaos");

            migrationBuilder.DropTable(
                name: "cauTraLois");

            migrationBuilder.DropTable(
                name: "codeDaNgonNgus");

            migrationBuilder.DropTable(
                name: "hoanThanhThucHanhs");

            migrationBuilder.DropTable(
                name: "khoaHocCuaNguoiDungs");

            migrationBuilder.DropTable(
                name: "lienHeAdmins");

            migrationBuilder.DropTable(
                name: "nguoiDungThichBaiViets");

            migrationBuilder.DropTable(
                name: "nguoiDungThichBinhLuanBaiHocs");

            migrationBuilder.DropTable(
                name: "nguoiDungThichBinhLuanBaiViets");

            migrationBuilder.DropTable(
                name: "refreshTokens");

            migrationBuilder.DropTable(
                name: "testCases");

            migrationBuilder.DropTable(
                name: "thongBaos");

            migrationBuilder.DropTable(
                name: "thongBaoTrangChus");

            migrationBuilder.DropTable(
                name: "xacNhanEmails");

            migrationBuilder.DropTable(
                name: "loaiBaoCaos");

            migrationBuilder.DropTable(
                name: "datCauHois");

            migrationBuilder.DropTable(
                name: "danhGias");

            migrationBuilder.DropTable(
                name: "binhLuanBaiHocs");

            migrationBuilder.DropTable(
                name: "binhLuanBaiViets");

            migrationBuilder.DropTable(
                name: "thucHanhs");

            migrationBuilder.DropTable(
                name: "baiViets");

            migrationBuilder.DropTable(
                name: "trangThaiBinhLuans");

            migrationBuilder.DropTable(
                name: "baiHocs");

            migrationBuilder.DropTable(
                name: "ngonNgus");

            migrationBuilder.DropTable(
                name: "loaiBaiViets");

            migrationBuilder.DropTable(
                name: "nguoiDungs");

            migrationBuilder.DropTable(
                name: "trangThaiBaiViets");

            migrationBuilder.DropTable(
                name: "chuongHocs");

            migrationBuilder.DropTable(
                name: "trangThaiBaiHocs");

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
                name: "tinhThanhs");
        }
    }
}
