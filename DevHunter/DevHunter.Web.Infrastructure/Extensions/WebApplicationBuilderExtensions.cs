namespace DevHunter.Web.Infrastructure.Extensions
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.DependencyInjection;

	using Data.Models;

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
	}
}
