using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class AddColumnsToJobOfferTable_RenameColumnInTableTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffer_AspNetUsers_UserId",
                table: "SavedJobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffer_JobOffers_JobOfferId",
                table: "SavedJobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Developments_DelopmentId",
                table: "Technologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedJobOffer",
                table: "SavedJobOffer");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "JobOffers");

            migrationBuilder.RenameTable(
                name: "SavedJobOffer",
                newName: "SavedJobOffers");

            migrationBuilder.RenameColumn(
                name: "DelopmentId",
                table: "Technologies",
                newName: "DevelopmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Technologies_DelopmentId",
                table: "Technologies",
                newName: "IX_Technologies_DevelopmentId");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "JobOffers",
                newName: "MinSalary");

            migrationBuilder.RenameIndex(
                name: "IX_SavedJobOffer_UserId",
                table: "SavedJobOffers",
                newName: "IX_SavedJobOffers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SavedJobOffer_JobOfferId",
                table: "SavedJobOffers",
                newName: "IX_SavedJobOffers_JobOfferId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "JobOffers",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxSalary",
                table: "JobOffers",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedJobOffers",
                table: "SavedJobOffers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffers_AspNetUsers_UserId",
                table: "SavedJobOffers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffers_JobOffers_JobOfferId",
                table: "SavedJobOffers",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Developments_DevelopmentId",
                table: "Technologies",
                column: "DevelopmentId",
                principalTable: "Developments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffers_AspNetUsers_UserId",
                table: "SavedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffers_JobOffers_JobOfferId",
                table: "SavedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Developments_DevelopmentId",
                table: "Technologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedJobOffers",
                table: "SavedJobOffers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "MaxSalary",
                table: "JobOffers");

            migrationBuilder.RenameTable(
                name: "SavedJobOffers",
                newName: "SavedJobOffer");

            migrationBuilder.RenameColumn(
                name: "DevelopmentId",
                table: "Technologies",
                newName: "DelopmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Technologies_DevelopmentId",
                table: "Technologies",
                newName: "IX_Technologies_DelopmentId");

            migrationBuilder.RenameColumn(
                name: "MinSalary",
                table: "JobOffers",
                newName: "Salary");

            migrationBuilder.RenameIndex(
                name: "IX_SavedJobOffers_UserId",
                table: "SavedJobOffer",
                newName: "IX_SavedJobOffer_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SavedJobOffers_JobOfferId",
                table: "SavedJobOffer",
                newName: "IX_SavedJobOffer_JobOfferId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedJobOffer",
                table: "SavedJobOffer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffer_AspNetUsers_UserId",
                table: "SavedJobOffer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffer_JobOffers_JobOfferId",
                table: "SavedJobOffer",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Developments_DelopmentId",
                table: "Technologies",
                column: "DelopmentId",
                principalTable: "Developments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
