using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHunter.Data.Migrations
{
    public partial class AddTechnologyAndDevelopmentConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Developments",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("010164b3-025f-461c-b393-b35bd679bf30"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/Customer%20Support.png", "Customer Support" },
                    { new Guid("09b3a04b-ca29-42db-8f68-85e92f8c83ac"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/Mobile%20Development.png", "Mobile Development" },
                    { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/Infrastructure.png", "Infrastructure" },
                    { new Guid("35f8777e-b96b-49ee-b8d0-44598863c068"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/ERP%20-%20CRM%20development.png", "ERP / CRM Development" },
                    { new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/PM%20-%20BA%20and%20more.png", "PM/BA and more" },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1711954697/DevHunter/development/Backend%20Development.png", "Backend Development" },
                    { new Guid("49bbc31e-0241-411e-81c2-3356d002d3d6"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052845/DevHunter/development/UI%20-%20UX%2C%20Arts.png", "UI/UX, Arts" },
                    { new Guid("5223d4e3-3508-47ca-a24c-538923500838"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052845/DevHunter/development/Technical%20Support.png", "Technical Support" },
                    { new Guid("58e9c362-031c-4106-a273-7b730162f23b"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052406/DevHunter/development/Fullstack%20Development.png", "Fullstack Development" },
                    { new Guid("5f4e14ae-b693-4f22-8167-4c808c436391"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/IT%20Management.png", "IT Management" },
                    { new Guid("60151c1f-394a-49e4-8777-fd85d41f1341"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/Junior%20-%20Intern.png", "Junior/Intern" },
                    { new Guid("6c5ab4bf-2e97-4c27-8483-bbbdb4a6aad7"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/Hardware%20and%20Engineering.png", "Hardware and Engineering" },
                    { new Guid("8448cd52-5cb6-4a42-8324-17c34e58837f"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052845/DevHunter/development/Quality%20Assurance.png", "Quality Assurance" },
                    { new Guid("8b1cdd7b-2455-4067-96f0-452a7a9eba50"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/ERP%20-%20CRM%20development.png", "ERP / CRM Development" },
                    { new Guid("c385035d-2a4d-442a-b6ca-6443bb378be1"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1711959225/DevHunter/development/Frontend%20Development.png", "Frontend Development" },
                    { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/Data%20Science.png", "Data Science" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("049faadc-8d63-4cda-af30-3a8dc6a17ef1"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071545/DevHunter/technology/Postman.png", "Postman" },
                    { new Guid("055f5e0a-ea4f-4335-a37c-ec829fe0b395"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1710397259/DevHunter/technology/Npm.png", "Npm" },
                    { new Guid("075ec4e5-5197-456c-9a75-aa215fa8b3da"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071546/DevHunter/technology/Ruby.png", "Ruby" },
                    { new Guid("097d02e0-0577-4110-8fb7-8989f60d53b9"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071532/DevHunter/technology/Git.png", "Git" },
                    { new Guid("09bead07-5680-4204-a837-2bf34509b3af"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071532/DevHunter/technology/Github.png", "Github" },
                    { new Guid("0b05da1d-b9ae-42e2-a86e-b3746674e6cd"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071537/DevHunter/technology/jQuery.png", "jQuery" },
                    { new Guid("0c07e73e-21de-4d34-acf8-15f1ed993ee9"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071544/DevHunter/technology/Php.jpg", "PHP" },
                    { new Guid("1194737c-bef9-4091-a36c-6dc1c8f574e9"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png", "Kubernetes" },
                    { new Guid("1835a5be-934c-4149-a7bf-72e4d22589b0"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071549/DevHunter/technology/Spine.png", "Spine" },
                    { new Guid("1c30015e-939d-4104-82d9-eeed2eca6210"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071530/DevHunter/technology/Firewall.png", "Firewall" },
                    { new Guid("1e27c97f-ffdb-4d3a-afc6-6d4d75532711"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071547/DevHunter/technology/Salesforce.png", "Salesforce" },
                    { new Guid("1e6ff7c4-ac00-4738-b124-9608b126e979"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1710850648/DevHunter/technology/Jest.jpg", "Jest" },
                    { new Guid("218f872d-55e4-4bb4-8252-41a667dcd39c"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071531/DevHunter/technology/French.png", "French" },
                    { new Guid("2250faa8-6a00-40cc-8bfc-ac6f04601d79"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071548/DevHunter/technology/Shellbash.png", "Shellbash" },
                    { new Guid("2961db2f-88a5-4831-b721-ebf69eff0e2b"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071537/DevHunter/technology/Jira.png", "Jira" },
                    { new Guid("29704a55-8dff-46d3-ad94-6fca2a393b48"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png", "Linux" },
                    { new Guid("2a698b89-b775-41f4-b97d-f20942a72b8d"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071543/DevHunter/technology/Oracle.png", "Oracle" },
                    { new Guid("2c1b6d09-a0ce-4247-827d-8ac66f0d3bf4"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071530/DevHunter/technology/Excel.png", "Excel" },
                    { new Guid("329bd2e3-a970-4ce0-be03-bc5e5e568d2d"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071551/DevHunter/technology/Visual%20studio.png", "Visual Studio" },
                    { new Guid("32bd6276-3776-40a9-a278-73d6dbfed488"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071544/DevHunter/technology/Playright.png", "Playright" },
                    { new Guid("34e4a9b0-deb3-4479-939c-1f37a354c155"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071548/DevHunter/technology/Sketch.png", "Sketch" },
                    { new Guid("361f8fcb-ca22-459a-94c1-3f9e7b3faa25"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png", "Bootstrap" },
                    { new Guid("382e7a27-67cd-4ff0-8f2e-f81051798905"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png", "MongoDb" },
                    { new Guid("39a790cb-1cc9-4fc8-b1c3-ad957bfb28af"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071544/DevHunter/technology/Postgresql.png", "Postgresql" },
                    { new Guid("3a94c0b2-5737-49c9-82a0-2b981ca2aed8"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png", "Ansible" },
                    { new Guid("40e8906f-241b-4b60-b957-9e64b1c1e7a7"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071521/DevHunter/technology/Azure.png", "Azure" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("47656ee3-b8dd-417f-9116-9f6569f67787"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071526/DevHunter/technology/Davinci%20Resolve.png", "Davinci Resolve" },
                    { new Guid("4815599e-4d99-458a-ad41-de90b75b3c0f"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071535/DevHunter/technology/iOs.png", "iOS" },
                    { new Guid("48ba2840-ceb6-4546-9d03-9b9163b131d5"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071520/DevHunter/technology/ASP.Net.png", "ASP.Net" },
                    { new Guid("4972cc43-375b-40a7-829d-9c0acaefbcf0"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png", "Nodejs" },
                    { new Guid("4d77692e-1582-4bd5-b3b9-dc8fa496c690"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071519/DevHunter/technology/Apache%20Apex.png", "Apache Apex" },
                    { new Guid("4fae2df2-174d-43a3-b6d7-a46eb1b298ec"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071517/DevHunter/technology/Adobe%20Creative.png", "Adobe Creative" },
                    { new Guid("51a1d7d5-2eb9-4b82-b161-c5663ac52e90"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071540/DevHunter/technology/Maven.png", "Maven" },
                    { new Guid("55cee988-b391-4796-8ba2-f7bc132d98c6"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071522/DevHunter/technology/Babel.png", "Babel" },
                    { new Guid("564bb8e0-14f2-4812-a754-18697abd6bd7"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071538/DevHunter/technology/Kicad.png", "Kicad" },
                    { new Guid("56e3673e-0798-4f06-b348-d6129e385bad"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png", "Javascript" },
                    { new Guid("57c726d8-8348-4c10-b039-610c7c95c21c"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png", "Django" },
                    { new Guid("593da6d6-919f-457f-b726-5889aa0caab9"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071531/DevHunter/technology/German.png", "German" },
                    { new Guid("5c55f4b2-7f9b-434b-9478-fae3c846f900"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1710850042/DevHunter/technology/AWS.png", "AWS" },
                    { new Guid("5cd0472e-8077-4893-890e-b4bb953c0885"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071542/DevHunter/technology/NetCore.png", ".Net Core" },
                    { new Guid("6208abee-b855-4281-beaa-aa94673784a0"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712078890/DevHunter/technology/Android.png", "Android" },
                    { new Guid("62b07f73-52ce-44c1-8e19-91bac46a6074"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png", "Html5" },
                    { new Guid("646b656f-3fb9-47d5-80e4-ba0f807e70d3"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071534/DevHunter/technology/Informatica.png", "Informatica" },
                    { new Guid("6485e41d-f52a-43a8-821c-cc18498406d2"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071551/DevHunter/technology/Visio.png", "Visio" },
                    { new Guid("64ff7067-eb71-49d1-8672-ac5d71da71ac"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071525/DevHunter/technology/Csharp.png", "C#" },
                    { new Guid("68153bf6-f21f-4029-add0-95575725afed"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071552/DevHunter/technology/Windows.png", "Windows" },
                    { new Guid("7397e5d6-527e-47f9-8f23-20dd62692500"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071542/DevHunter/technology/Net.png", ".Net" },
                    { new Guid("74638738-681d-4375-95a7-3c9016b68383"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071530/DevHunter/technology/Figma.png", "Figma" },
                    { new Guid("773fa43e-1d6e-41c2-a029-c0e15773e565"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071529/DevHunter/technology/Event%20bridge.jpg", "Event bridge" },
                    { new Guid("78cefe08-c625-4bda-bbd8-67c1cf91c1fa"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1710397175/DevHunter/technology/Kotlin.png", "Kotlin" },
                    { new Guid("7a199941-2479-425a-9d3b-f7a73ad05c7f"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071548/DevHunter/technology/Shopify.png", "Shopify" },
                    { new Guid("7b61c994-30e7-48b0-b8a7-2377763627ea"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071525/DevHunter/technology/Coredraw.jpg", "Coredraw" },
                    { new Guid("7efbded2-e248-46d5-b460-ae908229cb2c"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071523/DevHunter/technology/Blockchain.png", "Blockchain" },
                    { new Guid("81692dbb-1b59-432b-a2fa-a56115b38e77"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071540/DevHunter/technology/Microsoft%20office.png", "Microsoft office" },
                    { new Guid("85d93d19-68e5-4baa-8d91-72cd70a6fcea"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071536/DevHunter/technology/Java.png", "Java" },
                    { new Guid("85eb8c55-d4ac-4408-8167-8887f9b3dc78"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png", "Typescript" },
                    { new Guid("88a342ad-594b-4fff-91ee-ce21baadf092"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071535/DevHunter/technology/Internet%20of%20things.png", "Internet of things" },
                    { new Guid("88ce0fe5-bd18-4d14-97bd-0bceb7213ab4"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg", "Gitlab" },
                    { new Guid("8a8e4999-65b7-4c87-92de-be929ac0169f"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071518/DevHunter/technology/Xd.png", "Adobe Xd" },
                    { new Guid("8b8d6dc4-5abe-46fe-b7f9-dbe2c5d2fac9"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png", "React" },
                    { new Guid("8c8373a3-a9bf-4b31-96d8-e9a8ec6a5f13"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712078787/DevHunter/technology/SAP.png", "SAP" },
                    { new Guid("8f655fe5-67cb-4a15-98d0-579bf136c31d"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071533/DevHunter/technology/Google%20cloud.png", "Google Creative" },
                    { new Guid("96ff8fde-ca05-47f6-8dd9-1bb9db0f58b8"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071518/DevHunter/technology/Adobe.png", "Adobe" },
                    { new Guid("9716bf74-9616-4fcc-a33a-3b3801a89ae1"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png", "Ecma" },
                    { new Guid("97d7e08e-f34d-4105-9508-133bcde2c403"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071546/DevHunter/technology/RDBMS.png", "RDBMS" },
                    { new Guid("9d4a5af6-3409-45f7-a326-7b8f769fe764"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071522/DevHunter/technology/Balsamia.png", "Balsamia" },
                    { new Guid("9dcfddda-5de8-4406-8e73-c4c0f6f0951e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png", "Angular" },
                    { new Guid("a111ea4f-b5e1-404a-98f4-29703b584333"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071520/DevHunter/technology/AWAF.png", "AWAF" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("a2b5056f-bea7-4a9b-b2f7-322cef5ba16b"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071552/DevHunter/technology/Waterfall.jpg", "Waterfall" },
                    { new Guid("a367010c-a083-490c-b2ed-976ee8f49c53"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071545/DevHunter/technology/Powershell.png", "Powershell" },
                    { new Guid("a4adde33-5e29-4520-b703-625195b17adc"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071541/DevHunter/technology/Mysql.png", "Mysql" },
                    { new Guid("a664a739-89bc-4b37-a343-402c4ab5b198"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071534/DevHunter/technology/Graphql.png", "Graphql" },
                    { new Guid("a8dfa119-36fe-4b45-a8a1-017289b4eea5"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071539/DevHunter/technology/Mac%20OS.png", "Mac OS" },
                    { new Guid("ac85a8f7-8055-431e-a343-96126fcd4680"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071549/DevHunter/technology/SQL.png", "SQL" },
                    { new Guid("ad4ee1df-2cc4-48d1-9914-bbd68df162ff"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071535/DevHunter/technology/IP.png", "IP" },
                    { new Guid("b06f66e5-1531-4343-8a88-2ffa4b981bcc"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg", "Docker" },
                    { new Guid("b21cc378-8485-4de2-b282-ff63aee397bd"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071543/DevHunter/technology/Outlook.png", "Microsoft Outlook" },
                    { new Guid("b46807cb-75fa-4039-80f2-df044be56f90"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071528/DevHunter/technology/Dragonbones.png", "Dragon bones" },
                    { new Guid("b540d04c-7569-493e-a390-62f3df559d4f"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png", "Python" },
                    { new Guid("bb8aafc8-0ac4-4694-9dda-a10ddfdd31ce"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png", "Go" },
                    { new Guid("c2f40ecc-4f66-4e5b-92fd-7a7bf898bb10"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png", "Flink" },
                    { new Guid("c3fe8667-8b40-4057-bcd6-cba4e5c17370"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071550/DevHunter/technology/Tailwind%20CSS.jpg", "Tailwind CSS" },
                    { new Guid("c43707a9-9307-476c-95e6-3c1381364e0e"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png", "Apache" },
                    { new Guid("c7296f6a-2f8b-42d8-9cc3-7bd6111c576a"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1710665563/DevHunter/technology/Cypress.jpg", "Cypress" },
                    { new Guid("cc431206-48a9-42f7-816b-1c720977a2ea"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png", "CSS" },
                    { new Guid("d9fa804a-d7dd-4ba4-b790-8827a6b06e1e"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712077397/DevHunter/technology/NUnit.png", "NUnit" },
                    { new Guid("dbd65e30-7822-429c-9217-9f53adcc8060"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071520/DevHunter/technology/Photoshop.png", "Adobe Photoshop" },
                    { new Guid("dd012c57-87fa-421b-a955-75a7504b7794"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1711954963/DevHunter/technology/Spring.png", "Spring" },
                    { new Guid("de1b71b5-0646-4740-bda8-70334f459601"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png", "MariaDb" },
                    { new Guid("df7e83ee-76f9-4ef0-97fe-930e79230c20"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071520/DevHunter/technology/Argo%20CD.png", "Argo CD" },
                    { new Guid("e0988db1-54b6-47b9-9293-c96423280230"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071547/DevHunter/technology/SAS.png", "SAS" },
                    { new Guid("e1fdc176-5f0e-44a2-8b02-84f757fe5118"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071536/DevHunter/technology/Jenkins.png", "Jenkins" },
                    { new Guid("e365f0cc-e847-482f-9cd2-3bc87df71ecb"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071522/DevHunter/technology/Bitbucket.png", "Bitbucket" },
                    { new Guid("e6218084-2b54-4165-b8a9-60c0d9ee7e1d"), "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png", "Vue" },
                    { new Guid("e6ded6a5-8674-490f-aa6c-50f2eb477132"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071521/DevHunter/technology/AWS%20Cloudformation.png", "AWS Cloudformation" },
                    { new Guid("e702256c-0504-41e2-aa0d-65c3bffa1095"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071517/DevHunter/technology/ilustrator.png", "Adobe Illustrator" },
                    { new Guid("ed1f9d3f-835c-4af3-95a1-fa2f32e67f4e"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071547/DevHunter/technology/Selenium.png", "Selenium" },
                    { new Guid("f17cd3dd-0853-4a47-95bb-7449128c7fda"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071524/DevHunter/technology/C.jpg", "C++" },
                    { new Guid("f1aaf947-ccbf-4418-a55a-7c48931cb4bf"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071524/DevHunter/technology/Confluence.png", "Confluence" },
                    { new Guid("f66c9fc1-f609-4049-a8e4-cd01b152315e"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1710397054/DevHunter/technology/English.png", "English" },
                    { new Guid("f7861a1b-f927-475f-9a9c-86aa1e923b73"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071550/DevHunter/technology/Terraform.png", "Terraform" },
                    { new Guid("fb31126c-96f7-4043-abaf-009ac7942537"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1710849528/DevHunter/technology/Elastic%20searh.png", "Elastic search" },
                    { new Guid("fcbf7357-7271-497e-a76f-6bf3f27178e4"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071528/DevHunter/technology/Drawio.png", "Draw.io" },
                    { new Guid("fd19139b-6abf-4d8d-99fc-2f35213c750c"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1710415630/DevHunter/technology/Json.png", "Json" },
                    { new Guid("fe4648c2-8e4f-42b1-b27b-d5826830e76a"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071553/DevHunter/technology/Wordpress.png", "Wordpress" },
                    { new Guid("ff98cf9c-d2be-409a-93a3-306ff8c3aacc"), "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071527/DevHunter/technology/DNS.png", "DNS" }
                });

            migrationBuilder.InsertData(
                table: "TechnologiesDevelopments",
                columns: new[] { "DevelopmentId", "TechnologyId", "IsActive" },
                values: new object[,]
                {
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("075ec4e5-5197-456c-9a75-aa215fa8b3da"), true },
                    { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("09bead07-5680-4204-a837-2bf34509b3af"), true },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("0c07e73e-21de-4d34-acf8-15f1ed993ee9"), true },
                    { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("1194737c-bef9-4091-a36c-6dc1c8f574e9"), true },
                    { new Guid("8b1cdd7b-2455-4067-96f0-452a7a9eba50"), new Guid("1e27c97f-ffdb-4d3a-afc6-6d4d75532711"), true },
                    { new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"), new Guid("2961db2f-88a5-4831-b721-ebf69eff0e2b"), true },
                    { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("2a698b89-b775-41f4-b97d-f20942a72b8d"), true },
                    { new Guid("09b3a04b-ca29-42db-8f68-85e92f8c83ac"), new Guid("4815599e-4d99-458a-ad41-de90b75b3c0f"), true },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("48ba2840-ceb6-4546-9d03-9b9163b131d5"), true },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("4972cc43-375b-40a7-829d-9c0acaefbcf0"), true },
                    { new Guid("c385035d-2a4d-442a-b6ca-6443bb378be1"), new Guid("56e3673e-0798-4f06-b348-d6129e385bad"), true },
                    { new Guid("09b3a04b-ca29-42db-8f68-85e92f8c83ac"), new Guid("6208abee-b855-4281-beaa-aa94673784a0"), true },
                    { new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"), new Guid("646b656f-3fb9-47d5-80e4-ba0f807e70d3"), true },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("64ff7067-eb71-49d1-8672-ac5d71da71ac"), true },
                    { new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"), new Guid("81692dbb-1b59-432b-a2fa-a56115b38e77"), true },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("85d93d19-68e5-4baa-8d91-72cd70a6fcea"), true },
                    { new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"), new Guid("88a342ad-594b-4fff-91ee-ce21baadf092"), true },
                    { new Guid("c385035d-2a4d-442a-b6ca-6443bb378be1"), new Guid("8b8d6dc4-5abe-46fe-b7f9-dbe2c5d2fac9"), true },
                    { new Guid("8b1cdd7b-2455-4067-96f0-452a7a9eba50"), new Guid("8c8373a3-a9bf-4b31-96d8-e9a8ec6a5f13"), true },
                    { new Guid("c385035d-2a4d-442a-b6ca-6443bb378be1"), new Guid("9dcfddda-5de8-4406-8e73-c4c0f6f0951e"), true },
                    { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("a367010c-a083-490c-b2ed-976ee8f49c53"), true },
                    { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("b06f66e5-1531-4343-8a88-2ffa4b981bcc"), true },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("b540d04c-7569-493e-a390-62f3df559d4f"), true },
                    { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("bb8aafc8-0ac4-4694-9dda-a10ddfdd31ce"), true },
                    { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("c43707a9-9307-476c-95e6-3c1381364e0e"), true },
                    { new Guid("8448cd52-5cb6-4a42-8324-17c34e58837f"), new Guid("d9fa804a-d7dd-4ba4-b790-8827a6b06e1e"), true },
                    { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("e0988db1-54b6-47b9-9293-c96423280230"), true },
                    { new Guid("c385035d-2a4d-442a-b6ca-6443bb378be1"), new Guid("e6218084-2b54-4165-b8a9-60c0d9ee7e1d"), true },
                    { new Guid("8448cd52-5cb6-4a42-8324-17c34e58837f"), new Guid("ed1f9d3f-835c-4af3-95a1-fa2f32e67f4e"), true },
                    { new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"), new Guid("f1aaf947-ccbf-4418-a55a-7c48931cb4bf"), true },
                    { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("f7861a1b-f927-475f-9a9c-86aa1e923b73"), true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("010164b3-025f-461c-b393-b35bd679bf30"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("35f8777e-b96b-49ee-b8d0-44598863c068"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("49bbc31e-0241-411e-81c2-3356d002d3d6"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("5223d4e3-3508-47ca-a24c-538923500838"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("58e9c362-031c-4106-a273-7b730162f23b"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("5f4e14ae-b693-4f22-8167-4c808c436391"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("60151c1f-394a-49e4-8777-fd85d41f1341"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("6c5ab4bf-2e97-4c27-8483-bbbdb4a6aad7"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("049faadc-8d63-4cda-af30-3a8dc6a17ef1"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("055f5e0a-ea4f-4335-a37c-ec829fe0b395"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("097d02e0-0577-4110-8fb7-8989f60d53b9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0b05da1d-b9ae-42e2-a86e-b3746674e6cd"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1835a5be-934c-4149-a7bf-72e4d22589b0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1c30015e-939d-4104-82d9-eeed2eca6210"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1e6ff7c4-ac00-4738-b124-9608b126e979"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("218f872d-55e4-4bb4-8252-41a667dcd39c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2250faa8-6a00-40cc-8bfc-ac6f04601d79"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("29704a55-8dff-46d3-ad94-6fca2a393b48"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2c1b6d09-a0ce-4247-827d-8ac66f0d3bf4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("329bd2e3-a970-4ce0-be03-bc5e5e568d2d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("32bd6276-3776-40a9-a278-73d6dbfed488"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("34e4a9b0-deb3-4479-939c-1f37a354c155"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("361f8fcb-ca22-459a-94c1-3f9e7b3faa25"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("382e7a27-67cd-4ff0-8f2e-f81051798905"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("39a790cb-1cc9-4fc8-b1c3-ad957bfb28af"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3a94c0b2-5737-49c9-82a0-2b981ca2aed8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("40e8906f-241b-4b60-b957-9e64b1c1e7a7"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("47656ee3-b8dd-417f-9116-9f6569f67787"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4d77692e-1582-4bd5-b3b9-dc8fa496c690"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4fae2df2-174d-43a3-b6d7-a46eb1b298ec"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("51a1d7d5-2eb9-4b82-b161-c5663ac52e90"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("55cee988-b391-4796-8ba2-f7bc132d98c6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("564bb8e0-14f2-4812-a754-18697abd6bd7"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("57c726d8-8348-4c10-b039-610c7c95c21c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("593da6d6-919f-457f-b726-5889aa0caab9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5c55f4b2-7f9b-434b-9478-fae3c846f900"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5cd0472e-8077-4893-890e-b4bb953c0885"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("62b07f73-52ce-44c1-8e19-91bac46a6074"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6485e41d-f52a-43a8-821c-cc18498406d2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("68153bf6-f21f-4029-add0-95575725afed"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7397e5d6-527e-47f9-8f23-20dd62692500"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("74638738-681d-4375-95a7-3c9016b68383"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("773fa43e-1d6e-41c2-a029-c0e15773e565"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("78cefe08-c625-4bda-bbd8-67c1cf91c1fa"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7a199941-2479-425a-9d3b-f7a73ad05c7f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7b61c994-30e7-48b0-b8a7-2377763627ea"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7efbded2-e248-46d5-b460-ae908229cb2c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("85eb8c55-d4ac-4408-8167-8887f9b3dc78"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("88ce0fe5-bd18-4d14-97bd-0bceb7213ab4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8a8e4999-65b7-4c87-92de-be929ac0169f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8f655fe5-67cb-4a15-98d0-579bf136c31d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("96ff8fde-ca05-47f6-8dd9-1bb9db0f58b8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9716bf74-9616-4fcc-a33a-3b3801a89ae1"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("97d7e08e-f34d-4105-9508-133bcde2c403"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9d4a5af6-3409-45f7-a326-7b8f769fe764"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a111ea4f-b5e1-404a-98f4-29703b584333"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a2b5056f-bea7-4a9b-b2f7-322cef5ba16b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a4adde33-5e29-4520-b703-625195b17adc"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a664a739-89bc-4b37-a343-402c4ab5b198"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a8dfa119-36fe-4b45-a8a1-017289b4eea5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ac85a8f7-8055-431e-a343-96126fcd4680"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ad4ee1df-2cc4-48d1-9914-bbd68df162ff"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b21cc378-8485-4de2-b282-ff63aee397bd"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b46807cb-75fa-4039-80f2-df044be56f90"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c2f40ecc-4f66-4e5b-92fd-7a7bf898bb10"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c3fe8667-8b40-4057-bcd6-cba4e5c17370"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c7296f6a-2f8b-42d8-9cc3-7bd6111c576a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("cc431206-48a9-42f7-816b-1c720977a2ea"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("dbd65e30-7822-429c-9217-9f53adcc8060"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("dd012c57-87fa-421b-a955-75a7504b7794"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("de1b71b5-0646-4740-bda8-70334f459601"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("df7e83ee-76f9-4ef0-97fe-930e79230c20"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e1fdc176-5f0e-44a2-8b02-84f757fe5118"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e365f0cc-e847-482f-9cd2-3bc87df71ecb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e6ded6a5-8674-490f-aa6c-50f2eb477132"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e702256c-0504-41e2-aa0d-65c3bffa1095"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f17cd3dd-0853-4a47-95bb-7449128c7fda"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f66c9fc1-f609-4049-a8e4-cd01b152315e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("fb31126c-96f7-4043-abaf-009ac7942537"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("fcbf7357-7271-497e-a76f-6bf3f27178e4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("fd19139b-6abf-4d8d-99fc-2f35213c750c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("fe4648c2-8e4f-42b1-b27b-d5826830e76a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ff98cf9c-d2be-409a-93a3-306ff8c3aacc"));

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("075ec4e5-5197-456c-9a75-aa215fa8b3da") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("09bead07-5680-4204-a837-2bf34509b3af") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("0c07e73e-21de-4d34-acf8-15f1ed993ee9") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("1194737c-bef9-4091-a36c-6dc1c8f574e9") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("8b1cdd7b-2455-4067-96f0-452a7a9eba50"), new Guid("1e27c97f-ffdb-4d3a-afc6-6d4d75532711") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"), new Guid("2961db2f-88a5-4831-b721-ebf69eff0e2b") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("2a698b89-b775-41f4-b97d-f20942a72b8d") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("09b3a04b-ca29-42db-8f68-85e92f8c83ac"), new Guid("4815599e-4d99-458a-ad41-de90b75b3c0f") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("48ba2840-ceb6-4546-9d03-9b9163b131d5") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("4972cc43-375b-40a7-829d-9c0acaefbcf0") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("c385035d-2a4d-442a-b6ca-6443bb378be1"), new Guid("56e3673e-0798-4f06-b348-d6129e385bad") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("09b3a04b-ca29-42db-8f68-85e92f8c83ac"), new Guid("6208abee-b855-4281-beaa-aa94673784a0") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"), new Guid("646b656f-3fb9-47d5-80e4-ba0f807e70d3") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("64ff7067-eb71-49d1-8672-ac5d71da71ac") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"), new Guid("81692dbb-1b59-432b-a2fa-a56115b38e77") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("85d93d19-68e5-4baa-8d91-72cd70a6fcea") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"), new Guid("88a342ad-594b-4fff-91ee-ce21baadf092") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("c385035d-2a4d-442a-b6ca-6443bb378be1"), new Guid("8b8d6dc4-5abe-46fe-b7f9-dbe2c5d2fac9") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("8b1cdd7b-2455-4067-96f0-452a7a9eba50"), new Guid("8c8373a3-a9bf-4b31-96d8-e9a8ec6a5f13") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("c385035d-2a4d-442a-b6ca-6443bb378be1"), new Guid("9dcfddda-5de8-4406-8e73-c4c0f6f0951e") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("a367010c-a083-490c-b2ed-976ee8f49c53") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("b06f66e5-1531-4343-8a88-2ffa4b981bcc") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("b540d04c-7569-493e-a390-62f3df559d4f") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"), new Guid("bb8aafc8-0ac4-4694-9dda-a10ddfdd31ce") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("c43707a9-9307-476c-95e6-3c1381364e0e") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("8448cd52-5cb6-4a42-8324-17c34e58837f"), new Guid("d9fa804a-d7dd-4ba4-b790-8827a6b06e1e") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"), new Guid("e0988db1-54b6-47b9-9293-c96423280230") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("c385035d-2a4d-442a-b6ca-6443bb378be1"), new Guid("e6218084-2b54-4165-b8a9-60c0d9ee7e1d") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("8448cd52-5cb6-4a42-8324-17c34e58837f"), new Guid("ed1f9d3f-835c-4af3-95a1-fa2f32e67f4e") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"), new Guid("f1aaf947-ccbf-4418-a55a-7c48931cb4bf") });

            migrationBuilder.DeleteData(
                table: "TechnologiesDevelopments",
                keyColumns: new[] { "DevelopmentId", "TechnologyId" },
                keyValues: new object[] { new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"), new Guid("f7861a1b-f927-475f-9a9c-86aa1e923b73") });

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("09b3a04b-ca29-42db-8f68-85e92f8c83ac"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("134cb2eb-71a2-430f-ae7d-b01895cbefb8"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("3925bab7-3529-47e6-807f-37a57d9c9cfd"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("8448cd52-5cb6-4a42-8324-17c34e58837f"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("8b1cdd7b-2455-4067-96f0-452a7a9eba50"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("c385035d-2a4d-442a-b6ca-6443bb378be1"));

            migrationBuilder.DeleteData(
                table: "Developments",
                keyColumn: "Id",
                keyValue: new Guid("f86ea64b-6602-48e6-a951-c4eed172decd"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("075ec4e5-5197-456c-9a75-aa215fa8b3da"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("09bead07-5680-4204-a837-2bf34509b3af"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0c07e73e-21de-4d34-acf8-15f1ed993ee9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1194737c-bef9-4091-a36c-6dc1c8f574e9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1e27c97f-ffdb-4d3a-afc6-6d4d75532711"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2961db2f-88a5-4831-b721-ebf69eff0e2b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2a698b89-b775-41f4-b97d-f20942a72b8d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4815599e-4d99-458a-ad41-de90b75b3c0f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("48ba2840-ceb6-4546-9d03-9b9163b131d5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4972cc43-375b-40a7-829d-9c0acaefbcf0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("56e3673e-0798-4f06-b348-d6129e385bad"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6208abee-b855-4281-beaa-aa94673784a0"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("646b656f-3fb9-47d5-80e4-ba0f807e70d3"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("64ff7067-eb71-49d1-8672-ac5d71da71ac"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("81692dbb-1b59-432b-a2fa-a56115b38e77"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("85d93d19-68e5-4baa-8d91-72cd70a6fcea"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("88a342ad-594b-4fff-91ee-ce21baadf092"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8b8d6dc4-5abe-46fe-b7f9-dbe2c5d2fac9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8c8373a3-a9bf-4b31-96d8-e9a8ec6a5f13"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9dcfddda-5de8-4406-8e73-c4c0f6f0951e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a367010c-a083-490c-b2ed-976ee8f49c53"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b06f66e5-1531-4343-8a88-2ffa4b981bcc"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b540d04c-7569-493e-a390-62f3df559d4f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bb8aafc8-0ac4-4694-9dda-a10ddfdd31ce"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c43707a9-9307-476c-95e6-3c1381364e0e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d9fa804a-d7dd-4ba4-b790-8827a6b06e1e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e0988db1-54b6-47b9-9293-c96423280230"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e6218084-2b54-4165-b8a9-60c0d9ee7e1d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ed1f9d3f-835c-4af3-95a1-fa2f32e67f4e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f1aaf947-ccbf-4418-a55a-7c48931cb4bf"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f7861a1b-f927-475f-9a9c-86aa1e923b73"));

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
    }
}
