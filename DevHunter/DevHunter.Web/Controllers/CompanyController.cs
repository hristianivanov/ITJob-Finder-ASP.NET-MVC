namespace DevHunter.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Interfaces;
	
	using static Common.NotificationMessagesConstants;

	public class CompanyController : Controller
	{
		private readonly ICompanyService companyService;

		public CompanyController(ICompanyService companyService)
		{
			this.companyService = companyService;
		}

		[HttpGet]
		public async Task<IActionResult> Detail(string id)
		{
			string? companyId = await companyService.GetCompanyIdByCreatorIdAsync(id);

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

		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("Index", "Home");
		}
	}
}
