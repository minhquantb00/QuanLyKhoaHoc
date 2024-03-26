using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourseManagement_Models.Migrations
{
    /// <inheritdoc />
    public partial class upnguoiDungKhoaHocv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chinhSachVaQuyenRiengTus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoTaChinhSach = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chinhSachVaQuyenRiengTus", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chinhSachVaQuyenRiengTus");
        }
    }
}
