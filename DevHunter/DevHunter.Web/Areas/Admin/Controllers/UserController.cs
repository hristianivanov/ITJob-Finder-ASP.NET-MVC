namespace DevHunter.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class UserController : BaseAdminController
	{
		public IActionResult All()
		{
			return View();
		}
	}
}
