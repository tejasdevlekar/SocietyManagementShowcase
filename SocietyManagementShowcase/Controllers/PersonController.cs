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
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepo _personRepo;
        public PersonController(ILogger<PersonController> logger, IPersonRepo personRepo)
        {
            _logger = logger;
            _personRepo = personRepo;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<IActionResult> Get(string firstId)
        {
            try
            {
                List<Person> persons = await _personRepo.GetAllPersonsAsync(Convert.ToInt32(firstId));
                return Ok(JsonSerializer.Serialize(persons));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting persons");
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                { 
                    ReasonPhrase = "Error getting persons"
                };

                return new NotFoundObjectResult(errorResponse);

            }

        }

        //// GET api/<PersonController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PersonController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PersonController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PersonController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
