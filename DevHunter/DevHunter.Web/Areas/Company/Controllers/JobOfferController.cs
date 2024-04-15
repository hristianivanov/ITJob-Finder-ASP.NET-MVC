namespace DevHunter.Web.Areas.Company.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Infrastructure.Extensions;
	using Services.Data.Interfaces;
	using ViewModels.JobOffer;

	using static Common.GeneralApplicationConstants;
	using static Common.NotificationMessagesConstants;
	using DevHunter.Data.Models.Enums;

	[Area(CompanyAreaName)]
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
		public IActionResult Add()
		{
			var model = new JobOfferFormModel();

			return View(model);
		}

		[HttpPost]
		[Route("company/postjob")]
		public async Task<IActionResult> Add(JobOfferFormModel model)
		{
			if (model.SalaryType is SalaryType.Range)
			{
				if (!model.MaxSalary.HasValue || !model.MinSalary.HasValue)
				{
					ModelState.AddModelError(nameof(model.SalaryType), "Please type min and max salary!");
				}
			}

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

		[HttpGet]
		[Route("jobpost/edit/{id}")]
		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				bool jobOfferExists = await this.jobOfferService.ExistsByIdAsync(id);

				if (!jobOfferExists)
				{
					TempData[ErrorMessage] = "Job post does not exist!";

					return RedirectToAction("All");
				}

				var model = await this.jobOfferService.GetForEditByIdAsync(id);


				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		[Route("jobpost/edit/{id}")]
		public async Task<IActionResult> Edit(string id, JobOfferEditFormModel model)
		{
			if (model.SalaryType is SalaryType.Range)
			{
				if (!model.MaxSalary.HasValue || !model.MinSalary.HasValue)
				{
					ModelState.AddModelError(nameof(model.SalaryType), "Please type min and max salary!");
				}
			}

			if (!ModelState.IsValid)
			{
				return this.View();
			}

			try
			{
				bool jobOfferExists = await jobOfferService.ExistsByIdAsync(id);

				if (!jobOfferExists)
				{
					TempData[ErrorMessage] = "Job post does not exist!";

					return RedirectToAction("All");
				}

				TempData[SuccessMessage] = "Job post was edited successfully!";

				await jobOfferService.EditJobOfferAsync(id, model);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to edit the technology!");

				return View(model);
			}

			return RedirectToAction("All");
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
