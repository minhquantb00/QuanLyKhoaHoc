using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class upUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BietDanh",
                table: "nguoiDungs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChungNhan",
                table: "nguoiDungs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GioiThieuBanThan",
                table: "nguoiDungs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkFacebook",
                table: "nguoiDungs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkInstagram",
                table: "nguoiDungs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkYoutube",
                table: "nguoiDungs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoTaBanThan",
                table: "nguoiDungs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BietDanh",
                table: "nguoiDungs");

            migrationBuilder.DropColumn(
                name: "ChungNhan",
                table: "nguoiDungs");

            migrationBuilder.DropColumn(
                name: "GioiThieuBanThan",
                table: "nguoiDungs");

            migrationBuilder.DropColumn(
                name: "LinkFacebook",
                table: "nguoiDungs");

            migrationBuilder.DropColumn(
                name: "LinkInstagram",
                table: "nguoiDungs");

            migrationBuilder.DropColumn(
                name: "LinkYoutube",
                table: "nguoiDungs");

            migrationBuilder.DropColumn(
                name: "MoTaBanThan",
                table: "nguoiDungs");
        }
    }
}
