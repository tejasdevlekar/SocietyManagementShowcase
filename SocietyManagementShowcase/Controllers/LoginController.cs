using Common;
using Common.Common;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.IRepository;
using SocietyManagementShowcase.Repository;
using System.Collections;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocietyManagementShowcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly ISessionRepo _sessionRepo;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IUserRepo userRepo, ILogger<LoginController> logger, ISessionRepo sessionRepo)
        {
            _userRepo = userRepo;
            _logger = logger;
            _sessionRepo = sessionRepo;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public User Get()
        {
            return new User() { Id = 1, Password = "Test", PersonId = 1, Username = "Test" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User value)
         {
            try
            {
                User retrivedUser = await _userRepo.VerifyUser(value);
                if (retrivedUser != null)
                {
                    MySession session = new MySession(Login.USERID, retrivedUser.Username);
                    session.Set(Login.USERROLETYPE, retrivedUser.RoleType);

                    MySessionModel mySessionModel = new MySessionModel()
                    {
                        Id = Helper.GenerateRandomString(20),
                        Value = session.GetSessionData(),
                        ExpiresAtTime = DateTime.UtcNow.AddMinutes(20),
                        SlidingExpirationInSeconds = 300, 
                        AbsoluteExpiration = DateTime.UtcNow.AddMinutes(60)
                    };

                    await _sessionRepo.AddSession(mySessionModel);

                    Response.Headers.Add(Login.SESSIONID, mySessionModel.Id);
                    LoginResponse data = new LoginResponse()
                    {
                        status = true,
                        User = retrivedUser,
                    };
                    return new ObjectResult(JsonSerializer.Serialize(data));
                }
                else
                {
                    LoginResponse data = new LoginResponse()
                    {
                        status = false
                    };
                    return new ObjectResult(JsonSerializer.Serialize(data));
                }
            }
            catch (Exception ex)
            {
                var data = new { 
                    status = "Exception occurred", 
                    message = ex.ToString()
                };

                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"),
                    ReasonPhrase = "user not verified"
                };
                return new ObjectResult(errorResponse);
            }
        }

        //// POST api/<ValuesController>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] User value)
        //{
        //    bool result = await _userRepo.VerifyUser(value);
        //    if (result)
        //    {
        //        var successResponse = new HttpResponseMessage(HttpStatusCode.OK)
        //        {
        //            Content = new StringContent("\"status\":\"user verified\"", Encoding.UTF8, "application/json"),
        //            ReasonPhrase = "user verified"
        //        };
        //        return new ObjectResult(successResponse);
        //    }
        //    else
        //    {
        //        {
        //            var errorResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
        //            {
        //                Content = new StringContent("\"status\":\"user not verified\"", Encoding.UTF8, "application/json"),
        //                ReasonPhrase = "user not verified"
        //            };
        //            return new ObjectResult(errorResponse);
        //        }
        //    }
        //}

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
