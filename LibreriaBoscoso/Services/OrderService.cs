using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;

        // URL base de la API para las órdenes (ajusta la URL según tu API)
        private const string BaseUrl = "https://localhost:7021/api/Order"; // Cambia la URL según la de tu API

        public OrderService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todas las órdenes
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Order>>(BaseUrl);
        }

        // Obtener una orden por ID
        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _httpClient.GetFromJsonAsync<Order>($"{BaseUrl}/{orderId}");
        }

        // Crear una nueva orden (POST)
        public async Task<bool> CreateOrderAsync(Order order)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, order);
            return response.IsSuccessStatusCode;
        }

        // Actualizar una orden (PUT)
        public async Task<bool> UpdateOrderAsync(int orderId, Order order)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{orderId}", order);  // Usamos PUT para reemplazar la orden
            return response.IsSuccessStatusCode;
        }

        // Eliminar una orden (DELETE)
        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{orderId}");
            return response.IsSuccessStatusCode;
        }
    }
}
