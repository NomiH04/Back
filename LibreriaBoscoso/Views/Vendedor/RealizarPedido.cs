using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        private readonly OrderService _orderService;
        private List<OrderDetail> _orderDetails;
        private List<User> _providersList;


        public RealizarPedido()
        {
            InitializeComponent();
            _orderDetailService = new OrderDetailService();
            _orderService = new OrderService();
            _orderDetails = new List<OrderDetail>(); // Inicializa la lista de pedidos
            _providersList = new List<User>();

        }

        private void RealizarPedido_Load(object sender, EventArgs e)
        {
            CargarDetallesPedido();
        }

        private async void btn_FinalizarPedido_Click_1(object sender, EventArgs e)
        {
            if (_orderDetails.Count == 0)
            {
                MessageBox.Show("No hay libros en el pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Order nuevoPedido = new Order
            {
                OrderDate = DateTime.UtcNow
            };

            int orderId = await _orderService.RegistrarPedidoAsync(nuevoPedido);

            if (orderId > 0)
            {
                foreach (var libro in _orderDetails)
                {
                    libro.OrderId = orderId;
                }

                bool detallesGuardados = await GuardarDetallePedidoAsync(_orderDetails);

                if (detallesGuardados)
                {
                    MessageBox.Show("Pedido realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _orderDetails.Clear();
                    ActualizarTabla();
                }
            }
            else
            {
                MessageBox.Show("Error al registrar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> GuardarDetallePedidoAsync(List<OrderDetail> orderDetails)
        {
            bool exitoso = true;

            foreach (var detalle in orderDetails)
            {
                try
                {
                    bool resultado = await _orderDetailService.RegistrarDetallePedidoAsync(detalle);
                    if (!resultado)
                    {
                        Console.WriteLine($"Error al registrar el libro con ID {detalle.BookId}");
                        exitoso = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado al registrar el libro {detalle.BookId}: {ex.Message}");
                    exitoso = false;
                }
            }

            return exitoso;
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

        /*private async Task CargarProveedores()
        {
            try
            {
                _providersList = await _userService.GetProvidersAsync(); // 🔹 Obtenemos los proveedores desde `UserService`

                if (_providersList != null && _providersList.Count > 0)
                {
                    cmb_Proveedor.DataSource = _providersList;
                    cmb_Proveedor.DisplayMember = "Username"; 
                }
                else
                {
                    MessageBox.Show("No hay proveedores disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        */

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

        public void AgregarLibroAPedido(OrderDetail libro)
        {
            _orderDetails.Add(libro);
            ActualizarTabla();
        }
        private void ActualizarTabla()
        {
            dgv_Libros.DataSource = null;
            dgv_Libros.DataSource = _orderDetails;
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
