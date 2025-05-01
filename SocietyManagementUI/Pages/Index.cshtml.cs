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
        }

        public async void OnPost(User user)
        {
            string test = user.Username;
            string test2 = user.Password;

            string testLogin = await _loginService.PostLoginAsync(user);

        }
    }
}
