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

			Assembly configAssembly = Assembly.GetAssembly(typeof(DevHunterDbContext)) ??
									  Assembly.GetExecutingAssembly();

			builder.ApplyConfigurationsFromAssembly(configAssembly);
		}
	}
}