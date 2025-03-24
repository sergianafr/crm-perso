using crm_perso.Extensions;
using crm_perso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace crm_perso.Filters
{
    public class AuthSessionFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Session.GetObject<UserWRole>("CurrentUser");
        
            if (user == null)
            {
                context.Result = new RedirectToActionResult("Index", "Auth", null);
                return;
            }
            // // Optionnel : Vérification des rôles
            // var requiredRole = context.HttpContext.GetRouteValue("role")?.ToString();
            // if (!string.IsNullOrEmpty(requiredRole) && user.role != requiredRole)
            // {
            //     context.Result = new ViewResult { ViewName = "AccessDenied" };
            // }
        }
    }
}