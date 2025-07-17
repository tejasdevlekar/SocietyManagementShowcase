using Common.Models;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.IRepository;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocietyManagementShowcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WingController : ControllerBase
    {
        private readonly ILogger<MaintenanceLogController> _logger;
        private readonly IWingRepo _wingRepo;

        public WingController(ILogger<MaintenanceLogController> logger, IWingRepo wingRepo)
        {
            _logger = logger;
            _wingRepo = wingRepo;
        }

        // GET: api/<WingController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Wing> wings = await _wingRepo.GetWingIdAndNameAsync();
                if (wings.Count > 0)
                {
                    return new OkObjectResult(JsonSerializer.Serialize(wings));
                }

                return new NotFoundObjectResult(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    ReasonPhrase = "No wings found"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                var errorResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    ReasonPhrase = "An error occurred"
                };

                return new NotFoundObjectResult(errorResponse);
            }
        }

        //// GET api/<WingController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<WingController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<WingController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<WingController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
