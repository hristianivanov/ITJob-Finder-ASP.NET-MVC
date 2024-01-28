namespace DevHunter.Data
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using Models;

	public class DevHunterDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
	{
		public DbSet<JobOffer> JobOffers { get; set; } = null!;
		public DbSet<Company> Companies { get; set; } = null!;
		public DbSet<Technology> Technologies { get; set; } = null!;
		public DbSet<Development> Developments { get; set; } = null!;
		public DbSet<SavedJobOffer> SavedJobOffers { get; set; } = null!;

		public DevHunterDbContext(DbContextOptions<DevHunterDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Technology>()
				.HasOne(t => t.JobOffer)
				.WithMany(j => j.Technologies)
				.HasForeignKey(t => t.JobOfferId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}