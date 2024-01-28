using DevHunter.Services.Data.Models.JobOffer;
using DevHunter.Web.ViewModels.JobOffer;

namespace DevHunter.Services.Data
{
	using DevHunter.Data;
	using DevHunter.Data.Models;
	using Interfaces;
	using Microsoft.EntityFrameworkCore;

	public class JobOfferService : IJobOfferService
	{
		private readonly DevHunterDbContext dbContext;

		public JobOfferService(DevHunterDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<AllJobOffersFilteredAndPagedServiceModel> AllAsync(AllJobOffersQueryModel queryModel)
		{
			IQueryable<JobOffer> jobOffersQuery = this.dbContext
				.JobOffers
				//.Where(j => j.IsActive)
				.AsQueryable();

			//TODO: filtering logic


			IEnumerable<JobOfferAllViewModel> allJobOffers = await jobOffersQuery
				//.Where(j => j.IsActive) TODO: is it necessary?
				.Include(j => j.Company)
				.Skip((queryModel.CurrentPage - 1) * queryModel.JobOffersPerPage)
				.Take(queryModel.JobOffersPerPage)
				.Select(j => new JobOfferAllViewModel
				{
					Id = j.Id.ToString(),
					JobPosition = j.JobPosition,
					CompanyImageUrl = j.Company.ImageUrl,
					CompanyName = j.Company.Name,
					CreatedOn = j.CreatedOn.ToString("dd MMM."),
					JobLocation = j.PlaceToWork,
					MaxSalary = j.MaxSalary.ToString()!, // TODO: think when salary is null for the card
					MinSalary = j.MinSalary.ToString()!
				})
				.ToArrayAsync();

			int totalJobOffers = jobOffersQuery.Count();

			return new AllJobOffersFilteredAndPagedServiceModel()
			{
				TotalJobOffersCount = totalJobOffers,
				JobOffers = allJobOffers
			};
		}
	}
}