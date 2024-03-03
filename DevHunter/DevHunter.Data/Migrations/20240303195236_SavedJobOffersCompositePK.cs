using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class SavedJobOffersCompositePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedJobOffers",
                table: "SavedJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_SavedJobOffers_UserId",
                table: "SavedJobOffers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SavedJobOffers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedJobOffers",
                table: "SavedJobOffers",
                columns: new[] { "UserId", "JobOfferId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedJobOffers",
                table: "SavedJobOffers");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SavedJobOffers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedJobOffers",
                table: "SavedJobOffers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobOffers_UserId",
                table: "SavedJobOffers",
                column: "UserId");
        }
    }
}
