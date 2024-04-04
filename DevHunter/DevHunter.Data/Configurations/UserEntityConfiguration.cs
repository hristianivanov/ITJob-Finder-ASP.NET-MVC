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
			builder.HasData(this.GenerateUsers());
		}

		private IEnumerable<ApplicationUser> GenerateUsers()
		{
			var users = new HashSet<ApplicationUser>();
			var hasher = new PasswordHasher<ApplicationUser>();

			ApplicationUser applicationUser;

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

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("89DCCCDC-645E-4968-822E-5A3761805A21"),
				UserName = "roiti@gmail.com",
				NormalizedUserName = "ROITI@GMAIL.COM",
				Email = "roiti@gmail.com",
				NormalizedEmail = "ROITI@GMAIL.COM"
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "company123");
			users.Add(applicationUser);

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("8BC9F34C-E049-478C-9D62-60B5A7E1AE87"),
				UserName = "dxctechnology@gmail.com",
				NormalizedUserName = "DXCTECHNOLOGY@GMAIL.COM",
				Email = "dxctechnology@gmail.com",
				NormalizedEmail = "DXCTECHNOLOGY@GMAIL.COM"
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "company123");
			users.Add(applicationUser);

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("9231CC3C-ED70-4A91-AF87-8D70252D9B50"),
				UserName = "yettel@gmail.com",
				NormalizedUserName = "YETTEL@GMAIL.COM",
				Email = "yettel@gmail.com",
				NormalizedEmail = "YETTEL@GMAIL.COM"
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "company123");
			users.Add(applicationUser);

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("2F4BBC62-7DB6-4E14-8790-EA0C3D704158"),
				UserName = "smartit@gmail.com",
				NormalizedUserName = "SMARTIT@GMAIL.COM",
				Email = "smartit@gmail.com",
				NormalizedEmail = "SMARTIT@GMAIL.COM"
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "company123");
			users.Add(applicationUser);

			return users;
		}
	}
}
