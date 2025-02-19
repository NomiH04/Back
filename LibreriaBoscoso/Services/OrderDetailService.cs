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
    public class OrderDetailService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/OrderDetail"; // Ajusta la URL según tu API

        public OrderDetailService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todos los detalles de las órdenes con manejo de errores
        public async Task<List<OrderDetail>> GetOrderDetailsAsync()
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

                // Intentar deserializar como una lista de detalles de órdenes directamente
                try
                {
                    var orderDetails = JsonSerializer.Deserialize<List<OrderDetail>>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (orderDetails != null && orderDetails.Count > 0)
                    {
                        return orderDetails;
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("El JSON no es una lista directa de detalles de órdenes.");
                }

                // Si no funcionó, intentar deserializar como objeto con una propiedad raíz
                try
                {
                    var orderDetailResponse = JsonSerializer.Deserialize<OrderDetailResponse>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (orderDetailResponse?.OrderDetails != null && orderDetailResponse.OrderDetails.Count > 0)
                    {
                        return orderDetailResponse.OrderDetails;
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("El JSON tampoco coincide con un objeto raíz esperado.");
                }

                throw new Exception("No se encontraron detalles de órdenes o el formato del JSON es incorrecto.");
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
                throw new Exception("Error al obtener los detalles de las órdenes: " + ex.Message);
            }
        }

        // Clase para manejar respuestas con un objeto raíz
        public class OrderDetailResponse
        {
            [JsonPropertyName("orderDetails")]
            public List<OrderDetail> OrderDetails { get; set; }
        }

        //Metodo para registrar detalle de pedidos
        public async Task<bool> RegistrarDetallePedidoAsync(OrderDetail detallePedido)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(BaseUrl, detallePedido);

                if (response.IsSuccessStatusCode)
                {
                    return true; // Éxito en la operación
                }
                else
                {
                    Console.WriteLine($"Error al registrar detalle del pedido: {response.ReasonPhrase}");
                    return false; // Fallo en la operación
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado en RegistrarDetallePedidoAsync: {ex.Message}");
                return false;
            }
        }
    }
}
