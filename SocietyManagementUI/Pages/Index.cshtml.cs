using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocietyManagementShowcase.Models;
using SocietyManagementUI.Api;

namespace SocietyManagementUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LoginService _loginService;

        [BindProperty]
        public User _user { get; set; }
        public IndexModel(ILogger<IndexModel> logger, LoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
            _user = new User();
        }

        public void OnGet()
        {
            int test = 0;
            ViewData["Message"] = "GetTest";
        }

        public async Task<IActionResult> OnPost(User user)
        {
            try
            {
                string test = user.Username;
                string test2 = user.Password;

                string testLogin = "Default value";
                testLogin = await _loginService.PostLoginAsync(user);
                ViewData["Message"] = testLogin;

                return Page();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.ToString();
                return Page();
            }

        }
    }
}
