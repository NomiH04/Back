﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class SaleService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/Sale"; // Ajusta la URL pública de la API

        public SaleService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todas las ventas con manejo de errores
        public async Task<List<Sale>> GetSalesAsync()
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

                // Intentar deserializar como un objeto raíz que contiene la lista de ventas
                try
                {
                    var saleResponse = JsonSerializer.Deserialize<JsonElement>(jsonString);
                    var salesArray = saleResponse.GetProperty("sale");

                    var sales = JsonSerializer.Deserialize<List<Sale>>(salesArray.ToString(), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (sales != null && sales.Count > 0)
                    {
                        return sales;
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error al deserializar el JSON: " + ex.Message);
                }

                throw new Exception("No se encontraron ventas o el formato del JSON es incorrecto.");
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
                throw new Exception("Error al obtener las ventas: " + ex.Message);
            }
        }

        // Clase para manejar respuestas con un objeto raíz
        public class SaleResponse
        {
            [JsonPropertyName("sale")]
            public List<Sale> Sales { get; set; }
        }
    }
}
