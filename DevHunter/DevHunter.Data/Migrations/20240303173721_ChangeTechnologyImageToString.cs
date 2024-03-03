using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class ChangeTechnologyImageToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "ImageOriginalContent",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "ImageThumbnailContent",
                table: "Technologies");

            migrationBuilder.RenameColumn(
                name: "ImageOriginalType",
                table: "Technologies",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Technologies",
                newName: "ImageOriginalType");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Technologies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageOriginalContent",
                table: "Technologies",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageThumbnailContent",
                table: "Technologies",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
