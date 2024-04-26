namespace DevHunter.Web.Controllers
{
	using Microsoft.AspNetCore.Authentication;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Identity;

	using Data.Models;
	using ViewModels.User;
	using Services.Data.Interfaces;

	using static Common.NotificationMessagesConstants;

	public class AccountController : Controller
	{
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly ICompanyService companyService;

		public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ICompanyService companyService)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.companyService = companyService;
		}

		[HttpGet]
		[Route("account/option")]
		public IActionResult RegisterOption()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Index", "Home");
			}

			return View();
		}

		[HttpGet]
		[Route("account/register-company")]
		public IActionResult RegisterCompany()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Index", "Home");
			}

			var model = new CompanyRegisterFormModel();

			return View(model);
		}

		[HttpPost]
		[Route("account/register-company")]
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

			ApplicationUser user = new ApplicationUser()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
			};

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

			await this.companyService.AddAsync(model, user.Id);

			await this.signInManager.SignInAsync(user, isPersistent: false);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[Route("account/register-user")]
		public IActionResult Register()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Index", "Home");
			}

			var model = new RegisterFormModel();

			return View(model);
		}

		[HttpPost]
		[Route("account/register-user")]
		public async Task<IActionResult> Register(RegisterFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return this.View(model);
			}

			ApplicationUser user = new ApplicationUser()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
			};

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

		[HttpGet]
		[Route("account/login")]

		public IActionResult Login()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Index", "Home");
			}

			return View();
		}

		[HttpPost]
		[Route("account/login")]
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

			string returnUrl = TempData["ReturnUrl"] as string;
			TempData.Remove("ReturnUrl");

			return this.Redirect(returnUrl ?? "/Home/Index");
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();

			string returnUrl = HttpContext.Request.Query["returnUrl"];

			if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
				return Redirect(returnUrl);

			return RedirectToAction("Index", "Home");
		}
	}
}