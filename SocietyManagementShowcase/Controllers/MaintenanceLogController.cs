using System.Net;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.IRepository;
using Common.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Http.HttpResults;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocietyManagementShowcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceLogController : ControllerBase
    {
        private readonly ILogger<MaintenanceLogController> _logger;
        private readonly IMaintenanceRepo _maintenanceRepo;

        public MaintenanceLogController(IMaintenanceRepo maintenanceRepo, ILogger<MaintenanceLogController> logger)
        {
            _maintenanceRepo = maintenanceRepo;
            _logger = logger;
        }
        //// GET: api/<MaintenanceLogController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<MaintenanceLogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaintenanceLog(MaintenanceLogType type, int lastId)
        {
            try
            {
                List<MaintenanceLog> maintenanceLogs = new List<MaintenanceLog>();
                maintenanceLogs = await _maintenanceRepo.GetMaintenanceLogAsync(type, lastId);
                if (maintenanceLogs.Count > 0)
                {
                    return new OkObjectResult(JsonSerializer.Serialize(maintenanceLogs));
                }
                else
                {
                    var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        ReasonPhrase = "No maintenance log found"
                    };

                    return new ObjectResult(errorResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "An error occurred"
                };

                return new ObjectResult(errorResponse);
            }

        }

        // POST api/<MaintenanceLogController>
        [HttpPost]
        public async Task<IActionResult> PostMaintenanceLog(MaintenanceLogType type, [FromBody] MaintenanceLog log)
        {
            try
            {
                bool isSuccess = await _maintenanceRepo.PostMaintenanceLogAsync(type, log);
                if (isSuccess)
                {
                    return Ok();
                }
                else
                    return Unauthorized();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "An error occurred"
                };
                return new BadRequestObjectResult(errorResponse);
            }
        }

        // PUT api/<MaintenanceLogController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MaintenanceLog value)
        {
            try
            {
                bool isSuccess = await _maintenanceRepo.EditMaintenanceLogAsync(value);
                if (isSuccess)
                    return Ok();
                else
                    return Unauthorized();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "An error occurred"
                };
                return new BadRequestObjectResult(errorResponse);
            }
        }

        //// DELETE api/<MaintenanceLogController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
