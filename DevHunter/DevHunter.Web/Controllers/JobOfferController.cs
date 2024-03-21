namespace DevHunter.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Interfaces;
	using Services.Data.Models.JobOffer;
	using ViewModels.JobOffer;
	using ViewModels.JobApplication;

	using static Common.NotificationMessagesConstants;

	public class JobOfferController : Controller
	{
		private readonly IDocumentService documentService;
		private readonly IJobOfferService jobOfferService;
		private readonly IJobApplicationService jobApplicationService;

		public JobOfferController(IJobOfferService jobOfferService, IJobApplicationService jobApplicationService, IDocumentService documentService)
		{
			this.jobOfferService = jobOfferService;
			this.jobApplicationService = jobApplicationService;
			this.documentService = documentService;
		}

		public async Task<IActionResult> All([FromQuery] AllJobOffersQueryModel queryModel)
		{
			AllJobOffersFilteredAndPagedServiceModel serviceModel =
				await jobOfferService.AllAsync(queryModel);

			queryModel.Filters = await this.jobOfferService.LoadFiltersAsync();

			queryModel.JobOffers = serviceModel.JobOffers;
			queryModel.TotalJobOffersCount = serviceModel.TotalJobOffersCount;

			return View(queryModel);
		}

		public async Task<IActionResult> AllSearch([FromQuery] AllJobOffersQueryModel queryModel, string search)
		{
			AllJobOffersFilteredAndPagedServiceModel serviceModel =
				await jobOfferService.AllAsync(queryModel);

			queryModel.JobOffers = serviceModel.JobOffers;
			queryModel.TotalJobOffersCount = serviceModel.TotalJobOffersCount;

			return View(queryModel);
		}

		//TODO: XSS on Description HTMLSanitizer
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

		[HttpPost]
		public async Task<IActionResult> Apply(JobApplicationFormModel model, string id)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Detail", new { id = id });
			}

			bool jobOfferExists = await this.jobOfferService
				.ExistsByIdAsync(id);

			if (!jobOfferExists)
			{
				TempData[ErrorMessage] = "Job offer with the provided id does not exist!";

				return RedirectToAction("All");
			}

			try
			{
				string applicationId = await this.jobApplicationService.ApplyJobOfferAsync(model, id);

				if (model.Files.Count > 0)
				{
					foreach (var file in model.Files)
					{
						string documentUrl = await this.documentService
							.UploadDocumentAsync(file, "DevHunter/documents");

						await this.documentService.AddAsync(documentUrl, applicationId);
					}
				}

				TempData[SuccessMessage] = "Your application has been sent successfully!";

				return RedirectToAction("Detail", new { id = id });
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