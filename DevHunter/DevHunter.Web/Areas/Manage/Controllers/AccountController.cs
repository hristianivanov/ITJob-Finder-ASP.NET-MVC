namespace DevHunter.Web.Areas.Manage.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using DevHunter.Services.Data.Interfaces;
	using Infrastructure.Extensions;

	using static Common.GeneralApplicationConstants;
	using static Common.NotificationMessagesConstants;

	public class AccountController : BaseManageController
	{
		private readonly ICompanyService companyService;
		private readonly IJobApplicationService jobApplicationService;

		public AccountController(ICompanyService companyService, IJobApplicationService jobApplicationService)
		{
			this.companyService = companyService;
			this.jobApplicationService = jobApplicationService;
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
		[Route("account/my-applications")]
		public async Task<IActionResult> MyApplications()
		{
			var model = await this.jobApplicationService
				.AllUserApplicationsAsync(User.GetId()!);

			return View(model);
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
