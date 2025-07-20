using System.Text;
using System.Text.Json;
using Common;
using Common.Common;
using Common.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SocietyManagementUI.Api
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<LoginService> _logger;

        public LoginService(HttpClient httpClient, ILogger<LoginService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7249/");
            _logger = logger;
        }

        public async Task<LoginResponse> PostLoginAsync(User user)
        {
            var userJson = new StringContent(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                Application.Json);

            var httpResponseMessage = await _httpClient.PostAsync("/api/Login/", userJson);
            var sessionId = httpResponseMessage.Headers.GetValues(Login.SESSIONID);
            var jsonResponse = httpResponseMessage.Content.ReadAsStringAsync();
            LoginResponse response = JsonSerializer.Deserialize<LoginResponse>(jsonResponse.Result.ToString());
            response.SessionId = sessionId.FirstOrDefault();

            //var result = JsonSerializer.Deserialize<data>(jsonResponse);
            httpResponseMessage.EnsureSuccessStatusCode();
            
             return response;
        }
    }

    
}
