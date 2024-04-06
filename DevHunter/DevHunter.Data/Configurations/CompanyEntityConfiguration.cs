namespace DevHunter.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder
				.HasOne(c => c.Creator)
				.WithMany(u => u.Companies)
				.HasForeignKey(c => c.CreatorId)
				.OnDelete(DeleteBehavior.Restrict);

			//builder.HasData(this.GenerateCompanies());
		}
	}
}
