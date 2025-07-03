using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.Models;
using SocietyManagementUI.Api;
using SocietyManagementUI.Common;
using SocietyManagementUI.Filters;
using SocietyManagementUI.Models;

namespace SocietyManagementUI.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly LoginService _loginService;


    public HomeController(ILogger<HomeController> logger, LoginService loginService)
    {
        _logger = logger;
        _loginService = loginService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Index(User user)
    {
        bool isAuthenticated = await _loginService.PostLoginAsync(user);
        if (isAuthenticated)
        {
            HttpContext.Session.SetInt32(Login.USERID, user.Id);
            HttpContext.Session.SetString(Login.USERNAME, user.Username);
            return RedirectToAction("Privacy", "Home");
        }
        else
        {
            ViewData["UserNotVerified"] = "User Not Verified";
            return View(user);
        }


    }

    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
    [LoginAuthenticationFilter]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    [LoginAuthenticationFilter]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
