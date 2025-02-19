﻿using System;
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
        private SaleService _saleService;
        private SaleDetailService _saleDetailService;
        private List<SaleDetail> _librosVenta; // Lista de libros que se van a vender
        private UserService _userService;
        private StoreService _storeService;

        public RealizarVenta()
        {
            InitializeComponent();
            Inicializar();
            _saleService = new SaleService();
            _storeService = new StoreService();
            _saleDetailService = new SaleDetailService();
            _userService = new UserService();
            _librosVenta = new List<SaleDetail>(); // Inicializa la lista vacía
        }

        private void Inicializar()
        {
            ObtenerIdVentaAsync();
        }

        private void btn_Agregar_Libro_Click(object sender, EventArgs e)
        {
            AgregarLibroFactura agregarLibroFactura = new AgregarLibroFactura(this);
            agregarLibroFactura.Show();
        }

        private async void Realizar_Venta_Load(object sender, EventArgs e)
        {
            await CargarDetallesVentas();

        }

        public void AgregarLibroAVenta(SaleDetail libro)
        {
            label_Total.Text = CalcularTotalVenta().ToString();
            _librosVenta.Add(libro); // Agregar el libro a la lista temporal
            ActualizarTabla(); // Refrescar la tabla de libros a vender
        }
        private void ActualizarTabla()
        {
            dgv_Libros.DataSource = null;
            dgv_Libros.DataSource = _librosVenta;
        }
        private async Task<int> ObtenerIdVentaAsync()
        {
            int numeroVenta = 0;
            try
            {
                List<Sale> ventas = await _saleService.GetSalesAsync();

                if (ventas != null && ventas.Count > 0)
                {
                    int maxSaleId = ventas.Max(v => v.SaleId);
                    numeroVenta = maxSaleId + 1; // Retorna el ID de venta más alto
                }
                else
                {
                    numeroVenta = 0; // Si no hay ventas, retorna 0
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el ID de la venta más alto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            label_Num_Venta.Text = numeroVenta.ToString();
            return numeroVenta;
        }

        private async Task<int> ObtenerIdUsuarioAsync()
        {
            try
            {
                string username = label_Usuario.Text.Trim(); // Obtener el nombre de usuario del Label

                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("El nombre de usuario no está disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

                int userId = await _userService.GetUserId(username);

                if (userId == -1)
                {
                    MessageBox.Show("No se encontró el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return userId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al obtener el ID del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
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

        private async void btn_Finalizar_Venta_Click(object sender, EventArgs e)
        {
            if (_librosVenta.Count == 0)
            {
                MessageBox.Show("No hay libros en la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = await ObtenerIdUsuarioAsync();
            if (userId != -1)
            {
                Sale nuevaVenta = new Sale
                {
                    UserId = userId,
                    StoreId = 1,
                    SaleDate = DateTime.UtcNow,
                    Total = CalcularTotalVenta()
                };

                bool ventaExitosa = await _saleService.RegistrarVentaAsync(nuevaVenta);

                if (ventaExitosa)
                {
                    MessageBox.Show("Venta realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _librosVenta.Clear(); // Vaciar la lista después de la venta
                    ActualizarTabla(); // Refrescar la tabla

                    await GuardarDetalleVentaAsync(_librosVenta);
                }
                else
                {
                    MessageBox.Show("Error al registrar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error al obtener el ususario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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


        private async Task CargarDetallesVentas()
        {
            try
            {
                // Obtener todos los detalles de venta
                _librosVenta = await _saleDetailService.GetSaleDetailsAsync();  // Guardamos los detalles de venta

                // Asignar los detalles de venta al DataGridView
                dgv_Libros.DataSource = _librosVenta;

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

    }
}
