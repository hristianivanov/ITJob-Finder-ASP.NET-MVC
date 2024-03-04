namespace DevHunter.Services.Data
{
	using DevHunter.Data;
	using DevHunter.Data.Models;
	using Interfaces;
	using Microsoft.EntityFrameworkCore;
	using Web.ViewModels.User;

	public class CompanyService : ICompanyService
	{
		private readonly DevHunterDbContext context;
		private readonly IImageService imageService;

		public CompanyService(DevHunterDbContext context, IImageService imageService)
        {
            this.context = context;
            this.imageService = imageService;
        }

		public async Task AddAsync(CompanyRegisterFormModel model)
		{
			var company = new Company()
			{
				Name = model.Name,
				WebsiteUrl = model.WebsiteUrl,
				ImageUrl = await this.imageService.UploadImage(model.Image,"DevHunter/companies",model.Name),
			};

			await context.Companies.AddAsync(company);
			await this.context.SaveChangesAsync();
		}

		public async Task<bool> ExistsByNameAsync(string name) 
			=> await this.context.Companies.FirstOrDefaultAsync(c => c.Name == name) != null;
	}
}
