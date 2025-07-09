using System.Text;
using System.Text.Json;
using Common;
using SocietyManagementShowcase.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SocietyManagementUI.Api
{
    public class MaintenanceLogService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MaintenanceLogService> _logger;

        public MaintenanceLogService(HttpClient httpClient, ILogger<MaintenanceLogService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7249/");
            _logger = logger;
        }

        public async Task<List<MaintenanceLog>> GetMaintenanceLogsAsync(MaintenanceLogType type, int lastId)
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync($"/api/MaintenanceLog/{type}?lastId={lastId}");
                var jsonResponse = httpResponseMessage.Content.ReadAsStringAsync();
                List<MaintenanceLog> maintenanceLogs = 
                    JsonSerializer.Deserialize<List<MaintenanceLog>>(jsonResponse.Result.ToString());
                return maintenanceLogs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<bool> PostMaintenanceLogsAsync(MaintenanceLogType type, MaintenanceLog log)
        {
            try
            {
                var logJson = new StringContent(
                        JsonSerializer.Serialize(log),
                        Encoding.UTF8,
                        Application.Json);

                var httpResponseMessage = await _httpClient.PostAsync($"/api/MaintenanceLog?type={type}", logJson);
                var message = httpResponseMessage.EnsureSuccessStatusCode();
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
