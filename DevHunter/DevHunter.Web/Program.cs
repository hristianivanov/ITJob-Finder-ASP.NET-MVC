namespace DevHunter.Web
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Data.Models;
	using Infrastructure.Extensions;
	using Infrastructure.ModelBinders;
	using Services.Data;
	using Services.Data.Interfaces;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			builder.Services.AddDbContext<DevHunterDbContext>(options =>
				options.UseSqlServer(connectionString));

			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
				{
					options.SignIn.RequireConfirmedAccount = false;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireUppercase = false;
					options.Password.RequireDigit = false;
				})
				.AddRoles<IdentityRole<Guid>>()
				.AddEntityFrameworkStores<DevHunterDbContext>();

			builder.Services.ConfigureApplicationCookie(cfg =>
			{
				cfg.LoginPath = "/User/Login";
			});

			builder.Services.AddControllersWithViews()
				.AddMvcOptions(options =>
				{
					options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
					options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
				});

			builder.Services.AddScoped<IJobOfferService, JobOfferService>();
			builder.Services.AddScoped<ITechnologyService, TechnologyService>();
			builder.Services.AddScoped<ICompanyService, CompanyService>();

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

			//TODO: in development state
			app.SeedCompany();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();
		}
	}
}