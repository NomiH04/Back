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
    public class SaleDetailService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/SaleDetail"; // Ajusta la URL según tu API

        public SaleDetailService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todos los detalles de las ventas con manejo de errores
        public async Task<List<SaleDetail>> GetSaleDetailsAsync()
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

                // Intentar deserializar como una lista de detalles de ventas directamente
                try
                {
                    var saleDetails = JsonSerializer.Deserialize<List<SaleDetail>>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (saleDetails != null && saleDetails.Count > 0)
                    {
                        return saleDetails;
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("El JSON no es una lista directa de detalles de ventas.");
                }

                // Si no funcionó, intentar deserializar como objeto con una propiedad raíz
                try
                {
                    var saleDetailResponse = JsonSerializer.Deserialize<SaleDetailResponse>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (saleDetailResponse?.SaleDetails != null && saleDetailResponse.SaleDetails.Count > 0)
                    {
                        return saleDetailResponse.SaleDetails;
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("El JSON tampoco coincide con un objeto raíz esperado.");
                }

                throw new Exception("No se encontraron detalles de ventas o el formato del JSON es incorrecto.");
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
                throw new Exception("Error al obtener los detalles de las ventas: " + ex.Message);
            }
        }

        // Clase para manejar respuestas con un objeto raíz
        public class SaleDetailResponse
        {
            [JsonPropertyName("saleDetails")]
            public List<SaleDetail> SaleDetails { get; set; }
        }

        // Registrar detalle venta
        public async Task<bool> RegistrarDetalleVentaAsync(SaleDetail libroVendido)
        {
            try
            {

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(BaseUrl, libroVendido);

                if (response.IsSuccessStatusCode)
                {
                    return true; // Venta registrada exitosamente
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error en la API al registrar venta: {errorMessage}");
                    return false; // Error en la API
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error de red al registrar la venta: {httpEx.Message}");
                return false; // Error de conexión o servidor no disponible
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado al registrar la venta: {ex.Message}");
                return false; // Cualquier otro error
            }
        }

    }
}
