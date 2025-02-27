using System;
using System.Windows.Forms;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Gerente
{
    public partial class EditarLibro : Form
    {
        int id;
        private BookService _bookService; // se hace una instancia de la clase orden service para extraer los datos de la api
        public EditarLibro(int id)
        {
            InitializeComponent();
            this.id = id;
            _bookService = new BookService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();//se llama al metodo que mostrara los detalles del libro al momento de abrir la ventana
        }

        private void consultarLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarLibro bucarLibro = new ConsultarLibro();
            bucarLibro.Show();
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
            ConsultarLibro consultarLibro = new ConsultarLibro();
            consultarLibro.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }


        private async void CargarDatos()
        {
            //se llama al metodo que obtiene el libro por medio del ID
            var book = await _bookService.GetBookByIdAsync(id);
            //luego se extrae los atributos para se mostrados en los textsbox
            txtTitulo.Text = book.Title;
            txtAutor.Text = book.Author;
            txtPrecio.Text = book.Price.ToString();
            txtPublishier.Text = book.Publisher;
            txtDescripcion.Text = book.Description;
            txtFecha.Text = book.PublicationDate.ToString("dd/MM/yyyy");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //no se modifica en la API
        }
    }
}
