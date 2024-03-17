namespace DevHunter.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using DevHunter.Data;
	using Interfaces;
	using Web.ViewModels.Development;
	using DevHunter.Data.Models;

	public class DevelopmentService : IDevelopmentService
	{
		private readonly IImageService imageService;
		private readonly DevHunterDbContext dbContext;

		public DevelopmentService(DevHunterDbContext dbContext, IImageService imageService)
		{
			this.dbContext = dbContext;
			this.imageService = imageService;
		}

		public async Task<bool> ExistsByNameAsync(string name)
		{
			bool exists = await this.dbContext
				.Developments
				.AnyAsync(t => t.Name.ToLower() == name.ToLower());

			return exists;
		}

		public async Task AddAsync(DevelopmentFormModel formModel)
		{
			Development development = new Development()
			{
				Name = formModel.Name,
				ImageUrl = await this.imageService
					.UploadImage(formModel.Image, "DevHunter/development", formModel.Name)
			};

			await this.dbContext.Developments.AddAsync(development);
			await this.dbContext.SaveChangesAsync();
		}
	}
}
