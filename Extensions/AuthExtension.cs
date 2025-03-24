using crm_perso.Models;

namespace crm_perso.Extensions
{
    public static class AuthExtension
    {

        public static Boolean IsAuthenticated(this HttpContext httpContext)
        {
            if (httpContext.Session.GetObject<UserWRole>("CurrentUser") != null)
            {
                return true;
            }
            return false;
        }
    }
}