using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Proveedor
{
    public partial class ProveedorPedidos : Form
    {
        public ProveedorPedidos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ProveedorPrincipal proveedorPrincipal = new ProveedorPrincipal();
            proveedorPrincipal.Show();
            this.Hide();
        }

        // Los siguientes métodos se encargan de la navegación entre formularios
        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorialPedidos historialPedidos = new HistorialPedidos();
            historialPedidos.Show();
            this.Hide();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProveedorPedidos proveedorPedidos = new ProveedorPedidos();
            proveedorPedidos.Show();
            this.Hide();
        }

        private void catalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogo catalogo = new Catalogo();
            catalogo.Show();
            this.Hide();
        }

        
    }
}
