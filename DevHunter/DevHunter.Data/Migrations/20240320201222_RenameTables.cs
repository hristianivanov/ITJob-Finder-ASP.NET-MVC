using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDocument_JobApplication_JobApplicationId",
                table: "ApplicationDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_JobOffers_JobOfferId",
                table: "JobApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationDocument",
                table: "ApplicationDocument");

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("05ad6a20-1f23-4b55-be2d-7dd19fd8a3f1"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("08614235-fe4d-40b1-b9c2-94137783181d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("14d2c3b6-bae3-40bb-9dbc-982809e312ad"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("19ce736e-0280-47ab-9b10-60ed6a0a6cda"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3745ac4b-1f6a-4b18-974a-fd32030a740f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("383d2137-388b-4651-b689-e08b84c0771e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5f036eee-eadf-4ccb-a06a-d7ffa3d89f6f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("62f64eae-30aa-4e1e-9ac1-4e30a4969d6a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7bde8d8c-311c-4aa9-bef8-e7e0b7ced04b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7ea06be9-cd6a-4c32-a263-1b431a7a4285"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("81526243-b33b-4bb1-9a37-b16a5bec3efb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9ddd7009-1620-48fe-91ee-7909d0a702f8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a04e0bd4-04c6-4a27-91c5-72b8cb787262"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a9c761bc-ad43-4f6c-bf24-93cf63dd4c2c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b389d54b-d112-4d0d-b2bb-4c9e90b702f0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b63c7830-5ba6-483b-becc-2dc0606f6fb9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b766c0da-a97e-4ee2-bc69-005250e40c32"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b9e0524f-f414-470d-ac3a-c795e5eab006"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("da8eb774-2338-487d-b064-3dd071ab5913"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("dfa8cacb-0b5b-494f-aea2-92c80cc06d58"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e0be3772-9b6e-47ec-941f-1c5e40ab26bd"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e2dd0955-cc4f-4ad1-93fa-14aa2a34a1d6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f7335b63-7df4-4a6a-89fc-e648b1a1ab10"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("fa3d670f-f35c-4456-8c3b-1c134cf29408"));

            migrationBuilder.RenameTable(
                name: "JobApplication",
                newName: "JobApplications");

            migrationBuilder.RenameTable(
                name: "ApplicationDocument",
                newName: "ApplicationDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_JobOfferId",
                table: "JobApplications",
                newName: "IX_JobApplications_JobOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationDocument_JobApplicationId",
                table: "ApplicationDocuments",
                newName: "IX_ApplicationDocuments_JobApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationDocuments",
                table: "ApplicationDocuments",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("18933cdd-5825-47bd-9f22-6c7589f8dbbc"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("2097de20-6c84-454d-a984-be79a847edea"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("266243be-0ead-44d5-848c-304c8c3b8e81"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("2ea0a8fe-0901-488b-a4bb-cf3bdd807b6b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("375257ae-3771-4e3e-a3f1-b946b41a291b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("49e2bf02-6b56-4c92-a3ae-70c48f2e2654"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("4fa3a309-dd2d-47cf-ad28-d10ffb95451f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("56e26d3c-6c84-4bec-91e4-9a491e30eb13"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("5bd9eafa-7569-43a6-9c2c-8bb1feeab051"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("6781e6a4-c6b0-43c0-91f0-28ccac7c9198"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("67f49978-1f60-4095-96fb-52f09662600f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("6fbe06eb-9be1-404d-80b8-7b43813be545"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("7c8446ab-e0d0-4452-8f53-dad17c56432f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("9717834b-4ed2-4615-9737-cb5606974879"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("a6c28a8f-0f23-45f3-abd9-ead664836048"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("b9147040-f5aa-4f1e-998b-9c1310e6bc1f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("b9b7655b-36ea-4aa7-a202-2bf9478e6754"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("bbfa3059-b0ca-4b43-8307-ef4ed30e7e89"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("c35eaa2d-5361-4380-8dc0-6db654150cc1"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("ce314c19-0046-4873-8c13-eedc92103bac"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("d5e1e985-969e-4d1c-b9b9-8b489dc639cd"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("e1ac166e-ce64-4be2-bcfc-d1699386254e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("ed38639d-47cd-4296-b07f-71739be605c1"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("f2a9095b-6f29-414a-b15e-3b4d96a330b8"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDocuments_JobApplications_JobApplicationId",
                table: "ApplicationDocuments",
                column: "JobApplicationId",
                principalTable: "JobApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_JobOffers_JobOfferId",
                table: "JobApplications",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDocuments_JobApplications_JobApplicationId",
                table: "ApplicationDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_JobOffers_JobOfferId",
                table: "JobApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationDocuments",
                table: "ApplicationDocuments");

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("18933cdd-5825-47bd-9f22-6c7589f8dbbc"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2097de20-6c84-454d-a984-be79a847edea"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("266243be-0ead-44d5-848c-304c8c3b8e81"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2ea0a8fe-0901-488b-a4bb-cf3bdd807b6b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("375257ae-3771-4e3e-a3f1-b946b41a291b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("49e2bf02-6b56-4c92-a3ae-70c48f2e2654"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4fa3a309-dd2d-47cf-ad28-d10ffb95451f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("56e26d3c-6c84-4bec-91e4-9a491e30eb13"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5bd9eafa-7569-43a6-9c2c-8bb1feeab051"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6781e6a4-c6b0-43c0-91f0-28ccac7c9198"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("67f49978-1f60-4095-96fb-52f09662600f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6fbe06eb-9be1-404d-80b8-7b43813be545"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7c8446ab-e0d0-4452-8f53-dad17c56432f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9717834b-4ed2-4615-9737-cb5606974879"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a6c28a8f-0f23-45f3-abd9-ead664836048"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b9147040-f5aa-4f1e-998b-9c1310e6bc1f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b9b7655b-36ea-4aa7-a202-2bf9478e6754"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bbfa3059-b0ca-4b43-8307-ef4ed30e7e89"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c35eaa2d-5361-4380-8dc0-6db654150cc1"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ce314c19-0046-4873-8c13-eedc92103bac"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d5e1e985-969e-4d1c-b9b9-8b489dc639cd"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e1ac166e-ce64-4be2-bcfc-d1699386254e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ed38639d-47cd-4296-b07f-71739be605c1"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f2a9095b-6f29-414a-b15e-3b4d96a330b8"));

            migrationBuilder.RenameTable(
                name: "JobApplications",
                newName: "JobApplication");

            migrationBuilder.RenameTable(
                name: "ApplicationDocuments",
                newName: "ApplicationDocument");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_JobOfferId",
                table: "JobApplication",
                newName: "IX_JobApplication_JobOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationDocuments_JobApplicationId",
                table: "ApplicationDocument",
                newName: "IX_ApplicationDocument_JobApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationDocument",
                table: "ApplicationDocument",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("05ad6a20-1f23-4b55-be2d-7dd19fd8a3f1"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("08614235-fe4d-40b1-b9c2-94137783181d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("14d2c3b6-bae3-40bb-9dbc-982809e312ad"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("19ce736e-0280-47ab-9b10-60ed6a0a6cda"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("3745ac4b-1f6a-4b18-974a-fd32030a740f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("383d2137-388b-4651-b689-e08b84c0771e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("5f036eee-eadf-4ccb-a06a-d7ffa3d89f6f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("62f64eae-30aa-4e1e-9ac1-4e30a4969d6a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("7bde8d8c-311c-4aa9-bef8-e7e0b7ced04b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("7ea06be9-cd6a-4c32-a263-1b431a7a4285"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("81526243-b33b-4bb1-9a37-b16a5bec3efb"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("9ddd7009-1620-48fe-91ee-7909d0a702f8"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("a04e0bd4-04c6-4a27-91c5-72b8cb787262"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("a9c761bc-ad43-4f6c-bf24-93cf63dd4c2c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("b389d54b-d112-4d0d-b2bb-4c9e90b702f0"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("b63c7830-5ba6-483b-becc-2dc0606f6fb9"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("b766c0da-a97e-4ee2-bc69-005250e40c32"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("b9e0524f-f414-470d-ac3a-c795e5eab006"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("da8eb774-2338-487d-b064-3dd071ab5913"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("dfa8cacb-0b5b-494f-aea2-92c80cc06d58"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("e0be3772-9b6e-47ec-941f-1c5e40ab26bd"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("e2dd0955-cc4f-4ad1-93fa-14aa2a34a1d6"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("f7335b63-7df4-4a6a-89fc-e648b1a1ab10"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("fa3d670f-f35c-4456-8c3b-1c134cf29408"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDocument_JobApplication_JobApplicationId",
                table: "ApplicationDocument",
                column: "JobApplicationId",
                principalTable: "JobApplication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_JobOffers_JobOfferId",
                table: "JobApplication",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
