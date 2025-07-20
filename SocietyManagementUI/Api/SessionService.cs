using Common;
using Common.Common;
using Common.Models;

namespace SocietyManagementUI.Api
{
    public class SessionService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SessionService> _logger;

        public SessionService(HttpClient httpClient, ILogger<SessionService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7249/");
            _logger = logger;
        }


        public async Task GetSessionKey(string sessionId)
        {
            _httpClient.DefaultRequestHeaders.Add(Login.SESSIONID, sessionId);
            var httpResponseMessage = await _httpClient.GetAsync($"/api/Session?sessionKey={Login.USERID}");
            var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
