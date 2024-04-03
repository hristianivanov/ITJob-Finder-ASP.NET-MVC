namespace DevHunter.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class DevelopmentEntityConfiguration : IEntityTypeConfiguration<Development>
	{
		public void Configure(EntityTypeBuilder<Development> builder)
		{
			builder.HasData(this.GenerateDevelopments());
		}

		private IEnumerable<Development> GenerateDevelopments()
		{
			return new HashSet<Development>()
			{
				new Development()
				{
					Id = Guid.Parse("4423b2a0-4b46-49fd-b6cd-92eadfcbcfd0"),
					Name = "Backend Development",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1711954697/DevHunter/development/Backend%20Development.png"
				},
				new Development()
				{
					Id = Guid.Parse("c385035d-2a4d-442a-b6ca-6443bb378be1"),
					Name = "Frontend Development",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1711959225/DevHunter/development/Frontend%20Development.png"
				},
				new Development()
				{
					Id = Guid.Parse("010164b3-025f-461c-b393-b35bd679bf30"),
					Name = "Customer Support",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/Customer%20Support.png"
				},
				new Development()
				{
					Id = Guid.Parse("58e9c362-031c-4106-a273-7b730162f23b"),
					Name = "Fullstack Development",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052406/DevHunter/development/Fullstack%20Development.png"
				},
				new Development()
				{
					Id = Guid.Parse("f86ea64b-6602-48e6-a951-c4eed172decd"),
					Name = "Data Science",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/Data%20Science.png"
				},
				new Development() {
					Id = Guid.Parse("5f4e14ae-b693-4f22-8167-4c808c436391"),
					Name = "IT Management",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/IT%20Management.png",
				},
				new Development() {
					Id = Guid.Parse("8b1cdd7b-2455-4067-96f0-452a7a9eba50"),
					Name = "ERP / CRM Development",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052843/DevHunter/development/ERP%20-%20CRM%20development.png",
				},
				new Development() {
					Id = Guid.Parse("134cb2eb-71a2-430f-ae7d-b01895cbefb8"),
					Name = "Infrastructure",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/Infrastructure.png",
				},
				new Development() {
					Id = Guid.Parse("60151c1f-394a-49e4-8777-fd85d41f1341"),
					Name = "Junior/Intern",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/Junior%20-%20Intern.png",
				},
				new Development() {
					Id = Guid.Parse("09b3a04b-ca29-42db-8f68-85e92f8c83ac"),
					Name = "Mobile Development",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/Mobile%20Development.png",
				},
				new Development() {
					Id = Guid.Parse("3925bab7-3529-47e6-807f-37a57d9c9cfd"),
					Name = "PM/BA and more",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052844/DevHunter/development/PM%20-%20BA%20and%20more.png",
				},
				new Development() {
					Id = Guid.Parse("8448cd52-5cb6-4a42-8324-17c34e58837f"),
					Name = "Quality Assurance",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052845/DevHunter/development/Quality%20Assurance.png",
				},
				new Development() {
					Id = Guid.Parse("5223d4e3-3508-47ca-a24c-538923500838"),
					Name = "Technical Support",
					ImageUrl = "https://res.cloudinary.com/dlffxtrek/image/upload/v1712052845/DevHunter/development/Technical%20Support.png",
				}
			};
		}
	}
}
