namespace DevHunter.Web.Infrastructure.Extensions
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.DependencyInjection;

	using Data.Models;

	using static Common.GeneralApplicationConstants;

	public static class WebApplicationBuilderExtensions
	{
		/// <summary>
		/// This method seeds company role if it does not exist.
		/// Passed email should be valid email of existing user in the application.
		/// </summary>
		/// <param name="app"></param>
		/// <returns></returns>
		public static IApplicationBuilder SeedCompany(this IApplicationBuilder app)
		{
			using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

			IServiceProvider serviceProvider = scopedServices.ServiceProvider;

			RoleManager<IdentityRole<Guid>> roleManager =
				serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

			Task.Run(async () =>
				{
					if (await roleManager.RoleExistsAsync("Company"))
					{
						return;
					}

					IdentityRole<Guid> role =
						new IdentityRole<Guid>("Company");

					await roleManager.CreateAsync(role);
				})
				.GetAwaiter()
				.GetResult();

			return app;
		}

		/// <summary>
		/// This method seeds admin role if it does not exist.
		/// Passed email should be valid email of existing user in the application.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="email"></param>
		/// <returns></returns>
		public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email = AdminEmail)
		{
			using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

			IServiceProvider serviceProvider = scopedServices.ServiceProvider;

			UserManager<ApplicationUser> userManager =
				serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			RoleManager<IdentityRole<Guid>> roleManager =
				serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

			Task.Run(async () =>
			{
				if (await roleManager.RoleExistsAsync(AdminRoleName))
				{
					return;
				}

				IdentityRole<Guid> role =
					new IdentityRole<Guid>(AdminRoleName);

				await roleManager.CreateAsync(role);
			})
			.GetAwaiter()
			.GetResult();

			Task.Run(async () =>
			{
				ApplicationUser adminUser =
					await userManager.FindByEmailAsync(email);

				if (adminUser == null)
				{
					adminUser = new ApplicationUser()
					{
						Id = Guid.NewGuid(),
						UserName = AdminEmail,
						NormalizedUserName = AdminEmail.ToUpper(),
						Email = AdminEmail,
						NormalizedEmail = AdminEmail.ToUpper(),
						SecurityStamp = Guid.NewGuid().ToString(),
					};

					await userManager.CreateAsync(adminUser, AdminPass);
				}

				await userManager.AddToRoleAsync(adminUser, AdminRoleName);
			})
			.GetAwaiter()
			.GetResult();

			return app;
		}
	}
}
