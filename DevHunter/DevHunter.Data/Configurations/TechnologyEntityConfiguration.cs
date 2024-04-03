namespace DevHunter.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class TechnologyEntityConfiguration : IEntityTypeConfiguration<Technology>
	{
		public void Configure(EntityTypeBuilder<Technology> builder)
		{
			//builder.OwnsOne(t => t.Image, i =>
			//	{
			//		i.Property(i => i.OriginalFileName).HasColumnName("ImageFileName");
			//		i.Property(i => i.OriginalContent).HasColumnName("ImageOriginalContent");
			//		i.Property(i => i.ThumbnailContent).HasColumnName("ImageThumbnailContent");
			//		i.Property(i => i.OriginalType).HasColumnName("ImageOriginalType");
			//	});

			builder.HasData(this.GenerateTechnologies());
		}

		private IEnumerable<Technology> GenerateTechnologies()
		{
			return new HashSet<Technology>()
			{
				new Technology
				{
					Id = Guid.Parse("bb8aafc8-0ac4-4694-9dda-a10ddfdd31ce"),
					Name = "Go",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071533/DevHunter/technology/Go.png"
				},
				new Technology
				{
					Id= Guid.Parse("62b07f73-52ce-44c1-8e19-91bac46a6074"),
					Name = "Html5",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png"
				},
				new Technology
				{
					Id= Guid.Parse("1194737c-bef9-4091-a36c-6dc1c8f574e9"),
					Name = "Kubernetes",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png"
				},
				new Technology
				{
					Id= Guid.Parse("c43707a9-9307-476c-95e6-3c1381364e0e"),
					Name = "Apache",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png"
				},
				new Technology
				{
					Id= Guid.Parse("9dcfddda-5de8-4406-8e73-c4c0f6f0951e"),
					Name = "Angular",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png"
				},
				new Technology
				{
					Id= Guid.Parse("56e3673e-0798-4f06-b348-d6129e385bad"),
					Name = "Javascript",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png"
				},
				new Technology
				{
					Id= Guid.Parse("88ce0fe5-bd18-4d14-97bd-0bceb7213ab4"),
					Name = "Gitlab",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg"
				},
				new Technology
				{
					Id= Guid.Parse("cc431206-48a9-42f7-816b-1c720977a2ea"),
					Name = "CSS",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png"
				},
				new Technology
				{
					Id= Guid.Parse("361f8fcb-ca22-459a-94c1-3f9e7b3faa25"),
					Name = "Bootstrap",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png"
				},
				new Technology
				{
					Id= Guid.Parse("8b8d6dc4-5abe-46fe-b7f9-dbe2c5d2fac9"),
					Name = "React",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png"
				},
				new Technology
				{
					Id= Guid.Parse("b540d04c-7569-493e-a390-62f3df559d4f"),
					Name = "Python",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png"
				},
				new Technology
				{
					Id= Guid.Parse("57c726d8-8348-4c10-b039-610c7c95c21c"),
					Name = "Django",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png"
				},
				new Technology
				{
					Id= Guid.Parse("382e7a27-67cd-4ff0-8f2e-f81051798905"),
					Name = "MongoDb",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png"
				},
				new Technology
				{
					Id= Guid.Parse("3a94c0b2-5737-49c9-82a0-2b981ca2aed8"),
					Name = "Ansible",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png"
				},
				new Technology
				{
					Id= Guid.Parse("c2f40ecc-4f66-4e5b-92fd-7a7bf898bb10"),
					Name = "Flink",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png"
				},
				new Technology
				{
					Id= Guid.Parse("9716bf74-9616-4fcc-a33a-3b3801a89ae1"),
					Name = "Ecma",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png"
				},
				new Technology
				{
					Id= Guid.Parse("29704a55-8dff-46d3-ad94-6fca2a393b48"),
					Name = "Linux",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png"
				},
				new Technology
				{
					Id= Guid.Parse("85eb8c55-d4ac-4408-8167-8887f9b3dc78"),
					Name = "Typescript",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png"
				},
				new Technology
				{
					Id= Guid.Parse("de1b71b5-0646-4740-bda8-70334f459601"),
					Name = "MariaDb",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png"
				},
				new Technology
				{
					Id= Guid.Parse("4972cc43-375b-40a7-829d-9c0acaefbcf0"),
					Name = "Nodejs",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png"
				},
				new Technology
				{
					Id= Guid.Parse("b06f66e5-1531-4343-8a88-2ffa4b981bcc"),
					Name = "Docker",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg"
				},
				new Technology
				{
					Id= Guid.Parse("e6218084-2b54-4165-b8a9-60c0d9ee7e1d"),
					Name = "Vue",
					ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png"
				},
				new Technology
				{
					Id = Guid.Parse("f66c9fc1-f609-4049-a8e4-cd01b152315e"),
					Name="English",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1710397054/DevHunter/technology/English.png"
				},
				new Technology
				{
					Id = Guid.Parse("78cefe08-c625-4bda-bbd8-67c1cf91c1fa"),
					Name="Kotlin",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1710397175/DevHunter/technology/Kotlin.png"
				},
				new Technology
				{
					Id = Guid.Parse("055f5e0a-ea4f-4335-a37c-ec829fe0b395"),
					Name="Npm",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1710397259/DevHunter/technology/Npm.png"
				},
				new Technology
				{
					Id = Guid.Parse("fd19139b-6abf-4d8d-99fc-2f35213c750c"),
					Name="Json",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1710415630/DevHunter/technology/Json.png"
				},
				new Technology
				{
					Id = Guid.Parse("c7296f6a-2f8b-42d8-9cc3-7bd6111c576a"),
					Name = "Cypress",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1710665563/DevHunter/technology/Cypress.jpg"
				},
				new Technology
				{
					Id = Guid.Parse("fb31126c-96f7-4043-abaf-009ac7942537"),
					Name = "Elastic search",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1710849528/DevHunter/technology/Elastic%20searh.png"
				},
				new Technology
				{
					Id = Guid.Parse("5c55f4b2-7f9b-434b-9478-fae3c846f900"),
					Name = "AWS",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1710850042/DevHunter/technology/AWS.png"
				},
				new Technology
				{
					Id = Guid.Parse("1e6ff7c4-ac00-4738-b124-9608b126e979"),
					Name = "Jest",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1710850648/DevHunter/technology/Jest.jpg"
				},
				new Technology
				{
					Id = Guid.Parse("dd012c57-87fa-421b-a955-75a7504b7794"),
					Name = "Spring",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1711954963/DevHunter/technology/Spring.png"
				},
				new Technology
				{
					Id = Guid.Parse("e702256c-0504-41e2-aa0d-65c3bffa1095"),
					Name = "Adobe Illustrator",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071517/DevHunter/technology/ilustrator.png"
				},
				new Technology
				{
					Id = Guid.Parse("4fae2df2-174d-43a3-b6d7-a46eb1b298ec"),
					Name = "Adobe Creative",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071517/DevHunter/technology/Adobe%20Creative.png"
				},
				new Technology
				{
					Id = Guid.Parse("8a8e4999-65b7-4c87-92de-be929ac0169f"),
					Name = "Adobe Xd",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071518/DevHunter/technology/Xd.png"
				},
				new Technology
				{
					Id = Guid.Parse("96ff8fde-ca05-47f6-8dd9-1bb9db0f58b8"),
					Name = "Adobe",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071518/DevHunter/technology/Adobe.png"
				},
				new Technology
				{
					Id = Guid.Parse("4d77692e-1582-4bd5-b3b9-dc8fa496c690"),
					Name = "Apache Apex",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071519/DevHunter/technology/Apache%20Apex.png"
				},
				new Technology
				{
					Id = Guid.Parse("df7e83ee-76f9-4ef0-97fe-930e79230c20"),
					Name = "Argo CD",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071520/DevHunter/technology/Argo%20CD.png"
				},
				new Technology
				{
					Id = Guid.Parse("dbd65e30-7822-429c-9217-9f53adcc8060"),
					Name = "Adobe Photoshop",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071520/DevHunter/technology/Photoshop.png"
				},
				new Technology
				{
					Id = Guid.Parse("48ba2840-ceb6-4546-9d03-9b9163b131d5"),
					Name = "ASP.Net",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071520/DevHunter/technology/ASP.Net.png"
				},
				new Technology
				{
					Id = Guid.Parse("a111ea4f-b5e1-404a-98f4-29703b584333"),
					Name = "AWAF",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071520/DevHunter/technology/AWAF.png"
				},
				new Technology
				{
					Id = Guid.Parse("e6ded6a5-8674-490f-aa6c-50f2eb477132"),
					Name = "AWS Cloudformation",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071521/DevHunter/technology/AWS%20Cloudformation.png"
				},
				new Technology
				{
					Id = Guid.Parse("40e8906f-241b-4b60-b957-9e64b1c1e7a7"),
					Name = "Azure",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071521/DevHunter/technology/Azure.png"
				},
				new Technology
				{
					Id = Guid.Parse("55cee988-b391-4796-8ba2-f7bc132d98c6"),
					Name = "Babel",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071522/DevHunter/technology/Babel.png"
				},
				new Technology
				{
					Id = Guid.Parse("9d4a5af6-3409-45f7-a326-7b8f769fe764"),
					Name = "Balsamia",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071522/DevHunter/technology/Balsamia.png"
				},
				new Technology
				{
					Id = Guid.Parse("e365f0cc-e847-482f-9cd2-3bc87df71ecb"),
					Name = "Bitbucket",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071522/DevHunter/technology/Bitbucket.png"
				},
				new Technology
				{
					Id = Guid.Parse("7efbded2-e248-46d5-b460-ae908229cb2c"),
					Name = "Blockchain",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071523/DevHunter/technology/Blockchain.png"
				},
				new Technology
				{
					Id = Guid.Parse("f17cd3dd-0853-4a47-95bb-7449128c7fda"),
					Name = "C++",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071524/DevHunter/technology/C.jpg"
				},
				new Technology
				{
					Id = Guid.Parse("f1aaf947-ccbf-4418-a55a-7c48931cb4bf"),
					Name = "Confluence",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071524/DevHunter/technology/Confluence.png"
				},
				new Technology
				{
					Id = Guid.Parse("7b61c994-30e7-48b0-b8a7-2377763627ea"),
					Name = "Coredraw",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071525/DevHunter/technology/Coredraw.jpg"
				},
				new Technology
				{
					Id = Guid.Parse("64ff7067-eb71-49d1-8672-ac5d71da71ac"),
					Name = "C#",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071525/DevHunter/technology/Csharp.png"
				},
				new Technology
				{
					Id = Guid.Parse("47656ee3-b8dd-417f-9116-9f6569f67787"),
					Name = "Davinci Resolve",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071526/DevHunter/technology/Davinci%20Resolve.png"
				},
				new Technology
				{
					Id = Guid.Parse("ff98cf9c-d2be-409a-93a3-306ff8c3aacc"),
					Name = "DNS",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071527/DevHunter/technology/DNS.png"
				},
				new Technology
				{
					Id = Guid.Parse("b46807cb-75fa-4039-80f2-df044be56f90"),
					Name = "Dragon bones",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071528/DevHunter/technology/Dragonbones.png"
				},
				new Technology
				{
					Id = Guid.Parse("fcbf7357-7271-497e-a76f-6bf3f27178e4"),
					Name = "Draw.io",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071528/DevHunter/technology/Drawio.png"
				},
				new Technology
				{
					Id = Guid.Parse("773fa43e-1d6e-41c2-a029-c0e15773e565"),
					Name = "Event bridge",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071529/DevHunter/technology/Event%20bridge.jpg"
				},
				new Technology
				{
					Id = Guid.Parse("2c1b6d09-a0ce-4247-827d-8ac66f0d3bf4"),
					Name = "Excel",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071530/DevHunter/technology/Excel.png"
				},
				new Technology
				{
					Id = Guid.Parse("74638738-681d-4375-95a7-3c9016b68383"),
					Name = "Figma",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071530/DevHunter/technology/Figma.png"
				},
				new Technology
				{
					Id = Guid.Parse("1c30015e-939d-4104-82d9-eeed2eca6210"),
					Name = "Firewall",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071530/DevHunter/technology/Firewall.png"
				},
				new Technology
				{
					Id = Guid.Parse("218f872d-55e4-4bb4-8252-41a667dcd39c"),
					Name = "French",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071531/DevHunter/technology/French.png"
				},
				new Technology
				{
					Id = Guid.Parse("593da6d6-919f-457f-b726-5889aa0caab9"),
					Name = "German",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071531/DevHunter/technology/German.png"
				},
				new Technology
				{
					Id = Guid.Parse("097d02e0-0577-4110-8fb7-8989f60d53b9"),
					Name = "Git",
					ImageUrl="https://res.cloudinary.com/dlffxtrek/image/upload/v1712071532/DevHunter/technology/Git.png"
				},
				new Technology
				{
					Id = Guid.Parse("09bead07-5680-4204-a837-2bf34509b3af"),
					Name = "Github",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071532/DevHunter/technology/Github.png"
				},
				new Technology
				{
					Id = Guid.Parse("8f655fe5-67cb-4a15-98d0-579bf136c31d"),
					Name = "Google Creative",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071533/DevHunter/technology/Google%20cloud.png"
				},
				new Technology
				{
					Id = Guid.Parse("a664a739-89bc-4b37-a343-402c4ab5b198"),
					Name = "Graphql",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071534/DevHunter/technology/Graphql.png"
				},
				new Technology
				{
					Id = Guid.Parse("646b656f-3fb9-47d5-80e4-ba0f807e70d3"),
					Name = "Informatica",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071534/DevHunter/technology/Informatica.png"
				},
				new Technology
				{
					Id = Guid.Parse("88a342ad-594b-4fff-91ee-ce21baadf092"),
					Name = "Internet of things",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071535/DevHunter/technology/Internet%20of%20things.png"
				},
				new Technology
				{
					Id = Guid.Parse("4815599e-4d99-458a-ad41-de90b75b3c0f"),
					Name = "iOS",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071535/DevHunter/technology/iOs.png"
				},
				new Technology
				{
					Id = Guid.Parse("ad4ee1df-2cc4-48d1-9914-bbd68df162ff"),
					Name = "IP",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071535/DevHunter/technology/IP.png"
				},
				new Technology
				{
					Id = Guid.Parse("85d93d19-68e5-4baa-8d91-72cd70a6fcea") ,
					Name = "Java",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071536/DevHunter/technology/Java.png"
				},
				new Technology
				{
					Id = Guid.Parse("e1fdc176-5f0e-44a2-8b02-84f757fe5118") ,
					Name = "Jenkins",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071536/DevHunter/technology/Jenkins.png"
				},
				new Technology
				{
					Id = Guid.Parse("2961db2f-88a5-4831-b721-ebf69eff0e2b") ,
					Name = "Jira",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071537/DevHunter/technology/Jira.png"
				},
				new Technology
				{
					Id = Guid.Parse("0b05da1d-b9ae-42e2-a86e-b3746674e6cd") ,
					Name = "jQuery",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071537/DevHunter/technology/jQuery.png"
				},
				new Technology
				{
					Id = Guid.Parse("564bb8e0-14f2-4812-a754-18697abd6bd7") ,
					Name = "Kicad",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071538/DevHunter/technology/Kicad.png"
				},
				new Technology
				{
					Id = Guid.Parse("a8dfa119-36fe-4b45-a8a1-017289b4eea5") ,
					Name = "Mac OS",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071539/DevHunter/technology/Mac%20OS.png"
				},
				new Technology
				{
					Id = Guid.Parse("81692dbb-1b59-432b-a2fa-a56115b38e77") ,
					Name = "Microsoft office",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071540/DevHunter/technology/Microsoft%20office.png"
				},
				new Technology
				{
					Id = Guid.Parse("51a1d7d5-2eb9-4b82-b161-c5663ac52e90") ,
					Name = "Maven",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071540/DevHunter/technology/Maven.png"
				},
				new Technology
				{
					Id = Guid.Parse("a4adde33-5e29-4520-b703-625195b17adc") ,
					Name = "Mysql",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071541/DevHunter/technology/Mysql.png"
				},
				new Technology
				{
					Id = Guid.Parse("7397e5d6-527e-47f9-8f23-20dd62692500") ,
					Name = ".Net",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071542/DevHunter/technology/Net.png"
				},
				new Technology
				{
					Id = Guid.Parse("5cd0472e-8077-4893-890e-b4bb953c0885") ,
					Name = ".Net Core",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071542/DevHunter/technology/NetCore.png"
				},
				new Technology
				{
					Id = Guid.Parse("2a698b89-b775-41f4-b97d-f20942a72b8d") ,
					Name = "Oracle",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071543/DevHunter/technology/Oracle.png"
				},
				new Technology
				{
					Id = Guid.Parse("b21cc378-8485-4de2-b282-ff63aee397bd") ,
					Name = "Microsoft Outlook",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071543/DevHunter/technology/Outlook.png"
				},
				new Technology
				{
					Id = Guid.Parse("0c07e73e-21de-4d34-acf8-15f1ed993ee9") ,
					Name = "PHP",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071544/DevHunter/technology/Php.jpg"
				},
				new Technology
				{
					Id = Guid.Parse("32bd6276-3776-40a9-a278-73d6dbfed488") ,
					Name = "Playright",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071544/DevHunter/technology/Playright.png"
				},
				new Technology
				{
					Id = Guid.Parse("39a790cb-1cc9-4fc8-b1c3-ad957bfb28af") ,
					Name = "Postgresql",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071544/DevHunter/technology/Postgresql.png"
				},
				new Technology
				{
					Id = Guid.Parse("049faadc-8d63-4cda-af30-3a8dc6a17ef1") ,
					Name = "Postman",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071545/DevHunter/technology/Postman.png"
				},
				new Technology
				{
					Id = Guid.Parse("a367010c-a083-490c-b2ed-976ee8f49c53") ,
					Name = "Powershell",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071545/DevHunter/technology/Powershell.png"
				},
				new Technology
				{
					Id = Guid.Parse("97d7e08e-f34d-4105-9508-133bcde2c403") ,
					Name = "RDBMS",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071546/DevHunter/technology/RDBMS.png"
				},
				new Technology
				{
					Id = Guid.Parse("075ec4e5-5197-456c-9a75-aa215fa8b3da") ,
					Name = "Ruby",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071546/DevHunter/technology/Ruby.png"
				},
				new Technology
				{
					Id = Guid.Parse("1e27c97f-ffdb-4d3a-afc6-6d4d75532711") ,
					Name = "Salesforce",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071547/DevHunter/technology/Salesforce.png"
				},
				new Technology
				{
					Id = Guid.Parse("e0988db1-54b6-47b9-9293-c96423280230") ,
					Name = "SAS",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071547/DevHunter/technology/SAS.png"
				},
				new Technology
				{
					Id = Guid.Parse("ed1f9d3f-835c-4af3-95a1-fa2f32e67f4e") ,
					Name = "Selenium",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071547/DevHunter/technology/Selenium.png"
				},
				new Technology
				{
					Id = Guid.Parse("2250faa8-6a00-40cc-8bfc-ac6f04601d79") ,
					Name = "Shellbash",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071548/DevHunter/technology/Shellbash.png"
				},
				new Technology
				{
					Id = Guid.Parse("7a199941-2479-425a-9d3b-f7a73ad05c7f") ,
					Name = "Shopify",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071548/DevHunter/technology/Shopify.png"
				},
				new Technology
				{
					Id = Guid.Parse("34e4a9b0-deb3-4479-939c-1f37a354c155") ,
					Name = "Sketch",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071548/DevHunter/technology/Sketch.png"
				},
				new Technology
				{
					Id = Guid.Parse("1835a5be-934c-4149-a7bf-72e4d22589b0") ,
					Name = "Spine",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071549/DevHunter/technology/Spine.png"
				},
				new Technology
				{
					Id = Guid.Parse("ac85a8f7-8055-431e-a343-96126fcd4680") ,
					Name = "SQL",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071549/DevHunter/technology/SQL.png"
				},
				new Technology
				{
					Id = Guid.Parse("c3fe8667-8b40-4057-bcd6-cba4e5c17370") ,
					Name = "Tailwind CSS",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071550/DevHunter/technology/Tailwind%20CSS.jpg"
				},
				new Technology
				{
					Id = Guid.Parse("f7861a1b-f927-475f-9a9c-86aa1e923b73") ,
					Name = "Terraform",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071550/DevHunter/technology/Terraform.png"
				},
				new Technology
				{
					Id = Guid.Parse("6485e41d-f52a-43a8-821c-cc18498406d2") ,
					Name = "Visio",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071551/DevHunter/technology/Visio.png"
				},
				new Technology
				{
					Id = Guid.Parse("329bd2e3-a970-4ce0-be03-bc5e5e568d2d") ,
					Name = "Visual Studio",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071551/DevHunter/technology/Visual%20studio.png"
				},
				new Technology
				{
					Id = Guid.Parse("a2b5056f-bea7-4a9b-b2f7-322cef5ba16b") ,
					Name = "Waterfall",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071552/DevHunter/technology/Waterfall.jpg"
				},
				new Technology
				{
					Id = Guid.Parse("68153bf6-f21f-4029-add0-95575725afed") ,
					Name = "Windows",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071552/DevHunter/technology/Windows.png"
				},
				new Technology
				{
					Id = Guid.Parse("fe4648c2-8e4f-42b1-b27b-d5826830e76a"),
					Name = "Wordpress",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712071553/DevHunter/technology/Wordpress.png"
				},
				new Technology
				{
					Id = Guid.Parse("d9fa804a-d7dd-4ba4-b790-8827a6b06e1e"),
					Name = "NUnit",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712077397/DevHunter/technology/NUnit.png"
				},
				new Technology
				{
					Id = Guid.Parse("8c8373a3-a9bf-4b31-96d8-e9a8ec6a5f13"),
					Name = "SAP",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712078787/DevHunter/technology/SAP.png"
				},
				new Technology
				{
					Id = Guid.Parse("6208abee-b855-4281-beaa-aa94673784a0"),
					Name = "Android",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712078890/DevHunter/technology/Android.png"
				}
			};
		}
	}
}
