using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

using System.Text.Json.Serialization;

using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
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

        // Obtener todas las tiendas
        public async Task<List<Store>> GetStoresAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("JSON recibido desde la API:\n" + jsonString);

                try
                {
                    // Intentar deserializar el JSON paginado correctamente
                    var storeResponse = JsonSerializer.Deserialize<PaginatedStoreResponse>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (storeResponse?.Store != null && storeResponse.Store.Count > 0)
                    {
                        return storeResponse.Store;
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("Error al deserializar el JSON. Formato inesperado.");
                }

                throw new Exception("No se encontraron tiendas o el formato del JSON es incorrecto.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las tiendas: " + ex.Message);
            }
        }

        // Clase para manejar la estructura del JSON paginado
        public class PaginatedStoreResponse
        {
            public int TotalItems { get; set; }
            public int TotalPages { get; set; }
            public int CurrentPage { get; set; }
            public int PageSize { get; set; }
            public List<Store> Store { get; set; }
        }

        public class StoreResponse
        {
            public List<Store> Stores { get; set; }
        }

      

        // Crear una tienda
        public async Task<bool> CreateStoreAsync(Store store)
        {
            try
            {
                // Creamos el DTO para la creación de la tienda
                var storeCreateDto = new StoreCreateDto
                {
                    Name = store.Name,
                    Location = store.Location
                };

                // Para depurar, puedes imprimir el objeto storeCreateDto
                Console.WriteLine("Enviando tienda: " + JsonSerializer.Serialize(storeCreateDto));

                // Enviamos el DTO como JSON al servidor
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, storeCreateDto);

                if (response.IsSuccessStatusCode)
                {
                    // Si la respuesta es exitosa, retornamos true
                    return true;
                }
                else
                {
                    // Si la respuesta no es exitosa, mostramos el error
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al crear la tienda: {response.StatusCode} - {errorResponse}");

                    // Se puede devolver más información si lo necesitas
                    // Puedes también mostrar un mensaje específico con la respuesta
                    MessageBox.Show($"Error al crear la tienda: {response.StatusCode} - {errorResponse}");

                    return false;
                }
            }
            catch (Exception ex)
            {
                // Capturamos cualquier excepción y la mostramos en el log
                Console.WriteLine($"Error al crear la tienda: {ex.Message}");
                MessageBox.Show($"Error al crear la tienda: {ex.Message}");
                return false;
            }
        }

        // Actualizar una tienda
        public async Task<bool> UpdateStoreAsync(int id, Store store)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", store);

                if (response.IsSuccessStatusCode)
                    return true;

                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al actualizar la tienda: {response.StatusCode} - {errorResponse}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la tienda: {ex.Message}");
                return false;
            }
        }

        // Eliminar una tienda
        public async Task<bool> DeleteStoreAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Tienda con ID {id} eliminada correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al eliminar la tienda. Código de estado: {response.StatusCode}");
                    return false;
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error HTTP al eliminar la tienda: {httpEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado al eliminar la tienda: {ex.Message}");
                return false;
            }
        }


        // DTO para la creación de la tienda
        public class StoreCreateDto
        {
            public string Name { get; set; }
            public string Location { get; set; }

        }
    }
}
