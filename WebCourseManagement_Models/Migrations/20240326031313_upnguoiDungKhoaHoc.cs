using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class upnguoiDungKhoaHoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NguoiDungGuiThongBaoId",
                table: "thongBaos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LoaiVanDeId",
                table: "baoCaos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "loaiVanDes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiVanDe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiVanDes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nguoiDungHoanThanhBaiHocs",
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
                    table.PrimaryKey("PK_nguoiDungHoanThanhBaiHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nguoiDungHoanThanhBaiHocs_baiHocs_BaiHocId",
                        column: x => x.BaiHocId,
                        principalTable: "baiHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nguoiDungHoanThanhBaiHocs_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungHoanThanhBaiHocs_BaiHocId",
                table: "nguoiDungHoanThanhBaiHocs",
                column: "BaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiDungHoanThanhBaiHocs_NguoiDungId",
                table: "nguoiDungHoanThanhBaiHocs",
                column: "NguoiDungId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loaiVanDes");

            migrationBuilder.DropTable(
                name: "nguoiDungHoanThanhBaiHocs");

            migrationBuilder.DropColumn(
                name: "LoaiVanDeId",
                table: "baoCaos");

            migrationBuilder.AlterColumn<int>(
                name: "NguoiDungGuiThongBaoId",
                table: "thongBaos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
