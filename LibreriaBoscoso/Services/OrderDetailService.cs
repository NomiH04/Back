using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class OrderDetailService
    {
        private readonly HttpClient _httpClient;

        // URL base de la API para los detalles de la orden (ajusta la URL según tu API)
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/OrderDetail"; // Cambia esta URL según tu API

        public OrderDetailService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todos los detalles de las órdenes
        public async Task<List<OrderDetail>> GetOrderDetailsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<OrderDetail>>(BaseUrl);
        }

        // Obtener los detalles de una orden específica
        public async Task<List<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _httpClient.GetFromJsonAsync<List<OrderDetail>>($"{BaseUrl}/{orderId}");
        }

        // Crear un nuevo detalle de orden
        public async Task<bool> CreateOrderDetailAsync(OrderDetail orderDetail)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, orderDetail);
            return response.IsSuccessStatusCode;
        }

        // Eliminar un detalle de orden
        public async Task<bool> DeleteOrderDetailAsync(int orderId, int bookId)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{orderId}/{bookId}");
            return response.IsSuccessStatusCode;
        }
    }
}
