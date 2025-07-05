using Common;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;
using SocietyManagementShowcase.Models;

namespace SocietyManagementUI.Api
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7249/");

        }

        public async Task<List<User>> GetAllUserAsync()
        {
            var httpResponseMessage = await _httpClient.GetAsync("/api/AddUser/");
            var jsonResponse = httpResponseMessage.Content.ReadAsStringAsync();
            
            List<User> users = JsonSerializer.Deserialize<List<User>>(jsonResponse.Result.ToString());

            return users;
        }
        public async Task<bool> AddUserAsync(User user)
        {
            var userJson = new StringContent(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                Application.Json);

            var httpResponseMessage = await _httpClient.PostAsync("/api/AddUser/", userJson);
            var jsonResponse = httpResponseMessage.Content.ReadAsStringAsync();
            LoginResponse response = JsonSerializer.Deserialize<LoginResponse>(jsonResponse.Result.ToString());

            //var result = JsonSerializer.Deserialize<data>(jsonResponse);
            httpResponseMessage.EnsureSuccessStatusCode();

            return response.status;
        }

        public async Task<User> FetchUserAsync(int id)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"/api/AddUser/{id}");
            var jsonResponse = httpResponseMessage.Content.ReadAsStringAsync();

            User user = JsonSerializer.Deserialize<User>(jsonResponse.Result.ToString());

            return user;
        }
        public async Task<bool> EditUserAsync(int id, User user)
        {
            var userJson = new StringContent(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                Application.Json);

            var httpResponseMessage = await _httpClient.PutAsync($"/api/AddUser/{id}", userJson);

            var jsonResponse = httpResponseMessage.Content.ReadAsStringAsync();
            CommonResponse response = JsonSerializer.Deserialize<CommonResponse>(jsonResponse.Result.ToString());

            //var result = JsonSerializer.Deserialize<data>(jsonResponse);
            httpResponseMessage.EnsureSuccessStatusCode();

            return response.isSuccess;

        }


    }
}
