using System;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Gerente
{
    public partial class AgregarNuevoLibro : Form
    {
        private readonly BookService _bookService;
        private bool isAddingUser = false;
        public AgregarNuevoLibro()
        {
            InitializeComponent();
            _bookService = new BookService();
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
                string.IsNullOrWhiteSpace(txtDescripcion.Text) )
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
            //se crea un objeto para enviar por parametro al metodo de crear libro
            var book = new Book
            {
                Title = txtTitulo.Text,
                Author = txtAutor.Text,
                Price = precio,
                Description = txtDescripcion.Text,
                PublicationDate = DateTime.Parse(txtFecha.Text),
                Publisher = txtPublishier.Text
            };

            //se llama al metodo de crear libro y si este envia una confirmacion
            bool resultado = await _bookService.CreateBookAsync(book);

            if (resultado)// si el resultado es true se agrega el libro se envia un mensaje de confirmacion
            {
                MessageBox.Show("Libro agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // **LIMPIAR LOS CAMPOS DESPUÉS DE ENVIAR LOS DATOS**
                txtTitulo.Text = "Titulo";
                txtAutor.Text = "Autor";
                txtPrecio.Text = "Precio";
                txtDescripcion.Text = "Descripcion";
                txtFecha.Text = "Fecha";
                txtPublishier.Text = "Publisher";
            }
            else
            {//en caso de no agregar el libro tambien se envia un mensaje para informar
                MessageBox.Show("Error al agregar el libro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ConsultarLibro consultar = new ConsultarLibro();
            consultar.Show();
            this.Close();
        }
    }
}
