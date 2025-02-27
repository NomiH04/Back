using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Gerente
{
    public partial class VerPedido : Form
    {
        int id;
        private readonly OrderService _orderService = new OrderService();
        private readonly UserService _userService = new UserService();
        private readonly StoreService _storeService = new StoreService();
        private readonly BookService _bookService = new BookService();
        private readonly OrderDetailService _orderDetailService = new OrderDetailService();
        public VerPedido(int id)
        {
            InitializeComponent();
            this.id = id;  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
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
            //se llaman a los datos necesarios para obtener la informacion detallada del pedido
            var order = await _orderService.GetOrderByIdAsync(id); //al ser el principal se necesita para obtener mas informacion del pedido
            var user = await _userService.GetUserByIdAsync(order.UserId.Value);//se utiliza para extraer el nombre del vendedor por medio del ID proporcionado en el pedido
            var store = await _storeService.GetStoreByIdAsync(order.StoreId.Value);//tambien se utiliza el ID de la orden para obtener el nombre de la tienda

            //se cargan los datos en sus respectivos campos
            lbVenta.Text = id.ToString();
            lbFecha.Text = order.OrderDate?.ToString("dd/MM/yyyy");
            txtVendedor.Text = user.Name;
            txtStatus.Text = order.Status.ToString();
            txtStore.Text = store.Name;
        }//Fin Cargar Datos
    }
}
