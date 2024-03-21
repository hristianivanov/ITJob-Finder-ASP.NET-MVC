namespace DevHunter.Web.Areas.Company.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using static Common.GeneralApplicationConstants;

	[Area(CompanyAreaName)]
	[Authorize(Roles = CompanyRoleName)]
	public class BaseCompanyController : Controller
	{
	}
}
