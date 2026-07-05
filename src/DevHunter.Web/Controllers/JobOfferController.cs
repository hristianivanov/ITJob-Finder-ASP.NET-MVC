namespace DevHunter.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Infrastructure.Extensions;
    using Services.Data.Interfaces;
    using Services.Data.Models.JobOffer;
    using ViewModels.JobOffer;
    using ViewModels.JobApplication;

    using static Common.NotificationMessagesConstants;

    public class JobOfferController : Controller
    {
        private readonly IDocumentService documentService;
        private readonly IJobOfferService jobOfferService;
        private readonly IDevelopmentService devDevelopmentService;
        private readonly IJobApplicationService jobApplicationService;
        private readonly ILogger<JobOfferController> logger;

        public JobOfferController(IJobOfferService jobOfferService, IJobApplicationService jobApplicationService, IDocumentService documentService, IDevelopmentService devDevelopmentService, ILogger<JobOfferController> logger)
        {
            this.jobOfferService = jobOfferService;
            this.jobApplicationService = jobApplicationService;
            this.documentService = documentService;
            this.devDevelopmentService = devDevelopmentService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("joboffer/all")]
        public async Task<IActionResult> All([FromQuery] AllJobOffersQueryModel queryModel, Guid development)
        {
            var developmentsExists = await this.devDevelopmentService.ExistsByIdAsync(development);

            if (!developmentsExists)
            {
                TempData[ErrorMessage] = "Development does not exist!";

                return RedirectToAction("Index", "Home");
            }

            queryModel.Development = await this.devDevelopmentService.GetByIdAsync(development);

            queryModel.Filters = await this.jobOfferService.LoadFiltersAsync();

            AllJobOffersFilteredAndPagedServiceModel serviceModel =
                await jobOfferService.AllAsync(queryModel);

            queryModel.JobOffers = serviceModel.JobOffers;
            queryModel.TotalJobOffersCount = serviceModel.TotalJobOffersCount;

            return View(queryModel);
        }

        [HttpGet]
        [Route("joboffer/jobs")]
        public async Task<IActionResult> AllSearch([FromQuery] AllJobOffersQueryModel queryModel)
        {
            AllJobOffersFilteredAndPagedServiceModel serviceModel =
                await jobOfferService.AllBySearchAsync(queryModel);

            queryModel.JobOffers = serviceModel.JobOffers;
            queryModel.TotalJobOffersCount = serviceModel.TotalJobOffersCount;

            return View(queryModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Guid id)
        {
            if (!User!.Identity!.IsAuthenticated)
            {
                return new JsonResult(new { success = false, errorMsg = "Please log in or register to save a job!" });
            }

            try
            {
                Guid userId = this.User.GetGuid();

                bool jobOfferExists = await this.jobOfferService.ExistsByIdAsync(id);

                if (!jobOfferExists)
                {
                    return new JsonResult(new { success = false, errorMsg = "Job offer does not exist!" });
                }

                bool isJobOfferSaved = await this.jobOfferService.IsJobOfferSaved(id, userId);

                if (isJobOfferSaved)
                {
                    await this.jobOfferService.RemoveSaveJobAsync(id, userId);

                    return new JsonResult(new { success = true, saved = true });
                }

                await this.jobOfferService.SaveJobAsync(id, userId);

                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(JobOfferController));
                return GeneralError();
            }
        }

        [HttpGet]
        [Route("job-offer/detail")]
        public async Task<IActionResult> Detail(Guid id)
        {
            try
            {
                bool jobOfferExists = await this.jobOfferService
                    .ExistsByIdAsync(id);

                if (!jobOfferExists)
                {
                    TempData[ErrorMessage] = "Job offer does not exist!";

                    return RedirectToAction("All");
                }

                var model = await this.jobOfferService
                    .GetDetailsByIdAsync(id);

                if (this.User.Identity!.IsAuthenticated)
                {
                    model.ApplyModel = new JobApplicationFormModel()
                    {
                        Email = this.User.Identity.Name!,
                    };
                }

                return View(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception in {Controller}", nameof(JobOfferController));
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Apply(JobApplicationFormModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, errorMsg = "There is an error in one or more fields" });
            }

            try
            {
                bool jobOfferExists = await this.jobOfferService.ExistsByIdAsync(id);

                if (!jobOfferExists)
                {
                    TempData[ErrorMessage] = "Job offer with the provided id does not exist!";

                    return RedirectToAction("All");
                }

                Guid userId = this.User.Identity!.IsAuthenticated ? this.User.GetGuid() : Guid.Empty;

                string applicationId = await this.jobApplicationService.ApplyJobOfferAsync(model, id, userId);

                if (model.Files.Count > 0)
                {
                    Guid parsedApplicationId = Guid.Parse(applicationId);
                    foreach (var file in model.Files)
                    {
                        await this.documentService.UploadAndSaveAsync(file, "DevHunter/documents", parsedApplicationId);
                    }
                }

                return new JsonResult(new { success = true, successMsg = "Your application has been sent successfully!" });
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

            return RedirectToAction("Index", "Home");
        }
    }
}
