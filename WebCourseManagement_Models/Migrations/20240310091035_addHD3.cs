using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class addHD3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_khoaHocCuaNguoiDungs_baiHocs_BaiHocHienTaiId",
                table: "khoaHocCuaNguoiDungs");

            migrationBuilder.DropForeignKey(
                name: "FK_khoaHocCuaNguoiDungs_danhGias_DanhGiaId",
                table: "khoaHocCuaNguoiDungs");

            migrationBuilder.AlterColumn<int>(
                name: "DanhGiaId",
                table: "khoaHocCuaNguoiDungs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BaiHocHienTaiId",
                table: "khoaHocCuaNguoiDungs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "chuongHocs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_khoaHocCuaNguoiDungs_baiHocs_BaiHocHienTaiId",
                table: "khoaHocCuaNguoiDungs",
                column: "BaiHocHienTaiId",
                principalTable: "baiHocs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_khoaHocCuaNguoiDungs_danhGias_DanhGiaId",
                table: "khoaHocCuaNguoiDungs",
                column: "DanhGiaId",
                principalTable: "danhGias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_khoaHocCuaNguoiDungs_baiHocs_BaiHocHienTaiId",
                table: "khoaHocCuaNguoiDungs");

            migrationBuilder.DropForeignKey(
                name: "FK_khoaHocCuaNguoiDungs_danhGias_DanhGiaId",
                table: "khoaHocCuaNguoiDungs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "chuongHocs");

            migrationBuilder.AlterColumn<int>(
                name: "DanhGiaId",
                table: "khoaHocCuaNguoiDungs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BaiHocHienTaiId",
                table: "khoaHocCuaNguoiDungs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_khoaHocCuaNguoiDungs_baiHocs_BaiHocHienTaiId",
                table: "khoaHocCuaNguoiDungs",
                column: "BaiHocHienTaiId",
                principalTable: "baiHocs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_khoaHocCuaNguoiDungs_danhGias_DanhGiaId",
                table: "khoaHocCuaNguoiDungs",
                column: "DanhGiaId",
                principalTable: "danhGias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
