namespace DevHunter.Web
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	using CloudinaryDotNet;

	using Data;
	using Data.Models;
	using Infrastructure.Extensions;
	using Infrastructure.ModelBinders;
    using Services.Data.Interfaces;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

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
				.AddEntityFrameworkStores<DevHunterDbContext>();

			builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/Account/Login";
            });

            builder.Services.AddApplicationServices(typeof(IJobOfferService));

			ConfigureCloudinaryService(builder.Services, builder.Configuration);

			builder.Services.AddControllersWithViews()
				.AddMvcOptions(options =>
				{
					options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
					options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
				});

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.EnableOnlineUsersCheck();

			//TODO: in development state
			app.SeedCompany();
			app.SeedAdministrator();

			app.UseEndpoints(config =>
			{
				config.MapControllerRoute(
					name: "areas",
					pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);

				config.MapDefaultControllerRoute();

				config.MapRazorPages();
			});


			app.Run();
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
	}
}