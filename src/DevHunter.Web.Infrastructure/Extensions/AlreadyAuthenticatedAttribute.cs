namespace DevHunter.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class AlreadyAuthenticatedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User?.Identity?.IsAuthenticated ?? false)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
