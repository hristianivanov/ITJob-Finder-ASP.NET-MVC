namespace DevHunter.Web.Areas.Company.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using ViewModels.Company;
	using Services.Data.Interfaces;
	using Infrastructure.Extensions;

	using static Common.NotificationMessagesConstants;

	public class CompanyController : BaseCompanyController
	{
		private readonly ICompanyService companyService;
		private readonly IJobApplicationService jobApplicationService;

		public CompanyController(ICompanyService companyService, IJobApplicationService jobApplicationService)
		{
			this.companyService = companyService;
			this.jobApplicationService = jobApplicationService;
		}

		[HttpGet]
		[Route("company/edit/{id}")]
		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				bool companyExists = await this.companyService.ExistsByIdAsync(id!);

				if (!companyExists)
				{
					TempData[ErrorMessage] = "Company does not exist!";

					return RedirectToAction("Index", "Home", new { area = "" });
				}

				var model = await this.companyService.GetForEditByIdAsync(id!);

				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		[Route("company/edit/{id}")]
		public async Task<IActionResult> Edit([FromRoute] string id, CompanyFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return this.View();
			}

			try
			{
				bool companyExists = await this.companyService.ExistsByIdAsync(id!);

				if (!companyExists)
				{
					TempData[ErrorMessage] = "Company does not exist!";

					return RedirectToAction("Index", "Home");
				}

				await this.companyService.EditAsync(id!, model);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to edit the company!");

				return View(model);
			}

			return RedirectToAction("Detail", "Company", new { area = "", id });
		}

		[HttpPost]
		public async Task<IActionResult> ApproveApplication(string id)
		{
			bool applicationExists = await this.jobApplicationService.ExistsByIdAsync(id);

			if (!applicationExists)
			{
				TempData[ErrorMessage] = "Application does not exist!";

				return RedirectToAction("Candidates");
			}

			await this.jobApplicationService.ApproveApplicationAsync(id);

			TempData[SuccessMessage] = "You successfully approved one candidate!";

			return RedirectToAction("Candidates");
		}

		[HttpPost]
		public async Task<IActionResult> RejectApplication(string id)
		{
			bool applicationExists = await this.jobApplicationService.ExistsByIdAsync(id);

			if (!applicationExists)
			{
				TempData[ErrorMessage] = "Application does not exist!";

				return RedirectToAction("Candidates");
			}

			await this.jobApplicationService.RejectApplicationAsync(id);

			TempData[InformationMessage] = "You successfully rejected one candidate!";

			return RedirectToAction("Candidates");
		}

		[HttpGet]
		[Route("company/candidates")]
		public async Task<IActionResult> Candidates()
		{
			string? companyId =
				await this.companyService.GetCompanyIdByCreatorIdAsync(this.User.GetId()!);

			var model = await this.jobApplicationService
				.AllCandidatesByCompanyIdAsync(companyId);

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetApplicationDetails(string applicationId)
		{

			var application = await this.jobApplicationService.GetApplicationById(applicationId);

			return PartialView("_JobApplicationModalPartial", application);
		}

		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("Index", "Home", new { area = "" });
		}
	}
}
