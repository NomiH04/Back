using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/Order"; // Ajusta esta URL según tu API

        public OrderService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todos los pedidos con manejo de errores
        public async Task<List<Order>> GetOrdersAsync()
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

                // Intentar deserializar como una lista de pedidos directamente
                try
                {
                    var orders = JsonSerializer.Deserialize<List<Order>>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (orders != null && orders.Count > 0)
                    {
                        return orders;
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("El JSON no es una lista directa de pedidos.");
                }

                // Si no funcionó, intentar deserializar como objeto con una propiedad raíz
                try
                {
                    var orderResponse = JsonSerializer.Deserialize<OrderResponse>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (orderResponse?.Orders != null && orderResponse.Orders.Count > 0)
                    {
                        return orderResponse.Orders;
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("El JSON tampoco coincide con un objeto raíz esperado.");
                }

                throw new Exception("No se encontraron pedidos o el formato del JSON es incorrecto.");
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
                throw new Exception("Error al obtener los pedidos: " + ex.Message);
            }
        }

        // Clase para manejar respuestas con un objeto raíz
        public class OrderResponse
        {
            [JsonPropertyName("orders")]
            public List<Order> Orders { get; set; }
        }
    }
}
