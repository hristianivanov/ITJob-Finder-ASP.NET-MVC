namespace DevHunter.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class MappingEntitiesConfiguration : IEntityTypeConfiguration<TechnologyDevelopments>,
		IEntityTypeConfiguration<CompanyTechnologies>,
		IEntityTypeConfiguration<TechnologyJobOffers>,
		IEntityTypeConfiguration<SavedJobOffer>,
		IEntityTypeConfiguration<UserJobApplications>
	{
		public void Configure(EntityTypeBuilder<TechnologyDevelopments> builder)
		{
			builder.HasKey(td => new { td.TechnologyId, td.DevelopmentId });
		}

		public void Configure(EntityTypeBuilder<CompanyTechnologies> builder)
		{
			builder.HasKey(ct => new { ct.CompanyId, ct.TechnologyId });
		}

		public void Configure(EntityTypeBuilder<TechnologyJobOffers> builder)
		{
			builder.HasKey(tj => new { tj.JobOfferId, tj.TechnologyId });
		}

		public void Configure(EntityTypeBuilder<SavedJobOffer> builder)
		{
			builder.HasKey(sj => new { sj.UserId, sj.JobOfferId });
		}

		public void Configure(EntityTypeBuilder<UserJobApplications> builder)
		{
			builder.HasKey(uja => new { uja.UserId, uja.JobApplicationId });
		}
	}
}