namespace DevHunter.Web.Controllers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using Data.Models;
using ViewModels.User;
using Services.Data.Interfaces;
using Infrastructure.Extensions;

using static Common.NotificationMessagesConstants;

public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IAccountService accountService;

    public AccountController(
        SignInManager<ApplicationUser> signInManager,
        IAccountService accountService)
    {
        this.signInManager = signInManager;
        this.accountService = accountService;
    }

    [HttpGet]
    [Route("account/option")]
    [AlreadyAuthenticated]
    public IActionResult RegisterOption() => View();

    [HttpGet]
    [Route("account/register-company")]
    [AlreadyAuthenticated]
    public IActionResult RegisterCompany() => View(new CompanyRegisterFormModel());

    [HttpPost]
    [Route("account/register-company")]
    public async Task<IActionResult> RegisterCompany(CompanyRegisterFormModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        IdentityResult result = await this.accountService.RegisterCompanyAsync(model);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(error.Code == nameof(model.Name) ? nameof(model.Name) : string.Empty, error.Description);

            return View(model);
        }

        var user = await this.signInManager.UserManager.FindByEmailAsync(model.Email);
        await this.signInManager.SignInAsync(user!, isPersistent: false);

        TempData[SuccessMessage] = "Welcome to DevHunter! Your company account has been created.";

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Route("account/register-user")]
    [AlreadyAuthenticated]
    public IActionResult Register() => View(new RegisterFormModel());

    [HttpPost]
    [Route("account/register-user")]
    public async Task<IActionResult> Register(RegisterFormModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        IdentityResult result = await this.accountService.RegisterUserAsync(model);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                TempData[ErrorMessage] = error.Description;
            }

            return View(model);
        }

        var user = await this.signInManager.UserManager.FindByEmailAsync(model.Email);
        await this.signInManager.SignInAsync(user!, isPersistent: false);

        TempData[SuccessMessage] = "Welcome to DevHunter! Your account has been created.";

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Route("account/login")]
    [AlreadyAuthenticated]
    public IActionResult Login() => View();

    [HttpPost]
    [Route("account/login")]
    public async Task<IActionResult> Login(LoginFormModel model)
    {
        await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

        if (!ModelState.IsValid)
            return View();

        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

        if (!result.Succeeded)
        {
            TempData[ErrorMessage] = "Invalid login attempt!";
            return View(model);
        }

        string? returnUrl = TempData["ReturnUrl"] as string;
        TempData.Remove("ReturnUrl");

        return Redirect(returnUrl ?? "/Home/Index");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        string? returnUrl = HttpContext.Request.Query["returnUrl"].FirstOrDefault();

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index", "Home");
    }
}