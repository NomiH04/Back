using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Vendedor
{
    public partial class ConsultarStock : Form
    {
        private readonly InventoryService _inventoryService;
        private readonly BookService _bookService;
        private List<Inventory> _inventoryList;
        List<StockItem> stockWithNames;

        public ConsultarStock()
        {
            InitializeComponent();
            _inventoryService = new InventoryService();
            _bookService = new BookService();
            stockWithNames = new List<StockItem>();
        }

        private async void ConsultarStock_Load(object sender, EventArgs e)
        {
            await CargarStock();
        }

        private async Task CargarStock()
        {
            try
            {
                _inventoryList = await _inventoryService.GetInventoryAsync();
                stockWithNames.Clear(); // Limpiar lista antes de llenarla

                if (_inventoryList != null && _inventoryList.Count > 0)
                {
                    foreach (var item in _inventoryList)
                    {
                        var book = await _bookService.GetBookByIdAsync(item.BookId); // Obtener libro completo

                        if (book != null)
                        {
                            stockWithNames.Add(new StockItem
                            {
                                Codigo = item.BookId,
                                Titulo = book.Title,
                                Precio = book.Price,
                                Cantidad = item.Quantity
                            });
                        }
                        else
                        {
                            stockWithNames.Add(new StockItem
                            {
                                Codigo = item.BookId,
                                Titulo = "Desconocido",
                                Precio = 0,
                                Cantidad = item.Quantity
                            });
                        }
                    }

                    //Limpiar columnas antes de asignar el DataSource
                    dgv_Stock_Libros.DataSource = null;
                    dgv_Stock_Libros.Columns.Clear(); // <- Esto evita que las columnas se dupliquen
                    dgv_Stock_Libros.AutoGenerateColumns = true;
                    dgv_Stock_Libros.DataSource = stockWithNames;
                    dgv_Stock_Libros.Refresh();

                }
                else
                {
                    MessageBox.Show("No hay libros en inventario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            FiltrarStockAsync(txt_Buscador.Text);

        }

        private async Task FiltrarStockAsync(string filtro)
        {
            // Si el filtro está vacío, mostramos toda la lista original
            if (string.IsNullOrWhiteSpace(filtro))
            {
                await CargarStock();
            }
            else
            {
                // Filtrar la lista de libros por título
                var librosFiltrados = stockWithNames
                    .Where(book => book.Titulo != null && book.Titulo.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                // Asignar los datos filtrados al DataGridView con BindingList
                dgv_Stock_Libros.DataSource = new BindingList<StockItem>(librosFiltrados);

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
            RealizarPedido realizarPedido = new RealizarPedido();
            realizarPedido.Show();
            this.Hide();
        }
        private void txt_Buscar_Enter(object sender, EventArgs e)
        {
            if (txt_Buscar.Text == "Buscar")
            {
                txt_Buscador.Text = "";
                txt_Buscador.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txt_Buscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Buscar.Text))
            {
                txt_Buscar.Text = "Buscar";
                txt_Buscar.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txt_Buscador_Enter(object sender, EventArgs e)
        {
            if (txt_Buscador.Text == "Buscar")
            {
                txt_Buscador.Text = "";
                txt_Buscador.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txt_Buscador_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Buscador.Text))
            {
                txt_Buscador.Text = "Buscar";
                txt_Buscador.ForeColor = System.Drawing.Color.Gray;
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

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            VendedorPrincipal vendedorPrincipal = new VendedorPrincipal();
            vendedorPrincipal.Show();
            this.Hide();
        }

        private void consultar_Stock_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarStock consultarStock = new ConsultarStock();
            consultarStock.Show();
            this.Hide();
        }

        private void dgv_Stock_Libros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConsultarStock_Load_1(object sender, EventArgs e)
        {

        }
    }
    public class StockItem
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }

}
