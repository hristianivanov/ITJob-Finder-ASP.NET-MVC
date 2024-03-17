namespace DevHunter.Web.Areas.Company.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Infrastructure.Extensions;
	using Services.Data.Interfaces;
	using ViewModels.JobOffer;

	using static Common.GeneralApplicationConstants;
	using static Common.NotificationMessagesConstants;

	[Area("Company")]
	[Authorize(Roles = CompanyRoleName)]
	public class JobOfferController : Controller
	{
		private readonly ITechnologyService technologyService;
		private readonly IJobOfferService jobOfferService;

		public JobOfferController(ITechnologyService technologyService, IJobOfferService jobOfferService)
		{
			this.technologyService = technologyService;
			this.jobOfferService = jobOfferService;
		}

		[Route("company/job-offers")]
		public async Task<IActionResult> All()
		{
			var model = await this.jobOfferService
				.AllByCompanyIdAsync(this.User.GetId()!);

			return View(model);
		}

		[Route("company/postjob")]
		public async Task<IActionResult> Add()
		{
			var model = new JobOfferFormModel()
			{
				Technologies = await this.technologyService.AllAsync()
			};

			return View(model);
		}

		//TODO: XSS on Description HTMLSanitizer
		[HttpPost]
		[Route("company/postjob")]
		public async Task<IActionResult> Add(JobOfferFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				string jobOfferId =
					await jobOfferService.CreateAndReturnIdAsync(model, this.User.GetId()!);

				TempData[SuccessMessage] = "Job offer was added successfully!";

				return RedirectToAction("All");
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to add your new job offer!");

				return View(model);
			}
		}

		[Route("jobpost/edit")]
		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				bool technologyExists = await this.jobOfferService.ExistsByIdAsync(id);

				if (!technologyExists)
				{
					TempData[ErrorMessage] = "Technology with the provided id does not exist!";

					return RedirectToAction("All");
				}

				var model = await this.jobOfferService.GetForEditByIdAsync(id);

				model.Technologies = await this.technologyService.AllAsync();

				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		[Route("jobpost/edit")]
		public async Task<IActionResult> Edit(string id, JobOfferEditFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return this.View();
			}

			return Ok(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete([FromRoute] string id)
		{
			try
			{
				bool jobOfferExists = await this.jobOfferService.ExistsByIdAsync(id);

				if (!jobOfferExists)
				{
					TempData[ErrorMessage] = "Job post with the provided id does not exist!";

					return RedirectToAction("All");
				}

				await jobOfferService.DeleteByIdAsync(id);

				TempData[WarningMessage] = "The job post successfully was deleted!";

				return RedirectToAction("All");
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("All");
		}
	}
}
