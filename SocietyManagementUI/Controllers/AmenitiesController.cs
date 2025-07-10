using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.Models;
using SocietyManagementUI.Api;
using Common;
using SocietyManagementUI.Filters;
using Microsoft.AspNetCore.Routing.Constraints;

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

        [AdminAuthorizationFilter]
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
                AmenitiesResponse response = new AmenitiesResponse()
                {
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

        //[HttpGet]
        //public async Task<IActionResult> SwimmingPoolAction()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> GenericMaintenanceLog(int id, MaintenanceLogType type)
        {
            try
            {
                //lastId = lastId != null ? lastId : 0;
                int lastId = id;
                List<MaintenanceLog> maintenanceLogs = new List<MaintenanceLog>();
                switch (type)
                {
                    case MaintenanceLogType.Gym:
                        maintenanceLogs = await _maintenanceLogService
                    .GetMaintenanceLogsAsync(MaintenanceLogType.Gym, lastId);
                        if (maintenanceLogs == null)
                            maintenanceLogs = new List<MaintenanceLog>();
                        return View(maintenanceLogs);
                        break;
                    case MaintenanceLogType.SwimmingPool:
                        break;
                    case MaintenanceLogType.CommonAmenities:
                        break;
                    default:
                        break;
                }


                if (maintenanceLogs == null)
                    maintenanceLogs = new List<MaintenanceLog>();
                return View(maintenanceLogs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }

        [StaffAuthorizationFilter]
        [HttpGet]
        public async Task<IActionResult> AddMaintenanceLog(MaintenanceLogType type)
        {
            try
            {
                MaintenanceLog log = new MaintenanceLog();
                log.DateAndTime = System.DateTime.Now;
                log.LogType = type;
                return View(log);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }

        [StaffAuthorizationFilter]
        [HttpPost]
        public async Task<IActionResult> AddMaintenanceLog(MaintenanceLogType logType, MaintenanceLog log)
        {
            try
            {
                switch (logType)
                {
                    case MaintenanceLogType.Gym:
                        bool isSuccess = await _maintenanceLogService
                                    .PostMaintenanceLogsAsync(MaintenanceLogType.Gym, log);
                        if (isSuccess)
                            return RedirectToAction("GenericMaintenanceLog", "Amenities", new
                            {
                                id = 0,
                                type = (int)logType
                            });
                        else
                            return RedirectToAction("Error", "Home");
                        break;
                    case MaintenanceLogType.SwimmingPool:
                        break;
                    case MaintenanceLogType.CommonAmenities:
                        break;
                    default:
                        break;
                }
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }


        [AdminAuthorizationFilter]
        [HttpGet]
        public async Task<IActionResult> EditMaintenanceLog(int id, MaintenanceLogType logType)
        {
            try
            {
                MaintenanceLog log = await _maintenanceLogService.GetSingleMaintenanceLogAsync(id, logType);
                log.LogType = logType;
                return View(log);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }

        [AdminAuthorizationFilter]
        [HttpPost]
        public async Task<IActionResult> EditMaintenanceLog(MaintenanceLog log)
        {
            try
            {
                bool isSuccess = await _maintenanceLogService.PutMaintenanceLogsAsync(log);
                if (isSuccess)
                    return RedirectToAction("GenericMaintenanceLog", "Amenities",
                        new { id = 0, type = log.LogType });
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
