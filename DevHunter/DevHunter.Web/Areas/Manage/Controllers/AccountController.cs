namespace DevHunter.Web.Areas.Manage.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Identity;

	using Data.Models;
	using DevHunter.Services.Data.Interfaces;
	using Infrastructure.Extensions;
	using ViewModels.User;

	using static Common.GeneralApplicationConstants;
	using static Common.NotificationMessagesConstants;

	public class AccountController : BaseManageController
	{
		private readonly ICompanyService companyService;
		private readonly IJobOfferService jobOfferService;
		private readonly IJobApplicationService jobApplicationService;
		private readonly IUserService userService;

		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly UserManager<ApplicationUser> userManager;

		public AccountController(ICompanyService companyService, IJobApplicationService jobApplicationService, IJobOfferService jobOfferService, IUserService userService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
		{
			this.companyService = companyService;
			this.jobApplicationService = jobApplicationService;
			this.jobOfferService = jobOfferService;
			this.userService = userService;
			this.signInManager = signInManager;
			this.userManager = userManager;
		}

		[HttpGet]
		[Route("account/manage")]
		public async Task<IActionResult> Manage(UserManageFormModel model)
		{
			var user = await userManager.FindByIdAsync(this.User.GetId()!);

			model.Email = user.Email;

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

		[HttpPost]
		public async Task<IActionResult> ChangePassword(UserChangePasswordFormModel model)
		{
			if (!ModelState.IsValid)
			{
				if (ModelState.ErrorCount > 1)
				{
					ModelState.Clear();

					if (string.IsNullOrWhiteSpace(model.Password)
						&& string.IsNullOrWhiteSpace(model.ConfirmPassword))
					{
						ModelState.AddModelError(string.Empty, "Both password fields are required.");
					}
					else if (model.Password != model.ConfirmPassword)
					{
						ModelState.AddModelError(string.Empty, "The password and confirmation password do not match.");
					}
					else
					{
						ModelState.AddModelError(string.Empty, "There is an error in one or more fields.");
					}
				}

				var invalid = new UserManageFormModel()
				{
					ChangePasswordModel = model
				};

				return View("Manage", invalid);
			}

			var user = await this.userService.GetUserByIdAsync(User.GetId()!);

			var token = await this.userManager.GeneratePasswordResetTokenAsync(user);

			var result = await userManager.ResetPasswordAsync(user, token, model.Password);

			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}

				var invalid = new UserManageFormModel()
				{
					ChangePasswordModel = model
				};

				return View("Manage", invalid);
			}

			TempData[SuccessMessage] = "Successfully changed password!";

			return RedirectToAction("Manage");
		}
	}
}
