using System;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Gerente
{
    public partial class AgregarNuevoLibro : Form
    {
        private readonly BookService _bookService = new BookService();
        private readonly CategoryService _categoryService = new CategoryService();
        public AgregarNuevoLibro()
        {
            InitializeComponent();
            CargarCategories();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void consultarLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarLibro buscarLibro = new ConsultarLibro();
            buscarLibro.Show();
            this.Hide();
        }

        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarVentas consultarVentas = new ConsultarVentas();
            consultarVentas.Show();
            this.Hide();
        }

        private void consultarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarPedido consultarPedido = new ConsultarPedido();
            consultarPedido.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultarLibro bucarLibro = new ConsultarLibro();
            bucarLibro.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private async void btnAgregar_Click(object sender, EventArgs e) //agregar libro
        {
            // Validar que todos los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrWhiteSpace(txtAutor.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtPublishier.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace (txtStock.Text) ||
                string.IsNullOrWhiteSpace(txtFecha.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que Precio sea un número decimal
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var book = new Book
            {
                Title = txtTitulo.Text,
                Author = txtAutor.Text,
                Price = precio,
                Description = txtDescripcion.Text,
                PublicationDate = DateTime.Now,
                Publisher = txtPublishier.Text // 
            };

            bool resultado = await _bookService.CreateBookAsync(book);

            if (resultado)
            {
                MessageBox.Show("Libro agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // **LIMPIAR LOS CAMPOS DESPUÉS DE ENVIAR LOS DATOS**
                txtTitulo.Text = "";
                txtAutor.Text = "";
                txtPrecio.Text = "";
                txtStock.Text = "";
                boxCategoria.SelectedIndex = -1;  // Desseleccionar el ComboBox
                txtDescripcion.Text = "";
                txtTitulo.Focus();  // Opcional: Enfocar el primer campo
            }
            else
            {
                MessageBox.Show("Error al agregar el libro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CargarCategories()
        {
            try
            {
                var categories = await _categoryService.GetCategoriesAsync();

                if (categories == null )
                {
                    MessageBox.Show("No se encontraron categorías.");
                    return;
                }

                boxCategoria.Items.Clear();
                boxCategoria.DataSource = null;  // Limpiar cualquier dato anterior
                boxCategoria.DataSource = categories;
                boxCategoria.DisplayMember = "Name";


                boxCategoria.Refresh(); // Forzar actualización visual
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}");
            }
        }
    }
}
