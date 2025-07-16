using Common.Models;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.IRepository;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocietyManagementShowcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDatabaseController : ControllerBase
    {
        private readonly ILogger<MaintenanceLogController> _logger;
        private readonly ISeedDatabaseRepo _seedDatabaseRepo;

        public SeedDatabaseController(ISeedDatabaseRepo seedDatabaseRepo, ILogger<MaintenanceLogController> logger)
        {
            _seedDatabaseRepo = seedDatabaseRepo;
            _logger = logger;
        }

        // GET: api/<SeedDatabaseController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Society society = await _seedDatabaseRepo.SeedDatabaseAsync();
                if (society != null)
                {
                    return new OkObjectResult(society);
                }
                else
                {
                    var errorResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        ReasonPhrase = "No data found"
                    };
                    return new NotFoundObjectResult(errorResponse);
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

        //// GET api/<SeedDatabaseController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<SeedDatabaseController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SeedDatabaseController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SeedDatabaseController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
