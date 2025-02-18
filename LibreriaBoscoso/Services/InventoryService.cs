using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class InventoryService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/Inventory"; // Ajusta la URL de tu API

        public InventoryService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todo el inventario con manejo de errores
        public async Task<List<Inventory>> GetInventoryAsync()
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

                // Intentar deserializar como un objeto raíz que contiene la lista de inventarios
                try
                {
                    var inventoryResponse = JsonSerializer.Deserialize<JsonElement>(jsonString);
                    var inventoryArray = inventoryResponse.GetProperty("inventory");

                    var inventories = JsonSerializer.Deserialize<List<Inventory>>(inventoryArray.ToString(), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (inventories != null && inventories.Count > 0)
                    {
                        return inventories;
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error al deserializar el JSON: " + ex.Message);
                }

                throw new Exception("No se encontraron inventarios o el formato del JSON es incorrecto.");
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
                throw new Exception("Error al obtener el inventario: " + ex.Message);
            }
        }

        // Clase para manejar respuestas con un objeto raíz
        public class InventoryResponse
        {
            [JsonPropertyName("inventory")]
            public List<Inventory> Inventories { get; set; }
        }
    }
}
