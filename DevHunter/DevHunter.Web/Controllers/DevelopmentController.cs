using DevHunter.Services.Data.Interfaces;

namespace DevHunter.Web.Controllers
{
	using DevHunter.Web.ViewModels.Technology;
	using Microsoft.AspNetCore.Mvc;

	using ViewModels.Development;

	using static Common.NotificationMessagesConstants;
	using static Common.EntityValidationConstants.Development;

	public class DevelopmentController : Controller
	{
		private readonly IDevelopmentService developmentService;

		public DevelopmentController(IDevelopmentService developmentService)
		{
			this.developmentService = developmentService;
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
				bool technologyExists =
					await this.developmentService.ExistsByNameAsync(formModel.Name);

				if (technologyExists)
				{
					ModelState.AddModelError(nameof(formModel.Name),
						"Development with this name already exists!");
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

				await this.developmentService.AddAsync(formModel);

				TempData[SuccessMessage] = "Technology was created successfully!";

				return RedirectToAction("Index","Home");
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to add your new technology!");

				return View(formModel);
			}
		}


		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("Index", "Home");
		}
	}
}
