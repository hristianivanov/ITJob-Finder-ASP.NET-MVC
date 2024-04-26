namespace DevHunter.Web.Controllers
{
	using System.Diagnostics;

	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Interfaces;
	using ViewModels.Home;
	using Infrastructure.Extensions;

	using static Common.GeneralApplicationConstants;
	using static Common.NotificationMessagesConstants;
	using Microsoft.AspNetCore.Authorization;

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> logger;
		private readonly IDevelopmentService developmentService;
		private readonly IEmailService emailService;

		public HomeController(ILogger<HomeController> logger, IDevelopmentService developmentService, IEmailService emailService)
		{
			this.logger = logger;
			this.developmentService = developmentService;
			this.emailService = emailService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			if (this.User.IsCompany())
			{
				return RedirectToAction("All", "JobOffer", new { area = CompanyAreaName });
			}
			if (this.User.IsAdmin())
			{
				return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
			}

			var model = new HomeViewModel()
			{
				Developments = await this.developmentService.AllAsync()
			};

			return View(model);
		}

		[Authorize(Roles = "Admin")]
		public IActionResult About()
		{
			return View();
		}

		[HttpGet]
		[Route("/contact")]
		public IActionResult Contact()
		{
			var model = new FormMessageModel();

			return View(model);
		}

		[HttpPost]
		[Route("/contact")]
		public async Task<IActionResult> Contact(FormMessageModel model)
		{
			if (!ModelState.IsValid)
			{
				TempData[ErrorMessage] = "Unexpected error occurred!";

				return View(model);
			}

			try
			{
				await emailService.SendEmailAsync(model);
			}
			catch (Exception e)
			{
				TempData[ErrorMessage] = e.Message;

				return View(model);
			}

			TempData[SuccessMessage] = "Successfully sent email!";

			return RedirectToAction("Contact");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		[Route("Error/{statusCode}")]
		public IActionResult Error(int statusCode)
		{ var errorMsg = ((System.Net.HttpStatusCode)statusCode).ToString();
			
			var model = new ErrorViewModel
			{
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
				StatusCode = statusCode,
				Error = errorMsg.InsertSpacesBeforeUppercase()
			};

			return View(model);
		}
	}
}