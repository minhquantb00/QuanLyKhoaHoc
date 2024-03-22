using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class upKhoaHoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoHocVienHocKhoaHoc",
                table: "khoaHocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SoSaoTrungBinh",
                table: "khoaHocs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TrailerKhoaHoc",
                table: "khoaHocs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoHocVienHocKhoaHoc",
                table: "khoaHocs");

            migrationBuilder.DropColumn(
                name: "SoSaoTrungBinh",
                table: "khoaHocs");

            migrationBuilder.DropColumn(
                name: "TrailerKhoaHoc",
                table: "khoaHocs");
        }
    }
}
