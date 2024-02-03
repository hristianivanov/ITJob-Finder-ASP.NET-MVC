using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class AddMappingRelationBetweenJobOfferAndTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_JobOffers_JobOfferId",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_JobOfferId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "JobOfferId",
                table: "Technologies");

            migrationBuilder.CreateTable(
                name: "TechnologyJobOffers",
                columns: table => new
                {
                    JobOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyJobOffers", x => new { x.JobOfferId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_TechnologyJobOffers_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnologyJobOffers_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnologyJobOffers_TechnologyId",
                table: "TechnologyJobOffers",
                column: "TechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnologyJobOffers");

            migrationBuilder.AddColumn<Guid>(
                name: "JobOfferId",
                table: "Technologies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_JobOfferId",
                table: "Technologies",
                column: "JobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_JobOffers_JobOfferId",
                table: "Technologies",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
