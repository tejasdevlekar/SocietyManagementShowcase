﻿using System.Text;
using System.Text.Json;
using Common;
using SocietyManagementShowcase.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SocietyManagementUI.Api
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7249/");

        }

        public async Task<string> PostLoginAsync(User user)
        {
            var userJson = new StringContent(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                Application.Json);

            var httpResponseMessage = await _httpClient.PostAsync("/api/Login/", userJson);
            var jsonResponse = httpResponseMessage.Content.ReadAsStringAsync();
            LoginResponse response = JsonSerializer.Deserialize<LoginResponse>(jsonResponse.Result.ToString());
            
            //var result = JsonSerializer.Deserialize<data>(jsonResponse);
            httpResponseMessage.EnsureSuccessStatusCode();
            
             return response.status;
        }
    }

    
}
