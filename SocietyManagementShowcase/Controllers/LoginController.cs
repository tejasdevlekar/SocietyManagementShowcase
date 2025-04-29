using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.IRepository;
using SocietyManagementShowcase.Models;
using SocietyManagementShowcase.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocietyManagementShowcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUserRepo _userRepo;

        public LoginController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public User Get()
        {
            return new User() { Id =1, Password="Test", PersonId=1, Username="Test"};
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<string[]> Post([FromBody] User value)
        {
            bool result = await _userRepo.VerifyUser(value);
            if (result) return new string[] { "status", "user verified"}.ToArray();
            else return new string[] { "status", "user not verified or user not found" }.ToArray();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
