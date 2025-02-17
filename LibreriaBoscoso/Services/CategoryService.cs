using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;

        // URL base de la API para las categorías (ajusta la URL según tu API)
        private const string BaseUrl = "https://localhost:7021/api/Category"; // Cambia esta URL según tu API

        public CategoryService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todas las categorías
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Category>>(BaseUrl);
        }

        // Obtener una categoría por ID
        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _httpClient.GetFromJsonAsync<Category>($"{BaseUrl}/{categoryId}");
        }

        // Crear una nueva categoría
        public async Task<bool> CreateCategoryAsync(Category category)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, category);
            return response.IsSuccessStatusCode;
        }

        // Actualizar una categoría
        public async Task<bool> UpdateCategoryAsync(int categoryId, Category category)
        {
            var response = await _httpClient.PatchAsJsonAsync($"{BaseUrl}/{categoryId}", category);
            return response.IsSuccessStatusCode;
        }

        // Eliminar una categoría
        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{categoryId}");
            return response.IsSuccessStatusCode;
        }
    }
}
