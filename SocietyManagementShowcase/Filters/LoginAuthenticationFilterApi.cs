using Common.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;

namespace SocietyManagementShowcase.Filters
{
    public class LoginAuthenticationFilterApi : Attribute, IAuthorizationFilter
    {
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorisedTask = IsAuthorised(context).Result;
            if (!isAuthorisedTask)
            {
                context.HttpContext.Response.StatusCode = 401; // Unauthorized
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Session" },
                    { "action", "Delete" }
                });
            }
        }

        private async Task<bool> IsAuthorised(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue(Login.SESSIONID, out var sessionID);

            ISessionRepo _sessionRepo = context.HttpContext.RequestServices.GetService<ISessionRepo>();
            //IsSessionValid
            MySessionModel mySessionModel = await _sessionRepo.GetSession(sessionID);
            if (mySessionModel != null)
            {
                if (mySessionModel.ExpiresAtTime.AddSeconds(mySessionModel.SlidingExpirationInSeconds) > DateTime.UtcNow
                    && mySessionModel.AbsoluteExpiration > DateTime.UtcNow)
                {
                    mySessionModel.ExpiresAtTime = DateTime.UtcNow; // reset the expiration time
                    await _sessionRepo.SetSessionAccess(mySessionModel);
                    return true;
                }
            }
            return false;



        }
    }
}
