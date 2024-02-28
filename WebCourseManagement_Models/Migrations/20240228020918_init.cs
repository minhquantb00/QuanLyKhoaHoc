using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TieuDeKhoaHoc",
                table: "khoaHocs",
                newName: "MoTa");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "nguoiDungs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaKhoaHoc",
                table: "khoaHocs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "khoaHocs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "khoaHocs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "khoaHocs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NguoiTaoId",
                table: "khoaHocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_khoaHocs_NguoiTaoId",
                table: "khoaHocs",
                column: "NguoiTaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_khoaHocs_nguoiDungs_NguoiTaoId",
                table: "khoaHocs",
                column: "NguoiTaoId",
                principalTable: "nguoiDungs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_khoaHocs_nguoiDungs_NguoiTaoId",
                table: "khoaHocs");

            migrationBuilder.DropIndex(
                name: "IX_khoaHocs_NguoiTaoId",
                table: "khoaHocs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "nguoiDungs");

            migrationBuilder.DropColumn(
                name: "GiaKhoaHoc",
                table: "khoaHocs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "khoaHocs");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "khoaHocs");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "khoaHocs");

            migrationBuilder.DropColumn(
                name: "NguoiTaoId",
                table: "khoaHocs");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "khoaHocs",
                newName: "TieuDeKhoaHoc");
        }
    }
}
