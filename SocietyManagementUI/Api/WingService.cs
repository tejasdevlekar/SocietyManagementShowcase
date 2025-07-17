using Common.Models;
using System.Text.Json;

namespace SocietyManagementUI.Api
{
    public class WingService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WingService> _logger;

        public WingService(HttpClient httpClient, ILogger<WingService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7249/");
            _logger = logger;
        }


        public async Task<List<Wing>> GetWingIdAndNameAsync()
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync("/api/Wing");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    List<Wing> wings = JsonSerializer.Deserialize<List<Wing>>(jsonResponse);
                    return wings;
                }
                else
                {
                    _logger.LogError($"Failed to fetch wings: {httpResponseMessage.ReasonPhrase}");
                    return new List<Wing>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching wings.");
                return new List<Wing>();
            }
        }
    }
}
