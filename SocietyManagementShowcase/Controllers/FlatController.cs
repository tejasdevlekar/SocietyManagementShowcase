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
    public class FlatController : ControllerBase
    {
        private readonly ILogger<MaintenanceLogController> _logger;
        private readonly IFlatRepo _flatRepo;
        public FlatController(ILogger<MaintenanceLogController> logger, IFlatRepo flatRepo)
        {
            _logger = logger;
            _flatRepo = flatRepo;
        }
        // GET: api/<FlatController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FlatController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Flat flat = await _flatRepo.GetFlatAsync(id);
                if (flat != null)
                {
                    return new OkObjectResult(JsonSerializer.Serialize(flat));
                }
                else
                {
                    var errorResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        ReasonPhrase = "Flat not found"
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
                return new BadRequestObjectResult(errorResponse);
            }
        }

        // POST api/<FlatController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Flat flat)
        {
            try
            {
                if (flat != null)
                {
                    bool isSuccess = await _flatRepo.AddFlatAsync(flat);
                    if (isSuccess)
                    {
                        return Ok();
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(flat));
                }
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

        //// PUT api/<FlatController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<FlatController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
