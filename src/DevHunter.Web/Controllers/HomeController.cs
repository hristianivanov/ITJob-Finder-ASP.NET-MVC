namespace DevHunter.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using ViewModels.Home;
    using Infrastructure.Extensions;

    using static Common.GeneralApplicationConstants;
    using static Common.NotificationMessagesConstants;

    public class HomeController : Controller
    {
        private readonly IDevelopmentService developmentService;
        private readonly IEmailService emailService;

        public HomeController(IDevelopmentService developmentService, IEmailService emailService)
        {
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
            else if (this.User.IsAdmin())
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            var model = new HomeViewModel()
            {
                Developments = await this.developmentService.AllAsync()
            };

            return View(model);
        }

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
                TempData[ErrorMessage] = UnexpectedError;

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
        {
            var errorMsg = ((System.Net.HttpStatusCode)statusCode).ToString();

            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                StatusCode = statusCode,
                Error = InsertSpacesBeforeUppercase(errorMsg)
            };

            return View(model);
        }

        private static string InsertSpacesBeforeUppercase(string input)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var ch in input)
            {
                if (char.IsUpper(ch) && sb.Length > 0)
                    sb.Append(' ');
                sb.Append(ch);
            }
            return sb.ToString();
        }
    }
}
