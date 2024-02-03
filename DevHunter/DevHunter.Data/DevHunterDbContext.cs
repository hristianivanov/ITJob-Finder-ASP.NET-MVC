namespace DevHunter.Data
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using Models;

	public class DevHunterDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public DbSet<JobOffer> JobOffers { get; set; } = null!;
		public DbSet<Company> Companies { get; set; } = null!;
		public DbSet<Technology> Technologies { get; set; } = null!;
		public DbSet<Development> Developments { get; set; } = null!;
		public DbSet<SavedJobOffer> SavedJobOffers { get; set; } = null!;
		public DbSet<TechnologyDevelopments> TechnologiesDevelopments { get; set; } = null!;
		public DbSet<CompanyTechnologies> CompanyTechnologies { get; set; } = null!;
		public DbSet<TechnologyJobOffers> TechnologyJobOffers { get; set; } = null!;

		public DevHunterDbContext(DbContextOptions<DevHunterDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Technology>()
				.OwnsOne(t => t.Image, i =>
				{
					i.Property(i => i.OriginalFileName).HasColumnName("ImageFileName");
					i.Property(i => i.OriginalContent).HasColumnName("ImageOriginalContent");
					i.Property(i => i.ThumbnailContent).HasColumnName("ImageThumbnailContent");
					i.Property(i => i.OriginalType).HasColumnName("ImageOriginalType");
				});

			builder.Entity<TechnologyDevelopments>()
				.HasKey(td => new { td.TechnologyId, td.DevelopmentId });

			builder.Entity<CompanyTechnologies>()
				.HasKey(ct => new { ct.CompanyId, ct.TechnologyId });

			builder.Entity<TechnologyJobOffers>()
				.HasKey(tj => new { tj.JobOfferId, tj.TechnologyId });
		}
	}
}