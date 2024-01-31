namespace DevHunter.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Interfaces;

	using ViewModels.Technology;

	using static Common.NotificationMessagesConstants;

	[Authorize]
	public class TechnologyController : Controller
	{
		private readonly ITechnologyService technologyService;

		//TODO: only admin

		public TechnologyController(ITechnologyService technologyService)
		{
			this.technologyService = technologyService;
		}

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
		public async Task<IActionResult> Add(TechnologyFormModel formModel)
		{
			bool technologyExists =
				await this.technologyService.TechnologyExistsByNameAsync(formModel.Name);

			if (technologyExists)
			{
				ModelState.AddModelError(nameof(formModel.Name), "Technology with this name already exists!");
			}

			//TODO: to check code of the image

			if (!ModelState.IsValid)
			{
				return View(formModel);
			}

			try
			{
				await this.technologyService.AddAsync(formModel);

				return RedirectToAction("All", "Technology");
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to add your new technology!");
			}

			return View(formModel);
		}

		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("Index", "Home");
		}
	}
}
