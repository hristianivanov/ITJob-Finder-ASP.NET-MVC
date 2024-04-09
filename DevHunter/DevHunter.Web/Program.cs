namespace DevHunter.Web
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Data.Models;
	using Data.Seeding;
	using Infrastructure.Extensions;
	using Infrastructure.ModelBinders;
	using Services.Data.Interfaces;

	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
								   ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			builder.Services.AddDbContext<DevHunterDbContext>(options =>
			{
				options.UseLazyLoadingProxies();
				options.UseSqlServer(connectionString);
			});

			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
				{
					options.SignIn.RequireConfirmedAccount =
						builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
					options.Password.RequireLowercase =
						builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
					options.Password.RequireUppercase =
						builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
					options.Password.RequireNonAlphanumeric =
						builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
					options.Password.RequiredLength =
						builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
				})
				.AddRoles<IdentityRole<Guid>>()
				.AddEntityFrameworkStores<DevHunterDbContext>()
				.AddDefaultTokenProviders();

			builder.Services.ConfigureApplicationCookie(cfg =>
			{
				cfg.LoginPath = "/Account/Login";
			});

			builder.Services.AddApplicationServices(typeof(IJobOfferService), builder.Configuration);

			builder.Services.AddControllersWithViews()
				.AddMvcOptions(options =>
				{
					options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
					options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
				});

			var app = builder.Build();

			using (var serviceScope = app.Services.CreateScope())
			{
				var dbContext = serviceScope.ServiceProvider.GetRequiredService<DevHunterDbContext>();

				await dbContext.Database.MigrateAsync();

				await DevHunterDbContextSeeder.SeedAsync(dbContext, serviceScope.ServiceProvider);
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.EnableOnlineUsersCheck();

			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error/500");
				app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

				app.UseHsts();
			}

			app.UseEndpoints(config =>
			{
				config.MapControllerRoute(
					name: "areas",
					pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);

				config.MapDefaultControllerRoute();

				config.MapRazorPages();
			});

			await app.RunAsync();
		}
	}
}