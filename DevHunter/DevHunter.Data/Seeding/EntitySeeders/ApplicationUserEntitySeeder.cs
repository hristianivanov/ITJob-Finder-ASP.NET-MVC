namespace DevHunter.Data.Seeding.EntitySeeders
{
	using System;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.DependencyInjection;

	using Contacts;
	using Models;

	using static Common.GeneralApplicationConstants;

	public class ApplicationUserEntitySeeder : IEntitySeeder
	{
		public async Task SeedAsync(DevHunterDbContext dbContext, IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			if (await dbContext.Users.AnyAsync())
			{
				return;
			}

			var hasher = new PasswordHasher<ApplicationUser>();

			ApplicationUser applicationUser;

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("F06D4765-779A-4766-EB64-08DB8A42133C"),
				UserName = "defi@gmail.com",
				FirstName = "Defi",
				LastName = "Ivanova",
				Email = "defi@gmail.com",
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "123456");
			await userManager.CreateAsync(applicationUser);

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("F2525385-0162-4B42-8FA5-08DB8A43496A"),
				UserName = "pesho_petrov@yahoo.com",
				FirstName = "Pesho",
				LastName = "Petrov",
				Email = "pesho_petrov@yahoo.com",
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "123456");
			await userManager.CreateAsync(applicationUser);

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("89DCCCDC-645E-4968-822E-5A3761805A21"),
				UserName = "roiti@gmail.com",
				FirstName = "Georgi",
				LastName = "Dimitrov",
				Email = "roiti@gmail.com",
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "company123");
			await userManager.CreateAsync(applicationUser);
			await userManager.AddToRoleAsync(applicationUser, CompanyRoleName);

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("8BC9F34C-E049-478C-9D62-60B5A7E1AE87"),
				UserName = "dxctechnology@gmail.com",
				FirstName = "Boiko",
				LastName = "Borisov",
				Email = "dxctechnology@gmail.com",
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "company123");
			await userManager.CreateAsync(applicationUser);
			await userManager.AddToRoleAsync(applicationUser, CompanyRoleName);

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("9231CC3C-ED70-4A91-AF87-8D70252D9B50"),
				UserName = "yettel@gmail.com",
				FirstName = "Stefan",
				LastName = "Shikov",
				Email = "yettel@gmail.com",
			};
			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "company123");
			await userManager.CreateAsync(applicationUser);
			await userManager.AddToRoleAsync(applicationUser, CompanyRoleName);

			applicationUser = new ApplicationUser()
			{
				Id = Guid.Parse("2F4BBC62-7DB6-4E14-8790-EA0C3D704158"),
				UserName = "smartit@gmail.com",
				FirstName = "Dimitar",
				LastName = "Dimitrov",
				Email = "smartit@gmail.com",
			};

			applicationUser.PasswordHash = hasher.HashPassword(applicationUser, "company123");
			await userManager.CreateAsync(applicationUser);
			await userManager.AddToRoleAsync(applicationUser, CompanyRoleName);
		}
	}
}
