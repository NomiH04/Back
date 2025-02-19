using System;
using System.Windows.Forms;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Gerente
{
    public partial class VerPedido : Form
    {
        int id;
        private readonly OrderService _orderService = new OrderService();
        public VerPedido(int id)
        {
            InitializeComponent();
            this.id = id;
            this.CargarDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void consultarLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarLibro consultarLibro = new ConsultarLibro();
            consultarLibro.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultarPedido consultarPedido1 = new ConsultarPedido();
            consultarPedido1.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private async void CargarDatos()
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            lbVenta.Text = id.ToString();
            lbFecha.Text = order.OrderDate?.ToString("dd/MM/yyyy") ?? "Sin fecha";
            txtVendedor.Text = order.UserId.ToString();
            txtStatus.Text = order.Status.ToString();

        }
    }
}
