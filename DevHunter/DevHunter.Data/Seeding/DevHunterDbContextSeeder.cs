namespace DevHunter.Data.Seeding
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Logging;

	using Contacts;
	using Models;
	using EntitySeeders;

	using static Common.GeneralApplicationConstants;

	public static class DevHunterDbContextSeeder
	{
		public static async Task SeedAsync(DevHunterDbContext dbContext, IServiceProvider serviceProvider)
		{
			if (dbContext == null)
			{
				throw new ArgumentNullException(nameof(dbContext));
			}

			if (serviceProvider == null)
			{
				throw new ArgumentNullException(nameof(serviceProvider));
			}

			var logger = serviceProvider
				.GetService<ILoggerFactory>()?
				.CreateLogger(typeof(DevHunterDbContext));

			using var scope = serviceProvider.CreateScope();

			var roleManager = scope.ServiceProvider
				.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
			var userManager = scope.ServiceProvider
				.GetRequiredService<UserManager<ApplicationUser>>();

			if (!await roleManager.RoleExistsAsync(CompanyRoleName))
			{
				IdentityRole<Guid> companyRole =
					new IdentityRole<Guid>(CompanyRoleName);

				await roleManager.CreateAsync(companyRole);

				logger?.LogInformation("Company role created.");
			}

			var seeders = new List<IEntitySeeder>
			{
				new ApplicationUserEntitySeeder(),
				new CompanyEntitySeeder(),
				new TechnologyEntitySeeder(),
				new DevelopmentEntitySeeder(),
				new JobOfferEntitySeeder(),
			};

			foreach (var seeder in seeders)
			{
				await seeder.SeedAsync(dbContext, serviceProvider);
				logger?.LogInformation($"Seeder {seeder.GetType().Name} done.");
			}

			if (!await roleManager.RoleExistsAsync(AdminRoleName))
			{
				IdentityRole<Guid> adminRole =
					new IdentityRole<Guid>(AdminRoleName);

				await roleManager.CreateAsync(adminRole);

				logger?.LogInformation("Admin role created.");
			}


			ApplicationUser adminUser =
				await userManager.FindByEmailAsync(AdminEmail);

			if (adminUser == null)
			{
				adminUser = new ApplicationUser()
				{
					UserName = AdminEmail,
					Email = AdminEmail,
				};

				await userManager.CreateAsync(adminUser, AdminPass);

				logger?.LogInformation($"Created admin profile.");
			}

			if (!await userManager.IsInRoleAsync(adminUser, AdminRoleName))
			{
				await userManager.AddToRoleAsync(adminUser, AdminRoleName);

				logger?.LogInformation($"Assigned admin role to the admin.");
			}
		}
	}
}
