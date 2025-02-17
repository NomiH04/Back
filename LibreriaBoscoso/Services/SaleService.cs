using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class SaleService
    {
        private readonly HttpClient _httpClient;

        // URL base de la API (ajustada a la nueva URL)
        private const string BaseUrl = "https://localhost:7021/api/Sale"; // Aquí ajustamos la URL

        public SaleService()
        {
            _httpClient = new HttpClient();
        }

        // ✅ 1. Obtener todas las ventas (GET)
        public async Task<List<Sale>> GetSalesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Sale>>(BaseUrl);
        }

        // ✅ 2. Obtener una venta por ID (GET)
        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Sale>($"{BaseUrl}/{id}");
        }

        // ✅ 3. Crear una nueva venta (POST)
        public async Task<bool> CreateSaleAsync(Sale sale)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, sale);
            return response.IsSuccessStatusCode;
        }

        // ✅ 4. Actualizar una venta parcialmente (PATCH)
        public async Task<bool> UpdateSaleAsync(int id, Sale sale)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", sale);
            return response.IsSuccessStatusCode;
        }

        // ✅ 5. Eliminar una venta (DELETE)
        public async Task<bool> DeleteSaleAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
