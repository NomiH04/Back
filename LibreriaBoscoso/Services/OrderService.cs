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

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            try
            {
                //extrae el pedido por su id
                var response = await _httpClient.GetAsync($"{BaseUrl}/{orderId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Order>();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null; // Retorna null si la API devuelve 404
                }
                else
                {
                    throw new Exception($"Error en la API: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de conexión con la API.", ex);
            }
        }

        // Clase para manejar respuestas con un objeto raíz
        public class OrderResponse
        {
            [JsonPropertyName("orders")]
            public List<Order> Orders { get; set; }
        }

        //Metodo para registrar un pedido
        public async Task<int> RegistrarPedidoAsync(Order nuevoPedido)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(BaseUrl, nuevoPedido);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta (el ID del pedido creado)
                    int orderId = await response.Content.ReadFromJsonAsync<int>();
                    return orderId;
                }
                else
                {
                    Console.WriteLine($"Error al registrar pedido: {response.ReasonPhrase}");
                    return -1; // Devuelve -1 si hay un error
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado en RegistrarPedidoAsync: {ex.Message}");
                return -1;
            }
        }
    }
}
