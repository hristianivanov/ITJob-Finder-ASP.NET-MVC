namespace DevHunter.Web.Areas.Company.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using ViewModels.Company;
    using Services.Data.Interfaces;

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
                bool isOwned = await this.companyService.IsOwnedByUserAsync(id, CurrentUserId);

                if (!AssertOwnership(isOwned))
                    return RedirectToAction("Index", "Home", new { area = "" });

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
                return View(model);

            try
            {
                bool isOwned = await this.companyService.IsOwnedByUserAsync(id, CurrentUserId);

                if (!AssertOwnership(isOwned))
                    return RedirectToAction("Index", "Home", new { area = "" });

                await this.companyService.EditAsync(id, model, CurrentUserId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(CompanyController));
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to edit the company!");
                return View(model);
            }

            return RedirectToAction("Detail", "Company", new { area = "", id });
        }

        [HttpPost]
        public async Task<IActionResult> ApproveApplication(Guid id)
        {
            try
            {
                if (!await AssertApplicationOwnershipAsync(id))
                    return RedirectToAction("Candidates");

                await this.jobApplicationService.ApproveApplicationAsync(id, CurrentUserId);

                TempData[SuccessMessage] = "You successfully approved one candidate!";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(CompanyController));
                return GeneralError();
            }

            return RedirectToAction("Candidates");
        }

        [HttpPost]
        public async Task<IActionResult> RejectApplication(Guid id)
        {
            try
            {
                if (!await AssertApplicationOwnershipAsync(id))
                    return RedirectToAction("Candidates");

                await this.jobApplicationService.RejectApplicationAsync(id, CurrentUserId);

                TempData[InformationMessage] = "You successfully rejected one candidate!";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(CompanyController));
                return GeneralError();
            }

            return RedirectToAction("Candidates");
        }

        [HttpGet]
        [Route("company/candidates")]
        public async Task<IActionResult> Candidates()
        {
            try
            {
                Guid? companyId = await this.companyService.GetCompanyIdByCreatorIdAsync(CurrentUserId);

                var model = await this.jobApplicationService.AllCandidatesByCompanyIdAsync(companyId);

                return View(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(CompanyController));
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationDetails(Guid applicationId)
        {
            try
            {
                bool isOwned = await this.jobApplicationService.IsOwnedByCompanyAsync(applicationId, CurrentUserId);

                if (!AssertOwnership(isOwned))
                    return RedirectToAction("Candidates");

                var application = await this.jobApplicationService.GetApplicationById(applicationId, CurrentUserId);

                return PartialView("_JobApplicationModalPartial", application);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(CompanyController));
                return GeneralError();
            }
        }

        private async Task<bool> AssertApplicationOwnershipAsync(Guid applicationId)
        {
            bool isOwned = await this.jobApplicationService.IsOwnedByCompanyAsync(applicationId, CurrentUserId);

            if (!isOwned)
                TempData[ErrorMessage] = "Application does not exist or does not belong to your company!";

            return isOwned;
        }
    }
}
