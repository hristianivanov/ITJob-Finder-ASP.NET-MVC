namespace DevHunter.Web.Areas.Admin.Controllers
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
	public class TechnologyController : BaseAdminController
	{
		private readonly ITechnologyService technologyService;

		public TechnologyController(ITechnologyService technologyService)
		{
			this.technologyService = technologyService;
		}

		[HttpGet]
		[Route("technology/all")]
		public async Task<IActionResult> All()
		{
			try
			{
				var model = await technologyService.AllAsync();

				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpGet]
		[Route("technology/add")]
		public IActionResult Add(string id)
		{
			try
			{
				TechnologyFormModel formModel = new TechnologyFormModel()
				{
					DevelopmentId = id
				};

				return View(formModel);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		[Route("technology/add")]
		[RequestSizeLimit(ImageMaxMegaBytesFileSize * 1024 * 1024)]
		public async Task<IActionResult> Add(TechnologyFormModel formModel, string? id)
		{
			try
			{
				bool technologyExists =
					await technologyService.TechnologyExistsByNameAsync(formModel.Name);

				if (technologyExists)
				{
					ModelState.AddModelError(nameof(formModel.Name),
						"Technology with this name already exists!");
				}

				//TODO: think whether is it necessary to check it when I validate it with attribute ?!?!? 
				if (formModel.Image.Length > ImageMaxMegaBytesFileSize * 1024 * 1024)
				{
					ModelState.AddModelError(nameof(formModel.Image),
						"You cannot upload image size more than 10 megabytes!");
				}

				if (!ModelState.IsValid)
				{
					return View(formModel);
				}

				await technologyService.AddAsync(formModel, id);

				TempData[SuccessMessage] = "Technology was created successfully!";

				if (!string.IsNullOrWhiteSpace(id))
					return RedirectToAction("All", "Development");
				else
					return RedirectToAction("All");
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to add your new technology!");

				return View(formModel);
			}
		}

		[HttpGet]
		[Route("technology/edit/{id}")]
		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				bool technologyExists = await technologyService.ExistsByIdAsync(id);

				if (!technologyExists)
				{
					TempData[ErrorMessage] = "Technology with the provided id does not exist!";

					return RedirectToAction("All");
				}

				var model = await technologyService.GetForEditByIdAsync(id);

				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		[Route("technology/edit/{id}")]
		public async Task<IActionResult> Edit(string id, TechnologyEditFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				bool technologyExists = await technologyService.ExistsByIdAsync(id);

				if (!technologyExists)
				{
					TempData[ErrorMessage] = "Technology with the provided id does not exist!";

					return RedirectToAction("All");
				}

				await technologyService.EditTechnologyAsync(id, model);
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
		[Route("technology/delete/{id}")]
		public async Task<IActionResult> Delete([FromRoute] string id)
		{
			try
			{
				bool technologyExists = await technologyService.ExistsByIdAsync(id);

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
			var headers = Response.GetTypedHeaders();

			headers.CacheControl = new CacheControlHeaderValue
			{
				Public = true,
				MaxAge = TimeSpan.FromDays(30)
			};

			headers.Expires = new DateTimeOffset(DateTime.UtcNow.AddDays(30));

			return File(image, "image/jpeg");
		}
		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("Index", "Home");
		}
	}
}
