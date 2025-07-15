using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Common.Models;
using SocietyManagementUI.Common;

namespace SocietyManagementUI.Filters
{
    public class SuperAdminAuthrorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsAuthorised(context))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "User" },
                    { "action", "Index" }
                });
            }
        }

        private bool IsAuthorised(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetInt32(Login.USERROLETYPE) != null)
                //&& context.HttpContext.Session.GetInt32(Login.USERROLETYPE) == (int)UserRoleType.SuperAdmin)
            {
                int roleType = (int)context.HttpContext.Session.GetInt32(Login.USERROLETYPE);
                if(roleType == (int)UserRoleType.SuperAdmin)
                return true;
                else return false;
            }
            else
            {
                return false;
            }
        }
    }
}
