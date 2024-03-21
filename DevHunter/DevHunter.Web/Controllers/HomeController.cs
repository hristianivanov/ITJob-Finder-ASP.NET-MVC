namespace DevHunter.Web.Controllers
{
	using System.Diagnostics;

	using Microsoft.AspNetCore.Mvc;

	using ViewModels.Home;
	using Infrastructure.Extensions;

	using static Common.GeneralApplicationConstants;

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IActionResult Index()
		{
			if (this.User.IsCompany())
			{
				return RedirectToAction("All", "JobOffer", new { area = CompanyAreaName });
			}
			if (this.User.IsAdmin())
			{
				return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
			}

			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}