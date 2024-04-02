namespace DevHunter.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using DevHunter.Services.Data.Interfaces;

	public class CompanyController : BaseAdminController
	{
		private readonly ICompanyService companyService;

		public CompanyController(ICompanyService companyService)
		{
			this.companyService = companyService;
		}

		[HttpGet]
		[Route("company/all")]
		public async Task<IActionResult> All()
		{
			var model = await this.companyService.AllAsync();

			return View(model);
		}
	}
}
