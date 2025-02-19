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

        public AgregarLibroFactura()
        {
            InitializeComponent();
            _bookService = new BookService();
        }

        private async void AgregarLibroFactura_Load(object sender, EventArgs e)
        {
            await CargarLibros();
        }

        private async Task CargarLibros()
        {
            try
            {
                // Obtener todos los libros desde el servicio
                allBooks = await _bookService.GetBooksAsync(); // Guardamos los libros

                // Asignar la lista de libros al DataGridView
                dgv_Libros_Disponibles.DataSource = allBooks;

                // Configurar las columnas del DataGridView
                dgv_Libros_Disponibles.AutoGenerateColumns = true;

                // Configurar los encabezados de las columnas
                if (dgv_Libros_Disponibles.Columns["BookId"] != null)
                    dgv_Libros_Disponibles.Columns["BookId"].HeaderText = "ID";
                if (dgv_Libros_Disponibles.Columns["Title"] != null)
                    dgv_Libros_Disponibles.Columns["Title"].HeaderText = "Título";
                if (dgv_Libros_Disponibles.Columns["Author"] != null)
                    dgv_Libros_Disponibles.Columns["Author"].HeaderText = "Autor";
                if (dgv_Libros_Disponibles.Columns["Price"] != null)
                    dgv_Libros_Disponibles.Columns["Price"].HeaderText = "Precio";
                if (dgv_Libros_Disponibles.Columns["Description"] != null)
                    dgv_Libros_Disponibles.Columns["Description"].HeaderText = "Descripción";
                if (dgv_Libros_Disponibles.Columns["PublicationDate"] != null)
                    dgv_Libros_Disponibles.Columns["PublicationDate"].HeaderText = "Fecha de Publicación";
                if (dgv_Libros_Disponibles.Columns["Publisher"] != null)
                    dgv_Libros_Disponibles.Columns["Publisher"].HeaderText = "Editorial";

                // Ajustar el ancho de las columnas correctamente para permitir el scroll
                foreach (DataGridViewColumn column in dgv_Libros_Disponibles.Columns)
                {
                    if (column.Frozen)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // No usa Fill para evitar errores y permitir el scroll
                    }
                }

                // Habilitar scroll si hay más datos de los que caben en la pantalla
                dgv_Libros_Disponibles.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los libros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    x.Title.ToLower().Contains(searchValue) ||
                    x.Author.ToLower().Contains(searchValue) ||
                    x.Publisher.ToLower().Contains(searchValue)
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

        }
    }
}
