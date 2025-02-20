using System;
using System.Collections.Generic;
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
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/Category"; // URL pública de la API

        public CategoryService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todas las categorías con manejo de errores
        public async Task<List<Category>> GetCategoriesAsync()
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
                    var categorias = JsonSerializer.Deserialize<List<Category>>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (categorias != null && categorias.Count > 0)
                    {
                        return categorias;
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("El JSON no es una lista directa de categorías.");
                }

                try
                {
                    var categoryResponse = JsonSerializer.Deserialize<CategoryResponse>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (categoryResponse?.Categories != null && categoryResponse.Categories.Count > 0)
                    {
                        return categoryResponse.Categories;
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("El JSON tampoco coincide con un objeto raíz esperado.");
                }

                throw new Exception("No se encontraron categorías o el formato del JSON es incorrecto.");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de solicitud HTTP: " + ex.Message);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error al procesar JSON: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las categorías: " + ex.Message);
            }
        }

        // Agregar una nueva categoría
        public async Task<bool> AddCategoryAsync(Category category)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(category);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(BaseUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error al agregar categoría: {response.StatusCode}");
                    return false;
                }

                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error de solicitud HTTP: " + ex.Message);
                return false;
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error al procesar JSON: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar la categoría: " + ex.Message);
                return false;
            }
        }

        // Clase para manejar respuestas con un objeto raíz
        public class CategoryResponse
        {
            [JsonPropertyName("categories")]
            public List<Category> Categories { get; set; }
        }

        // Eliminar una categoría por ID
        public async Task DeleteCategoryAsync(int categoryId)
        {
            try
            {
                var url = $"{BaseUrl}/{categoryId}"; // URL con el ID de la categoría
                var response = await _httpClient.DeleteAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al eliminar la categoría: {response.StatusCode}");
                }

                Console.WriteLine($"Categoría con ID {categoryId} eliminada correctamente.");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de solicitud HTTP: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la categoría: " + ex.Message);
            }
        }

        // Método para actualizar una categoría
        public async Task<bool> UpdateCategoryAsync(Category updatedCategory)
        {
            try
            {
                // Serializar la categoría a JSON
                var jsonContent = JsonSerializer.Serialize(updatedCategory);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Crear la solicitud PATCH utilizando la URL como Uri y el método PATCH
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), new Uri($"{BaseUrl}/{updatedCategory.CategoryId}"))
                {
                    Content = content
                };

                // Enviar la solicitud PATCH a la API
                var response = await _httpClient.SendAsync(request);

                // Verificar si la respuesta es exitosa
                if (response.IsSuccessStatusCode)
                {
                    return true;  // La categoría se actualizó correctamente
                }
                else
                {
                    // Manejo de errores si la respuesta no fue exitosa
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al actualizar la categoría: {errorMessage}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Capturar excepciones y mostrar un mensaje de error
                MessageBox.Show($"Error al actualizar la categoría: {ex.Message}");
                return false;
            }
        }


    }
}
