namespace DevHunter.Services.Data
{
	using DevHunter.Data;
	using Interfaces;

	public class JobOfferService : IJobOfferService
	{
		private readonly DevHunterDbContext dbContext;

		public JobOfferService(DevHunterDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
	}
}