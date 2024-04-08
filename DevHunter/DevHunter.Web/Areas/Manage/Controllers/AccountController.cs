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
		private readonly IJobOfferService jobOfferService;
		private readonly IJobApplicationService jobApplicationService;
		private readonly IUserService userService;

		public AccountController(ICompanyService companyService, IJobApplicationService jobApplicationService, IJobOfferService jobOfferService, IUserService userService)
		{
			this.companyService = companyService;
			this.jobApplicationService = jobApplicationService;
			this.jobOfferService = jobOfferService;
			this.userService = userService;
		}

		[HttpGet]
		[Route("account/manage")]
		public async Task<IActionResult> Manage()
		{
			var model = await this.userService.GetUserByIdAsync(this.User.GetId()!);
			
			return View(model);
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
		[Route("account/saved-joboffers")]
		public async Task<IActionResult> SavedJobOffers()
		{
			var model = await this.jobOfferService.AllSavedJobOffersByUserIdAsync(User.GetId()!);	

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
