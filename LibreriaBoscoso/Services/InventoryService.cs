using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class InventoryService
    {
        private readonly HttpClient _httpClient;

        // URL base de la API para el inventario (ajusta la URL según tu API)
        private const string BaseUrl = "https://localhost:7021/api/Inventory"; // Cambia esta URL según tu API

        public InventoryService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todo el inventario
        public async Task<List<Inventory>> GetInventoryAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Inventory>>(BaseUrl);
        }

        // Obtener el inventario de una tienda específica
        public async Task<List<Inventory>> GetInventoryByStoreIdAsync(int storeId)
        {
            return await _httpClient.GetFromJsonAsync<List<Inventory>>($"{BaseUrl}/store/{storeId}");
        }

        // Crear o actualizar el inventario de un libro en una tienda
        public async Task<bool> CreateOrUpdateInventoryAsync(Inventory inventory)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, inventory);
            return response.IsSuccessStatusCode;
        }

        // **Método para actualizar el inventario** (PUT)
        public async Task<bool> UpdateInventoryAsync(int storeId, int bookId, Inventory inventory)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{storeId}/{bookId}", inventory); // Usamos PUT para actualizar el inventario
            return response.IsSuccessStatusCode;
        }

        // Eliminar un inventario de una tienda para un libro específico
        public async Task<bool> DeleteInventoryAsync(int storeId, int bookId)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{storeId}/{bookId}");
            return response.IsSuccessStatusCode;
        }
    }
}
