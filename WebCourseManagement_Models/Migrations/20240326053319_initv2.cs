using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class initv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianHoanThanh",
                table: "nguoiDungHoanThanhBaiHocs",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThoiGianHoanThanh",
                table: "nguoiDungHoanThanhBaiHocs");
        }
    }
}
