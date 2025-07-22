using Common.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.IRepository;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocietyManagementShowcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;
        private readonly ISessionRepo _sessionRepo;
        public SessionController(ILogger<SessionController> logger, ISessionRepo sessionRepo)
        {
            _logger = logger;
            _sessionRepo = sessionRepo;
        }
        // GET: api/<SessionController>
        [HttpGet]
        public async Task<IActionResult> Get(string sessionKey)
        {
            Request.Headers.TryGetValue(Login.SESSIONID, out var value);
            string sessionId = value;

            MySessionModel sessionModel = await _sessionRepo.GetSession(sessionId);
            MySession session = new MySession();
            session.SetSessionData(sessionModel.Value);

            var sessionValue = session.Get(sessionKey);


            return Ok(JsonSerializer.Serialize(sessionValue));
        }

        //// GET: api/<SessionController>
        //[HttpGet]
        //public async Task<IActionResult> Get()// Unauthorised session
        //{
        //    var data = new { 
        //        Message = "Unauthorised session. Please login again.",
        //    };

        //    return Unauthorized(JsonSerializer.Serialize(data));
        //}

        //// GET api/<SessionController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<SessionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //Post session then return session id
        }

        //// PUT api/<SessionController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<SessionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var data = new
            {
                Message = "Unauthorised session. Please login again.",
            };

            return Unauthorized(JsonSerializer.Serialize(data));
        }

    }
}
