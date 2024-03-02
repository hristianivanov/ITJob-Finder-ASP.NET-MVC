namespace DevHunter.Web.Areas.Company.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

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
			return View();
		}
	}
}
