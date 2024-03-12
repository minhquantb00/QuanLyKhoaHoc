using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class upBinhLuan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DuongDanAnhBinhLuan",
                table: "binhLuanBaiHocs",
                newName: "NoiDungBinhLuan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoiDungBinhLuan",
                table: "binhLuanBaiHocs",
                newName: "DuongDanAnhBinhLuan");
        }
    }
}
