using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.Models;
using SocietyManagementUI.Api;
using Common;

namespace SocietyManagementUI.Controllers
{
    public class AmenitiesController : Controller
    {
        private readonly ILogger<AmenitiesController> _logger;
        private readonly AmenitiesService _amenitiesService;

        public AmenitiesController(ILogger<AmenitiesController> logger, AmenitiesService amenitiesService)
        {
            _logger = logger;
            _amenitiesService = amenitiesService;
        }

        public async Task<IActionResult> GymAction()
        {
            try
            {
                Gym gym = await _amenitiesService.GetAmenityAsync(AmenityType.Gym);
                return View(gym);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
