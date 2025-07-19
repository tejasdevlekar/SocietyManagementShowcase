using Common.Models;
using System.Text.Json;

namespace SocietyManagementUI.Api
{
    public class PersonService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PersonService> _logger;

        public PersonService(HttpClient httpClient, ILogger<PersonService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7249/");
            _logger = logger;
        }

        public async Task<List<Person>> GetAllPersonsAsync(int firstId)
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync($"/api/Person?firstId={firstId}");
                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                List<Person> persons = JsonSerializer.Deserialize<List<Person>>(jsonResponse);
                return persons;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new List<Person>();
            }
        }




    }
}
