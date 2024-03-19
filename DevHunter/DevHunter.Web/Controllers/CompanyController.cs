namespace DevHunter.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Interfaces;
	using ViewModels.Company;

	using static Common.NotificationMessagesConstants;

	public class CompanyController : Controller
	{
		private readonly ICompanyService companyService;

		public CompanyController(ICompanyService companyService)
		{
			this.companyService = companyService;
		}

		public async Task<IActionResult> Detail(string id)
		{
			string? companyId = await this.companyService.GetCompanyIdByCreatorIdAsync(id);

			bool companyExists = await this.companyService
				.ExistsByIdAsync(companyId!);

			if (!companyExists)
			{
				TempData[ErrorMessage] = "Company with the provided id does not exist!";

				return RedirectToAction("Index","Home");
			}

			try
			{
				var model = await this.companyService
					.GetDetailsByIdAsync(companyId!);

				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
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

					return RedirectToAction("Index","Home");
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

					return RedirectToAction("Index","Home");
				}

				await this.companyService.EditAsync(id, model);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to edit the company!");

				return View(model);
			}

			return RedirectToAction("Index","Home");
		}

		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("Index", "Home");
		}
	}
}
