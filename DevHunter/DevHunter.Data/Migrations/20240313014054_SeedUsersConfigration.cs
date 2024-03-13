using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class SeedUsersConfigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0495bf8f-ceda-4199-a1f4-b1ffb59495da"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0fd920f2-f3a2-440b-80c1-6d5f9a85d5cd"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("11ec66c8-6f99-4c5d-ad1c-5cb1367d142e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("15ff2965-3d68-41f6-a067-702a1bd6d885"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1bade1ff-48ee-47f9-bd90-6e003b087b03"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("232d3c96-1c09-42e7-aebc-ccb27f9602e0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3dcd6ce5-fa91-4fbf-aed4-1085fd4da409"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("470206d5-f404-479d-a990-b9bfe6109e7d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4ac52817-206c-4acc-b97f-a98252081c5b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5d34cfde-9fdf-47a0-b079-2f07da493418"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5dc9ac9d-9a37-4cea-922e-072700db70ae"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6fccfd01-a3d2-4f06-b5d1-c9606647e34a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("76f0e99b-b7a2-4a02-9dfe-d30b8146a57e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7a320b78-3aee-40ad-bd4d-9ddde33ef1ae"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7af33a43-9d28-4ea6-bde8-c640e9ec10ce"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8621d025-d801-4d97-806f-e29ea241bb38"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("86bd85de-1907-4e11-8cc5-559a5fc3b83c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9264106a-6c5c-4071-b2ca-06f0eee31965"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9aeaf7dc-2339-4cdc-ad76-866f521d790b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ac182c79-6536-47e1-bf17-8eb93abf3d98"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d8c4e1ad-ad44-46fe-ad3b-926f22c04936"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("dc1fc49b-4036-496c-b9d6-fdd8e05ecd63"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("de944478-66c4-4b17-a975-94cef1c7b776"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e70bec80-9618-44ee-9bd7-bc740c02d45e"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("8a5edc49-7490-493f-2f01-08db8a416485"), 0, "fe4d861b-aa29-45b6-be62-5203e744fe42", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEKixlLbYWabPTbj/HGNxO1pkVE3rBuuKThr0zcKMxQVgtno0MbfLodPiYSpzSMxRbQ==", null, false, null, false, "admin@gmail.com" },
                    { new Guid("f06d4765-779a-4766-eb64-08db8a42133c"), 0, "71c0c430-fce0-4483-8cf4-aa80b1b95c4a", "defi@gmail.com", false, false, null, "DEFI@GMAIL.COM", "DEFI@GMAIL.COM", "AQAAAAEAACcQAAAAEPFfnmmNot3ipvM6PfHtfcwT28HAIOx/ofbQRo19v54OwJxDU3BKFiWPMM1xwzfKLA==", null, false, null, false, "defi@gmail.com" },
                    { new Guid("f2525385-0162-4b42-8fa5-08db8a43496a"), 0, "f9b1c52f-ce5c-43e1-b51b-4588d06a5d97", "pesho_petrov@yahoo.com", false, false, null, "PESHO_PETROV@YAHOO.COM", "PESHO_PETROV@YAHOO.COM", "AQAAAAEAACcQAAAAEIKHpdv/ceOVjOl09eM9XR4aSY/4dvSJGXT10VZgaJSe1TGd5/dnmOmGPhfTjNn6xg==", null, false, null, false, "pesho_petrov@yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("03f00a4d-5946-4bfc-9bf8-d986e13f2763"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("06fb55df-500a-4bf3-a64c-579034ceb0ad"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("0c5da6a9-4336-4dad-902c-e90582e6a9a5"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("1a54e033-bef5-47c0-80c7-1cf01d463be9"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("2f938bc9-ac5e-4dee-9393-6b759a4dc048"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("40753a55-7ba3-4c53-b742-b9ba9cd11170"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("551d3877-bc1b-4734-8845-fc001b120bc5"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("63b3d599-8bce-4f77-95b1-ee835e7cfcdf"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("682c55d1-7674-432e-882b-715f89ee55df"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("7c3ab177-16f4-4fef-b1da-81be79a75a63"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("7dc12f1a-d3db-43cf-adff-374212722a5d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("804926af-71c1-4b96-b255-7e0796224468"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("8ebcb369-1519-4f31-b996-170bd8fbb45d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("a007d83f-75ff-49b6-885e-adb4e8197c22"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("a69ae21a-42f1-4ab7-bd6a-de0ac18d5596"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("acb2f9f7-d0e9-4079-9ba0-b9b4a4149035"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("b4df498b-e900-44ff-b6c9-9c4b4af09e82"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("bd168209-fa3b-42dc-b613-6327d23036fd"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("c0243c0e-9237-4e05-ba19-c8850e353434"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("c53dc983-d355-4e33-af97-14b782185906"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("de192ea4-9464-4f44-bfa2-82b4e278c1bb"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("dfda9dff-ba4f-48b9-943f-f1011f8777a6"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("e144e9a4-4da4-4dfb-a8b8-1cb630102d8f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("e2fbe483-b20b-4caa-bf47-da78b1df950d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a5edc49-7490-493f-2f01-08db8a416485"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f06d4765-779a-4766-eb64-08db8a42133c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f2525385-0162-4b42-8fa5-08db8a43496a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("03f00a4d-5946-4bfc-9bf8-d986e13f2763"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("06fb55df-500a-4bf3-a64c-579034ceb0ad"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0c5da6a9-4336-4dad-902c-e90582e6a9a5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1a54e033-bef5-47c0-80c7-1cf01d463be9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2f938bc9-ac5e-4dee-9393-6b759a4dc048"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("40753a55-7ba3-4c53-b742-b9ba9cd11170"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("551d3877-bc1b-4734-8845-fc001b120bc5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("63b3d599-8bce-4f77-95b1-ee835e7cfcdf"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("682c55d1-7674-432e-882b-715f89ee55df"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7c3ab177-16f4-4fef-b1da-81be79a75a63"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7dc12f1a-d3db-43cf-adff-374212722a5d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("804926af-71c1-4b96-b255-7e0796224468"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8ebcb369-1519-4f31-b996-170bd8fbb45d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a007d83f-75ff-49b6-885e-adb4e8197c22"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a69ae21a-42f1-4ab7-bd6a-de0ac18d5596"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("acb2f9f7-d0e9-4079-9ba0-b9b4a4149035"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b4df498b-e900-44ff-b6c9-9c4b4af09e82"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bd168209-fa3b-42dc-b613-6327d23036fd"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c0243c0e-9237-4e05-ba19-c8850e353434"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c53dc983-d355-4e33-af97-14b782185906"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("de192ea4-9464-4f44-bfa2-82b4e278c1bb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("dfda9dff-ba4f-48b9-943f-f1011f8777a6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e144e9a4-4da4-4dfb-a8b8-1cb630102d8f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e2fbe483-b20b-4caa-bf47-da78b1df950d"));

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("0495bf8f-ceda-4199-a1f4-b1ffb59495da"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("0fd920f2-f3a2-440b-80c1-6d5f9a85d5cd"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("11ec66c8-6f99-4c5d-ad1c-5cb1367d142e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("15ff2965-3d68-41f6-a067-702a1bd6d885"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("1bade1ff-48ee-47f9-bd90-6e003b087b03"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("232d3c96-1c09-42e7-aebc-ccb27f9602e0"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("3dcd6ce5-fa91-4fbf-aed4-1085fd4da409"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("470206d5-f404-479d-a990-b9bfe6109e7d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("4ac52817-206c-4acc-b97f-a98252081c5b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("5d34cfde-9fdf-47a0-b079-2f07da493418"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("5dc9ac9d-9a37-4cea-922e-072700db70ae"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("6fccfd01-a3d2-4f06-b5d1-c9606647e34a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("76f0e99b-b7a2-4a02-9dfe-d30b8146a57e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("7a320b78-3aee-40ad-bd4d-9ddde33ef1ae"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("7af33a43-9d28-4ea6-bde8-c640e9ec10ce"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("8621d025-d801-4d97-806f-e29ea241bb38"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("86bd85de-1907-4e11-8cc5-559a5fc3b83c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("9264106a-6c5c-4071-b2ca-06f0eee31965"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("9aeaf7dc-2339-4cdc-ad76-866f521d790b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("ac182c79-6536-47e1-bf17-8eb93abf3d98"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("d8c4e1ad-ad44-46fe-ad3b-926f22c04936"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("dc1fc49b-4036-496c-b9d6-fdd8e05ecd63"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("de944478-66c4-4b17-a975-94cef1c7b776"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("e70bec80-9618-44ee-9bd7-bc740c02d45e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" }
                });
        }
    }
}
