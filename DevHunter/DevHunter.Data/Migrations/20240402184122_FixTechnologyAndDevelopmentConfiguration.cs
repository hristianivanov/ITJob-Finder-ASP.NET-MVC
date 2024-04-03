using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class FixTechnologyAndDevelopmentConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("35f8777e-b96b-49ee-b8d0-44598863c068"));

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("09bead07-5680-4204-a837-2bf34509b3af") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("0c07e73e-21de-4d34-acf8-15f1ed993ee9") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("48ba2840-ceb6-4546-9d03-9b9163b131d5") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("b06f66e5-1531-4343-8a88-2ffa4b981bcc") });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bb8aafc8-0ac4-4694-9dda-a10ddfdd31ce"),
                column: "ImageUrl",
                value: "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071533/DevHunter/technology/Go.png");

            migrationBuilder.InsertData(
                table: "TechnologiesDevelopments",
                columns: new[] { "DevelopmentId", "TechnologyId", "IsActive" },
                values: new object[,]
                {
                    { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("1835a5be-934c-4149-a7bf-72e4d22589b0"), true },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("7397e5d6-527e-47f9-8f23-20dd62692500"), true },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("85eb8c55-d4ac-4408-8167-8887f9b3dc78"), true },
                    { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("e1fdc176-5f0e-44a2-8b02-84f757fe5118"), true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("1835a5be-934c-4149-a7bf-72e4d22589b0") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("7397e5d6-527e-47f9-8f23-20dd62692500") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("85eb8c55-d4ac-4408-8167-8887f9b3dc78") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("e1fdc176-5f0e-44a2-8b02-84f757fe5118") });

            migrationBuilder.InsertData(
                table: "Developments",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { new Guid("35f8777e-b96b-49ee-b8d0-44598863c068"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/ERP%20-%20CRM%20development.png", "ERP / CRM Development" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bb8aafc8-0ac4-4694-9dda-a10ddfdd31ce"),
                column: "ImageUrl",
                value: "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png");

            migrationBuilder.InsertData(
                table: "TechnologiesDevelopments",
                columns: new[] { "DevelopmentId", "TechnologyId", "IsActive" },
                values: new object[,]
                {
                    { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("09bead07-5680-4204-a837-2bf34509b3af"), true },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("0c07e73e-21de-4d34-acf8-15f1ed993ee9"), true },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("48ba2840-ceb6-4546-9d03-9b9163b131d5"), true },
                    { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("b06f66e5-1531-4343-8a88-2ffa4b981bcc"), true }
                });
        }
    }
}
