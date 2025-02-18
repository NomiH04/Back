using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
    namespace LibreriaBoscoso.Services
    {
        public class StoreService
        {
            private readonly HttpClient _httpClient;

            // URL base de la API (ajusta la URL según tu API)
            private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/Category"; // Ajusta la URL según la de tu API

        public StoreService()
            {
                _httpClient = new HttpClient();
            }

            // ✅ 1. Obtener todas las tiendas (GET)
            public async Task<List<Store>> GetStoresAsync()
            {
                return await _httpClient.GetFromJsonAsync<List<Store>>(BaseUrl);
            }

            // ✅ 2. Obtener una tienda por ID (GET)
            public async Task<Store> GetStoreByIdAsync(int id)
            {
                return await _httpClient.GetFromJsonAsync<Store>($"{BaseUrl}/{id}");
            }

            // ✅ 3. Crear una nueva tienda (POST)
            public async Task<bool> CreateStoreAsync(Store store)
            {
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, store);
                return response.IsSuccessStatusCode;
            }

            // ✅ 4. Actualizar una tienda (PUT)
            public async Task<bool> UpdateStoreAsync(int id, Store store)
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", store);
                return response.IsSuccessStatusCode;
            }

            // ✅ 5. Eliminar una tienda (DELETE)
            public async Task<bool> DeleteStoreAsync(int id)
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
        }
    }
