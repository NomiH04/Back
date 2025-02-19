using System;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Administrador
{
    public partial class GestionUsuarios : Form
    {
        public GestionUsuarios()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificamos si el clic fue en una celda de datos, no en los encabezados de columna
                if (e.RowIndex >= 0)
                {
                    // Obtenemos el usuario seleccionado en la fila
                    var selectedUser = (User)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                    // Rellenamos los TextBox con los datos del usuario seleccionado
                    textBox2.Text = selectedUser.Name;  // Nombre
                    textBox4.Text = selectedUser.Email; // Correo
                    textBox5.Text = selectedUser.Pass;  // Contraseña
                                                        // Puedes seleccionar el rol, si tienes una forma de hacerlo en el formulario
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar el usuario: {ex.Message}");
            }
        }

    }
}
