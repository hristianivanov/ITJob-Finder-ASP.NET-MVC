namespace DevHunter.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Interfaces;

	public class AccountController : BaseAdminController
	{
		private readonly IUserService userService;

		public AccountController(IUserService userService)
		{
			this.userService = userService;
		}

		public async Task<IActionResult> All()
		{
			var model = await this.userService.AllAsync();

			return View(model);
		}
	}
}
