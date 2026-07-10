namespace DevHunter.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class TechnologyEntityConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            
        }
    }
}
