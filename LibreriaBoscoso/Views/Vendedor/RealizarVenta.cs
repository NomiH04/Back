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
    public partial class RealizarVenta : Form
    {
        private SaleDetailService _saleDetailService;
        private List<SaleDetail> allSaleDetails;

        public RealizarVenta()
        {
            InitializeComponent();
            _saleDetailService = new SaleDetailService();
        }
        private async void Realizar_Venta_Load(object sender, EventArgs e)
        {
            await CargarDetallesVentas();
        }

        private async Task CargarDetallesVentas()
        {
            try
            {
                // Obtener todos los detalles de venta
                allSaleDetails = await _saleDetailService.GetSaleDetailsAsync();  // Guardamos los detalles de venta

                // Asignar los detalles de venta al DataGridView
                dgv_Libros.DataSource = allSaleDetails;

                // Configurar las columnas del DataGridView
                dgv_Libros.AutoGenerateColumns = true;

                // Configurar los encabezados de las columnas
                if (dgv_Libros.Columns["SaleId"] != null)
                    dgv_Libros.Columns["SaleId"].HeaderText = "ID de Venta";
                if (dgv_Libros.Columns["Title"] != null)
                    dgv_Libros.Columns["Title"].HeaderText = "Título";
                if (dgv_Libros.Columns["Author"] != null)
                    dgv_Libros.Columns["Author"].HeaderText = "Autor";
                if (dgv_Libros.Columns["Price"] != null)
                    dgv_Libros.Columns["Price"].HeaderText = "Precio";

                // Ajustar el ancho de las columnas
                foreach (DataGridViewColumn column in dgv_Libros.Columns)
                {
                    if (column.Frozen)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los detalles de las ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                var filteredData = allSaleDetails.Where(x => x.SaleId.ToString().Contains(searchValue)).ToList();

                if (filteredData.Any())
                {
                    // Actualizar el DataGridView con los resultados filtrados
                    dgv_Libros.DataSource = filteredData;
                }
                else
                {
                    // Mostrar mensaje cuando no se encuentren resultados
                    MessageBox.Show("No se encontraron ventas con ese ID.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_Libros.DataSource = allSaleDetails;  // Volver a mostrar todos los datos si no se encontró nada
                }
            }
            else
            {
                // Si no hay valor de búsqueda, recargar todos los detalles
                dgv_Libros.DataSource = allSaleDetails;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            VendedorPrincipal vendedorPrincipal = new VendedorPrincipal();
            vendedorPrincipal.Show();
            this.Hide();
        }

        private void btn_Agregar_Libro_Click(object sender, EventArgs e)
        {
            AgregarLibroFactura agregarLibroFactura = new AgregarLibroFactura();
            agregarLibroFactura.Show();
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
                    label_Numero_de_Venta.Text = saleId.ToString();
                }
                else
                {
                    MessageBox.Show("SaleId no disponible en esta fila.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
