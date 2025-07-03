using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocietyManagementUI.Common;

namespace SocietyManagementUI.Filters
{
    public class LoginAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsAuthorised(context))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Home" },   
                    { "action", "Index" }       
                });
            }
        }

        public bool IsAuthorised(AuthorizationFilterContext context) 
        {
            if(!String.IsNullOrWhiteSpace(context.HttpContext.Session.GetString(Login.USERNAME)))
                return true;

            return false;
        }
    }
}
