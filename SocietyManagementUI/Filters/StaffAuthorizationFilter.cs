using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocietyManagementShowcase.Models;
using SocietyManagementUI.Common;

namespace SocietyManagementUI.Filters
{
    public class StaffAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsAuthorised(context))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Home" },
                    { "action", "Dashboard" }
                });
            }
        }

        private bool IsAuthorised(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetInt32(Login.USERROLETYPE) != null
                && context.HttpContext.Session.GetInt32(Login.USERROLETYPE) <= (int)UserRoleType.Staff)
                return true;
            else
                return false;
        }
    }
}
