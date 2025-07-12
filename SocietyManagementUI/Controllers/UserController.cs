using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using SocietyManagementUI.Api;
using SocietyManagementUI.Filters;

namespace SocietyManagementUI.Controllers
{
    [LoginAuthenticationFilter]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;


        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<User> users = await _userService.GetAllUserAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            bool isUserAdded = await _userService.AddUserAsync(user);
            if (isUserAdded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            try
            {
                User retrievedUser = await _userService.FetchUserAsync(id);
                return View(retrievedUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            try
            {
                _logger.LogInformation("Editing user");
                bool isSuccess = await _userService.EditUserAsync(user.Id,user);
                _logger.LogInformation("User edited successfully");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return View();
        }

        [SuperAdminAuthrorizationFilter]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                _logger.LogInformation("Deleting user");
                bool isSuccess = await _userService.DeleteUserAsync(id);
                _logger.LogInformation("User deleted successfully");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Index");
            }
        }
    }
}
