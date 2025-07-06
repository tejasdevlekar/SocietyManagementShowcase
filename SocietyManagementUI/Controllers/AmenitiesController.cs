using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.Models;
using SocietyManagementUI.Api;

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
                Gym gym = await _amenitiesService.GetGymAsync(1); //Hardcoding gym id 'cause there's only 1 gym.
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
