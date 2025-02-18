using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibreriaBoscoso.Services;   // Asegúrate de incluir el namespace del servicio
using LibreriaBoscoso.Models;     // Y el namespace de los modelos
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Proveedor
{
    public partial class HistorialPedidos : Form
    {
        private OrderService _orderService;

        public HistorialPedidos()
        {
            InitializeComponent();
            _orderService = new OrderService();  // Instanciamos el servicio para consumir la API
        }

        // Renombramos el evento para mayor claridad (asegúrate de actualizar el diseñador si es necesario)
        private async void HistorialPedidos_Load(object sender, EventArgs e)
        {
            try
            {
                // Consumir la API para obtener la lista de pedidos
                List<Order> orders = await _orderService.GetOrdersAsync();

                // Asignar los datos al DataGridView (asegúrate de tener uno en el formulario llamado dataGridViewOrders)
                dataGridViewOrders.DataSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Los siguientes métodos se encargan de la navegación entre formularios
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


        private void btnSalir_Click(object sender, EventArgs e)
        {
            ProveedorPrincipal proveedorPrincipal = new ProveedorPrincipal();
            proveedorPrincipal.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        
    }
}

