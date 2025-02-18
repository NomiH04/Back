using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        // URL base de la API (ajusta la URL según tu API)
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/Category";

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        // ✅ 1. Obtener todos los usuarios (GET)
        public async Task<List<User>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>(BaseUrl);
        }

        // ✅ 2. Obtener un usuario por ID (GET)
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"{BaseUrl}/{id}");
        }

        // ✅ 3. Crear un nuevo usuario (POST)
        public async Task<bool> CreateUserAsync(User user)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, user);
            return response.IsSuccessStatusCode;
        }

        // ✅ 4. Actualizar un usuario (PUT)
        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            var response = await _httpClient.PatchAsJsonAsync($"{BaseUrl}/{id}", user);
            return response.IsSuccessStatusCode;
        }

        // ✅ 5. Eliminar un usuario (DELETE)
        public async Task<bool> DeleteUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
        // ✅ 6. Autenticación de usuario (POST a /login)
        public async Task<User> AuthenticateUserAsync(string email, string password)
        {
            var loginData = new { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/login", loginData);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<User>();

            return null;
        }
    }
}
