using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class upchuong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuongDanAnhBinhLuan",
                table: "binhLuanBaiViets");

            migrationBuilder.AddColumn<string>(
                name: "AnhChuongHoc",
                table: "chuongHocs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnhChuongHoc",
                table: "chuongHocs");

            migrationBuilder.AddColumn<string>(
                name: "DuongDanAnhBinhLuan",
                table: "binhLuanBaiViets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
