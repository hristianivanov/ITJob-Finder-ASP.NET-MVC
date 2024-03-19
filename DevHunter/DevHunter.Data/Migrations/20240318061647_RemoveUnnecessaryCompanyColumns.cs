using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class RemoveUnnecessaryCompanyColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("208168a0-b7c1-4d02-b23e-dc6f8190ee3e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("32a46de8-8031-4423-b480-f9eaed02b42f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("373eca56-9862-43c7-9815-f6a83bb01107"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3e601a45-8257-4677-b4af-eff4da158b8f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4f02416f-01e1-4837-8aa4-60a7ead0bc66"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5379dc42-996b-48b7-96ab-5faf91b4b3e7"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5b1503b0-77c4-4dd2-b944-fc711f2be42f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5d3e2cb7-10f8-453a-8f0a-07a8feb260de"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("65ebb9b7-f19a-4d4b-8fbe-4c802ce2ab82"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("68861b7d-9baa-4694-bc64-72d95755f39d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("68c37025-c5cc-4e09-8878-92a6ee2607d2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7881243e-9142-4551-8828-00827abd53b8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("79394630-ff56-47a5-b18e-3f4f3accdd0b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8c8d6277-6d50-4eea-93fb-3e78cf77f85d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("903ee453-b7a4-449e-bbf6-8ffc66ec9c1d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("93962e69-bb1d-4743-b4ca-90c0e6018efa"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("94f8b926-378d-40ec-983b-c8fa3d5475aa"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9c585fee-13a0-4dce-857f-1d3551e0d27a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a2503f53-dac6-4f1c-8792-ca0801db32b6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a9b2e8a9-40a0-4d7b-91b0-f290f222c957"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ab21fe6f-cf43-4bcf-ae26-844fa4089705"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bbabc9b1-ae0f-4667-af08-d49875e50c68"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e7c8c758-6384-4765-a48c-8e0eb13f5ba3"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f5c594f4-ed75-438d-9ab4-fd1c5ac1bdcb"));

            migrationBuilder.DropColumn(
                name: "PaidVacationDays",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "WorkingHoursPerDay",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("01e0660a-cc5e-4231-8cb8-4b77faf675b5"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("02357982-488c-42be-8897-01f4c0a38c4f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("0661536b-8b2c-4719-a826-e15781fd61c6"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("1983dc1b-dd3e-419a-b999-08234845fa2a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("258cf6df-05ab-4519-9e8b-6de40733d03f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("27a4b816-edcd-4b61-80f6-f1301f9f4af0"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("2857b4b5-6c79-4b8f-bdbf-1bdb95598838"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("3f1ba21d-31ed-41f5-ac9f-a5b00ece45ea"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("49de4a07-51dd-4d23-a1c5-c71acf614231"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("57dff658-78ff-4a94-88ff-f7f0c8c74b44"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("629a5b10-5458-4ae0-9df7-5ad6be7703f0"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("65e7acdf-dd44-4656-bde1-a32d52595a73"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("7e195663-afd1-4efe-b93d-476a5699089a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("807d4138-bef4-42f4-bcd4-7477fd999217"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("93df91d4-38cf-410f-a07d-d4973b426994"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("a73bbba5-fb45-446e-b461-8bb04cd63f52"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("aa75f934-f0d4-4e55-bd21-7adb70d49307"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("abf41feb-bced-4505-b7d7-b08abbd10277"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("af293b70-325d-4b84-bd63-68211158b218"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("b150355b-7f1a-4460-9294-eb9bb16da1b6"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("ede91045-2f67-4b9e-9a0f-5fb6ac1bb1d7"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("ee8e618a-67f9-4ba6-a25f-489189448be2"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("f206e1b4-38ee-4bf6-8490-86e6ac9d529a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("f8e98839-3a86-45a8-be56-57eea64b898b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("01e0660a-cc5e-4231-8cb8-4b77faf675b5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("02357982-488c-42be-8897-01f4c0a38c4f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0661536b-8b2c-4719-a826-e15781fd61c6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1983dc1b-dd3e-419a-b999-08234845fa2a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("258cf6df-05ab-4519-9e8b-6de40733d03f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("27a4b816-edcd-4b61-80f6-f1301f9f4af0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2857b4b5-6c79-4b8f-bdbf-1bdb95598838"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3f1ba21d-31ed-41f5-ac9f-a5b00ece45ea"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("49de4a07-51dd-4d23-a1c5-c71acf614231"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("57dff658-78ff-4a94-88ff-f7f0c8c74b44"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("629a5b10-5458-4ae0-9df7-5ad6be7703f0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("65e7acdf-dd44-4656-bde1-a32d52595a73"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7e195663-afd1-4efe-b93d-476a5699089a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("807d4138-bef4-42f4-bcd4-7477fd999217"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("93df91d4-38cf-410f-a07d-d4973b426994"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a73bbba5-fb45-446e-b461-8bb04cd63f52"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("aa75f934-f0d4-4e55-bd21-7adb70d49307"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("abf41feb-bced-4505-b7d7-b08abbd10277"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("af293b70-325d-4b84-bd63-68211158b218"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b150355b-7f1a-4460-9294-eb9bb16da1b6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ede91045-2f67-4b9e-9a0f-5fb6ac1bb1d7"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ee8e618a-67f9-4ba6-a25f-489189448be2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f206e1b4-38ee-4bf6-8490-86e6ac9d529a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f8e98839-3a86-45a8-be56-57eea64b898b"));

            migrationBuilder.AddColumn<int>(
                name: "PaidVacationDays",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingHoursPerDay",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("208168a0-b7c1-4d02-b23e-dc6f8190ee3e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("32a46de8-8031-4423-b480-f9eaed02b42f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("373eca56-9862-43c7-9815-f6a83bb01107"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("3e601a45-8257-4677-b4af-eff4da158b8f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("4f02416f-01e1-4837-8aa4-60a7ead0bc66"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("5379dc42-996b-48b7-96ab-5faf91b4b3e7"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("5b1503b0-77c4-4dd2-b944-fc711f2be42f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("5d3e2cb7-10f8-453a-8f0a-07a8feb260de"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("65ebb9b7-f19a-4d4b-8fbe-4c802ce2ab82"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("68861b7d-9baa-4694-bc64-72d95755f39d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("68c37025-c5cc-4e09-8878-92a6ee2607d2"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("7881243e-9142-4551-8828-00827abd53b8"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("79394630-ff56-47a5-b18e-3f4f3accdd0b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("8c8d6277-6d50-4eea-93fb-3e78cf77f85d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("903ee453-b7a4-449e-bbf6-8ffc66ec9c1d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("93962e69-bb1d-4743-b4ca-90c0e6018efa"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("94f8b926-378d-40ec-983b-c8fa3d5475aa"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("9c585fee-13a0-4dce-857f-1d3551e0d27a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("a2503f53-dac6-4f1c-8792-ca0801db32b6"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("a9b2e8a9-40a0-4d7b-91b0-f290f222c957"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("ab21fe6f-cf43-4bcf-ae26-844fa4089705"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("bbabc9b1-ae0f-4667-af08-d49875e50c68"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("e7c8c758-6384-4765-a48c-8e0eb13f5ba3"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("f5c594f4-ed75-438d-9ab4-fd1c5ac1bdcb"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" }
                });
        }
    }
}
