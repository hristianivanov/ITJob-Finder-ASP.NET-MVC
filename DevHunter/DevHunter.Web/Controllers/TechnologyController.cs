namespace DevHunter.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;

    using Services.Data.Interfaces;

    using ViewModels.Technology;

    using static Common.GeneralApplicationConstants;
    using static Common.NotificationMessagesConstants;
    using static Common.EntityValidationConstants.Technology;

    [Authorize(Roles = AdminRoleName)]
    public class TechnologyController : Controller
    {
        private readonly ITechnologyService technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            this.technologyService = technologyService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var model = await this.technologyService.AllAsync();

                return this.View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            try
            {
                TechnologyFormModel formModel = new TechnologyFormModel();

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        [RequestSizeLimit(ImageMaxMegaBytesFileSize * 1024 * 1024)]
        public async Task<IActionResult> Add(TechnologyFormModel formModel)
        {
            try
            {
                bool technologyExists =
                    await this.technologyService.TechnologyExistsByNameAsync(formModel.Name);

                if (technologyExists)
                {
                    ModelState.AddModelError(nameof(formModel.Name),
                        "Technology with this name already exists!");
                }

                //TODO: think whether is it necessary to check it when I validate it with attribute ?!?!? 
                if (formModel.Image.Length > ImageMaxMegaBytesFileSize * 1024 * 1024)
                {
                    this.ModelState.AddModelError(nameof(formModel.Image),
                        "You cannot upload image size more than 10 megabytes!");
                }

                if (!ModelState.IsValid)
                {
                    return View(formModel);
                }

                await this.technologyService.AddAsync(formModel);

                TempData[SuccessMessage] = "Technology was created successfully!";

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to add your new technology!");

                return View(formModel);
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                bool technologyExists = await this.technologyService.ExistsByIdAsync(id);

                if (!technologyExists)
                {
                    TempData[ErrorMessage] = "Technology with the provided id does not exist!";

                    return RedirectToAction("All");
                }

                var model = await this.technologyService.GetForEditByIdAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, TechnologyEditFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
                bool technologyExists = await this.technologyService.ExistsByIdAsync(id);

                if (!technologyExists)
                {
                    TempData[ErrorMessage] = "Technology with the provided id does not exist!";

                    return RedirectToAction("All");
                }

                await this.technologyService.EditTechnologyAsync(id, model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to edit the technology!");

                return View(model);
            }

            return RedirectToAction("All");
        }

        [HttpPost]
        [Route("/Technology/Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                bool technologyExists = await this.technologyService.ExistsByIdAsync(id);

                if (!technologyExists)
                {
                    TempData[ErrorMessage] = "Technology with the provided id does not exist!";

                    return RedirectToAction("All");
                }

                await technologyService.DeleteByIdAsync(id);

                TempData[WarningMessage] = "The technology successfully was deleted!";

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }


        private IActionResult ReturnImage(Stream image)
        {
            var headers = this.Response.GetTypedHeaders();

            headers.CacheControl = new CacheControlHeaderValue
            {
                Public = true,
                MaxAge = TimeSpan.FromDays(30)
            };

            headers.Expires = new DateTimeOffset(DateTime.UtcNow.AddDays(30));

            return this.File(image, "image/jpeg");
        }
        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected error occurred!";

            return RedirectToAction("Index", "Home");
        }
    }
}
