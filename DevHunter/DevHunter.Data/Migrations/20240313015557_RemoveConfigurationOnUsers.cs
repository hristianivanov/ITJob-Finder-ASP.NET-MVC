using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class RemoveConfigurationOnUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("071f5d0b-f057-4cef-a3a3-ec1da0b1990e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("25ddbb09-f887-4af6-8964-41a60ab6f2ef"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("27a27fd9-2823-4c58-8b31-bae732940f61"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("2f74ac82-8e0d-4a37-8a35-a0104ada4409"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("42901f87-33d9-48a9-b4ab-db426aa2c0e1"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("6a4a2dd8-1b9d-4247-bafc-32b4eb472ebd"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("6e2a190b-032c-493c-ba0b-5bf8979db8af"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("7aac0748-8702-44f0-abb2-50369f82a04d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("8bbaefc4-da12-43b0-aa8c-d0929c5317d8"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("94685d36-5c74-4900-9e5d-23e2253832f6"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("a7d2e657-ecfd-4a21-bc39-31655ae81ccb"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("ad749c75-da8b-4d3c-8b1f-69ff97189c77"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("af0baf65-f1e1-4a81-a40d-27bcb8cba98e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("b6176af4-69c7-46d4-8d88-54313e60fdad"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("cd142bb1-4e85-455a-8546-f819eb9745f5"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("d3d1e828-7dd0-4a50-a1ba-1bc0762be3c3"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("d73a5fe3-72f6-44b6-9770-3893a61eb341"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("db828c44-3b14-4f90-b37c-51a1e7799ec5"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("e36dbbb8-6884-4446-b5ff-bacb1767ae9e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("e7b98c94-aa79-417f-ba14-c6078e48220c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("e8404684-e4b9-4845-8c01-bcb9f1740f4d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("e9cfa32d-d49e-4f11-8508-81f1c01e5fd1"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("eeb2eb5b-354f-4210-b26a-df1d8389b38d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("f760daac-2c09-43c7-81a0-15ff06951748"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("071f5d0b-f057-4cef-a3a3-ec1da0b1990e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("25ddbb09-f887-4af6-8964-41a60ab6f2ef"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("27a27fd9-2823-4c58-8b31-bae732940f61"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2f74ac82-8e0d-4a37-8a35-a0104ada4409"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("42901f87-33d9-48a9-b4ab-db426aa2c0e1"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6a4a2dd8-1b9d-4247-bafc-32b4eb472ebd"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6e2a190b-032c-493c-ba0b-5bf8979db8af"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7aac0748-8702-44f0-abb2-50369f82a04d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8bbaefc4-da12-43b0-aa8c-d0929c5317d8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("94685d36-5c74-4900-9e5d-23e2253832f6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a7d2e657-ecfd-4a21-bc39-31655ae81ccb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ad749c75-da8b-4d3c-8b1f-69ff97189c77"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("af0baf65-f1e1-4a81-a40d-27bcb8cba98e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b6176af4-69c7-46d4-8d88-54313e60fdad"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("cd142bb1-4e85-455a-8546-f819eb9745f5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d3d1e828-7dd0-4a50-a1ba-1bc0762be3c3"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d73a5fe3-72f6-44b6-9770-3893a61eb341"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("db828c44-3b14-4f90-b37c-51a1e7799ec5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e36dbbb8-6884-4446-b5ff-bacb1767ae9e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e7b98c94-aa79-417f-ba14-c6078e48220c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e8404684-e4b9-4845-8c01-bcb9f1740f4d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e9cfa32d-d49e-4f11-8508-81f1c01e5fd1"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("eeb2eb5b-354f-4210-b26a-df1d8389b38d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f760daac-2c09-43c7-81a0-15ff06951748"));

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
    }
}
