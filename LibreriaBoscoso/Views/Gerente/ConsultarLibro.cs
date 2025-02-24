using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Gerente
{
    public partial class ConsultarLibro : Form
    {
        int idLibroSeleccionado = -1;
        private BookService _bookService; // se hace una instancia de la clase orden service para extraer los datos de la api
        public ConsultarLibro()
        {
            InitializeComponent();
            _bookService = new BookService();  // Se asume que ya existe y está configurado
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos(); //se creo un metodo que carga todos los datos a la tabla
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AgregarNuevoLibro nuevoLibro = new AgregarNuevoLibro();
            nuevoLibro.Show();
            this.Hide();
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

        private void button4_Click(object sender, EventArgs e)
        {
            GerentePrincipal gerentePrincipal = new GerentePrincipal();
            gerentePrincipal.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Verificar si el usuario ingresó el ID en el TextBox
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text) && int.TryParse(txtBuscar.Text, out int idDesdeTextbox))
            {
                idLibroSeleccionado = idDesdeTextbox;
            }
            else
            {
                // Si no se ingresó un ID válido en el TextBox, obtener el ID seleccionado en la tabla
                idLibroSeleccionado = ObtenerIdSeleccionado();
            }

            if (idLibroSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un libro de la tabla o ingrese un ID válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EditarLibro editarLibro = new EditarLibro(idLibroSeleccionado);
            editarLibro.Show();
            this.Hide();
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text) && int.TryParse(txtBuscar.Text, out int idDesdeTextbox))
            {
                idLibroSeleccionado = idDesdeTextbox;
            }
            else
            {
                // Si no se ingresó un ID válido en el TextBox, obtener el ID seleccionado en la tabla
                idLibroSeleccionado = ObtenerIdSeleccionado();
            }

            if (idLibroSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un libro de la tabla o ingrese un ID válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            VerLibro verLibro = new VerLibro(idLibroSeleccionado);//se llama a la ventana pedidos y se le ingresa por parametro el id a mostrar
            verLibro.Show();
            this.Hide();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)//buscar
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Ingrese el ID del pedido para buscar en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtBuscar.Text, out int id))
            {
                MessageBox.Show("El ID debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var book = await _bookService.GetBookByIdAsync(id);

                if (book != null)
                {
                    dataLibro.DataSource = new List<Book> { book };
                }
                else
                {
                    MessageBox.Show("No se encontró un pedido con el ID ingresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void CargarDatos()
        {
            try
            {
                // Instanciar la clase que contiene el método GetOrdersAsync
                var service = new BookService(); // 

                // Obtener la lista de órdenes
                var books = await service.GetBooksAsync();

                // Asignar la lista de órdenes al DataGridView
                dataLibro.DataSource = books;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar ()
        {
            CargarDatos();
            txtBuscar.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si el usuario ingresó el ID en el TextBox
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text) && int.TryParse(txtBuscar.Text, out int idDesdeTextbox))
            {
                idLibroSeleccionado = idDesdeTextbox;
            }
            else
            {
                // Si no se ingresó un ID válido en el TextBox, obtener el ID seleccionado en la tabla
                idLibroSeleccionado = ObtenerIdSeleccionado();
            }

            if (idLibroSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un libro de la tabla o ingrese un ID válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abrir la ventana de confirmación con el ID obtenido
            ModuloConfirmacion moduloConfirmacion = new ModuloConfirmacion(idLibroSeleccionado);
            moduloConfirmacion.Show();
        }

        private void dataLibro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que no se haga clic en el encabezado
            {
                DataGridViewRow filaSeleccionada = dataLibro.Rows[e.RowIndex];

                // Verificar que la celda no sea nula antes de convertirla a int
                if (filaSeleccionada.Cells[0].Value != null)
                {
                    idLibroSeleccionado = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                }
            }
        }

        private int ObtenerIdSeleccionado()
        {
            return idLibroSeleccionado;
        }
    }

}
