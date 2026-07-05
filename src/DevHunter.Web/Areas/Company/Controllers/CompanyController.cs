namespace DevHunter.Web.Areas.Company.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using ViewModels.Company;
    using Services.Data.Interfaces;
    using Infrastructure.Extensions;

    using static Common.NotificationMessagesConstants;

    public class CompanyController : BaseCompanyController
    {
        private readonly ICompanyService companyService;
        private readonly IJobApplicationService jobApplicationService;
        private readonly ILogger<CompanyController> logger;

        public CompanyController(ICompanyService companyService, IJobApplicationService jobApplicationService, ILogger<CompanyController> logger)
        {
            this.companyService = companyService;
            this.jobApplicationService = jobApplicationService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("company/edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                bool isOwnedByCompany = await this.companyService
                    .IsOwnedByUserAsync(id, CurrentUserId);

                if (!AssertOwnership(isOwnedByCompany))
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

                var model = await this.companyService.GetForEditByIdAsync(id);

                return View(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(CompanyController));
                return GeneralError();
            }
        }

        [HttpPost]
        [Route("company/edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id, CompanyFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
                bool isOwnedByCompany = await this.companyService
                    .IsOwnedByUserAsync(id, CurrentUserId);

                if (!AssertOwnership(isOwnedByCompany))
                {
                    return RedirectToAction("Index", "Home");
                }

                await this.companyService.EditAsync(id, model, CurrentUserId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(CompanyController));
                ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to edit the company!");

                return View(model);
            }

            return RedirectToAction("Detail", "Company", new { area = "", id });
        }

        [HttpPost]
        public async Task<IActionResult> ApproveApplication(Guid id)
        {
            bool isOwnedByCompany = await this.jobApplicationService.IsOwnedByCompanyAsync(id, CurrentUserId);

            if (!isOwnedByCompany)
            {
                TempData[ErrorMessage] = "Application does not exist or does not belong to your company!";

                return RedirectToAction("Candidates");
            }

            await this.jobApplicationService.ApproveApplicationAsync(id, CurrentUserId);

            TempData[SuccessMessage] = "You successfully approved one candidate!";

            return RedirectToAction("Candidates");
        }

        [HttpPost]
        public async Task<IActionResult> RejectApplication(Guid id)
        {
            bool isOwnedByCompany = await this.jobApplicationService.IsOwnedByCompanyAsync(id, CurrentUserId);

            if (!isOwnedByCompany)
            {
                TempData[ErrorMessage] = "Application does not exist or does not belong to your company!";

                return RedirectToAction("Candidates");
            }

            await this.jobApplicationService.RejectApplicationAsync(id, CurrentUserId);

            TempData[InformationMessage] = "You successfully rejected one candidate!";

            return RedirectToAction("Candidates");
        }

        [HttpGet]
        [Route("company/candidates")]
        public async Task<IActionResult> Candidates()
        {
            Guid? companyId = await this.companyService.GetCompanyIdByCreatorIdAsync(CurrentUserId);

            var model = await this.jobApplicationService
                .AllCandidatesByCompanyIdAsync(companyId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationDetails(Guid applicationId)
        {
            var application = await this.jobApplicationService
                .GetApplicationById(applicationId, CurrentUserId);

            return PartialView("_JobApplicationModalPartial", application);
        }

        private IActionResult GeneralError()
        {
                TempData[ErrorMessage] = UnexpectedError;

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
