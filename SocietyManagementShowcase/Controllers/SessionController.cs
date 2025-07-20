using Common.Common;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.IRepository;

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
        public async Task<IEnumerable<string>> Get(string sessionKey)
        {
            Request.Headers.TryGetValue(Login.SESSIONID, out var value);
            string sessionId = value;

            MySessionModel sessionModel = await _sessionRepo.GetSession(sessionId);
            MySession session = new MySession();
            session.SetSession(sessionModel.Value);

            var sessionValue = session.Get(sessionKey);

            return new string[] { "value1", "value2" };
        }

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

        //// DELETE api/<SessionController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
