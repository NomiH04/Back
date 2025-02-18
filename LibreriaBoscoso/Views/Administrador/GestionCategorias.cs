using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Administrador
{
    public partial class GestionCategorias : Form
    {
        private readonly CategoryService _categoryService;
        public GestionCategorias()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Llamamos al método para cargar las categorías al cargar el formulario
            await CargarCategorias();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic no sea en una celda de encabezado
            if (e.RowIndex >= 0)
            {
                // Obtén el ID de la categoría que fue clickeada
                var categoryId = (int)dataGridView1.Rows[e.RowIndex].Cells["CategoryId"].Value;

                // Puedes realizar alguna acción con el ID, como mostrar detalles de la categoría
                MessageBox.Show($"ID de la categoría seleccionada: {categoryId}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private async Task CargarCategorias()
        {
            try
            {
                // Obtener las categorías desde el servicio
                var categorias = await _categoryService.GetCategoriesAsync();

                // Verificar si 'categorias' tiene datos
                if (categorias != null && categorias.Count > 0)
                {
                    // Limpiar cualquier dato anterior en el DataGridView
                    dataGridView1.DataSource = null;

                    // Asignar las categorías al DataGridView
                    dataGridView1.DataSource = categorias;

                    // Asegurarnos de que AutoGenerateColumns esté activado y configurado correctamente
                    dataGridView1.AutoGenerateColumns = true;

                    // Personalizar el encabezado de las columnas
                    dataGridView1.Columns["CategoryId"].HeaderText = "ID";
                    dataGridView1.Columns["Name"].HeaderText = "Nombre";

                    // Si deseas ocultar la columna CategoryId (opcional)
                    // dataGridView1.Columns["CategoryId"].Visible = false;

                }
                else
                {
                    MessageBox.Show("No se encontraron categorías.");
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si algo sale mal
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}");
            }
        }
    }
}
