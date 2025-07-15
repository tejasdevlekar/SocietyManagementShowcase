using System.Diagnostics;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
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
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        LoginResponse response = await _loginService.PostLoginAsync(user);
        if (response.status)
        {
            HttpContext.Session.SetInt32(Login.USERID, response.User.Id);
            HttpContext.Session.SetString(Login.USERNAME, response.User.Username);
            HttpContext.Session.SetInt32(Login.USERROLETYPE, (int)response.User.RoleType);
            return RedirectToAction("Dashboard", "Home");
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

    [LoginAuthenticationFilter]
    public IActionResult Dashboard()
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
