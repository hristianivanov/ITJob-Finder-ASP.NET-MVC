namespace DevHunter.Data
{
    using DevHunter.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	public class DevHunterDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
	{
		public DevHunterDbContext(DbContextOptions<DevHunterDbContext> options)
			: base(options)
		{
		}
	}
}