using System;
using System.Windows.Forms;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Gerente
{
    public partial class GerentePrincipal : Form
    {
        public GerentePrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*Los siguientes metodos hacen referencia a los eventos del menu que esta presente
         en la ventana de gerente estos dirigen hacia las ventanas de consultar libros,
        venta y pedidos*/ 
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void consultarLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarLibro bucarLibro = new ConsultarLibro();
            bucarLibro.Show();
            this.Hide();
        }

        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarVentas consultarVentas = new ConsultarVentas();
            consultarVentas.Show();
            this.Hide();
        }

        private void consultarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarPedido consultarPedido = new ConsultarPedido();
            consultarPedido.Show();
            this.Hide();
        }
    }
}
