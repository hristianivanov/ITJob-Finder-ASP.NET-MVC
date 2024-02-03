using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class AddMappingTableBetweenCompanyAndTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Companies_CompanyId",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_CompanyId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Technologies");

            migrationBuilder.CreateTable(
                name: "CompanyTechnologies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTechnologies", x => new { x.CompanyId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_CompanyTechnologies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyTechnologies_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTechnologies_TechnologyId",
                table: "CompanyTechnologies",
                column: "TechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyTechnologies");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Technologies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_CompanyId",
                table: "Technologies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Companies_CompanyId",
                table: "Technologies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
