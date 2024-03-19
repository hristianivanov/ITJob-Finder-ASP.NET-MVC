namespace DevHunter.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using DevHunter.Data;
	using Interfaces;
	using Web.ViewModels.Development;
	using DevHunter.Data.Models;
	using DevHunter.Web.ViewModels.Technology;

	public class DevelopmentService : IDevelopmentService
	{
		private readonly IImageService imageService;
		private readonly ITechnologyService technologyService;
		private readonly DevHunterDbContext dbContext;

		public DevelopmentService(DevHunterDbContext dbContext, IImageService imageService, ITechnologyService technologyService)
		{
			this.dbContext = dbContext;
			this.imageService = imageService;
			this.technologyService = technologyService;
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

		public async Task<List<DevelopmentViewModel>> AllAsync()
		{
			var developments = await this.dbContext
				.Developments
				.Select(d => new DevelopmentViewModel()
				{
					Id = d.Id.ToString(),
					Name = d.Name,
					ImageUrl = d.ImageUrl
				})
				.ToListAsync();

			foreach (var development in developments)
			{
				development.Technologies = await this.technologyService.AllByDevelopmentAsync(development.Id);
			}

			return developments;
		}

		public async Task<bool> ExistsByIdAsync(string id)
		{
			bool result = await this.dbContext
				.Developments
				.AnyAsync(t => t.Id.ToString() == id);

			return result;
		}

		public async Task<DevelopmentEditFormModel> GetForEditByIdAsync(string id)
		{
			var development = await this.dbContext
				.Developments
				.FirstAsync(t => t.Id.ToString() == id);

			return new DevelopmentEditFormModel
			{
				Name = development.Name,
				ImageUrl = development.ImageUrl,
			};
		}
	}
}
