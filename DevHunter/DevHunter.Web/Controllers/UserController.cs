namespace DevHunter.Web.Controllers
{
	using Microsoft.AspNetCore.Authentication;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Identity;

	using Data.Models;
	using ViewModels.User;
	using DevHunter.Services.Data.Interfaces;

	using static Common.NotificationMessagesConstants;

	public class UserController : Controller
	{
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly ICompanyService companyService;

		public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ICompanyService companyService)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.companyService = companyService;
		}

		public IActionResult RegisterOption()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Index", "Home");
			}

			return View();
		}

		public IActionResult RegisterCompany()
		{
			var model = new CompanyRegisterFormModel();

			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> RegisterCompany(CompanyRegisterFormModel model)
		{
			bool companyExists = await this.companyService.ExistsByNameAsync(model.Name);

			if (companyExists)
			{
				ModelState.AddModelError(nameof(model.Name), "Company with this name already exists!");
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			ApplicationUser user = new ApplicationUser();

			await this.userManager.SetEmailAsync(user, model.Email);
			await this.userManager.SetUserNameAsync(user, model.Email);

			var result = await this.userManager.CreateAsync(user, model.Password);

			await this.userManager.AddToRoleAsync(user, "Company");

			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}

				return View(model);
			}

			await this.companyService.AddAsync(model);

			await this.signInManager.SignInAsync(user, isPersistent: false);

			return RedirectToAction("Index", "Home");
		}

		public IActionResult Register()
		{
			var model = new RegisterFormModel();

			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return this.View(model);
			}

			ApplicationUser user = new ApplicationUser();

			await this.userManager.SetEmailAsync(user, model.Email);
			await this.userManager.SetUserNameAsync(user, model.Email);

			var result = await this.userManager.CreateAsync(user, model.Password);

			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
					TempData[ErrorMessage] = error.Description;
				}

				return View(model);
			}

			await this.signInManager.SignInAsync(user, isPersistent: false);

			return RedirectToAction("Index", "Home");
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginFormModel model)
		{
			await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			if (!ModelState.IsValid)
			{
				return this.View();
			}

			var result =
				await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

			if (!result.Succeeded)
			{
				this.TempData[ErrorMessage] = "Invalid login attempt!";

				return this.View(model);
			}

			return this.Redirect(model.ReturnUrl ?? "/Home/Index");
		}

		[HttpPost]
		public async Task<IActionResult> Logout(string? returnUrl)
		{
			await signInManager.SignOutAsync();

			if (returnUrl != null)
			{
				return LocalRedirect(returnUrl);
			}

			return RedirectToAction("Index", "Home");
		}
	}
}