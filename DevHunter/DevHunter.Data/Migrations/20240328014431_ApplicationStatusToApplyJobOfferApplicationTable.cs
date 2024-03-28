using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class ApplicationStatusToApplyJobOfferApplicationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("08e056a5-3207-4d68-98f0-1926432826e2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1a517c9e-092e-419e-b7d5-af31874c54cc"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1ac7d32c-1c0c-4413-a2cf-77879273f97d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1d4c15aa-e3b9-4ce9-a4de-cf0cf7823bd2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1eda2d2a-c9fb-42ff-b6c9-893723e4ef43"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("31fe6436-5159-405e-8734-e2da9b848eab"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("598be024-00bf-4a25-9b3d-6ea2f7e56e0a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("691aa503-429e-467b-8d07-b90de7b7da9e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6a4eb183-7995-4ecc-9f1e-6b8fd8f329d4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("74afab24-92ae-4a3b-a322-70fb46e44ce2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7ec7fa3b-a36b-40c2-b544-80b13c222e47"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("83c5672f-0a1e-4d43-ac9e-bcff6b6f96c9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("901f238e-cc3a-4a59-96af-a08b023236ee"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("94e910df-493d-4446-8f5d-970dc8463a5c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a63d14ac-0e66-479b-9a6d-53c234f38e33"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bb7411b7-c882-4aa4-84fb-c03c3af161e6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c43a9a85-d384-4fa5-a269-0b3cf492ba1c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c75402e1-e8b6-4ae8-ae74-b97c0fd3d8b3"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c9528526-80b5-4584-aa78-6f080ef4af9d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d460629c-95a0-44e2-a714-344cd55bc718"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d61878d2-a581-4ddd-be28-8bc7674f40cf"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ec9e0929-860c-4143-9c1b-1a1ea3f5f191"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f8f3aa1e-d9de-4feb-8c10-7210bb5b1c48"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("fc7f6891-44ef-438f-9158-b00e7b3fe4fe"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "JobApplications",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("08b4ffed-d4fd-4235-9353-fe1cdc05fd5a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("0fccd60d-5cd5-48a8-860e-d943a6937e59"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("138696c3-97ce-44d3-9ee1-ce1503658bb9"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("1415e4ef-8be2-44d8-87eb-48cbd2297e56"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("1621a0bc-ed2a-481b-8674-c11e3919d41c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("162bc9bf-c578-4973-9a89-14c23fd85304"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("1fd67404-6267-47df-8bc2-d8e19bf7e140"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("2bbddf7c-98fa-497f-a724-93ace5178fc4"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("348c0dad-c34f-4c24-a0e1-b0d2ed06f77d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("453727c3-73b9-48d7-953f-9cbc15d44775"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("846563da-84a3-4496-a8a0-6cc40640ad85"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("8677416d-bb31-4fc0-ae0b-0a5d24d605bb"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("927ec8c3-138d-4e09-ac6d-bda467b5d71c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("97439586-7db7-4ca1-b826-f53f4ef80e14"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("97de44e6-7a49-46c6-9843-0aa7b92d1318"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("9cf5ab02-9223-49f0-8d79-f796563f8430"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("a372a0ab-f557-4e91-9474-f2d43b0486a4"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("cdcc3050-0929-4e8d-bf5a-9d3ff3ba214b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("db6a9164-d892-4132-acc8-35a114e7c078"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("e7e93852-f67e-464a-87ee-e2cf368b39b6"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("ea1e55aa-77d6-43dc-83f5-7fb9c9037a14"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("eab1d039-b440-472c-a8a3-f6989c0770f9"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("f742372a-00d1-4080-8749-f71fa58cb0ff"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("ff7f0b52-f72b-4c27-8a85-ebda496d82fa"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("08b4ffed-d4fd-4235-9353-fe1cdc05fd5a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0fccd60d-5cd5-48a8-860e-d943a6937e59"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("138696c3-97ce-44d3-9ee1-ce1503658bb9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1415e4ef-8be2-44d8-87eb-48cbd2297e56"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1621a0bc-ed2a-481b-8674-c11e3919d41c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("162bc9bf-c578-4973-9a89-14c23fd85304"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1fd67404-6267-47df-8bc2-d8e19bf7e140"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2bbddf7c-98fa-497f-a724-93ace5178fc4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("348c0dad-c34f-4c24-a0e1-b0d2ed06f77d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("453727c3-73b9-48d7-953f-9cbc15d44775"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("846563da-84a3-4496-a8a0-6cc40640ad85"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8677416d-bb31-4fc0-ae0b-0a5d24d605bb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("927ec8c3-138d-4e09-ac6d-bda467b5d71c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("97439586-7db7-4ca1-b826-f53f4ef80e14"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("97de44e6-7a49-46c6-9843-0aa7b92d1318"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9cf5ab02-9223-49f0-8d79-f796563f8430"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a372a0ab-f557-4e91-9474-f2d43b0486a4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("cdcc3050-0929-4e8d-bf5a-9d3ff3ba214b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("db6a9164-d892-4132-acc8-35a114e7c078"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e7e93852-f67e-464a-87ee-e2cf368b39b6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ea1e55aa-77d6-43dc-83f5-7fb9c9037a14"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("eab1d039-b440-472c-a8a3-f6989c0770f9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f742372a-00d1-4080-8749-f71fa58cb0ff"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ff7f0b52-f72b-4c27-8a85-ebda496d82fa"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "JobApplications");

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("08e056a5-3207-4d68-98f0-1926432826e2"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("1a517c9e-092e-419e-b7d5-af31874c54cc"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("1ac7d32c-1c0c-4413-a2cf-77879273f97d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("1d4c15aa-e3b9-4ce9-a4de-cf0cf7823bd2"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("1eda2d2a-c9fb-42ff-b6c9-893723e4ef43"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("31fe6436-5159-405e-8734-e2da9b848eab"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("598be024-00bf-4a25-9b3d-6ea2f7e56e0a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("691aa503-429e-467b-8d07-b90de7b7da9e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("6a4eb183-7995-4ecc-9f1e-6b8fd8f329d4"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("74afab24-92ae-4a3b-a322-70fb46e44ce2"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("7ec7fa3b-a36b-40c2-b544-80b13c222e47"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("83c5672f-0a1e-4d43-ac9e-bcff6b6f96c9"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("901f238e-cc3a-4a59-96af-a08b023236ee"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("94e910df-493d-4446-8f5d-970dc8463a5c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("a63d14ac-0e66-479b-9a6d-53c234f38e33"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("bb7411b7-c882-4aa4-84fb-c03c3af161e6"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("c43a9a85-d384-4fa5-a269-0b3cf492ba1c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("c75402e1-e8b6-4ae8-ae74-b97c0fd3d8b3"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("c9528526-80b5-4584-aa78-6f080ef4af9d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("d460629c-95a0-44e2-a714-344cd55bc718"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("d61878d2-a581-4ddd-be28-8bc7674f40cf"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("ec9e0929-860c-4143-9c1b-1a1ea3f5f191"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("f8f3aa1e-d9de-4feb-8c10-7210bb5b1c48"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("fc7f6891-44ef-438f-9158-b00e7b3fe4fe"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" }
                });
        }
    }
}
