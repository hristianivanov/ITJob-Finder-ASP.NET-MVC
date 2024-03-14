namespace DevHunter.Web.Areas.Company.Controllers
{
	using DevHunter.Web.Infrastructure.Extensions;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Cors.Infrastructure;
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Interfaces;
	using ViewModels.JobOffer;

	using static Common.NotificationMessagesConstants;

	[Authorize]
	[Area("Company")]
	public class JobOfferController : Controller
	{
		private readonly ITechnologyService technologyService;
		private readonly IJobOfferService jobOfferService;

		public JobOfferController(ITechnologyService technologyService, IJobOfferService jobOfferService)
		{
			this.technologyService = technologyService;
			this.jobOfferService = jobOfferService;
		}

		[Route("company/postjob")]
		public async Task<IActionResult> Add()
		{
			var model = new JobOfferFormModel()
			{
				Technologies = await this.technologyService.AllAsync()
			};

			return View(model);
		}

		//TODO: XSS on Description HTMLSanitizer
        [HttpPost]
		[Route("company/postjob")]
		public async Task<IActionResult> Add(JobOfferFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				string jobOfferId =
					await jobOfferService.CreateAndReturnIdAsync(model,this.User.GetId()!);

				TempData[SuccessMessage] = "Job offer was added successfully!";

				return RedirectToAction("Detail", "JobOffer", new { id = jobOfferId });
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to add your new job offer!");

				return View(model);
			}
		}
	}
}
