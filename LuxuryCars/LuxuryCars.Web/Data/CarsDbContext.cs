namespace LuxuryCars.Web.Data
{
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	public class CarsDbContext : IdentityDbContext
	{
		public CarsDbContext(DbContextOptions<CarsDbContext> options)
			: base(options)
		{
		}
	}
}