namespace SocietyManagementUI.Common
{
    public static class CookieHelper
    {
        public static HttpContext _httpContext { get; set; }

        
        public static string GetCookieValue(string cookieName)
        {
            // Check if the HttpContext is available
            var context = _httpContext;
            if (context != null && context.Request.Cookies[cookieName] != null)
            {
                return context.Request.Cookies[cookieName];
            }
            return null; // Return null if the cookie doesn't exist
        }
    }

}
