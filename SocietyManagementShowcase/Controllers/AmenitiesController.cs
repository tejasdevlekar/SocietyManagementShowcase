using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.IRepository;
using SocietyManagementShowcase.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocietyManagementShowcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenitiesRepo _amenitiesRepo;
        private readonly ILogger<AmenitiesController> _logger;

        public AmenitiesController(IAmenitiesRepo amenitiesRepo, ILogger<AmenitiesController> logger)
        {
            _amenitiesRepo = amenitiesRepo;
            _logger = logger;
        }

        //// GET: api/<AmenitiesController>
        //[HttpGet]
        //public async Task<IEnumerable<IActionResult>> Get()
        //{
            
        //}

        // GET api/<AmenitiesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(AmenityType type)
        {
            try
            {
                AmenitiesResponse response = new AmenitiesResponse();
                Gym gym = await _amenitiesRepo.GetAmenityInfoAsync(type);
                if(gym != null)
                {
                    response.Type = AmenityType.Gym;
                    response.Amenity = gym;
                    return new ObjectResult(JsonSerializer.Serialize(response));
                }
                else
                {
                    var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent(JsonSerializer.Serialize(gym), Encoding.UTF8, "application/json"),
                        ReasonPhrase = "Gym not found"
                    };

                    return new ObjectResult(errorResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                var data = new
                {
                    status = "Exception occurred",
                    message = ex.ToString()
                };

                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"),
                    ReasonPhrase = "Gym not found"
                };

                return new ObjectResult(errorResponse);
            }
        }

        //// POST api/<AmenitiesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<AmenitiesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AmenitiesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
