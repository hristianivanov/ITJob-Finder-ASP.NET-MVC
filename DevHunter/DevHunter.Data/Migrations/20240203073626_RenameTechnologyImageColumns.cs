using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class RenameTechnologyImageColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThumbnailContent",
                table: "Technologies",
                newName: "ImageThumbnailContent");

            migrationBuilder.RenameColumn(
                name: "OriginalType",
                table: "Technologies",
                newName: "ImageOriginalType");

            migrationBuilder.RenameColumn(
                name: "OriginalFileName",
                table: "Technologies",
                newName: "ImageFileName");

            migrationBuilder.RenameColumn(
                name: "OriginalContent",
                table: "Technologies",
                newName: "ImageOriginalContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageThumbnailContent",
                table: "Technologies",
                newName: "ThumbnailContent");

            migrationBuilder.RenameColumn(
                name: "ImageOriginalType",
                table: "Technologies",
                newName: "OriginalType");

            migrationBuilder.RenameColumn(
                name: "ImageOriginalContent",
                table: "Technologies",
                newName: "OriginalContent");

            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Technologies",
                newName: "OriginalFileName");
        }
    }
}
