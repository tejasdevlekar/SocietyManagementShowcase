using System.Net;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.IRepository;
using SocietyManagementShowcase.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocietyManagementShowcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUserController : ControllerBase
    {
        IUserRepo _userRepo;

        public AddUserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        // GET: api/<AddUserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AddUserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddUserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                bool result = await _userRepo.AddUserAsync(user);

                if(result)
                {
                    LoginResponse data = new LoginResponse()
                    {
                        status = true
                    };
                    return new JsonResult(data);
                }
                else
                {
                    LoginResponse data = new LoginResponse()
                    {
                        status = false
                    };
                    return new JsonResult(data);
                }
            }
            catch (Exception ex)
            {
                var data = new
                {
                    status = "Exception occurred",
                    message = ex.ToString()
                };

                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"),
                    ReasonPhrase = "user not added"
                };
                return new ObjectResult(errorResponse);
            }
        }

        // PUT api/<AddUserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddUserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
