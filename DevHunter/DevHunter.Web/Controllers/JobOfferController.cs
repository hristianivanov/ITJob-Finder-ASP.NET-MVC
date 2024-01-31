namespace DevHunter.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Interfaces;
	using Services.Data.Models.JobOffer;
	using ViewModels.JobOffer;

	public class JobOfferController : Controller
	{
		private readonly IJobOfferService jobOfferService;

		public JobOfferController(IJobOfferService jobOfferService)
		{
			this.jobOfferService = jobOfferService;
		}

		public async Task<IActionResult> All([FromQuery] AllJobOffersQueryModel queryModel)
		{
			AllJobOffersFilteredAndPagedServiceModel serviceModel =
				await jobOfferService.AllAsync(queryModel);

			queryModel.JobOffers = serviceModel.JobOffers;
			queryModel.TotalJobOffersCount = serviceModel.TotalJobOffersCount;

			return View(queryModel);
		}
	}
}