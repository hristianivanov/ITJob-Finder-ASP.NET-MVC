namespace DevHunter.Web.Areas.Manage.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using static Common.GeneralApplicationConstants;

	[Authorize]
	[Area(ManageAreaName)]
	public class BaseManageController : Controller
	{
	}
}
