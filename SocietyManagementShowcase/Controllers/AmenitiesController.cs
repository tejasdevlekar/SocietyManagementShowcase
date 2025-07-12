using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [HttpGet]
        public async Task<IActionResult> Get(AmenityType type)
        {
            try
            {
                AmenitiesResponse response = new AmenitiesResponse();
                response = await _amenitiesRepo.GetAmenityInfoAsync(type);
                if (response != null)
                {   
                    return new OkObjectResult(JsonSerializer.Serialize(response));
                }
                else
                {
                    var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        ReasonPhrase = "Gym not found"
                    };

                    return new NotFoundObjectResult(errorResponse);
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

        // PUT api/<AmenitiesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] AmenitiesResponse value)
        {
            try
            {
                
                if (value == null) {
                    var someResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        ReasonPhrase = "Amenity not found"
                    };

                    return new BadRequestObjectResult(someResponse);
                }
                

                switch (value.Type)
                {
                    case AmenityType.Gym:
                        bool isSuccess = await _amenitiesRepo.UpdateAmenityInfoAsync(AmenityType.Gym, value);
                        //if result return success HttpResponse
                        if (isSuccess)
                            return Ok();
                        else
                            return BadRequest();
                            break;
                    case AmenityType.SwimmingPoolOutdoor:
                        break;
                    case AmenityType.SwimmingPoolIndoor:
                        break;
                    case AmenityType.CommonAmenitiesMen:
                        break;
                    case AmenityType.CommonAmenitiesWomen:
                        break;
                    default:
                        break;
                }

                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "Amenity not found"
                };

                return new BadRequestObjectResult(errorResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "Amenity not found"
                };

                return new BadRequestObjectResult(errorResponse);
            }
        }

        //// DELETE api/<AmenitiesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
