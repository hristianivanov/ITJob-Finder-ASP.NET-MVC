namespace DevHunter.Data.Configurations
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			//builder.HasData(this.GenerateUsers());
		}

		private IEnumerable<ApplicationUser> GenerateUsers()
		{
			var users = new HashSet<ApplicationUser>();
			var hasher = new PasswordHasher<ApplicationUser>();

			ApplicationUser applicationUser;
			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("8A5EDC49-7490-493F-2F01-08DB8A416485"),
				UserName = "admin@gmail.com",
				NormalizedUserName = "ADMIN@GMAIL.COM",
				Email = "admin@gmail.com",
				NormalizedEmail = "ADMIN@GMAIL.COM",
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "admin");
			users.Add(applicationUser);

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("F06D4765-779A-4766-EB64-08DB8A42133C"),
				UserName = "defi@gmail.com",
				NormalizedUserName = "DEFI@GMAIL.COM",
				Email = "defi@gmail.com",
				NormalizedEmail = "DEFI@GMAIL.COM",
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "123456");
			users.Add(applicationUser);

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("F2525385-0162-4B42-8FA5-08DB8A43496A"),
				UserName = "pesho_petrov@yahoo.com",
				NormalizedUserName = "PESHO_PETROV@YAHOO.COM",
				Email = "pesho_petrov@yahoo.com",
				NormalizedEmail = "PESHO_PETROV@YAHOO.COM",
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "123456");
			users.Add(applicationUser);

			return users;
		}
	}
}
