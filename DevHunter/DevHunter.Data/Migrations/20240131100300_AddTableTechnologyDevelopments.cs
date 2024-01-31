using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class AddTableTechnologyDevelopments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Developments_DevelopmentId",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_DevelopmentId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "DevelopmentId",
                table: "Technologies");

            migrationBuilder.CreateTable(
                name: "TechnologiesDevelopments",
                columns: table => new
                {
                    TechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DevelopmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologiesDevelopments", x => new { x.TechnologyId, x.DevelopmentId });
                    table.ForeignKey(
                        name: "FK_TechnologiesDevelopments_Developments_DevelopmentId",
                        column: x => x.DevelopmentId,
                        principalTable: "Developments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnologiesDevelopments_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnologiesDevelopments_DevelopmentId",
                table: "TechnologiesDevelopments",
                column: "DevelopmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnologiesDevelopments");

            migrationBuilder.AddColumn<Guid>(
                name: "DevelopmentId",
                table: "Technologies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_DevelopmentId",
                table: "Technologies",
                column: "DevelopmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Developments_DevelopmentId",
                table: "Technologies",
                column: "DevelopmentId",
                principalTable: "Developments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
