using Common.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace SocietyManagementUI.Api
{
    public class FlatService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FlatService> _logger;

        public FlatService(HttpClient httpClient, ILogger<FlatService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7249/");
            _logger = logger;
        }

        public async Task<bool> AddFlatAsync(Flat flat)
        {
            try
            {
                if (flat != null)
                {
                    var flatJson = new StringContent(
                       JsonSerializer.Serialize(flat),
                       Encoding.UTF8,
                       Application.Json);

                    string test = JsonSerializer.Serialize(flatJson);
                    var httpResponseMessage = await _httpClient.PostAsync("/api/Flat", flatJson);
                    httpResponseMessage.EnsureSuccessStatusCode();
                    return true;
                }
                else
                {
                    throw new ArgumentNullException(nameof(flat));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }


    }
}
