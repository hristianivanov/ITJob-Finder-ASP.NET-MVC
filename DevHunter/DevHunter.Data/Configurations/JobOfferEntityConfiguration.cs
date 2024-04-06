namespace DevHunter.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class JobOfferEntityConfiguration : IEntityTypeConfiguration<JobOffer>
	{
		public void Configure(EntityTypeBuilder<JobOffer> builder)
		{

		}
	}
}
