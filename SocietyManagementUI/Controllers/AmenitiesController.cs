using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Common.Models;
using SocietyManagementUI.Api;
using SocietyManagementUI.Filters;
using System.Text.Json;
using Common.Common;
using SocietyManagementUI.Models;

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
                AmenitiesResponse response = await _amenitiesService.GetAmenityAsync(AmenityType.Gym);
                Gym gym = JsonSerializer.Deserialize<Gym>(response.Amenity.ToString());
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
                AmenitiesResponse response = await _amenitiesService.GetAmenityAsync(AmenityType.Gym);
                Gym gym = JsonSerializer.Deserialize<Gym>(response.Amenity.ToString());
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

        [HttpGet]
        public async Task<IActionResult> SwimmingPoolAction(int id)
        {
            try
            {
                if(id == (int)SwimmingPoolType.Indoor)
                {
                    AmenitiesResponse response = await _amenitiesService.GetAmenityAsync(AmenityType.SwimmingPoolIndoor);
                    SwimmingPool pool = JsonSerializer.Deserialize<SwimmingPool>(response.Amenity.ToString());
                    return View(pool);
                }
                else
                {
                    AmenitiesResponse response = await _amenitiesService.GetAmenityAsync(AmenityType.SwimmingPoolOutdoor);
                    SwimmingPool pool = JsonSerializer.Deserialize<SwimmingPool>(response.Amenity.ToString());
                    return View(pool);
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }

        [AdminAuthorizationFilter]
        [HttpGet]
        public async Task<IActionResult> SwimmingPoolActionEdit(int id)
        {
            try
            {
                if (id == (int)SwimmingPoolType.Indoor)
                {
                    AmenitiesResponse response = await _amenitiesService.GetAmenityAsync(AmenityType.SwimmingPoolIndoor);
                    SwimmingPoolActionEditViewModel pool = JsonSerializer.Deserialize<SwimmingPoolActionEditViewModel>(response.Amenity.ToString());
                    return View(pool);
                }
                else
                {
                    AmenitiesResponse response = await _amenitiesService.GetAmenityAsync(AmenityType.SwimmingPoolOutdoor);
                    SwimmingPoolActionEditViewModel pool = JsonSerializer.Deserialize<SwimmingPoolActionEditViewModel>(response.Amenity.ToString());
                    return View(pool);
                }
                    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }

        [AdminAuthorizationFilter]
        [HttpPost]
        public async Task<IActionResult> SwimmingPoolActionEdit(SwimmingPool pool)
        {
            try
            {
                if (pool.PoolType == SwimmingPoolType.Indoor)
                {
                    AmenitiesResponse response = new AmenitiesResponse()
                    {
                        Type = AmenityType.SwimmingPoolIndoor,
                        Amenity = pool
                    };

                    bool isSuccess = await _amenitiesService.PutAmenityAsync(response);
                    if (isSuccess)
                        return RedirectToAction("SwimmingPoolAction", "Amenities", new { id = (int)pool.PoolType });
                    else
                        return RedirectToAction("Error", "Home");
                }
                else
                {
                    AmenitiesResponse response = new AmenitiesResponse()
                    {
                        Type = AmenityType.SwimmingPoolOutdoor,
                        Amenity = pool
                    };
                    bool isSuccess = await _amenitiesService.PutAmenityAsync(response);
                    if (isSuccess)
                        return RedirectToAction("SwimmingPoolAction", "Amenities", new { id = (int)pool.PoolType });
                    else
                        return RedirectToAction("Error", "Home");
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CommonAmenitiesAction()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }


        [HttpGet]
        public async Task<IActionResult> CommonAmenitiesStatus(int id)
        {
            try
            {
                if (id == (int)AmenityType.CommonAmenitiesMen)
                {
                    AmenitiesResponse response = await _amenitiesService.GetAmenityAsync(AmenityType.CommonAmenitiesMen);
                    CommonAmenities commonAmenities = JsonSerializer.Deserialize<CommonAmenities>(response.Amenity.ToString());
                    return View(commonAmenities);
                }
                else
                {
                    AmenitiesResponse response = await _amenitiesService.GetAmenityAsync(AmenityType.CommonAmenitiesWomen);
                    CommonAmenities commonAmenities = JsonSerializer.Deserialize<CommonAmenities>(response.Amenity.ToString());
                    return View(commonAmenities);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }

        [AdminAuthorizationFilter]
        [HttpGet]
        public async Task<IActionResult> CommonAmenitiesStatusEdit(int id)
        {
            try
            {
                if(id == (int)AmenityType.CommonAmenitiesMen)
                {
                    AmenitiesResponse response = await _amenitiesService.GetAmenityAsync(AmenityType.CommonAmenitiesMen);
                    CommonAmenities amenity = JsonSerializer.Deserialize<CommonAmenities>(response.Amenity.ToString());
                    return View(amenity);
                }
                else
                {
                    AmenitiesResponse response = await _amenitiesService.GetAmenityAsync(AmenityType.CommonAmenitiesWomen);
                    CommonAmenities amenity = JsonSerializer.Deserialize<CommonAmenities>(response.Amenity.ToString());
                    return View(amenity);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }


        [AdminAuthorizationFilter]
        [HttpPost]
        public async Task<IActionResult> CommonAmenitiesStatusEdit(CommonAmenities amenities)
        {
            try
            {
                if (amenities.AmenityType == AmenityType.CommonAmenitiesMen)
                {
                    AmenitiesResponse response = new AmenitiesResponse()
                    {
                        Type = AmenityType.CommonAmenitiesMen,
                        Amenity = amenities
                    };

                    bool isSuccess = await _amenitiesService.PutAmenityAsync(response);
                    if (isSuccess)
                        return RedirectToAction("CommonAmenitiesStatus", "Amenities", 
                            new { id = (int)AmenityType.CommonAmenitiesMen });
                    else
                        return RedirectToAction("Error", "Home");
                }
                else
                {
                    AmenitiesResponse response = new AmenitiesResponse()
                    {
                        Type = AmenityType.CommonAmenitiesWomen,
                        Amenity = amenities
                    };

                    bool isSuccess = await _amenitiesService.PutAmenityAsync(response);
                    if (isSuccess)
                        return RedirectToAction("CommonAmenitiesStatus", "Amenities", 
                            new { id = (int)AmenityType.CommonAmenitiesWomen});
                    else
                        return RedirectToAction("Error", "Home");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }

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

                    case MaintenanceLogType.SwimmingPoolIndoor:
                        maintenanceLogs = await _maintenanceLogService
                    .GetMaintenanceLogsAsync(MaintenanceLogType.SwimmingPoolIndoor, lastId);
                        if (maintenanceLogs == null)
                            maintenanceLogs = new List<MaintenanceLog>();
                        return View(maintenanceLogs);
                        break;
                    case MaintenanceLogType.SwimmingPoolOutdoor:
                        maintenanceLogs = await _maintenanceLogService
                    .GetMaintenanceLogsAsync(MaintenanceLogType.SwimmingPoolOutdoor, lastId);
                        if (maintenanceLogs == null)
                            maintenanceLogs = new List<MaintenanceLog>();
                        return View(maintenanceLogs);
                        break;
                    case MaintenanceLogType.CommonAmenitiesMen:
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
                    case MaintenanceLogType.SwimmingPoolIndoor:
                        bool isSuccessIndoor = await _maintenanceLogService
                                    .PostMaintenanceLogsAsync(MaintenanceLogType.SwimmingPoolIndoor, log);
                        if (isSuccessIndoor)
                            return RedirectToAction("GenericMaintenanceLog", "Amenities", new
                            {
                                id = 0,
                                type = (int)logType
                            });
                        else
                            return RedirectToAction("Error", "Home");
                        break;
                    case MaintenanceLogType.SwimmingPoolOutdoor:
                        bool isSuccessOutdoor = await _maintenanceLogService
                                    .PostMaintenanceLogsAsync(MaintenanceLogType.SwimmingPoolOutdoor, log);
                        if (isSuccessOutdoor)
                            return RedirectToAction("GenericMaintenanceLog", "Amenities", new
                            {
                                id = 0,
                                type = (int)logType
                            });
                        else
                            return RedirectToAction("Error", "Home");
                        break;
                    case MaintenanceLogType.CommonAmenitiesMen:
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
