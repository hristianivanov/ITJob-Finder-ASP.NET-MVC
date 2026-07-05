namespace DevHunter.Web.Areas.Company.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extensions;

    using static Common.GeneralApplicationConstants;
    using static Common.NotificationMessagesConstants;

    [Area(CompanyAreaName)]
    [Authorize(Roles = CompanyRoleName)]
    public class BaseCompanyController : Controller
    {
        protected bool AssertOwnership(bool isOwned, string redirectAction = "All")
        {
            if (!isOwned)
            {
                TempData[ErrorMessage] = "Resource does not exist or does not belong to your account.";
            }

            return isOwned;
        }

        protected Guid CurrentUserId => this.User.GetGuid();
    }
}
