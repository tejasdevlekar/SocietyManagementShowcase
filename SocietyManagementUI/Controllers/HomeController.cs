using Common;
using Common.Common;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementUI.Api;
using SocietyManagementUI.Filters;
using SocietyManagementUI.Models;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.Json;

namespace SocietyManagementUI.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly LoginService _loginService;
    private readonly SessionService _sessionService;


    public HomeController(ILogger<HomeController> logger, LoginService loginService, SessionService sessionService)
    {
        _logger = logger;
        _loginService = loginService;
        _sessionService = sessionService;
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
        Response.Cookies.Append(Login.SESSIONID, response.SessionId, new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddHours(2),
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict
        });

        //verify session
        //var sessionId = HttpContext.Request.Cookies[Login.SESSIONID];
        //string username = await _sessionService.GetSessionKey(sessionId);

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
    public async Task<IActionResult> Dashboard()
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
