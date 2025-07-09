using System.Text;
using System.Text.Json;
using Common;
using SocietyManagementShowcase.Models;
using static System.Net.Mime.MediaTypeNames;

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

        public async Task<bool> PutAmenityAsync(AmenitiesResponse response)
        {
            try
            {
                var responseJson = new StringContent(
                        JsonSerializer.Serialize(response),
                        Encoding.UTF8,
                        Application.Json);

                var httpResponseMessage = await _httpClient.PutAsync($"/api/Amenities/{response.Type}", responseJson);
                var jsonResponse = httpResponseMessage.Content.ReadAsStringAsync();
                httpResponseMessage.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }

        }
    }
}
