using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LibreriaBoscoso.Models;

namespace LibreriaBoscoso.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;

        private const string BaseUrl = "https://localhost:7021/api/Book"; // Cambia esta URL según tu API

        public BookService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todos los libros
        public async Task<List<Book>> GetBooksAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Book>>(BaseUrl);
        }

        // Obtener un libro por ID
        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            return await _httpClient.GetFromJsonAsync<Book>($"{BaseUrl}/{bookId}");
        }

        // Crear un nuevo libro
        public async Task<bool> CreateBookAsync(Book book)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, book);
            return response.IsSuccessStatusCode;
        }

        // Actualizar un libro
        public async Task<bool> UpdateBookAsync(int bookId, Book book)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{bookId}", book);
            return response.IsSuccessStatusCode;
        }

        // Eliminar un libro
        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{bookId}");
            return response.IsSuccessStatusCode;
        }
    }
}
