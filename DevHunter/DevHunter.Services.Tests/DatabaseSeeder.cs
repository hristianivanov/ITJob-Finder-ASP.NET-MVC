namespace DevHunter.Services.Tests
{
	using Microsoft.AspNetCore.Identity;

	using DevHunter.Data;
	using DevHunter.Data.Models;

	using static Common.GeneralApplicationConstants;

	public static class DatabaseSeeder
	{
		public static async void SeedDatabase(DevHunterDbContext dbContext)
		{
			await SeedUsers(dbContext);
			await SeedDevelopments(dbContext);

			await dbContext.SaveChangesAsync();
		}

		private static async Task SeedDevelopments(DevHunterDbContext dbContext)
		{
			var developments = new Development[]
			{
				new()
				{
					Name = "development_1",
					ImageUrl = "testImageUrl",
				},
				new()
				{
					Name = "development_2",
					ImageUrl = "testImageUrl",
				}
			};

			await dbContext.Developments.AddRangeAsync(developments);
		}

		private static async Task SeedUsers(DevHunterDbContext dbContext)
		{
			var roles = new IdentityRole<Guid>[]
			{
				new()
				{
					Name =  AdminRoleName
				},
				new()
				{
					Name =  CompanyRoleName
				},
			};

			var users = new ApplicationUser[]
			{
				new()
				{
					UserName = "test",
					Email = "test@gmail.com",
					PasswordHash = "hashedPassword",
				},
				new()
				{
					UserName = "company",
					Email = "company@gmail.com",
					PasswordHash = "hashedPassword"
				},
				new()
				{
					UserName = "admin",
					Email = "admin@gmail.com",
					PasswordHash = "hashedPassword"
				},
			};

			await dbContext.Roles.AddRangeAsync(roles);
			await dbContext.Users.AddRangeAsync(users);

			await dbContext.UserRoles.AddRangeAsync(new IdentityUserRole<Guid>[]
			{
				new()
				{
					UserId = users[2].Id,
					RoleId = roles[0].Id
				},
				new()
				{
					UserId = users[1].Id,
					RoleId = roles[1].Id
				},
			});
		}
	}
}