using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class AddEnumerationForPlaceToWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "JobPlace",
                table: "JobOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("03a65b5d-78f8-49e6-9c8d-190abc925c70"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("08ad65cf-ccfc-4f76-bdf2-1d0244f4b18a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("08e6563a-538b-4ca7-bd7c-56a21e35ae7e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("0d376e7e-a67c-486b-be2f-61040ed6f0cc"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("15b5336e-f80a-4b3c-a6ed-d516321deb19"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("2853ac73-be9e-4c10-86b0-dcbb4de4f3c5"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("43496537-73f2-4aa6-81a8-279fe432ff4c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("4b301dcf-f2ed-4924-b009-b5d6166e4346"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("5f46660d-221f-48cc-b57b-f0d70a67ca1d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("64d7f072-f2a4-400d-bc44-88cc612e4cd0"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("7bfd9eb0-f27d-48f5-b568-b31890e46a23"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("80585b12-9839-4d7d-9aff-185c5cc34805"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("81f51a2b-6c79-4dd8-8390-ba2f05dd85a9"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("830d5cb7-7b8a-4cda-aae3-e629ed647789"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("9237c917-03d6-4a2d-a981-56aec5ee39bb"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("a1f81b8c-fc07-47bf-a5cc-515c8c9b447e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("a8a5c0bc-6a2c-412e-b8ba-0819153bcb6c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("aa867ae4-5218-4fc2-b1b1-2f21e313fa00"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("bd28461d-405f-4504-9d82-9cb838335fbc"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("e78ce7ab-3cd8-46c6-a597-680e8fbe336a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("e843d7ce-af52-46b2-b78b-17046af1552c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("ed3b047b-1bfc-469d-bb89-249eaa4eb001"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("f2a21422-772b-40fe-ae32-6cce349d9bde"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("f8e23f42-cbe8-4a56-84cc-e6e6711f8955"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("03a65b5d-78f8-49e6-9c8d-190abc925c70"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("08ad65cf-ccfc-4f76-bdf2-1d0244f4b18a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("08e6563a-538b-4ca7-bd7c-56a21e35ae7e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0d376e7e-a67c-486b-be2f-61040ed6f0cc"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("15b5336e-f80a-4b3c-a6ed-d516321deb19"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2853ac73-be9e-4c10-86b0-dcbb4de4f3c5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("43496537-73f2-4aa6-81a8-279fe432ff4c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4b301dcf-f2ed-4924-b009-b5d6166e4346"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5f46660d-221f-48cc-b57b-f0d70a67ca1d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("64d7f072-f2a4-400d-bc44-88cc612e4cd0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7bfd9eb0-f27d-48f5-b568-b31890e46a23"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("80585b12-9839-4d7d-9aff-185c5cc34805"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("81f51a2b-6c79-4dd8-8390-ba2f05dd85a9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("830d5cb7-7b8a-4cda-aae3-e629ed647789"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9237c917-03d6-4a2d-a981-56aec5ee39bb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a1f81b8c-fc07-47bf-a5cc-515c8c9b447e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a8a5c0bc-6a2c-412e-b8ba-0819153bcb6c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("aa867ae4-5218-4fc2-b1b1-2f21e313fa00"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bd28461d-405f-4504-9d82-9cb838335fbc"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e78ce7ab-3cd8-46c6-a597-680e8fbe336a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e843d7ce-af52-46b2-b78b-17046af1552c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ed3b047b-1bfc-469d-bb89-249eaa4eb001"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f2a21422-772b-40fe-ae32-6cce349d9bde"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f8e23f42-cbe8-4a56-84cc-e6e6711f8955"));

            migrationBuilder.DropColumn(
                name: "JobPlace",
                table: "JobOffers");

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
        }
    }
}
