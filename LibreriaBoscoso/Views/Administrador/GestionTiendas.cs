using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;
using Newtonsoft.Json;

namespace LibreriaBoscoso.Views.Administrador
{
    public partial class GestionTiendas : Form
    {
        private readonly StoreService _storeService;
        private bool isAddingStore = false; // Flag para indicar cuando estamos agregando una tienda
        private List<Store> allStores;
        private List<Store> _StoreOriginales; // Verifica que este sea el tipo correcto


        public GestionTiendas()
        {
            InitializeComponent();
            _storeService = new StoreService();  // Inicializamos el servicio
           
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                var stores = await _storeService.GetStoresAsync();
                allStores = stores; // Guardamos todas las tiendas

                if (stores != null && stores.Count > 0)
                {
                    // Configurar las columnas del DataGridView
                    ConfigureDataGridView();

                    // Asignar las tiendas al DataGridView
                    dataGridView1.DataSource = stores;
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar las tiendas.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las tiendas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void consultarLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteVentas reporteVentas = new ReporteVentas();
            reporteVentas.Show();
            this.Hide();
        }

        private void reportesInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteInventarioGlobal reporteInventarioGlobal = new ReporteInventarioGlobal();
            reporteInventarioGlobal.Show();
            this.Hide();
        }

        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionTiendas gestionTiendas = new GestionTiendas();
            gestionTiendas.Show();
            this.Hide();
        }

        private void gestionarCategoriasLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionCategorias gestionCategorias = new GestionCategorias();
            gestionCategorias.Show();
            this.Hide();
        }

        private void consultarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios();
            gestionUsuarios.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdministradorPrincipal principal = new AdministradorPrincipal();
            principal.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        // Método para crear un nuevo tienda
        private async void button2_Click(object sender, EventArgs e)
        {
            // Validar los datos antes de proceder
            if (string.IsNullOrWhiteSpace(txt_Nombre.Text) || string.IsNullOrWhiteSpace(txt_Ubicacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Crear un nuevo objeto Store con los datos de los campos
            var newStore = new Store
            {
                Name = txt_Nombre.Text,
                Location = txt_Ubicacion.Text
            };

            try
            {
                // Indicamos que estamos agregando una tienda
                isAddingStore = true;

                // Imprimir el objeto 'newStore' para verificar los valores antes de enviar
                Console.WriteLine($"Tienda a enviar: {JsonConvert.SerializeObject(newStore)}");

                // Llamar al servicio para crear la nueva tienda
                bool isStoreCreated = await _storeService.CreateStoreAsync(newStore);

                // Verificamos si la tienda fue creada exitosamente
                if (isStoreCreated)
                {
                    MessageBox.Show("Tienda creada correctamente.");

                    // Recargamos las tiendas en el DataGridView
                    var stores = await _storeService.GetStoresAsync();
                    allStores = stores; // Guardar todas las tiendas nuevamente
                    dataGridView1.DataSource = stores;
                }
                else
                {
                    // Si no se creó la tienda, mostramos un mensaje de error
                    MessageBox.Show("Hubo un error al crear la tienda.");
                }
            }
            catch (HttpRequestException ex)
            {
                // Capturar errores específicos relacionados con la solicitud HTTP
                MessageBox.Show($"Error de conexión: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Capturar cualquier otra excepción general
                MessageBox.Show($"Error al crear la tienda: {ex.Message}");
            }
            finally
            {
                // Restablecemos el flag después de la adición
                isAddingStore = false;
            }
        }

        private void ConfigureDataGridView()
        {
            // Configuración de las columnas del DataGridView
            this.dataGridView1.AutoGenerateColumns = false;  // Desactiva la generación automática de columnas

            // Limpiar las columnas previas
            this.dataGridView1.Columns.Clear();

            // Crear las columnas manualmente para Store
            var colId = new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "StoreId", // Asegúrate de que el nombre coincida con el nombre de la propiedad
                Visible = true // Hacemos visible la columna ID
            };

            var colName = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Name"
            };

            var colLocation = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ubicación",
                DataPropertyName = "Location"
            };

            // Agregar las columnas necesarias
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                colId,
                colName,
                colLocation
            });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificamos si el clic fue en una celda de datos válida (no encabezado)
                if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].DataBoundItem is Store selectedStore)
                {
                    // Rellenamos los TextBox con los datos de la tienda seleccionada
                    txt_Nombre.Text = selectedStore.Name ?? string.Empty;
                    txt_Ubicacion.Text = selectedStore.Location ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar la tienda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_actualizar_tienda_Click_1(object sender, EventArgs e)
        {
            // Verificar que una fila esté seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una tienda para actualizar.");
                return;
            }

            // Obtener el ID de la tienda seleccionada usando el nombre correcto de la columna
            int colId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); // Usamos el índice (0) para la columna ID

            // Obtener los nuevos valores de los controles de texto
            string nuevoNombre = txt_Nombre.Text.Trim();
            string nuevaUbicacion = txt_Ubicacion.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nuevoNombre) || string.IsNullOrEmpty(nuevaUbicacion))
            {
                MessageBox.Show("Por favor, ingrese un nombre y una ubicación para la tienda.");
                return;
            }

            // Crear el objeto Store con los nuevos valores
            var tiendaActualizada = new Store
            {
                StoreId = colId,
                Name = nuevoNombre,
                Location = nuevaUbicacion
            };

            try
            {
                // Llamar al servicio para actualizar la tienda
                bool actualizado = await _storeService.UpdateStoreAsync(tiendaActualizada.StoreId, tiendaActualizada);

                if (actualizado)
                {
                    MessageBox.Show("Tienda actualizada correctamente.");
                    txt_Nombre.Clear();  // Limpiar el campo de nombre
                    txt_Ubicacion.Clear();  // Limpiar el campo de ubicación

                    // Recargar las tiendas en el DataGridView
                    var stores = await _storeService.GetStoresAsync();
                    allStores = stores; // Guardar todas las tiendas nuevamente
                    dataGridView1.DataSource = stores;
                }
                else
                {
                    MessageBox.Show("Error al actualizar la tienda.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show($"Error al actualizar la tienda: {ex.Message}");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox6.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                dataGridView1.DataSource = new List<Store>(_StoreOriginales);
            }
            else
            {
                var categoriasFiltradas = _StoreOriginales
                    .Where(c => c.Name.ToLower().Contains(filtro))
                    .ToList();

                dataGridView1.DataSource = categoriasFiltradas;
            }
        }
    }
}
