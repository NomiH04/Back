using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Services;   // Asegúrate de que este sea el namespace de tu servicio
using LibreriaBoscoso.Models;     // Y el namespace de tu modelo Order
using LibreriaBoscoso.Views.InicioLogin;
using System.Linq;

namespace LibreriaBoscoso.Views.Proveedor
{
    public partial class HistorialPedidos : Form
    {
        // Instancia del servicio para consumir la API
        private OrderService _orderService;

        public HistorialPedidos()
        {
            InitializeComponent();
            _orderService = new OrderService();  // Se asume que ya existe y está configurado
        }

        // Evento Load del formulario
        private async void HistorialPedidos_Load(object sender, EventArgs e)
        {
            await CargarPedidosRecibidos();
        }

        // Método para cargar los pedidos con el estado "Received" y mostrarlo como "Entregado"
        private async Task CargarPedidosRecibidos()
        {
            try
            {
                List<Order> allOrders = await _orderService.GetOrdersAsync();

                // Filtra los pedidos que tengan el estado "Received"
                var receivedOrders = allOrders.Where(o => o.Status == "Received").ToList();

                // Cambia el estado de "Received" a "Entregado" antes de asignarlos al DataGridView
                foreach (var order in receivedOrders)
                {
                    order.Status = "Entregado";  // Aquí cambiamos el estado a "Entregado"
                }

                // Asigna la lista de pedidos "Received" (ahora con el estado "Entregado") al DataGridView
                dataGridViewOrders.DataSource = receivedOrders;

                // Configura las columnas del DataGridView para mayor control
                dataGridViewOrders.AutoGenerateColumns = true;

                if (dataGridViewOrders.Columns.Contains("supplierId"))
                {
                    dataGridViewOrders.Columns["supplierId"].Visible = false;
                }

                // Si quieres configurar las columnas manualmente
                if (dataGridViewOrders.Columns["OrderId"] != null)
                    dataGridViewOrders.Columns["OrderId"].HeaderText = "ID de Orden";
                if (dataGridViewOrders.Columns["StoreId"] != null)
                    dataGridViewOrders.Columns["StoreId"].HeaderText = "ID de Tienda";
                if (dataGridViewOrders.Columns["UserId"] != null)
                    dataGridViewOrders.Columns["UserId"].HeaderText = "ID de Usuario";
                if (dataGridViewOrders.Columns["OrderDate"] != null)
                    dataGridViewOrders.Columns["OrderDate"].HeaderText = "Fecha de Orden";
                if (dataGridViewOrders.Columns["Status"] != null)
                    dataGridViewOrders.Columns["Status"].HeaderText = "Estado";

                // Opcional: Ajusta el ancho de las columnas para que se vea todo
                foreach (DataGridViewColumn column in dataGridViewOrders.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pedidos: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para filtrar los pedidos "Received" según el filtro proporcionado
        private async Task Filtrar(string filtro)
        {
            try
            {
                // Obtener todos los pedidos desde el servicio de manera asíncrona
                List<Order> allOrders = await _orderService.GetOrdersAsync();

                // Filtrar los pedidos que tienen el estado "Received"
                var receivedOrders = allOrders
                    .Where(o => o.Status == "Received")
                    .ToList();

                // Si se proporcionó un filtro, se filtra por OrderId o StoreId
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    receivedOrders = receivedOrders
                        .Where(o => o.OrderId.ToString().Contains(filtro) || o.StoreId.ToString().Contains(filtro))
                        .ToList();
                }

                // Asignar los resultados filtrados al DataGridView
                dataGridViewOrders.DataSource = receivedOrders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar los pedidos: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        // Evento del botón de buscar
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string filtro = txt_Buscador.Text.Trim(); // Obtener el texto del buscador
            Filtrar(filtro); // Llamar al método para filtrar los pedidos
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
