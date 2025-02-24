using System;
using System.Windows.Forms;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Gerente
{
    public partial class VerVenta : Form
    {
        int id;
        private readonly SaleService _saleService = new SaleService();
        public VerVenta(int id)
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
            ConsultarVentas consultarVentas1 = new ConsultarVentas();
            consultarVentas1.Show();
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
            var sale = await _saleService.GetSaleByIdAsync(id);

            lbNumVenta.Text = sale.SaleId.ToString();
            lbFecha.Text = sale.SaleDate?.ToString("dd/MM/yyyy");
            txtVendedor.Text = sale.UserId.ToString();
            txtTienda.Text = sale.StoreId.ToString();
            txtMonto.Text = sale.Total.ToString();
        }
    }
}
