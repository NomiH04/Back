using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class SaleService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/Sale";

        public SaleService()
        {
            _httpClient = new HttpClient();
        }

        // Método para registrar una venta
        public async Task<bool> RegistrarVentaAsync(Sale venta)
        {
            try
            {
                // Creamos un DTO para enviar solo los datos necesarios
                var saleCreateDto = new SaleCreateDto
                {
                    UserId = venta.UserId,
                    StoreId = venta.StoreId,
                    SaleDate = venta.SaleDate ?? DateTime.UtcNow, // Evitar nulos
                    Total = venta.Total
                };

                // Para depuración, imprimimos el JSON enviado
                Console.WriteLine("JSON enviado a la API: " + JsonSerializer.Serialize(saleCreateDto));

                var response = await _httpClient.PostAsJsonAsync(BaseUrl, saleCreateDto);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("✅ Venta registrada exitosamente.");
                    return true;
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"❌ Error al registrar la venta: {response.StatusCode} - {errorResponse}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ Error en RegistrarVentaAsync: {ex.Message}");
                return false;
            }
        }

        // Método para obtener todas las ventas
        public async Task<List<Sale>> GetSalesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("📥 JSON recibido desde la API:\n" + jsonString);

                return JsonSerializer.Deserialize<List<Sale>>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<Sale>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ Error al obtener ventas: {ex.Message}");
                return new List<Sale>();
            }
        }

        // Método para obtener una venta por ID
        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            try
            {
                var sale = await _httpClient.GetFromJsonAsync<Sale>($"{BaseUrl}/{id}");

                if (sale != null)
                {
                    Console.WriteLine($"📄 Venta encontrada: ID={sale.SaleId}");
                    return sale;
                }
                else
                {
                    Console.WriteLine($"❌ No se encontró la venta con ID {id}.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ Error en GetSaleByIdAsync: {ex.Message}");
                return null;
            }
        }

        // Método para eliminar una venta
        public async Task<bool> DeleteSaleAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"✅ Venta con ID {id} eliminada correctamente.");
                    return true;
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"❌ Error al eliminar la venta: {response.StatusCode} - {errorResponse}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ Error en DeleteSaleAsync: {ex.Message}");
                return false;
            }
        }
    }

    // DTO para enviar solo los datos necesarios al registrar una venta
    public class SaleCreateDto
    {
        public int? UserId { get; set; }
        public int? StoreId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Total { get; set; }
    }
}