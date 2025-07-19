using Common.Models;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementUI.Api;
using SocietyManagementUI.Filters;

namespace SocietyManagementUI.Controllers
{
    [LoginAuthenticationFilter]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly PersonService _personService;
        public PersonController(ILogger<PersonController> logger, PersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                List<Person> persons = await _personService.GetAllPersonsAsync(id);
                return View(persons);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Home");
            }
        }



    }
}
