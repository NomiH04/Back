using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    var booksArray = bookResponse.GetProperty("books");

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
            [JsonPropertyName("books")]
            public List<Book> Books { get; set; }
        }
        // Obtener un libro por ID
        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            try
            {
                var book = await _httpClient.GetFromJsonAsync<Book>($"{BaseUrl}/{bookId}");

                if (book != null)
                {
                    Console.WriteLine($"Libro encontrado: ID={book.BookId}, Título={book.Title}, Precio={book.Price}");
                    return book;
                }
                else
                {
                    Console.WriteLine($"No se encontró el libro con ID {bookId}.");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return null;
            }
        }



        public async Task<bool> CreateBookAsync(Book book)
        {
            try
            {
                var bookDto = new
                {
                    bookDto = new BookDto
                    {
                        Title = book.Title,
                        Author = book.Author,
                        Price = book.Price,
                        Description = book.Description,
                        PublicationDate = book.PublicationDate, 
                        Publisher = book.Publisher
                    }
                };

                // Para depurar, puedes imprimir el objeto userCreateDto
                Console.WriteLine("Enviando libro: " + JsonSerializer.Serialize(bookDto));
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
        }

        
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

        public async Task<bool> DeleteBookByIdAsync(int bookId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{BaseUrl}/{bookId}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Libro con ID {bookId} eliminado correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al eliminar el libro con ID {bookId}. Código: {response.StatusCode}");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> QuizasSirva(Book book)
        {
            try
            {
                // Creamos el DTO para la creación del usuario
                var bookDto = new BookDto
                {
                    Title = book.Title,
                    Author = book.Author,
                    Price = book.Price,
                    Description = book.Description,
                    PublicationDate = book.PublicationDate,
                    Publisher = book.Publisher
                };

                // Para depurar, puedes imprimir el objeto userCreateDto
                Console.WriteLine("Enviando usuario: " + JsonSerializer.Serialize(bookDto));

                // Enviamos el DTO como JSON al servidor
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, bookDto);

                if (response.IsSuccessStatusCode)
                {
                    // Si la respuesta es exitosa, retornamos true
                    return true;
                }
                else
                {
                    // Si la respuesta no es exitosa, mostramos el error
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al crear el usuario: {response.StatusCode} - {errorResponse}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Capturamos cualquier excepción y la mostramos en el log
                Console.WriteLine($"Error al crear usuario: {ex.Message}");
                return false;
            }
        }

        public class BookDto
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public DateTime PublicationDate { get; set; }
            public string Publisher { get; set; }
        }
    }
}
