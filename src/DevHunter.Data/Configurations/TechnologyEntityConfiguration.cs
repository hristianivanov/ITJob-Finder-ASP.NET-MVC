namespace DevHunter.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class TechnologyEntityConfiguration : IEntityTypeConfiguration<Technology>
	{
		public void Configure(EntityTypeBuilder<Technology> builder)
		{
			//builder.OwnsOne(t => t.Image, i =>
			//	{
			//		i.Property(i => i.OriginalFileName).HasColumnName("ImageFileName");
			//		i.Property(i => i.OriginalContent).HasColumnName("ImageOriginalContent");
			//		i.Property(i => i.ThumbnailContent).HasColumnName("ImageThumbnailContent");
			//		i.Property(i => i.OriginalType).HasColumnName("ImageOriginalType");
			//	});
		}
	}
}
