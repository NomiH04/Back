using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Vendedor
{
    public partial class AgregarLibroFactura : Form
    {
        private BookService _bookService;
        private List<Book> allBooks;
        private RealizarVenta _realizarVenta;

        public AgregarLibroFactura(RealizarVenta realizarVenta)
        {
            InitializeComponent();
            _bookService = new BookService();
            _realizarVenta = realizarVenta;
        }

        private async void AgregarLibroFactura_Load(object sender, EventArgs e)
        {
            await CargarLibros();
        }

        private async Task CargarLibros()
        {
            try
            {
                allBooks = await _bookService.GetBooksAsync();
                dgv_Libros_Disponibles.DataSource = allBooks;
                dgv_Libros_Disponibles.AutoGenerateColumns = true;

                // 🔹 Diccionario con los nombres originales y sus encabezados
                Dictionary<string, string> headers = new Dictionary<string, string>
                {
                    { "BookId", "ID" },
                    { "Title", "Título" },
                    { "Author", "Autor" },
                    { "Price", "Precio" },
          
                };

                // 🔹 Iterar por cada columna y asignar el encabezado si está en el diccionario
                foreach (DataGridViewColumn column in dgv_Libros_Disponibles.Columns)
                {
                    if (headers.ContainsKey(column.Name))
                    {
                        column.HeaderText = headers[column.Name];
                    }
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Ajustar tamaño
                }

                dgv_Libros_Disponibles.ScrollBars = ScrollBars.Both; // Habilitar scroll si es necesario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los libros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Agregar_Libro_Click(object sender, EventArgs e)
        {
            bool continuar = true; // Bandera para controlar el ciclo

            while (continuar)
            {
                try
                {
                    if (dgv_Libros_Disponibles.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccione un libro para agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int selectedIndex = dgv_Libros_Disponibles.SelectedRows[0].Index;

                    if (selectedIndex < 0 || selectedIndex >= allBooks.Count)
                    {
                        MessageBox.Show("Error al seleccionar el libro. Inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Book libroSeleccionado = allBooks[selectedIndex];

                    if (!int.TryParse(txt_Cantidad.Text, out int cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SaleDetail detalleVenta = new SaleDetail
                    {
                        BookId = libroSeleccionado.BookId,
                        Quantity = cantidad,
                        UnitPrice = libroSeleccionado.Price
                    };

                    _realizarVenta.AgregarLibroAVenta(detalleVenta);

                    DialogResult resultado = MessageBox.Show("¿Desea agregar otro libro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.No)
                    {
                        continuar = false; // Salir del bucle
                        this.Close(); // Cerrar la ventana inmediatamente
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Error en btn_Agregar_Libro_Click: {ex.Message}");
                    continuar = false;
                }
            }
        }


        private void consultar_Stock_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarStock consultarStock = new ConsultarStock();
            consultarStock.Show();
            this.Hide();
        }

        private void realizar_Venta_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizarVenta realizarVenta = new RealizarVenta();
            realizarVenta.Show();
            this.Hide();
        }

        private void realizar_Pedido_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizarPedido realizarPedido = new RealizarPedido();
            realizarPedido.Show();
            this.Hide();
        }

        private void txt_Buscar_Enter(object sender, EventArgs e)
        {
            if (txt_Buscar.Text == "Buscar")
            {
                txt_Buscador.Text = "";
                txt_Buscador.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txt_Buscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Buscar.Text))
            {
                txt_Buscar.Text = "Buscar";
                txt_Buscar.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txt_Buscador_Enter(object sender, EventArgs e)
        {
            if (txt_Buscador.Text == "Buscar")
            {
                txt_Buscador.Text = "";
                txt_Buscador.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txt_Buscador_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Buscador.Text))
            {
                txt_Buscador.Text = "Buscar";
                txt_Buscador.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btn_Cerrar_Sesion_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Seguro que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            // Obtener el valor del campo de búsqueda
            string searchValue = txt_Buscador.Text.Trim().ToLower(); // Convertimos a minúsculas para búsqueda insensible a mayúsculas

            if (!string.IsNullOrEmpty(searchValue))
            {
                // Filtrar los datos en base a Título, Autor o Publisher
                var filteredData = allBooks.Where(x =>
                    x.Title.ToLower().Contains(searchValue)
                ).ToList();

                if (filteredData.Any())
                {
                    // Actualizar el DataGridView con los resultados filtrados
                    dgv_Libros_Disponibles.DataSource = filteredData;
                }
                else
                {
                    // Mostrar mensaje cuando no se encuentren resultados
                    MessageBox.Show("No se encontraron libros con ese criterio.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_Libros_Disponibles.DataSource = allBooks;  // Volver a mostrar todos los datos si no se encontró nada
                }
            }
            else
            {
                // Si no hay valor de búsqueda, recargar todos los libros
                dgv_Libros_Disponibles.DataSource = allBooks;
            }
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
