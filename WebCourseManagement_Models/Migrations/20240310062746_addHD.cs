using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class addHD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GiaKhoaHocThucTe",
                table: "khoaHocs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PhanTramGiamGia",
                table: "khoaHocs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "trangThaiHoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trangThaiHoaDons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hoaDonDangKies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaGiaoDich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    KhoaHocId = table.Column<int>(type: "int", nullable: false),
                    TrangThaiHoaDonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDonDangKies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoaDonDangKies_khoaHocs_KhoaHocId",
                        column: x => x.KhoaHocId,
                        principalTable: "khoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDonDangKies_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDonDangKies_trangThaiHoaDons_TrangThaiHoaDonId",
                        column: x => x.TrangThaiHoaDonId,
                        principalTable: "trangThaiHoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonDangKies_KhoaHocId",
                table: "hoaDonDangKies",
                column: "KhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonDangKies_NguoiDungId",
                table: "hoaDonDangKies",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonDangKies_TrangThaiHoaDonId",
                table: "hoaDonDangKies",
                column: "TrangThaiHoaDonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hoaDonDangKies");

            migrationBuilder.DropTable(
                name: "trangThaiHoaDons");

            migrationBuilder.DropColumn(
                name: "GiaKhoaHocThucTe",
                table: "khoaHocs");

            migrationBuilder.DropColumn(
                name: "PhanTramGiamGia",
                table: "khoaHocs");
        }
    }
}
