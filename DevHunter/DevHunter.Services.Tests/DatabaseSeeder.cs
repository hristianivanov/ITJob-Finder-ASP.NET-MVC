namespace DevHunter.Services.Tests
{
	using DevHunter.Data;

	public static class DatabaseSeeder
	{
		public static void SeedDatabase(DevHunterDbContext dbContext)
		{

			dbContext.SaveChanges();
		}
	}
}
