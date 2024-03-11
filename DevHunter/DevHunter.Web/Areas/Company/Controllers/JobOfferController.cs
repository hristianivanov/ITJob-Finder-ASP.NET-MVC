namespace DevHunter.Web.Areas.Company.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Interfaces;
	using ViewModels.JobOffer;

	[Authorize]
	[Area("Company")]
	public class JobOfferController : Controller
	{
		private readonly ITechnologyService technologyService;

		public JobOfferController(ITechnologyService technologyService)
		{
			this.technologyService = technologyService;
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

			return Ok();
		}
	}
}
