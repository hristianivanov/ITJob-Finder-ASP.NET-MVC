namespace DevHunter.Web.Areas.Manage.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	[Authorize]
	[Area("Manage")]
	public class BaseManageController : Controller
	{
	}
}
