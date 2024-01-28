using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class AddColumnImageUrlToCompanyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Companies");
        }
    }
}
