namespace DevHunter.Web.Infrastructure.Extensions
{
	using System.Security.Claims;

	public static class ClaimsPrincipalExtensions
	{
		public static string? GetId(this ClaimsPrincipal user)
		{
			var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
			return userId;
		}

		public static bool IsAdmin(this ClaimsPrincipal user)
		{
			throw new NotImplementedException();
			//return user.IsInRole(AdminRoleName);
		}
	}
}
