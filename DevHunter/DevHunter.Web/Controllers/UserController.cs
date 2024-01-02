using Microsoft.AspNetCore.Authentication;

namespace DevHunter.Web.Controllers
{
	using DevHunter.Web.ViewModels.User;
	using DevHunter.Data.Models;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Identity;

	public class UserController : Controller
	{
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly UserManager<ApplicationUser> userManager;

		public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterFormModel model, string? returnUrl = null)
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
				}

				return View(model);
			}
				
			await this.signInManager.SignInAsync(user, isPersistent: false);

			if (returnUrl != null)
			{
				return LocalRedirect(returnUrl);
			}

			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginFormModel model, string? returnUrl = null)
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
				return this.View(model);
			}

			if (returnUrl != null)
			{
				return LocalRedirect(returnUrl);
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
