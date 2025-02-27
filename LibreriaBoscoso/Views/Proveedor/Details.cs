using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Models;  // Modelo de detalles de pedido
using LibreriaBoscoso.Services; // Servicio de API

namespace LibreriaBoscoso.Views.Proveedor
{
    public partial class Details : Form
    {
        private OrderDetailService _orderService; // Servicio de pedidos
        private int _orderId;  // ID del pedido recibido

        public Details(int orderId)
        {
            InitializeComponent();
            _orderService = new OrderDetailService(); // Instancia del servicio
            _orderId = orderId;
            CargarDetallesPedido();
            Numerotxt.Text = _orderId.ToString();
        }

        private async void Details_Load(object sender, EventArgs e)
        {
            await CargarDetallesPedido();
        }

        // Método para obtener y mostrar los detalles del pedido
        private async Task CargarDetallesPedido()
        {
            try
            {
                List<OrderDetail> orderDetails = await _orderService.GetOrderDetailsByOrderIdAsync(_orderId);
                // Verificar que los datos no sean nulos
                if (orderDetails == null)
                {
                    orderDetails = new List<OrderDetail>();
                }

                // Limpiar columnas anteriores
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                // Habilitar autogeneración de columnas
                dataGridView1.AutoGenerateColumns = true;

                // Asignar la fuente de datos
                dataGridView1.DataSource = orderDetails;

                // Opcional: Ajustar nombres de las columnas
                if (dataGridView1.Columns.Contains("OrderId"))
                    dataGridView1.Columns["OrderId"].HeaderText = "ID de Orden";
                if (dataGridView1.Columns.Contains("ProductId"))
                    dataGridView1.Columns["ProductId"].HeaderText = "ID del Producto";
                if (dataGridView1.Columns.Contains("Quantity"))
                    dataGridView1.Columns["Quantity"].HeaderText = "Cantidad";
                if (dataGridView1.Columns.Contains("Price"))
                    dataGridView1.Columns["Price"].HeaderText = "Precio";

                // Ajustar tamaño de columnas automáticamente
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los detalles del pedido o no tiene :3",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}