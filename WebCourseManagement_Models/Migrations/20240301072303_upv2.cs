using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class upv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChuongKhoaHocId",
                table: "baiHocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_baiHocs_ChuongKhoaHocId",
                table: "baiHocs",
                column: "ChuongKhoaHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_baiHocs_chuongKhoaHocs_ChuongKhoaHocId",
                table: "baiHocs",
                column: "ChuongKhoaHocId",
                principalTable: "chuongKhoaHocs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_baiHocs_chuongKhoaHocs_ChuongKhoaHocId",
                table: "baiHocs");

            migrationBuilder.DropIndex(
                name: "IX_baiHocs_ChuongKhoaHocId",
                table: "baiHocs");

            migrationBuilder.DropColumn(
                name: "ChuongKhoaHocId",
                table: "baiHocs");
        }
    }
}
