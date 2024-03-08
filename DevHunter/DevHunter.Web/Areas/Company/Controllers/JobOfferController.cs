namespace DevHunter.Web.Areas.Company.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using ViewModels.JobOffer;

	[Authorize]
	[Area("Company")]
	public class JobOfferController : Controller
	{
		public JobOfferController()
		{

		}

		[Route("company/postjob")]
		public IActionResult Add()
		{
			var model = new JobOfferFormModel();

			return View();
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
