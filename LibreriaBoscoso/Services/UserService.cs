﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/User";

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                Console.WriteLine("Enviando usuario: " + JsonSerializer.Serialize(user));

                var response = await _httpClient.PostAsJsonAsync(BaseUrl, user);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al crear el usuario: {response.StatusCode} - {errorResponse}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear usuario: {ex.Message}");
                return false;
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<User>($"{BaseUrl}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener usuario por ID: {ex.Message}");
                return null;
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("JSON recibido desde la API:\n" + jsonString);

                try
                {
                    var users = JsonSerializer.Deserialize<List<User>>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (users != null && users.Count > 0)
                    {
                        return users;
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("El JSON no es una lista directa de usuarios.");
                }

                try
                {
                    var userResponse = JsonSerializer.Deserialize<UserResponse>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (userResponse?.Users != null && userResponse.Users.Count > 0)
                    {
                        return userResponse.Users;
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("El JSON tampoco coincide con un objeto raíz esperado.");
                }

                throw new Exception("No se encontraron usuarios o el formato del JSON es incorrecto.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios: " + ex.Message);
            }
        }

        public class UserResponse
        {
            [JsonPropertyName("users")]
            public List<User> Users { get; set; }
        }
        // Método para obtener el ID de un usuario por su nombre
        public async Task<int> GetUserId(string username)
        {
            try
            {
                int? userId = await _httpClient.GetFromJsonAsync<int?>($"{BaseUrl}/GetUserId/{username}");
                return userId ?? -1;  // Retorna -1 si no se encuentra
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el ID del usuario: {ex.Message}");
                return -1; // En caso de error, retorna -1
            }
        }

    }
}
