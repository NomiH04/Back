using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Gerente
{
    public partial class ConsultarVentas : Form
    {
        private SaleService _saleService; // se hace una instancia de la clase orden service para extraer los datos de la api
        int idVentaSeleccionado = -1;
        public ConsultarVentas()
        {
            InitializeComponent();
            _saleService = new SaleService();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();
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

        private async void button7_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text) && int.TryParse(txtBuscar.Text, out int idDesdeTextbox))
            {
                idVentaSeleccionado = idDesdeTextbox;
            }
            else
            {
                // Si no se ingresó un ID válido en el TextBox, obtener el ID seleccionado en la tabla
                idVentaSeleccionado = ObtenerIdSeleccionado();
            }

            if (idVentaSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un libro de la tabla o ingrese un ID válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            VerVenta verVenta = new VerVenta(idVentaSeleccionado);//se llama a la ventana ver ventas y se le ingresa por parametro el id a mostrar
            verVenta.Show();
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
                var sale = await _saleService.GetSaleByIdAsync(id);

                if (sale != null)
                {
                    dataVenta.DataSource = new List<Sale> { sale };
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
                var service = new SaleService(); // 

                // Obtener la lista de órdenes
                var sales = await service.GetSalesAsync();

                // Asignar la lista de órdenes al DataGridView
                dataVenta.DataSource = sales;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
            txtBuscar.Text = "";
        }

        private void dataVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que no se haga clic en el encabezado
            {
                DataGridViewRow filaSeleccionada = dataVenta.Rows[e.RowIndex];

                // Verificar que la celda no sea nula antes de convertirla a int
                if (filaSeleccionada.Cells[0].Value != null)
                {
                    idVentaSeleccionado = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                }
            }
        }
        private int ObtenerIdSeleccionado()
        {
            return idVentaSeleccionado;
        }
    }
}
