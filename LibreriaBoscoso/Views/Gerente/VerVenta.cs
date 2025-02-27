using System;
using System.Windows.Forms;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Gerente
{
    public partial class VerVenta : Form
    {
        int id;
        private readonly SaleService _saleService;
        private readonly UserService _userService;
        private readonly StoreService _storeService;
        public VerVenta(int id)
        {
            InitializeComponent();
            this.id = id;
            
            _saleService = new SaleService();
            _userService = new UserService();
            _storeService = new StoreService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            CargarDatos();
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
            //se llaman a los datos necesarios para obtener la informacion detallada del pedido
            var sale = await _saleService.GetSaleByIdAsync(id);//al ser el principal se necesita para obtener mas informacion del pedido
            var user = await _userService.GetUserByIdAsync(sale.UserId.Value);//se utiliza para extraer el nombre del vendedor por medio del ID proporcionado en el pedido
            var store = await _storeService.GetStoreByIdAsync(sale.StoreId.Value);//tambien se utiliza el ID de la orden para obtener el nombre de la tienda

            //se cargan los datos en sus respectivos campos
            lbNumVenta.Text = sale.SaleId.ToString();
            lbFecha.Text = sale.SaleDate?.ToString("dd/MM/yyyy");
            txtVendedor.Text = user.Name;
            txtTienda.Text = store.Name;
            txtMonto.Text = sale.Total.ToString();
        }
    }
}
