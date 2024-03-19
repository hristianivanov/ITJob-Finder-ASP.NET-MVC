using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class RenameColumnCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "FoundedYear",
                table: "Companies",
                newName: "FoundedDate");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "FoundedDate",
                table: "Companies",
                newName: "FoundedYear");

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
    }
}
