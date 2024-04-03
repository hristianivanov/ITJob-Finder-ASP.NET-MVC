namespace DevHunter.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Development;
    using Services.Data.Interfaces;

    using static Common.NotificationMessagesConstants;
    using static Common.EntityValidationConstants.Development;

    public class DevelopmentController : BaseAdminController
    {
        private readonly IDevelopmentService developmentService;

        public DevelopmentController(IDevelopmentService developmentService)
        {
            this.developmentService = developmentService;
        }

        public async Task<IActionResult> All()
        {
            var model = new DevelopmentAllViewModel
            {
                Developments = await developmentService.AllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            try
            {
                DevelopmentFormModel formModel = new DevelopmentFormModel();

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        [RequestSizeLimit(ImageMaxMegaBytesFileSize * 1024 * 1024)]
        public async Task<IActionResult> Add(DevelopmentFormModel formModel)
        {
            try
            {
                bool developmentExists =
                    await developmentService.ExistsByNameAsync(formModel.Name);

                if (developmentExists)
                {
                    ModelState.AddModelError(nameof(formModel.Name),
                        "Development with this name already exists!");
                }

                if (formModel.Image.Length > ImageMaxMegaBytesFileSize * 1024 * 1024)
                {
                    ModelState.AddModelError(nameof(formModel.Image),
                        "You cannot upload image size more than 10 megabytes!");
                }

                if (!ModelState.IsValid)
                {
                    return View(formModel);
                }

                await developmentService.AddAsync(formModel);

                TempData[SuccessMessage] = "Technology was created successfully!";

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to add your new technology!");

                return View(formModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                bool developmentExists = await developmentService.ExistsByIdAsync(id);

                if (!developmentExists)
                {
                    TempData[ErrorMessage] = "Development with the provided id does not exist!";

                    return RedirectToAction("All");
                }

                var model = await developmentService.GetForEditByIdAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(string id, DevelopmentEditFormModel model)
        {
	        if (!ModelState.IsValid)
	        {
		        return View();
	        }

	        try
	        {
		        bool developmentExists = await developmentService.ExistsByIdAsync(id);

		        if (!developmentExists)
		        {
			        TempData[ErrorMessage] = "Development with the provided id does not exist!";

			        return RedirectToAction("All");
		        }

		        await developmentService.EditDevelopmentAsync(id, model);
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
        public async Task<IActionResult> Delete(string id)
        {
	        try
	        {
		        bool developmentExists = await developmentService.ExistsByIdAsync(id);

		        if (!developmentExists)
		        {
			        TempData[ErrorMessage] = "Development with the provided id does not exist!";

			        return RedirectToAction("All");
		        }

		        await developmentService.DeleteByIdAsync(id);

		        TempData[WarningMessage] = "The development successfully was deleted!";

		        return RedirectToAction("All");
	        }
	        catch (Exception)
	        {
		        return GeneralError();
	        }
		}
        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected error occurred!";

            return RedirectToAction("Index", "Home");
        }
    }
}
