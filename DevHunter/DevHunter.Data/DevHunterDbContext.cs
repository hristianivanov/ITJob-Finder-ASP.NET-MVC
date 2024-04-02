namespace DevHunter.Data
{
	using System.Reflection;

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
		public DbSet<JobApplication> JobApplications { get; set; } = null!;
		public DbSet<ApplicationDocument> ApplicationDocuments { get; set; } = null!;
		public DbSet<SavedJobOffer> SavedJobOffers { get; set; } = null!;
		public DbSet<TechnologyDevelopments> TechnologiesDevelopments { get; set; } = null!;
		public DbSet<CompanyTechnologies> CompanyTechnologies { get; set; } = null!;
		public DbSet<TechnologyJobOffers> TechnologyJobOffers { get; set; } = null!;
		public DbSet<UserJobApplications> UsersJobApplications { get; set; } = null!;


		public DevHunterDbContext(DbContextOptions<DevHunterDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<TechnologyDevelopments>()
				.HasKey(td => new { td.TechnologyId, td.DevelopmentId });

			builder.Entity<CompanyTechnologies>()
				.HasKey(ct => new { ct.CompanyId, ct.TechnologyId });

			builder.Entity<TechnologyJobOffers>()
				.HasKey(tj => new { tj.JobOfferId, tj.TechnologyId });

			builder.Entity<SavedJobOffer>()
				.HasKey(sj => new { sj.UserId, sj.JobOfferId });

			builder.Entity<UserJobApplications>()
				.HasKey(uja => new { uja.UserId, uja.JobApplicationId });

			Assembly configAssembly = Assembly.GetAssembly(typeof(DevHunterDbContext)) ??
									  Assembly.GetExecutingAssembly();

			builder.ApplyConfigurationsFromAssembly(configAssembly);


			builder.Entity<Company>()
				.HasOne(c => c.Creator)
				.WithMany(u => u.Companies)
				.HasForeignKey(c => c.CreatorId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}