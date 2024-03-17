namespace DevHunter.Services.Data
{
	using System.Globalization;

	using Microsoft.EntityFrameworkCore;

	using DevHunter.Data;
	using DevHunter.Data.Models;

	using Interfaces;
	using Web.ViewModels;
	using Web.ViewModels.User;
	using Web.ViewModels.JobOffer;
	using Web.ViewModels.Technology;

	public class CompanyService : ICompanyService
	{
		private readonly DevHunterDbContext context;
		private readonly IImageService imageService;
		private readonly IJobOfferService jobOfferService;


		public CompanyService(DevHunterDbContext context, IImageService imageService, IJobOfferService jobOfferService)
		{
			this.context = context;
			this.imageService = imageService;
			this.jobOfferService = jobOfferService;
		}

		public async Task AddAsync(CompanyRegisterFormModel model, Guid userId)
		{
			var company = new Company()
			{
				Name = model.Name,
				CreatorId = userId,
				WebsiteUrl = model.WebsiteUrl,
				ImageUrl = await this.imageService.UploadImage(model.Image, "DevHunter/companies", model.Name),
			};

			await context.Companies.AddAsync(company);
			await this.context.SaveChangesAsync();
		}

		public async Task<bool> ExistsByNameAsync(string name)
			=> await this.context.Companies.FirstOrDefaultAsync(c => c.Name == name) != null;

		public async Task<bool> ExistsByIdAsync(string id)
		=> await this.context.Companies.FirstOrDefaultAsync(c => c.Id.ToString() == id) != null;


		public async Task<CompanyDetailViewModel> GetDetailsByIdAsync(string id)
		{
			var company = await this.context
				.Companies
				.Include(c => c.JobOffers)
				.ThenInclude(j => j.TechnologyJobOffers)
				.ThenInclude(j => j.Technology)
				.FirstAsync(c => c.Id.ToString() == id);

			var companyJobOffers = company.JobOffers
				.Select(j => new JobOfferAllViewModel()
				{
					Id = j.Id.ToString(),
					CompanyImageUrl = company.ImageUrl,
					CompanyName = company.Name,
					JobPosition = j.JobPosition,
					CreatedOn = j.CreatedOn.ToString("dd MMM."),
					JobLocation = j.PlaceToWork,
					Technologies = j.TechnologyJobOffers
					.Select(tj => new TechnologyViewModel()
					{
						Id = tj.Technology.Id.ToString(),
						Name = tj.Technology.Name,
						ImageUrl = tj.Technology.ImageUrl,
					}).ToList(),
					Salary = GetSalary(j.MinSalary!.Value, j.MaxSalary!.Value),
				}).ToList();

			return new CompanyDetailViewModel()
			{
				Id = company.Id.ToString(),
				WebsiteUrl = company.WebsiteUrl,
				Sector = company.Sector,
				Location = company.Location,
				PaidVacationDays = company.PaidVacationDays.Value,
				EmployeesCnt = company.EmployeeCount.Value,
				FoundedYear = company.FoundedYear.Value.Year,
				Name = company.Name,
				Activity = company.Activity,
				Description = company.Description,
				JobOffers = companyJobOffers
			};
		}


		private static string GetSalary(decimal? minSalary, decimal? maxSalary)
		{
			string? formattedMaxSalary = maxSalary?
				.ToString("#,0", CultureInfo.InvariantCulture)
				.Replace(",", " ");
			string? formattedMinSalary = minSalary?
				.ToString("#,0", CultureInfo.InvariantCulture)
				.Replace(",", " ");

			if (!string.IsNullOrWhiteSpace(formattedMinSalary))
			{
				return $"{formattedMinSalary} - {formattedMaxSalary} lv.";
			}

			return $"{formattedMaxSalary} lv.";
		}
	}
}
