namespace DevHunter.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class CompanyController : BaseAdminController
	{
		public IActionResult All()
		{
			return View();
		}
	}
}
