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
    public partial class RealizarVenta : Form
    {
        private SaleService _saleService;
        private SaleDetailService _saleDetailService;
        private List<SaleDetail> _librosVenta; // Lista de libros que se van a vender
        private UserService _userService;
        private int idVenta = 0;

        public RealizarVenta()
        {
            InitializeComponent();

            _saleService = new SaleService();
            _saleDetailService = new SaleDetailService();
            _userService = new UserService();
            _librosVenta = new List<SaleDetail>(); // Inicializa la lista vacía
        }

        private void btn_Agregar_Libro_Click(object sender, EventArgs e)
        {
            AgregarLibroFactura agregarLibroFactura = new AgregarLibroFactura(this, idVenta);
            agregarLibroFactura.Show();
        }

        private async void Realizar_Venta_Load(object sender, EventArgs e)
        {
            ActualizarTabla();
            await ObtenerIdVentaAsync();

        }

        public void AgregarLibroAVenta(SaleDetail libro)
        {
            _librosVenta.Add(libro); // Agregar el libro a la lista temporal
            label_Total.Text = CalcularTotalVenta().ToString();
            ActualizarTabla(); // Refrescar la tabla de libros a vender
        }

        private void ActualizarTabla()
        {
            dgv_Libros.DataSource = null;
            if (_librosVenta != null)
            {
                dgv_Libros.DataSource = _librosVenta;
            }
        }

        private async Task<int> ObtenerIdVentaAsync()
        {
            int numeroVenta = 0;
            try
            {
                numeroVenta = await _saleService.GetTotalItemsAsync();
                numeroVenta++;
                idVenta = numeroVenta;
                label_Num_Venta.Text = numeroVenta.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el ID de la venta más alto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return numeroVenta;

        }

        private async void btn_Finalizar_Venta_Click_1(object sender, EventArgs e)
        {
            if (_librosVenta.Count == 0)
            {
                MessageBox.Show("No hay libros en la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que idVenta esté inicializado. Si es 0, intentar obtenerlo nuevamente.
            if (idVenta == 0)
            {
                idVenta = await ObtenerIdVentaAsync();
                if (idVenta == 0)
                {
                    MessageBox.Show("Error: el ID de venta no pudo asignarse correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Sale nuevaVenta = new Sale
            {
                UserId = 3,
                StoreId = 1,
                SaleDate = DateTime.UtcNow,
                Total = CalcularTotalVenta()
            };

            bool ventaExitosa = await _saleService.RegistrarVentaAsync(nuevaVenta);
            if (!ventaExitosa)
            {
                MessageBox.Show("Error al registrar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Usamos el SaleId asignado en nuevaVenta, si está disponible, o idVenta en caso contrario.
            int saleIdForDetails = idVenta;

            bool detallesGuardados = true;
            foreach (var detalle in _librosVenta)
            {
                // Asignar el ID de la venta a cada detalle.
                detalle.SaleId = saleIdForDetails;
                Console.WriteLine($"{detalle.BookId}+{detalle.Quantity}");

                bool resultado = await _saleDetailService.RegistrarDetalleVentaAsync(detalle);
                if (!resultado)
                {
                    detallesGuardados = false;
                    Console.WriteLine($"Error al registrar el libro con ID {detalle.BookId}");
                }
            }

            if (detallesGuardados)
            {
                MessageBox.Show("Venta realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La venta se realizó, pero hubo errores al registrar algunos detalles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpiar la lista y actualizar la tabla para reflejar la finalización de la venta.
            _librosVenta.Clear();
            ActualizarTabla();
        }


        private decimal CalcularTotalVenta()
        {
            decimal total = 0;

            foreach (var libro in _librosVenta)
            {
                total += libro.UnitPrice * libro.Quantity; // Sumar (precio * cantidad) de cada libro
            }

            return total;
        }

        private async Task<bool> GuardarDetalleVentaAsync(List<SaleDetail> librosVenta)
        {
            bool exitoso = true;

            foreach (var libro in librosVenta)
            {
                try
                {
                    libro.SaleId = int.Parse(label_Num_Venta.Text);
                    bool resultado = await _saleDetailService.RegistrarDetalleVentaAsync(libro);
                    if (!resultado)
                    {
                        Console.WriteLine($"Error al registrar el libro con ID {libro.BookId}");
                        exitoso = false; // Marcar como fallido si un libro no se registra
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado al registrar el libro {libro.BookId}: {ex.Message}");
                    exitoso = false;
                }
            }

            return exitoso;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Seguro que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void consultar_Stock_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarStock consultarStock = new ConsultarStock();
            consultarStock.Show();
            this.Hide();
        }

        private void realizar_Venta_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizarVenta realizarVenta = new RealizarVenta();
            realizarVenta.Show();
            this.Hide();
        }

        private void realizar_Pedido_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizarPedido realizarPedido = new RealizarPedido();
            realizarPedido.Show();
            this.Dispose();
        }

        private void txt_Buscar_Enter(object sender, EventArgs e)
        {
            // Verificamos si el texto es "Buscar" para borrarlo al hacer clic
            if (txt_Buscar.Text == "Buscar")
            {
                txt_Buscador.Clear();
            }
        }

        private void txt_Buscar_Leave(object sender, EventArgs e)
        {
            // Si el campo está vacío, restauramos el texto "Buscar"
            if (string.IsNullOrWhiteSpace(txt_Buscar.Text))
            {
                txt_Buscador.Text = "Buscar";
            }
        }

        private void txt_Buscador_Enter(object sender, EventArgs e)
        {
            // Verificamos si el texto es "Buscar" para borrarlo al hacer clic
            if (txt_Buscador.Text == "Buscar")
            {
                txt_Buscador.Clear();
            }
        }

        private void txt_Buscador_Leave(object sender, EventArgs e)
        {
            // Si el campo está vacío, restauramos el texto "Buscar"
            if (string.IsNullOrWhiteSpace(txt_Buscador.Text))
            {
                txt_Buscador.Text = "Buscar";
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            // Obtener el valor del campo de búsqueda
            string searchValue = txt_Buscador.Text.Trim();

            if (!string.IsNullOrEmpty(searchValue))
            {
                // Filtrar los datos en base al SaleId
                var filteredData = _librosVenta.Where(x => x.SaleId.ToString().Contains(searchValue)).ToList();

                if (filteredData.Any())
                {
                    // Actualizar el DataGridView con los resultados filtrados
                    dgv_Libros.DataSource = filteredData;
                }
                else
                {
                    // Mostrar mensaje cuando no se encuentren resultados
                    MessageBox.Show("No se encontraron ventas con ese ID.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_Libros.DataSource = _librosVenta;  // Volver a mostrar todos los datos si no se encontró nada
                }
            }
            else
            {
                // Si no hay valor de búsqueda, recargar todos los detalles
                dgv_Libros.DataSource = _librosVenta;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            VendedorPrincipal vendedorPrincipal = new VendedorPrincipal();
            vendedorPrincipal.Show();
            this.Hide();
        }

        private void dgv_Libros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que se haya seleccionado una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtén el ID de la venta (SaleId) de la fila seleccionada
                var saleId = dgv_Libros.Rows[e.RowIndex].Cells["SaleId"].Value;

                // Verifica si SaleId es nulo o vacío
                if (saleId != null && !string.IsNullOrEmpty(saleId.ToString()))
                {
                    // Asigna el SaleId a los labels
                    label_Num_Venta.Text = "Venta ID: " + saleId.ToString();
                    label_Total.Text = saleId.ToString();
                }
                else
                {
                    MessageBox.Show("SaleId no disponible en esta fila.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label_Total_Click(object sender, EventArgs e)
        {

        }

        private void label_Usuario_Click(object sender, EventArgs e)
        {

        }
    }
}
