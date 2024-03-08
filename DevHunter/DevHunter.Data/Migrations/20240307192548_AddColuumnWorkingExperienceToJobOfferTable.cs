using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class AddColuumnWorkingExperienceToJobOfferTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("01e5c513-747e-4675-83aa-cdce478b7c98"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("048d966f-eab1-4f8a-8d0c-8b44d16a0578"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0e1d2b55-033f-4861-8d9d-0261866cf345"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3026aa7a-0dbf-442e-a617-83f3c7ab8b2b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("30cde8d0-30a0-4d60-9128-f4400d5c10e2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("33d45478-46d1-4637-a367-cb4e77e8ec78"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3429b18e-c99d-4ddf-b40d-056ce5957be8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("35ae1836-4f18-4243-b631-f872e557f317"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3725a3eb-0d1c-4879-802f-0cc1ba8ceb1c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3a015e1c-9041-49b2-a89f-bcca4b793f16"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3d50abdf-5ada-462c-a0b4-dd0eeb6f08e1"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("47659686-f808-4a1f-8743-35dcbe11aac9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6b6f28ae-7a73-45f6-9326-8dcd3c9e0d71"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("77e83b3f-75ac-468c-bc23-78aaf2537d69"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7ac280dc-e58d-4f18-8ab6-0ca78ff05eae"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7e9fe2e1-4c99-4da3-a78d-621a28f8e144"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("891641b2-5661-471f-bffa-3ef493b63a64"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("89cc2a36-c44a-43fc-b207-95f0d331edeb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("918dd956-57b0-4010-9fee-43f52d799706"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d34859a6-f261-434f-9428-b31f031319d2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e01765d3-b878-4ecb-ab3a-ef2412227deb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e90776ef-67a1-424b-85fd-08c33d5e2904"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f97f3b8b-0438-4454-ba37-d55339c91b33"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("fcf1888e-b8bc-4b8f-9353-3200d74fb38b"));

            migrationBuilder.AddColumn<string>(
                name: "WorkingExperience",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("13b706ff-c617-4db2-b5c2-eea6177b91ca"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("1c1d4db5-677c-481d-994a-6c4f2072c7d4"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("223ffc5e-6957-45d0-98d2-bea99600c371"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("2c11f704-ca74-4f46-a98b-2bb7f1a9ec5b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("358b96db-abbc-442c-9c92-bbf4636bbae2"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("40a6fbe3-9143-4c60-9c9d-da218972e968"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("417265c9-3f5c-4b3f-9892-633da48d3abe"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("442cd210-ac50-410a-a5c3-6bbaf3c2f540"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("529ed53c-49e7-4655-bc53-b867362caded"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("538a1eb3-4369-40a1-8cfc-e90ddc69805d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("5c7d4c4d-9a8d-484c-b274-a4cd67f8aea2"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("7769d92e-4f20-4300-bd4b-4002f67e3788"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("7b155544-fc66-47b7-882e-38df920e5ca3"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("8b43ea2f-9d94-43e2-9b8e-3d2695d92e48"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("a7506713-9486-4cce-a065-ad04fd7d3021"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("b4737626-59f4-403c-89a4-af3d6fb57f2a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("b6a2efc7-e23c-486c-80e6-01275f769244"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("b9bb946e-94d1-4c7e-81ba-7038f37b94e5"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("c0a3ad06-b432-42db-b716-93fb62d4d85e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("d0ec5639-f3f4-43f1-9f9a-9c01bff78e2c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("d4882c3a-3e7b-478c-a28d-fb164e8aa5f2"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("d6286d84-905d-4504-93e2-9be2f2d9789a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("f733c5e7-6326-49cc-b11d-0c258d12674f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("fae2c1e5-54a4-429e-90ec-8336baecf5ee"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("13b706ff-c617-4db2-b5c2-eea6177b91ca"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1c1d4db5-677c-481d-994a-6c4f2072c7d4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("223ffc5e-6957-45d0-98d2-bea99600c371"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2c11f704-ca74-4f46-a98b-2bb7f1a9ec5b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("358b96db-abbc-442c-9c92-bbf4636bbae2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("40a6fbe3-9143-4c60-9c9d-da218972e968"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("417265c9-3f5c-4b3f-9892-633da48d3abe"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("442cd210-ac50-410a-a5c3-6bbaf3c2f540"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("529ed53c-49e7-4655-bc53-b867362caded"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("538a1eb3-4369-40a1-8cfc-e90ddc69805d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5c7d4c4d-9a8d-484c-b274-a4cd67f8aea2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7769d92e-4f20-4300-bd4b-4002f67e3788"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7b155544-fc66-47b7-882e-38df920e5ca3"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8b43ea2f-9d94-43e2-9b8e-3d2695d92e48"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a7506713-9486-4cce-a065-ad04fd7d3021"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b4737626-59f4-403c-89a4-af3d6fb57f2a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b6a2efc7-e23c-486c-80e6-01275f769244"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b9bb946e-94d1-4c7e-81ba-7038f37b94e5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c0a3ad06-b432-42db-b716-93fb62d4d85e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d0ec5639-f3f4-43f1-9f9a-9c01bff78e2c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d4882c3a-3e7b-478c-a28d-fb164e8aa5f2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d6286d84-905d-4504-93e2-9be2f2d9789a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f733c5e7-6326-49cc-b11d-0c258d12674f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("fae2c1e5-54a4-429e-90ec-8336baecf5ee"));

            migrationBuilder.DropColumn(
                name: "WorkingExperience",
                table: "JobOffers");

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("01e5c513-747e-4675-83aa-cdce478b7c98"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("048d966f-eab1-4f8a-8d0c-8b44d16a0578"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("0e1d2b55-033f-4861-8d9d-0261866cf345"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("3026aa7a-0dbf-442e-a617-83f3c7ab8b2b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("30cde8d0-30a0-4d60-9128-f4400d5c10e2"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("33d45478-46d1-4637-a367-cb4e77e8ec78"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("3429b18e-c99d-4ddf-b40d-056ce5957be8"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("35ae1836-4f18-4243-b631-f872e557f317"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("3725a3eb-0d1c-4879-802f-0cc1ba8ceb1c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("3a015e1c-9041-49b2-a89f-bcca4b793f16"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("3d50abdf-5ada-462c-a0b4-dd0eeb6f08e1"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("47659686-f808-4a1f-8743-35dcbe11aac9"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("6b6f28ae-7a73-45f6-9326-8dcd3c9e0d71"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("77e83b3f-75ac-468c-bc23-78aaf2537d69"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("7ac280dc-e58d-4f18-8ab6-0ca78ff05eae"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("7e9fe2e1-4c99-4da3-a78d-621a28f8e144"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("891641b2-5661-471f-bffa-3ef493b63a64"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("89cc2a36-c44a-43fc-b207-95f0d331edeb"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("918dd956-57b0-4010-9fee-43f52d799706"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("d34859a6-f261-434f-9428-b31f031319d2"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("e01765d3-b878-4ecb-ab3a-ef2412227deb"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("e90776ef-67a1-424b-85fd-08c33d5e2904"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("f97f3b8b-0438-4454-ba37-d55339c91b33"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("fcf1888e-b8bc-4b8f-9353-3200d74fb38b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" }
                });
        }
    }
}
