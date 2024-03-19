using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class AddColumnIsActiveInTechnologyDevelopments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("101af421-d482-4551-90e8-4d59a7a67efb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("27e2ac32-6a17-42bf-bb26-33f32f4a0b33"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3495bb04-a023-4359-84c6-195353ae1c19"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3972955e-f830-4870-8c27-b99cb4f10ec0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("51fc7007-edc0-4d15-b7b6-558dd31951ac"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("54b5b559-50ba-407e-b7a2-d669fda5d5a1"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6163100c-a08c-420b-8400-629f15d204c7"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("77eb7251-180f-4ecc-8ad5-32e38fac6d0f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7d0caa7a-38ea-476e-b641-7ae41102b841"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("81bdac65-c259-4e47-bee2-3598e0f6e49a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("870b99df-39ee-4a51-8299-655318403198"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9d75fff3-d2d1-4984-8f1e-9ad3ee6f72c5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9e8a122f-0198-4598-8c98-e602683d4865"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a254d33e-b9d5-4d86-8798-003cf9aba949"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a3783abd-f007-42d1-9e5f-508903d7259e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a66c1453-9748-4c9e-9183-b8f5330ccffc"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c29ce445-1834-4d48-bfbd-a19d00b1de20"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("cfd0bb21-335b-4cba-88a5-c697410d8392"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("de422914-5599-4d54-98dd-04eb7ec2768b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("df0b6e1d-2882-4d7d-bd34-74d73149baa8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e90f948b-3fb9-4713-a635-9bf56f2309fe"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ea0130fa-a618-4841-8c6b-243c69132576"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f5319ca7-f8ed-4872-9cc9-2fe96c7bea75"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("fcbae05a-3265-41d2-93ad-4a631fa793be"));

            migrationBuilder.DropColumn(
                name: "Seniority",
                table: "JobOffers");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TechnologiesDevelopments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("057c856a-a8d4-47ea-adb9-aa1cb4c5c684"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("08692db5-be1a-4586-8c3f-721b1f746a65"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("0a6a79a3-e696-428b-9f3f-c878588a5e5c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("0d8ba513-b1d6-4d29-8754-3f01ba659160"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("14f42a88-ece9-456c-b2aa-c2b23b7accfd"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("19074b0e-5ae0-4852-9b08-f79084d1555a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("1a41a768-701f-435c-9cc0-6979a7cc780a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("24102f04-ae18-4867-a2fd-97a48d7630b2"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("4564ac31-15b2-4c5c-8166-af60f0a5e460"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("4aece328-6599-40e2-b7a3-a6ecaf237f5c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("4ca07fb4-25f9-49a6-8240-426df5ffd898"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("612f95cc-4a40-40b9-9a25-60db16931b55"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("619e038e-65b0-48a0-917c-b1ea6a986714"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("70fa5119-2a10-4c3b-b376-d48d4f86c90b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("7d393185-a0ad-43c4-956b-99c165586883"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("8b623cfc-0fc2-48a1-9d50-2dd2fa10e29f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("9b461614-1684-41ba-826c-8078cef2792b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("a04d0130-1494-43a6-ba1d-cbdc2583665b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("a7f4819d-c4f4-4fba-a276-10d4391e1581"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("ccd4096a-cd02-483e-a5f1-3346a663fb4a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("dce63ab6-fae4-4a8a-8078-2fbd07f6f139"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("df4aa445-dc26-44b9-b2df-b31e61f22d9c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("dfa1833a-bfb5-458f-9759-c730c8f02275"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("f67233de-0d05-4f8e-a662-74956e067d6a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("057c856a-a8d4-47ea-adb9-aa1cb4c5c684"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("08692db5-be1a-4586-8c3f-721b1f746a65"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0a6a79a3-e696-428b-9f3f-c878588a5e5c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0d8ba513-b1d6-4d29-8754-3f01ba659160"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("14f42a88-ece9-456c-b2aa-c2b23b7accfd"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("19074b0e-5ae0-4852-9b08-f79084d1555a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1a41a768-701f-435c-9cc0-6979a7cc780a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("24102f04-ae18-4867-a2fd-97a48d7630b2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4564ac31-15b2-4c5c-8166-af60f0a5e460"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4aece328-6599-40e2-b7a3-a6ecaf237f5c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4ca07fb4-25f9-49a6-8240-426df5ffd898"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("612f95cc-4a40-40b9-9a25-60db16931b55"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("619e038e-65b0-48a0-917c-b1ea6a986714"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("70fa5119-2a10-4c3b-b376-d48d4f86c90b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7d393185-a0ad-43c4-956b-99c165586883"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8b623cfc-0fc2-48a1-9d50-2dd2fa10e29f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9b461614-1684-41ba-826c-8078cef2792b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a04d0130-1494-43a6-ba1d-cbdc2583665b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a7f4819d-c4f4-4fba-a276-10d4391e1581"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ccd4096a-cd02-483e-a5f1-3346a663fb4a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("dce63ab6-fae4-4a8a-8078-2fbd07f6f139"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("df4aa445-dc26-44b9-b2df-b31e61f22d9c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("dfa1833a-bfb5-458f-9759-c730c8f02275"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f67233de-0d05-4f8e-a662-74956e067d6a"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TechnologiesDevelopments");

            migrationBuilder.AddColumn<int>(
                name: "Seniority",
                table: "JobOffers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("101af421-d482-4551-90e8-4d59a7a67efb"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("27e2ac32-6a17-42bf-bb26-33f32f4a0b33"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("3495bb04-a023-4359-84c6-195353ae1c19"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("3972955e-f830-4870-8c27-b99cb4f10ec0"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("51fc7007-edc0-4d15-b7b6-558dd31951ac"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("54b5b559-50ba-407e-b7a2-d669fda5d5a1"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("6163100c-a08c-420b-8400-629f15d204c7"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("77eb7251-180f-4ecc-8ad5-32e38fac6d0f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("7d0caa7a-38ea-476e-b641-7ae41102b841"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("81bdac65-c259-4e47-bee2-3598e0f6e49a"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("870b99df-39ee-4a51-8299-655318403198"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("9d75fff3-d2d1-4984-8f1e-9ad3ee6f72c5"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("9e8a122f-0198-4598-8c98-e602683d4865"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("a254d33e-b9d5-4d86-8798-003cf9aba949"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("a3783abd-f007-42d1-9e5f-508903d7259e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("a66c1453-9748-4c9e-9183-b8f5330ccffc"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("c29ce445-1834-4d48-bfbd-a19d00b1de20"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("cfd0bb21-335b-4cba-88a5-c697410d8392"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("de422914-5599-4d54-98dd-04eb7ec2768b"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("df0b6e1d-2882-4d7d-bd34-74d73149baa8"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("e90f948b-3fb9-4713-a635-9bf56f2309fe"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("ea0130fa-a618-4841-8c6b-243c69132576"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("f5319ca7-f8ed-4872-9cc9-2fe96c7bea75"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("fcbae05a-3265-41d2-93ad-4a631fa793be"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" }
                });
        }
    }
}
