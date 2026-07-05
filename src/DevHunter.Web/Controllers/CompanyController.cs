namespace DevHunter.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Services.Data.Interfaces;

    using static Common.NotificationMessagesConstants;

    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly ILogger<CompanyController> logger;

        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            this.companyService = companyService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("companies")]
        public async Task<IActionResult> All()
        {
            var model = await this.companyService.AllAsync();

            return View(model);
        }

        [HttpGet]
        [Route("company/detail")]
        public async Task<IActionResult> Detail(Guid id)
        {
            try
            {
                bool companyExists = await this.companyService
                    .ExistsByIdAsync(id);

                if (!companyExists)
                {
                    TempData[ErrorMessage] = "Company does not exist!";

                    return RedirectToAction("Index", "Home");
                }

                var model = await this.companyService
                    .GetDetailsByIdAsync(id);

                return View(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(CompanyController));
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
                TempData[ErrorMessage] = UnexpectedError;

            return RedirectToAction("Index", "Home");
        }
    }
}
