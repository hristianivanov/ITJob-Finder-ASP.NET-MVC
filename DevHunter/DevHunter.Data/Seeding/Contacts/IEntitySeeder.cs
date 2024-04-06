namespace DevHunter.Data.Seeding.Contacts
{
	public interface IEntitySeeder
	{
		Task SeedAsync(DevHunterDbContext dbContext, IServiceProvider serviceProvider);
	}
}
