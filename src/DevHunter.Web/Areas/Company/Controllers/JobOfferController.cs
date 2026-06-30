namespace DevHunter.Web.Areas.Company.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Infrastructure.Extensions;
    using Services.Data.Interfaces;
    using ViewModels.JobOffer;

    using static Common.GeneralApplicationConstants;
    using static Common.NotificationMessagesConstants;
    using DevHunter.Data.Models.Enums;

    [Area(CompanyAreaName)]
    [Authorize(Roles = CompanyRoleName)]
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService jobOfferService;
        private readonly ILogger<JobOfferController> logger;

        public JobOfferController(IJobOfferService jobOfferService, ILogger<JobOfferController> logger)
        {
            this.jobOfferService = jobOfferService;
            this.logger = logger;
        }

        [Route("company/job-offers")]
        public async Task<IActionResult> All()
        {
            var model = await this.jobOfferService
                .AllByCompanyIdAsync(this.User.GetId()!);

            return View(model);
        }

        [Route("company/postjob")]
        public IActionResult Add()
        {
            var model = new JobOfferFormModel();

            return View(model);
        }

        [HttpPost]
        [Route("company/postjob")]
        public async Task<IActionResult> Add(JobOfferFormModel model)
        {
            if (model.SalaryType is SalaryType.Range)
            {
                if (!model.MaxSalary.HasValue || !model.MinSalary.HasValue)
                {
                    ModelState.AddModelError(nameof(model.SalaryType), "Please type min and max salary!");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await jobOfferService.CreateAndReturnIdAsync(model, this.User.GetId()!);

                TempData[SuccessMessage] = "Job offer was added successfully!";

                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(JobOfferController));
                ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to add your new job offer!");

                return View(model);
            }
        }

        [HttpGet]
        [Route("jobpost/edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                bool isOwnedByCompany = await this.jobOfferService
                    .IsOwnedByCompanyAsync(id, this.User.GetId()!);

                if (!isOwnedByCompany)
                {
                TempData[ErrorMessage] = JobOfferOwnershipError;

                    return RedirectToAction("All");
                }

                var model = await this.jobOfferService.GetForEditByIdAsync(id);


                return View(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(JobOfferController));
                return GeneralError();
            }
        }

        [HttpPost]
        [Route("jobpost/edit/{id}")]
        public async Task<IActionResult> Edit(string id, JobOfferEditFormModel model)
        {
            if (model.SalaryType is SalaryType.Range)
            {
                if (!model.MaxSalary.HasValue || !model.MinSalary.HasValue)
                {
                    ModelState.AddModelError(nameof(model.SalaryType), "Please type min and max salary!");
                }
            }

            if (!ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
                bool isOwnedByCompany = await this.jobOfferService
                    .IsOwnedByCompanyAsync(id, this.User.GetId()!);

                if (!isOwnedByCompany)
                {
                TempData[ErrorMessage] = JobOfferOwnershipError;

                    return RedirectToAction("All");
                }

                TempData[SuccessMessage] = "Job post was edited successfully!";

                await jobOfferService.EditJobOfferAsync(id, model, this.User.GetId()!);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(JobOfferController));
                ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to edit the technology!");

                return View(model);
            }

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                bool isOwnedByCompany = await this.jobOfferService
                    .IsOwnedByCompanyAsync(id, this.User.GetId()!);

                if (!isOwnedByCompany)
                {
                TempData[ErrorMessage] = JobOfferOwnershipError;

                    return RedirectToAction("All");
                }

                await jobOfferService.DeleteByIdAsync(id, this.User.GetId()!);

                TempData[WarningMessage] = "The job post successfully was deleted!";

                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(JobOfferController));
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
                TempData[ErrorMessage] = UnexpectedError;

            return RedirectToAction("All");
        }
    }
}
