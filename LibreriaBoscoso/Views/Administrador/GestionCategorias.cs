using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Administrador
{
    public partial class GestionCategorias : Form
    {
        private readonly CategoryService _categoryService;
        private List<Category> _categoriasOriginales = new List<Category>();

        public GestionCategorias()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarCategorias();
        }

        private async Task CargarCategorias()
        {
            try
            {
                dataGridView1.SuspendLayout();

                var categorias = await _categoryService.GetCategoriesAsync();
                if (categorias != null && categorias.Any())
                {
                    _categoriasOriginales = categorias;

                    dataGridView1.DataSource = null;
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "CategoryId",
                        HeaderText = "ID",
                        Name = "CategoryId"
                    });
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Name",
                        HeaderText = "Nombre",
                        Name = "Name"
                    });

                    dataGridView1.DataSource = _categoriasOriginales;
                }
                else
                {
                    MessageBox.Show("No se encontraron categorías.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}");
            }
            finally
            {
                dataGridView1.ResumeLayout();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;

                if (dataGridView1.Columns.Contains("CategoryId") &&
                    dataGridView1.Rows[e.RowIndex].Cells["CategoryId"].Value != null)
                {
                    int categoryId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CategoryId"].Value);
                    MessageBox.Show($"ID de la categoría seleccionada: {categoryId}");

                    dataGridView1.FirstDisplayedScrollingRowIndex = e.RowIndex;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Agregar_Click_1(object sender, EventArgs e)
        {
            string categoriaNombre = txt_Nombre_Categoria.Text.Trim();
            if (!string.IsNullOrEmpty(categoriaNombre))
            {
                var newCategory = new Category { Name = categoriaNombre };
                try
                {
                    bool isAdded = await _categoryService.AddCategoryAsync(newCategory);
                    if (isAdded)
                    {
                        MessageBox.Show("Categoría agregada correctamente.");
                        txt_Nombre_Categoria.Clear();
                        await CargarCategorias();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la categoría. Puede que ya exista.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar la categoría: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor ingresa un nombre para la categoría.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_eliminar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int categoryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["CategoryId"].Value);

            var confirmResult = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta categoría?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                await _categoryService.DeleteCategoryAsync(categoryId);
                MessageBox.Show("Categoría eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            string filtro = textBox6.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                dataGridView1.DataSource = new List<Category>(_categoriasOriginales);
            }
            else
            {
                var categoriasFiltradas = _categoriasOriginales
                    .Where(c => c.Name.ToLower().Contains(filtro))
                    .ToList();

                dataGridView1.DataSource = categoriasFiltradas;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios();
            gestionUsuarios.Show();
            this.Hide();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consultarLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteVentas reporteVentas = new ReporteVentas();
            reporteVentas.Show();
            this.Hide();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportesInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteInventarioGlobal reporteInventarioGlobal = new ReporteInventarioGlobal();
            reporteInventarioGlobal.Show();
            this.Hide();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consultarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios();
            gestionUsuarios.Show();
            this.Hide();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_actualizar_categoria_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría para actualizar.");
                return;
            }

            int categoryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["CategoryId"].Value);
            string nuevoNombre = txt_Nombre_Categoria.Text.Trim();

            if (string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("Por favor, ingrese un nuevo nombre para la categoría.");
                return;
            }

            var categoriaActualizada = new Category { CategoryId = categoryId, Name = nuevoNombre };

            try
            {
                bool actualizado = await _categoryService.UpdateCategoryAsync(categoriaActualizada);
                if (actualizado)
                {
                    MessageBox.Show("Categoría actualizada correctamente.");
                    txt_Nombre_Categoria.Clear();
                    await CargarCategorias();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la categoría.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la categoría: {ex.Message}");
            }
        }

       
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            AdministradorPrincipal principal = new AdministradorPrincipal();
            principal.Show();
            this.Hide();
        }
    }
}
