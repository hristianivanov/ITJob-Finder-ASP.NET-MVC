namespace DevHunter.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    using Data.Models;
    using Data;
    using Infrastructure.Extensions;
    using ViewModels.User;
    using Services.Data.Interfaces;

    using static Common.NotificationMessagesConstants;
    using static Common.GeneralApplicationConstants;

    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICompanyService companyService;
        private readonly DevHunterDbContext dbContext;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ICompanyService companyService,
            DevHunterDbContext dbContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.companyService = companyService;
            this.dbContext = dbContext;
        }

        [HttpGet]
        [AlreadyAuthenticated]
        [Route("account/option")]
        public IActionResult RegisterOption()
        {
            return View();
        }

        [HttpGet]
        [AlreadyAuthenticated]
        [Route("account/register-company")]
        public IActionResult RegisterCompany()
        {
            return View(new CompanyRegisterFormModel());
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

            bool isRelational = this.dbContext.Database.IsRelational();
            IDbContextTransaction? transaction = isRelational
                ? await this.dbContext.Database.BeginTransactionAsync()
                : null;

            try
            {
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email
                };

                IdentityResult createResult = await this.userManager.CreateAsync(user, model.Password);

                if (!AddIdentityErrors(createResult))
                {
                    return View(model);
                }

                IdentityResult roleResult = await this.userManager.AddToRoleAsync(user, CompanyRoleName);

                if (!AddIdentityErrors(roleResult))
                {
                    if (transaction != null) await transaction.RollbackAsync();
                    return View(model);
                }

                await this.companyService.AddAsync(model, user.Id);

                if (transaction != null) await transaction.CommitAsync();

                await this.signInManager.SignInAsync(user, isPersistent: false);

                TempData[SuccessMessage] = "Welcome to DevHunter! Your company account has been created.";

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                if (transaction != null) await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                if (transaction != null) await transaction.DisposeAsync();
            }
        }

        [HttpGet]
        [Route("account/register-user")]
        [AlreadyAuthenticated]
        public IActionResult Register()
        {
            return View(new RegisterFormModel());
        }

        [HttpPost]
        [Route("account/register-user")]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

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

            TempData[SuccessMessage] = "Welcome to DevHunter! Your account has been created.";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("account/login")]
        [AlreadyAuthenticated]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("account/login")]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                this.TempData[ErrorMessage] = "Invalid login attempt!";

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

        private bool AddIdentityErrors(IdentityResult result)
        {
            if (result.Succeeded)
            {
                return true;
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return false;
        }
    }
}
