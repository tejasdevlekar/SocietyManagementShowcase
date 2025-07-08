using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.Models;
using SocietyManagementUI.Api;
using Common;
using SocietyManagementUI.Filters;

namespace SocietyManagementUI.Controllers
{
    [LoginAuthenticationFilter]
    public class AmenitiesController : Controller
    {
        private readonly ILogger<AmenitiesController> _logger;
        private readonly AmenitiesService _amenitiesService;
        private readonly MaintenanceLogService _maintenanceLogService;

        public AmenitiesController(ILogger<AmenitiesController> logger,
            AmenitiesService amenitiesService,
            MaintenanceLogService maintenanceLogService)
        {
            _logger = logger;
            _amenitiesService = amenitiesService;
            _maintenanceLogService = maintenanceLogService;
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> GymActionEdit()
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

        [HttpPost]
        public async Task<IActionResult> GymActionEdit(Gym gym)
        {
            try
            {
                AmenitiesResponse response = new AmenitiesResponse() { 
                    Type = AmenityType.Gym,
                    Amenity = gym
                };
                bool isSuccess = await _amenitiesService.PutAmenityAsync(response);

                if (isSuccess)
                    return RedirectToAction("GymAction");
                else
                    return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GymMaintenanceLog(int id)
        {
            try
            {
                //lastId = lastId != null ? lastId : 0;
                int lastId = id;
                List<MaintenanceLog> maintenanceLogs = await _maintenanceLogService
                    .GetMaintenanceLogsAsync(MaintenanceLogType.Gym, lastId);
                return View(maintenanceLogs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }


    }
}
