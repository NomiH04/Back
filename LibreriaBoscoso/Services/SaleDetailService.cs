using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class SaleDetailService
    {
        private readonly HttpClient _httpClient;

        // URL base de la API (ajusta la URL según tu API)
        private const string BaseUrl = "https://localhost:7021/api/SaleDetail"; // Ajusta la URL de acuerdo con tu API

        public SaleDetailService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todos los detalles de ventas
        public async Task<List<SaleDetail>> GetSaleDetailsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<SaleDetail>>(BaseUrl);
        }

        // Obtener los detalles de una venta por ID
        public async Task<List<SaleDetail>> GetSaleDetailsBySaleIdAsync(int saleId)
        {
            return await _httpClient.GetFromJsonAsync<List<SaleDetail>>($"{BaseUrl}/{saleId}");
        }

        // Crear un nuevo detalle de venta
        public async Task<bool> CreateSaleDetailAsync(SaleDetail saleDetail)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, saleDetail);
            return response.IsSuccessStatusCode;
        }

        // Eliminar un detalle de venta
        public async Task<bool> DeleteSaleDetailAsync(int saleId, int bookId)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{saleId}/{bookId}");
            return response.IsSuccessStatusCode;
        }
    }
}
