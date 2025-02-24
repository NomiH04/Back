using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;
namespace LibreriaBoscoso.Services
{
    public class StoreService
    {
        private readonly HttpClient _httpClient;

        // URL base de la API (ajusta la URL según tu API)
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/Store"; // Ajusta la URL según la de tu API

        public StoreService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Store> GetStoreByIdAsync(int storeId)
        {
            try
            {
                //extrae el pedido por su id
                var response = await _httpClient.GetAsync($"{BaseUrl}/{storeId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Store>();
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
    }
}
