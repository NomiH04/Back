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
            //se valida que el usuario ingreso un ID en el textbox o selcciono la tabla
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text) && int.TryParse(txtBuscar.Text, out int idDesdeTextbox))
            {
                idVentaSeleccionado = idDesdeTextbox;
            }
            else
            {
                // Si no se ingresó un ID válido en el TextBox, obtener el ID seleccionado en la tabla
                idVentaSeleccionado = ObtenerIdSeleccionado();
            }
            //en caso de no hacer ninguna de las anteriores acciones se envia un mensaje
            if (idVentaSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un libro de la tabla o ingrese un ID válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //si realizo alguna de acciones anteriores se redirige a la ventana para ver a mas a detalle la venta
            VerVenta verVenta = new VerVenta(idVentaSeleccionado);//se llama a la ventana ver ventas y se le ingresa por parametro el id a mostrar
            verVenta.Show();
            this.Hide();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)//buscar
        {
            //se verifica que el textbox no este vacio para iniciar la busqueda
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Ingrese el ID del pedido para buscar en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //veridifca que el valor que se ingreso sea un numero
            if (!int.TryParse(txtBuscar.Text, out int id))
            {
                MessageBox.Show("El ID debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //se llama al metodo que obtiene la venta por ID 
                var sale = await _saleService.GetSaleByIdAsync(id);
                //verifica que exista
                if (sale != null)
                {
                    //si existe se mostrara en la tabla
                    dataVenta.DataSource = new List<Sale> { sale };
                }
                else
                {
                    //si no existe envia un mensaje
                    MessageBox.Show("No se encontró un pedido con el ID ingresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //si ocurre algun error al obtener los datos o con API se enviara un mensaje
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
                //en caso de que ocurra un error con la API se enviara un mensaje
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //facilita vaciar el textbox y deselccionar la tabla
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
            //obtiene el ID de la fila selccionada para poder usarse
            return idVentaSeleccionado;
        }
    }
}
