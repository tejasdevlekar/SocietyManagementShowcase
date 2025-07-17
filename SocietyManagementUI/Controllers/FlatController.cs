using Common.Models;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementUI.Api;
using SocietyManagementUI.Filters;
using SocietyManagementUI.Models;

namespace SocietyManagementUI.Controllers
{
    [LoginAuthenticationFilter]
    public class FlatController : Controller
    {
        private readonly ILogger<FlatController> _logger;
        private readonly FlatService _flatService;
        private readonly WingService _wingService;

        public FlatController(ILogger<FlatController> logger, FlatService flatService, WingService wingService)
        {
            _logger = logger;
            _flatService = flatService;
            _wingService = wingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddFlat()
        {
            AddFlatViewModel postFlat = new AddFlatViewModel();
            postFlat.Residents = new List<Person>();
            postFlat.WingIdAndName = await _wingService.GetWingIdAndNameAsync();
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
