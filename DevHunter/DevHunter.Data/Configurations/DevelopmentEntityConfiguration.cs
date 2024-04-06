namespace DevHunter.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class DevelopmentEntityConfiguration : IEntityTypeConfiguration<Development>
	{
		public void Configure(EntityTypeBuilder<Development> builder)
		{
			//builder.HasData(this.GenerateDevelopments());
		}
	}
}
