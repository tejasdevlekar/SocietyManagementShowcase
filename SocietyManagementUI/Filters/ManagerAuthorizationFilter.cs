using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Common.Models;
using SocietyManagementUI.Common;

namespace SocietyManagementUI.Filters
{
    public class ManagerAuthorizationFilter : Attribute, IAuthorizationFilter
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
                && context.HttpContext.Session.GetInt32(Login.USERROLETYPE) <= (int)UserRoleType.Manager)
                return true;
            else
                return false;
        }
    }
}
