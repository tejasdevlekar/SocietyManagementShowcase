using System.Text.Json;
using Common;
using SocietyManagementShowcase.Models;

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

        public async Task<List<MaintenanceLog>> GetMaintenanceLogsAsync(MaintenanceLogType type)
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync($"/api/MaintenanceLog/{type}");
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
    }
}
