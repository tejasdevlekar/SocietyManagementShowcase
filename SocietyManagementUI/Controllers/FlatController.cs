using Common.Models;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementUI.Api;
using SocietyManagementUI.Filters;

namespace SocietyManagementUI.Controllers
{
    [LoginAuthenticationFilter]
    public class FlatController : Controller
    {
        private readonly ILogger<FlatController> _logger;
        private readonly FlatService _flatService;

        public FlatController(ILogger<FlatController> logger, FlatService flatService)
        {
            _logger = logger;
            _flatService = flatService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddFlat()
        {
            Flat postFlat = new Flat();
            postFlat.Residents = new List<Person>();
            return View(postFlat);
        }

        [HttpPost]
        public async Task<IActionResult> AddFlat(Flat flat)
        {
            try
            {
                bool isSuccess = await _flatService.AddFlatAsync(flat);
                if (isSuccess)
                    return RedirectToAction("Index", "Flat");
                else
                    return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }



    }
}
