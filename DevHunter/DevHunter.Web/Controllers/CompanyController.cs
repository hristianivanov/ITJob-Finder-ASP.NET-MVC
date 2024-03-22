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
		[Route("company/detail")]
		public async Task<IActionResult> Detail(string id)
		{
			try
			{
				bool companyExists = await this.companyService
					.ExistsByIdAsync(id!);

				if (!companyExists)
				{
					TempData[ErrorMessage] = "Company does not exist!";

					return RedirectToAction("Index", "Home");
				}

				var model = await this.companyService
					.GetDetailsByIdAsync(id!);

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
