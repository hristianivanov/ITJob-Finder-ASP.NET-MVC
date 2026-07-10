namespace DevHunter.Web.Infrastructure.Extensions
{
    using System.Security.Claims;

    using static Common.GeneralApplicationConstants;

    public static class ClaimsPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.NameIdentifier);

        public static Guid GetGuid(this ClaimsPrincipal user)
        {
            var raw = user.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(raw, out Guid id) ? id : Guid.Empty;
        }

        public static bool IsAdmin(this ClaimsPrincipal user) 
            => user.IsInRole(AdminRoleName);

        public static bool IsCompany(this ClaimsPrincipal user) 
            => user.IsInRole(CompanyRoleName);
    }
}