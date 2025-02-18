using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Vendedor
{
    public partial class RealizarPedido : Form
    {
        private readonly OrderDetailService _orderDetailService;
        private List<OrderDetail> _orderDetails;

        public RealizarPedido()
        {
            InitializeComponent();
            _orderDetailService = new OrderDetailService();

        }

        private void RealizarPedido_Load(object sender, EventArgs e)
        {
            CargarDetallesPedido();
        }

        private async void CargarDetallesPedido()
        {
            try
            {
                // Obtener los detalles de los pedidos desde el servicio
                _orderDetails = await _orderDetailService.GetOrderDetailsAsync();

                // Configurar las columnas del DataGridView
                dgv_Libros.Columns.Clear();  // Limpiar cualquier columna anterior si existe

                // Crear y agregar columnas manualmente
                dgv_Libros.Columns.Add("OrderId", "Order ID");
                dgv_Libros.Columns.Add("BookId", "Book ID");
                dgv_Libros.Columns.Add("Quantity", "Quantity");

                // Establecer propiedades opcionales para la visualización
                dgv_Libros.Columns["OrderId"].Width = 100;
                dgv_Libros.Columns["BookId"].Width = 100;
                dgv_Libros.Columns["Quantity"].Width = 80;

                // Mostrar los detalles en el DataGridView
                dgv_Libros.DataSource = _orderDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los detalles del pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarDetallesPedido(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                dgv_Libros.DataSource = _orderDetails;
            }
            else
            {
                // Filtrar por OrderId (ajusta según lo que desees buscar)
                var resultadosFiltrados = _orderDetails.Where(od => od.OrderId.ToString().Contains(filtro)).ToList();

                dgv_Libros.DataSource = resultadosFiltrados;
            }
        }

        private void realizar_Venta_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizarVenta realizarVenta = new RealizarVenta();
            realizarVenta.Show();
            this.Hide();
        }

        private void realizar_Pedido_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizarVenta realizarVenta = new RealizarVenta();
            realizarVenta.Show();
            this.Hide();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            VendedorPrincipal vendedor = new VendedorPrincipal();
            vendedor.Show();
            this.Hide();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string filtro = txt_Buscador.Text.Trim();
            FiltrarDetallesPedido(filtro);
        }
        // Limpia el TextBox cuando entra (si tiene el valor por defecto)
        private void txt_Buscador_Enter(object sender, EventArgs e)
        {
            if (txt_Buscador.Text == "Buscar")
            {
                txt_Buscador.Clear();
            }
        }

        // Vuelve a poner el texto "Buscar" cuando se sale del TextBox y está vacío
        private void txt_Buscador_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Buscador.Text))
            {
                txt_Buscador.Text = "Buscar";
            }
        }

        private void btn_Cerrar_Sesion_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Seguro que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void txt_Buscar_Enter(object sender, EventArgs e)
        {
            if (txt_Buscar.Text == "Buscar")
            {
                txt_Buscar.Clear();
            }
        }

        private void txt_Buscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Buscar.Text))
            {
                txt_Buscar.Text = "Buscar";
            }
        }

        private void consultar_Stock_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarStock consultarStock = new ConsultarStock();
            consultarStock.Show();
            this.Hide();
        }
    }
}
