﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
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

        // Método para crear un usuario, ahora con el DTO necesario
        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                // Creamos el DTO para la creación del usuario
                var userCreateDto = new UserCreateDto
                {
                    Name = user.Name,
                    Email = user.Email,
                    HashPassword = user.Pass,  // Usamos la contraseña proporcionada
                    Role = user.Role
                };

                // Para depurar, puedes imprimir el objeto userCreateDto
                Console.WriteLine("Enviando usuario: " + JsonSerializer.Serialize(userCreateDto));

                // Enviamos el DTO como JSON al servidor
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, userCreateDto);

                if (response.IsSuccessStatusCode)
                {
                    // Si la respuesta es exitosa, retornamos true
                    return true;
                }
                else
                {
                    // Si la respuesta no es exitosa, mostramos el error
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al crear el usuario: {response.StatusCode} - {errorResponse}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Capturamos cualquier excepción y la mostramos en el log
                Console.WriteLine($"Error al crear usuario: {ex.Message}");
                return false;
            }
        }

        // Método para obtener todos los usuarios
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

        // DTO para la creación de usuario, siguiendo el modelo de la API
        public class UserCreateDto
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string HashPassword { get; set; }
            public string Role { get; set; }
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            try
            {
                var user = await _httpClient.GetFromJsonAsync<User>($"{BaseUrl}/{userId}");

                if (user != null)
                {
                    Console.WriteLine($"Usuario encontrado: ID={user.UserId}");
                    return user;
                }
                else
                {
                    Console.WriteLine($"No se encontró el usuario con ID {userId}.");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return null;
            }
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Usuario con ID {id} eliminado correctamente.");
                    return true;
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al eliminar el usuario: {response.StatusCode} - {errorResponse}");
                    return false;
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error HTTP al eliminar el usuario: {httpEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado al eliminar el usuario: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            try
            {
                Console.WriteLine($"Intentando actualizar usuario en: {BaseUrl}/{id}");
                Console.WriteLine($"Datos enviados: {JsonSerializer.Serialize(user)}");

                // Crear el contenido de la solicitud PATCH
                var jsonContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{BaseUrl}/{id}")
                {
                    Content = jsonContent
                };

                // Enviar la solicitud
                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"✅ Usuario con ID {id} actualizado correctamente.");
                    return true;
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"❌ Error al actualizar el usuario: {response.StatusCode} - {errorResponse}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error en UpdateUserAsync: {ex.Message}");
                return false;
            }
        }




    }
}
