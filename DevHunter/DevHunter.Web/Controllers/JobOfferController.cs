namespace DevHunter.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Interfaces;
	using Services.Data.Models.JobOffer;
	using ViewModels.JobOffer;

	using static Common.NotificationMessagesConstants;

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

		public async Task<IActionResult> Detail(string id)
		{
			bool jobOfferExists = await this.jobOfferService
				.ExistsByIdAsync(id);

			if (!jobOfferExists)
			{
				TempData[ErrorMessage] = "Job offer with the provided id does not exist!";

				return RedirectToAction("All");
			}

			try
			{
				var model = await this.jobOfferService
					.GetDetailsByIdAsync(id);

				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("Index", "Home");
		}
	}
}