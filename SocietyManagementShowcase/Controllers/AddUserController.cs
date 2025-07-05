using System.Net;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementShowcase.IRepository;
using SocietyManagementShowcase.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Azure.Core;
using Azure.Messaging;
using Azure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocietyManagementShowcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUserController : ControllerBase
    {
        IUserRepo _userRepo;
        private readonly ILogger<AddUserController> _logger;


        public AddUserController(IUserRepo userRepo, ILogger<AddUserController> logger)
        {
            _userRepo = userRepo;
            _logger = logger;
        }

        // GET: api/<AddUserController>
        [HttpGet]
        public async Task<string> Get()
        {
            return JsonSerializer.Serialize(await _userRepo.GetAllUsersAsync());
        }

        // GET api/<AddUserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                User retrievedUser = await _userRepo.FetchUserAsync(id);

                string jsonResponse = JsonSerializer.Serialize(retrievedUser);

                return new ObjectResult(jsonResponse);
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
                    ReasonPhrase = "user not added"
                };
                return new ObjectResult(errorResponse);
            }
            
        }

        // POST api/<AddUserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                bool result = await _userRepo.AddUserAsync(user);

                if (result)
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
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            try
            {
                bool result = await _userRepo.EditUserAsync(id, user);
                if (result)
                {

                    CommonResponse response = new CommonResponse() { 
                        Message = "User updated successfully",
                        isSuccess = true
                    };
                    
                    return new ObjectResult(JsonSerializer.Serialize(response));
                    //return response;
                }
                else
                {
                    CommonResponse response = new CommonResponse()
                    {
                        Message = "User not updated",
                        isSuccess = true
                    };

                    return new ObjectResult(JsonSerializer.Serialize(response));

                    //return response;
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return null;
            }
        }

        // DELETE api/<AddUserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isDeleted = await _userRepo.DeleteUserAsync(id);
                if (isDeleted)
                {
                    var successResponse = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent("User has been deleted", Encoding.UTF8, "application/json"),
                        ReasonPhrase = "user not added"
                    };
                    return new ObjectResult(successResponse);
                }
                else
                {
                    var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("User not deleted",Encoding.UTF8, "application/json"),
                        ReasonPhrase = "User not deleted"
                    };
                    return new ObjectResult(errorResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("User not deleted", Encoding.UTF8, "application/json"),
                    ReasonPhrase = "User not deleted"
                };
                return new ObjectResult(errorResponse);
            }
        }
    }
}
