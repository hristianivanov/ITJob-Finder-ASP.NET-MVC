using DevHunter.Web.ViewModels.Technology;

namespace DevHunter.Services.Data
{
	using DevHunter.Data;
	using DevHunter.Data.Models;
	using Interfaces;
	using Microsoft.EntityFrameworkCore;

	public class TechnologyService : ITechnologyService
	{
		private readonly DevHunterDbContext dbContext;

		public TechnologyService(DevHunterDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<bool> TechnologyExistsByNameAsync(string technologyName)
		{
			bool exists = await this.dbContext
				.Technologies
				.AnyAsync(t => t.Name.ToLower() == technologyName.ToLower());

			return exists;
		}

		public async Task AddAsync(TechnologyFormModel formModel)
		{
			Technology technology = new Technology()
			{
				Name = formModel.Name,
				ImageUrl = formModel.ImageUrl,
			};

			await this.dbContext.Technologies.AddAsync(technology);
			await this.dbContext.SaveChangesAsync();
		}
	}
}
