using System.Security.Claims;
using static SchoolLibrary.Core.Constants.AdministratorConstants;
namespace SchoolLibrary.Extension
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }
    }
}
