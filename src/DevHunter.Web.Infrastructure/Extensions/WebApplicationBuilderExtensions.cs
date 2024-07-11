namespace DevHunter.Web.Infrastructure.Extensions
{
	using System.Linq;
	using System.Reflection;

	using CloudinaryDotNet;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	using Common;
	using Middlewares;
	using Data.Models;

	using static Common.GeneralApplicationConstants;

	public static class WebApplicationBuilderExtensions
	{
		/// <summary>
		/// This method registers all services with their interfaces and implementations of given assembly.
		/// The assembly is taken from the type of any service implementation provided.
		/// </summary>
		/// <param name="serviceType"></param>
		/// <exception cref="InvalidOperationException"></exception>
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, Type serviceType, IConfiguration configuration)
		{
			ConfigureCloudinaryService(services, configuration);

			ConfigureEmailService(services, configuration);

			Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
			if (serviceAssembly == null)
			{
				throw new InvalidOperationException("Invalid service type provided!");
			}

			Type[] serviceTypes = serviceAssembly
				.GetTypes()
				.Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
				.ToArray();

			foreach (Type implementationType in serviceTypes)
			{
				Type? interfaceType = implementationType.GetInterface($"I{implementationType.Name}");

				if (interfaceType == null)
				{
					throw new InvalidOperationException($"No interface is provided for the service with name: {implementationType.Name}");
				}

				services.AddScoped(interfaceType, implementationType);
			}

			return services;
		}

		private static void ConfigureEmailService(IServiceCollection services, IConfiguration configuration)
		{
			var emailConfig = configuration
				.GetSection("EmailConfiguration")
				.Get<EmailConfig>();

			services.AddSingleton(emailConfig);
		}

		private static void ConfigureCloudinaryService(IServiceCollection services, IConfiguration configuration)
		{
			var cloudName = configuration.GetValue<string>("AccountSettings:CloudName");
			var apiKey = configuration.GetValue<string>("AccountSettings:ApiKey");
			var apiSecret = configuration.GetValue<string>("AccountSettings:ApiSecret");

			if (new[] { cloudName, apiKey, apiSecret }.Any(string.IsNullOrWhiteSpace))
			{
				throw new ArgumentException("Please specify your Cloudinary account Information");
			}

			services.AddSingleton(new Cloudinary(new Account(cloudName, apiKey, apiSecret)));
		}

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

		public static IApplicationBuilder EnableOnlineUsersCheck(this IApplicationBuilder app)
		{
			return app.UseMiddleware<OnlineUsersMiddleware>();
		}
	}
}
