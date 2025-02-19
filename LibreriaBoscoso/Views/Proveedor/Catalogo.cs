using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Proveedor
{
    public partial class Catalogo : Form
    {
        private readonly BookService _bookService;
        private List<Book> _bookList;

        public Catalogo()
        {
            InitializeComponent();
            _bookService = new BookService();
            _bookList = new List<Book>();
        }

        private async void Catalogo_Load(object sender, EventArgs e)
        {
            await CargarCatalogo();
        }

        private async Task CargarCatalogo()
        {
            try
            {
                _bookList = await _bookService.GetBooksAsync();
                Console.WriteLine($"Libros obtenidos: {_bookList.Count}"); // Depuración

                if (_bookList == null || _bookList.Count == 0)
                {
                    MessageBox.Show("No hay libros disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Asignar datos al DataGridView
                dgv_Catalogo.DataSource = null;
                dgv_Catalogo.Columns.Clear();
                dgv_Catalogo.AutoGenerateColumns = true;
                dgv_Catalogo.DataSource = _bookList;

                // Ocultar columnas innecesarias (si las hay)
                if (dgv_Catalogo.Columns["Stock"] != null)
                    dgv_Catalogo.Columns["Stock"].Visible = false;
                if (dgv_Catalogo.Columns["BookId"] != null)
                    dgv_Catalogo.Columns["BookId"].Visible = false;
                // Configurar encabezados de columnas

                if (dgv_Catalogo.Columns["Title"] != null)
                    dgv_Catalogo.Columns["Title"].HeaderText = "Título";
                if (dgv_Catalogo.Columns["Price"] != null)
                    dgv_Catalogo.Columns["Price"].HeaderText = "Precio";

                // Ajustar ancho de columnas
                foreach (DataGridViewColumn column in dgv_Catalogo.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                dgv_Catalogo.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el catálogo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ProveedorPrincipal proveedorPrincipal = new ProveedorPrincipal();
            proveedorPrincipal.Show();
            this.Hide();
        }

        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorialPedidos historialPedidos = new HistorialPedidos();
            historialPedidos.Show();
            this.Hide();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProveedorPedidos proveedorPedidos = new ProveedorPedidos();
            proveedorPedidos.Show();
            this.Hide();
        }

        private void catalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ya estás en el catálogo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Seguro que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private async Task FiltrarCatalogo(string filtro)
        {
            try
            {
                // Obtener todos los libros desde el servicio
                List<Book> allBooks = await _bookService.GetBooksAsync();

                // Filtrar los libros por título si hay un filtro
                var filteredBooks = string.IsNullOrWhiteSpace(filtro)
     ? allBooks
     : allBooks.Where(b => b.Title.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0).ToList();


                // Asignar los resultados filtrados al DataGridView
                dgv_Catalogo.DataSource = null;
                dgv_Catalogo.DataSource = filteredBooks;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar el catálogo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón de buscar
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string filtro = txt_Buscador.Text.Trim(); // Obtener el texto del buscador
            FiltrarCatalogo(filtro); // Llamar al método para filtrar los libros por título
        }

        // Limpia el TextBox cuando entra (si tiene el valor por defecto)
        private void txt_Buscador_Enter(object sender, EventArgs e)
        {
            if (txt_Buscador.Text == "Buscar")
            {
                txt_Buscador.Clear(); // Limpiar el texto por defecto
            }
        }

        // Vuelve a poner el texto "Buscar" cuando se sale del TextBox y está vacío
        private void txt_Buscador_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Buscador.Text))
            {
                txt_Buscador.Text = "Buscar"; // Volver a poner "Buscar" si está vacío
            }
        }

        
    }
}
