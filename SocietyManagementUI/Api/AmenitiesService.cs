using System.Text.Json;
using Common;
using SocietyManagementShowcase.Models;

namespace SocietyManagementUI.Api
{
    public class AmenitiesService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<LoginService> _logger;

        public AmenitiesService(HttpClient httpClient, ILogger<LoginService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7249/");
            _logger = logger;
        }

        public async Task<Gym> GetGymAsync(int id)
        {

            try
            {
                var httpResponseMessage = await _httpClient.GetAsync($"/api/Amenities/{1}");
                var jsonResponse = httpResponseMessage.Content.ReadAsStringAsync();
                Gym gym = JsonSerializer.Deserialize<Gym>(jsonResponse.Result.ToString());

                return gym;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
