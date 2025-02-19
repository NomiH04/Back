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
    public class BookService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://mi-api-boscoso.somee.com/api/Book"; // Ajustada la URL pública de la API

        public BookService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener todos los libros con manejo de errores
        public async Task<List<Book>> GetBooksAsync()
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

                // Intentar deserializar como un objeto raíz que contiene la lista de libros
                try
                {
                    var bookResponse = JsonSerializer.Deserialize<JsonElement>(jsonString);
                    var booksArray = bookResponse.GetProperty("book");

                    var books = JsonSerializer.Deserialize<List<Book>>(booksArray.ToString(), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (books != null && books.Count > 0)
                    {
                        return books;
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error al deserializar el JSON: " + ex.Message);
                }

                throw new Exception("No se encontraron libros o el formato del JSON es incorrecto.");
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
                throw new Exception("Error al obtener los libros: " + ex.Message);
            }
        }

        // Clase para manejar respuestas con un objeto raíz
        public class BookResponse
        {
            [JsonPropertyName("book")]
            public List<Book> Books { get; set; }
        }
        // Obtener un libro por ID
        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/{bookId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Book>();
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

        /*public async Task<bool> CreateBookAsync(Book book)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, book);

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al agregar el libro: {response.StatusCode} - {errorMessage}");
                }

                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de conexión con la API.", ex);
            }
        }*/

        public async Task<bool> CreateBookAsync(Book book)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, book);
            return response.IsSuccessStatusCode;
        }
        // 🔹 Obtener un libro por ID para extraer su título
        public async Task<string> GetBookTitleByIdAsync(int bookId)
        {
            try
            {
                var book = await _httpClient.GetFromJsonAsync<Book>($"{BaseUrl}/{bookId}");
                return book?.Title ?? "Desconocido"; // Si no encuentra el libro
            }
            catch (Exception)
            {
                return "Desconocido"; // En caso de error
            }
        }
    }
}
