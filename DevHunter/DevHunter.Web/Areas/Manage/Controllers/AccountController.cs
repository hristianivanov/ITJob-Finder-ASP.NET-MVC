namespace DevHunter.Web.Areas.Manage.Controllers
{
	using DevHunter.Services.Data.Interfaces;
	using Microsoft.AspNetCore.Mvc;

	using static Common.GeneralApplicationConstants;
	using static Common.NotificationMessagesConstants;

	public class AccountController : BaseManageController
	{
		private readonly ICompanyService companyService;

		public AccountController(ICompanyService companyService)
		{
			this.companyService = companyService;
		}

		[HttpGet]
		[Route("account/manage")]
		public IActionResult Manage()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> ManageCompany(string userId)
		{
			string? companyId = await this.companyService.GetCompanyIdByCreatorIdAsync(userId);

			if (companyId == null)
			{
				TempData[ErrorMessage] = "Unexpected error occurred!";

				return RedirectToAction("Manage");
			}

			return RedirectToAction("Edit", "Company", new { area = CompanyAreaName, id = companyId });
		}

		[HttpGet]
		public async Task<IActionResult> DetailCompany(string userId)
		{
			string? companyId = await this.companyService.GetCompanyIdByCreatorIdAsync(userId);

			if (companyId == null)
			{
				TempData[ErrorMessage] = "Unexpected error occurred!";

				return RedirectToAction("Manage");
			}

			return RedirectToAction("Detail", "Company", new { id = companyId });
		}
	}
}
