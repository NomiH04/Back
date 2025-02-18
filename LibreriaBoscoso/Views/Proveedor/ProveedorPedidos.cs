using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Services;  // Asegúrate de que este sea el namespace de tu servicio
using LibreriaBoscoso.Models;    // Y el de tu modelo Order
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Proveedor
{
    public partial class ProveedorPedidos : Form
    {
        // Instancia del servicio para consumir la API
        private OrderService _orderService;

        public ProveedorPedidos()
        {
            InitializeComponent();
            _orderService = new OrderService(); // Se asume que ya existe y está configurado
        }

        // Evento Load del formulario
        private async void ProveedorPedidos_Load(object sender, EventArgs e)
        {
            await CargarPedidosPendientes();
        }

        // Método para cargar los pedidos pendientes
        private async Task CargarPedidosPendientes()
        {
            try
            {
                List<Order> allOrders = await _orderService.GetOrdersAsync();

                // Filtra aquellos que estén pendientes (ajusta la condición según tu lógica)
                var pendingOrders = allOrders.FindAll(o => o.Status == "Pending");

                // Asigna la lista de pedidos pendientes al DataGridView
                dataGridViewPedidos.DataSource = pendingOrders;

                // Opcional: Configura las columnas del DataGridView para mayor control
                dataGridViewPedidos.AutoGenerateColumns = true;

                // Si quieres configurar las columnas manualmente
                if (dataGridViewPedidos.Columns["OrderId"] != null)
                    dataGridViewPedidos.Columns["OrderId"].HeaderText = "ID de Orden";
                if (dataGridViewPedidos.Columns["StoreId"] != null)
                    dataGridViewPedidos.Columns["StoreId"].HeaderText = "ID de Tienda";
                if (dataGridViewPedidos.Columns["UserId"] != null)
                    dataGridViewPedidos.Columns["UserId"].HeaderText = "ID de Usuario";
                if (dataGridViewPedidos.Columns["OrderDate"] != null)
                    dataGridViewPedidos.Columns["OrderDate"].HeaderText = "Fecha de Orden";
                if (dataGridViewPedidos.Columns["Status"] != null)
                    dataGridViewPedidos.Columns["Status"].HeaderText = "Estado";

                // Opcional: Ajusta el ancho de las columnas para que se vea todo
                foreach (DataGridViewColumn column in dataGridViewPedidos.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pedidos pendientes: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ----------------------------------
        // Botón para cerrar sesión
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        // Botón para salir al menú principal de proveedor
        private void btnSalir_Click(object sender, EventArgs e)
        {
            ProveedorPrincipal proveedorPrincipal = new ProveedorPrincipal();
            proveedorPrincipal.Show();
            this.Hide();
        }

        // Métodos para navegar a otros formularios
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
            Catalogo catalogo = new Catalogo();
            catalogo.Show();
            this.Hide();
        }
    }
}
