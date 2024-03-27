namespace DevHunter.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Interfaces;
	using Services.Data.Models.JobOffer;
	using ViewModels.JobOffer;
	using ViewModels.JobApplication;

	using static Common.NotificationMessagesConstants;
	using DevHunter.Web.Infrastructure.Extensions;
	using Microsoft.AspNetCore.Authorization;

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

		[HttpGet]
		[Route("joboffer/all")]
		public async Task<IActionResult> All([FromQuery] AllJobOffersQueryModel queryModel)
		{
			queryModel.Filters = await this.jobOfferService.LoadFiltersAsync();

			AllJobOffersFilteredAndPagedServiceModel serviceModel =
				await jobOfferService.AllAsync(queryModel);

			queryModel.JobOffers = serviceModel.JobOffers;
			queryModel.TotalJobOffersCount = serviceModel.TotalJobOffersCount;

			return View(queryModel);
		}

		[HttpGet]
		[Route("joboffer/jobs")]
		public async Task<IActionResult> AllSearch([FromQuery] AllJobOffersQueryModel queryModel)
		{
			AllJobOffersFilteredAndPagedServiceModel serviceModel =
				await jobOfferService.AllBySearchAsync(queryModel);

			queryModel.JobOffers = serviceModel.JobOffers;
			queryModel.TotalJobOffersCount = serviceModel.TotalJobOffersCount;

			return View(queryModel);
		}

		public async Task<IActionResult> Save(string id)
		{
			if (!User!.Identity!.IsAuthenticated)
			{
				return new JsonResult(new { success = false, errorMsg = "Please log in or register to save a job!" });
			}

			string userId = this.User.GetId()!;

			bool jobOfferExists = await this.jobOfferService.ExistsByIdAsync(id);

			if (!jobOfferExists)
			{
				return new JsonResult(new { success = false, errorMsg = "Job offer does not exist!" });
			}

			bool isJobOfferSaved = await this.jobOfferService.IsJobOfferSaved(id, this.User.GetId()!);

			if (isJobOfferSaved)
			{
				await this.jobOfferService.RemoveSaveJobAsync(id, userId);

				return new JsonResult(new { success = true, saved = true });
			}

			await this.jobOfferService.SaveJobAsync(id, userId);

			return new JsonResult(new { success = true });
		}

		[HttpGet]
		[Route("job-offer/detail")]
		public async Task<IActionResult> Detail(string id)
		{
			try
			{
				bool jobOfferExists = await this.jobOfferService
					.ExistsByIdAsync(id);

				if (!jobOfferExists)
				{
					TempData[ErrorMessage] = "Job offer does not exist!";

					return RedirectToAction("All");
				}

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
				return new JsonResult(new { success = false, errorMsg = "There is an error in one or more fields" });
			}

			try
			{
				bool jobOfferExists = await this.jobOfferService.ExistsByIdAsync(id);

				if (!jobOfferExists)
				{
					TempData[ErrorMessage] = "Job offer with the provided id does not exist!";

					return RedirectToAction("All");
				}

				string applicationId = await this.jobApplicationService.ApplyJobOfferAsync(model, id);

				if (model.Files.Count > 0)
				{
					foreach (var file in model.Files)
					{
						string documentUrl = await this.documentService.UploadDocumentAsync(file, "DevHunter/documents");

						await this.documentService.AddAsync(documentUrl, applicationId);
					}
				}

				return new JsonResult(new { success = true, successMsg = "Your application has been sent successfully!" });
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