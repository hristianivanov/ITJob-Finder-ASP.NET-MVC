namespace DevHunter.Data.Configurations
{
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Microsoft.EntityFrameworkCore;

	using Models;

	public class TechnologyDevelopmentsEntityConfiguration : IEntityTypeConfiguration<TechnologyDevelopments>
	{
		public void Configure(EntityTypeBuilder<TechnologyDevelopments> builder)
		{
			builder.HasData(this.GenerateTechnologyDevelopments());
		}

		private IEnumerable<TechnologyDevelopments> GenerateTechnologyDevelopments()
		{
			return new HashSet<TechnologyDevelopments>()
			{
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"),
					TechnologyId = Guid.Parse("85d93d19-68e5-4baa-8d91-72cd70a6fcea"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"),
					TechnologyId = Guid.Parse("85eb8c55-d4ac-4408-8167-8887f9b3dc78"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"),
					TechnologyId = Guid.Parse("64ff7067-eb71-49d1-8672-ac5d71da71ac"),
					IsActive = true,
				},new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"),
					TechnologyId = Guid.Parse("075ec4e5-5197-456c-9a75-aa215fa8b3da"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"),
					TechnologyId = Guid.Parse("b540d04c-7569-493e-a390-62f3df559d4f"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"),
					TechnologyId = Guid.Parse("bb8aafc8-0ac4-4694-9dda-a10ddfdd31ce"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"),
					TechnologyId = Guid.Parse("4972cc43-375b-40a7-829d-9c0acaefbcf0"),
					IsActive = true,
				},


				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("c385035d-2a4d-442a-b6ca-6443bb378be1"),
					TechnologyId = Guid.Parse("56e3673e-0798-4f06-b348-d6129e385bad"),
					IsActive= true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("c385035d-2a4d-442a-b6ca-6443bb378be1"),
					TechnologyId = Guid.Parse("8b8d6dc4-5abe-46fe-b7f9-dbe2c5d2fac9"),
					IsActive= true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("c385035d-2a4d-442a-b6ca-6443bb378be1"),
					TechnologyId = Guid.Parse("9dcfddda-5de8-4406-8e73-c4c0f6f0951e"),
					IsActive= true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("c385035d-2a4d-442a-b6ca-6443bb378be1"),
					TechnologyId = Guid.Parse("e6218084-2b54-4165-b8a9-60c0d9ee7e1d"),
					IsActive= true,
				},


				new TechnologyDevelopments
				{
					DevelopmentId =   Guid.Parse("134cb2eb-71a2-430f-ae7d-b01895cbefb8"),
					TechnologyId = Guid.Parse("1194737c-bef9-4091-a36c-6dc1c8f574e9"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId =   Guid.Parse("134cb2eb-71a2-430f-ae7d-b01895cbefb8"),
					TechnologyId = Guid.Parse("a367010c-a083-490c-b2ed-976ee8f49c53"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId =  Guid.Parse("134cb2eb-71a2-430f-ae7d-b01895cbefb8"),
					TechnologyId = Guid.Parse("f7861a1b-f927-475f-9a9c-86aa1e923b73"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId =  Guid.Parse("134cb2eb-71a2-430f-ae7d-b01895cbefb8"),
					TechnologyId = Guid.Parse("e1fdc176-5f0e-44a2-8b02-84f757fe5118"),
					IsActive = true,
				},


				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("8448cd52-5cb6-4a42-8324-17c34e58837f"),
					TechnologyId = Guid.Parse("d9fa804a-d7dd-4ba4-b790-8827a6b06e1e"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("8448cd52-5cb6-4a42-8324-17c34e58837f"),
					TechnologyId = Guid.Parse("ed1f9d3f-835c-4af3-95a1-fa2f32e67f4e"),
					IsActive = true,
				},


				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("3925bab7-3529-47e6-807f-37a57d9c9cfd"),
					TechnologyId = Guid.Parse("88a342ad-594b-4fff-91ee-ce21baadf092"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("3925bab7-3529-47e6-807f-37a57d9c9cfd"),
					TechnologyId = Guid.Parse("81692dbb-1b59-432b-a2fa-a56115b38e77"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("3925bab7-3529-47e6-807f-37a57d9c9cfd"),
					TechnologyId = Guid.Parse("646b656f-3fb9-47d5-80e4-ba0f807e70d3"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("3925bab7-3529-47e6-807f-37a57d9c9cfd"),
					TechnologyId = Guid.Parse("2961db2f-88a5-4831-b721-ebf69eff0e2b"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("3925bab7-3529-47e6-807f-37a57d9c9cfd"),
					TechnologyId = Guid.Parse("f1aaf947-ccbf-4418-a55a-7c48931cb4bf"),
					IsActive = true,
				},


				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("f86ea64b-6602-48e6-a951-c4eed172decd"),
					TechnologyId = Guid.Parse("e0988db1-54b6-47b9-9293-c96423280230"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("f86ea64b-6602-48e6-a951-c4eed172decd"),
					TechnologyId = Guid.Parse("c43707a9-9307-476c-95e6-3c1381364e0e"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("f86ea64b-6602-48e6-a951-c4eed172decd"),
					TechnologyId = Guid.Parse("2a698b89-b775-41f4-b97d-f20942a72b8d"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("f86ea64b-6602-48e6-a951-c4eed172decd"),
					TechnologyId = Guid.Parse("1835a5be-934c-4149-a7bf-72e4d22589b0"),
					IsActive = true,
				},


				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("8b1cdd7b-2455-4067-96f0-452a7a9eba50"),
					TechnologyId = Guid.Parse("1e27c97f-ffdb-4d3a-afc6-6d4d75532711"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("8b1cdd7b-2455-4067-96f0-452a7a9eba50"),
					TechnologyId = Guid.Parse("8c8373a3-a9bf-4b31-96d8-e9a8ec6a5f13"),
					IsActive = true,
				},


				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("09b3a04b-ca29-42db-8f68-85e92f8c83ac"),
					TechnologyId = Guid.Parse("4815599e-4d99-458a-ad41-de90b75b3c0f"),
					IsActive = true,
				},
				new TechnologyDevelopments
				{
					DevelopmentId = Guid.Parse("09b3a04b-ca29-42db-8f68-85e92f8c83ac"),
					TechnologyId = Guid.Parse("6208abee-b855-4281-beaa-aa94673784a0"),
					IsActive = true,
				},
			};
		}
	}
}
