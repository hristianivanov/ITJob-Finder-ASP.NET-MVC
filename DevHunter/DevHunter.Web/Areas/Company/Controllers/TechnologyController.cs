namespace DevHunter.Web.Areas.Company.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using DevHunter.Services.Data.Interfaces;

	public class TechnologyController : Controller
	{
		private readonly ITechnologyService technologyService;

		public TechnologyController(ITechnologyService technologyService)
		{
			this.technologyService = technologyService;
		}

		[HttpGet]
		public async Task<IActionResult> GetTechnologies()
		{
			var technologies = await this.technologyService.AllAsync();

			var model = technologies.Select(t => t.Name).Distinct().ToList();

			return Ok(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetJobOfferTechnologies(string id)
		{
			var technologies = await this.technologyService.AllByJobOfferIdAsync(id);

			var model = technologies.Select(t => t.Name).Distinct().ToList();

			return Ok(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetRemainingTechnologies(string id)
		{
			var technologies = await this.technologyService.AllWithoutJobOfferOnesAsync(id);

			var model = technologies.Select(t => t.Name).Distinct().ToList();

			return Ok(model);
		}
	}
}
