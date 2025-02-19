using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/Category"; // Ajustada la URL pública de la API

        public CategoryService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todas las categorías con manejo de errores
        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                // Hacer la solicitud GET
                var response = await _httpClient.GetAsync(BaseUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}");
                }

                // Obtener el JSON en formato string
                var jsonString = await response.Content.ReadAsStringAsync();

                // Imprimir JSON recibido para depuración
                Console.WriteLine("JSON recibido desde la API:\n" + jsonString);

                // Intentar deserializar como una lista de categorías directamente
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

                // Si no funcionó, intentar deserializar como objeto con una propiedad raíz
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

        // Clase para manejar respuestas con un objeto raíz
        public class CategoryResponse
        {
            [JsonPropertyName("categories")]
            public List<Category> Categories { get; set; }
        }
    }
}
