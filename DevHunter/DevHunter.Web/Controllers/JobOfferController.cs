namespace DevHunter.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class JobOfferController : Controller
	{
		

		public IActionResult All()
		{
			return View();
		}
	}
}