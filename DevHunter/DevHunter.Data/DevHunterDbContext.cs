namespace DevHunter.Web.Data
{
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	public class DevHunterDbContext : IdentityDbContext
	{
		public DevHunterDbContext(DbContextOptions<DevHunterDbContext> options)
			: base(options)
		{
		}
	}
}