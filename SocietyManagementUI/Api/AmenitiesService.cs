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

        public async Task<Gym> GetAmenityAsync(AmenityType type)
        {

            try
            {
                var httpResponseMessage = await _httpClient.GetAsync($"/api/Amenities/{type}");
                var jsonResponse = httpResponseMessage.Content.ReadAsStringAsync();
                AmenitiesResponse response = JsonSerializer.Deserialize<AmenitiesResponse>(jsonResponse.Result.ToString());
                
                Gym gym = JsonSerializer.Deserialize<Gym>(response.Amenity.ToString());
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
