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
		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				string? companyId = await this.companyService.GetCompanyIdByCreatorIdAsync(id);

				bool companyExists = await this.companyService.ExistsByIdAsync(companyId!);

				if (!companyExists)
				{
					TempData[ErrorMessage] = "Company with the provided id does not exist!";

					return RedirectToAction("Index", "Home");
				}

				var model = await this.companyService.GetForEditByIdAsync(companyId!);

				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(string id, CompanyFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return this.View();
			}

			try
			{
				bool companyExists = await this.companyService.ExistsByIdAsync(id);

				if (!companyExists)
				{
					TempData[ErrorMessage] = "Company with the provided id does not exist!";

					return RedirectToAction("Index", "Home");
				}

				await this.companyService.EditAsync(id, model);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to edit the company!");

				return View(model);
			}

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> Candidates()
		{
			string? companyId = 
				await this.companyService.GetCompanyIdByCreatorIdAsync(this.User.GetId()!);

			var model = await this.jobApplicationService
				.AllCandidatesByCompanyIdAsync(companyId);

			return View(model);
		}

		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("Index", "Home");
		}
	}
}
