using System.Net;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.IRepository;
using SocietyManagementShowcase.Models;
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
        public async Task<IActionResult> GetMaintenanceLog(MaintenanceLogType type)
        {
            try
            {
                List<MaintenanceLog> maintenanceLogs = new List<MaintenanceLog>();
                maintenanceLogs = await _maintenanceRepo.GetMaintenanceLogAsync(type);
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

        //// POST api/<MaintenanceLogController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<MaintenanceLogController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MaintenanceLogController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
