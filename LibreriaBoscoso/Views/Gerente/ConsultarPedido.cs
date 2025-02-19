using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Gerente
{
    public partial class ConsultarPedido : Form
    {
        private OrderService _orderService; // se hace una instancia de la clase orden service para extraer los datos de la api
        public ConsultarPedido()
        {
            InitializeComponent();
            _orderService = new OrderService();  // Se asume que ya existe y está configurado
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos(); //se creo un metodo que carga todos los datos a la tabla
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

        //con el boton ver damos accion para pasar a la ventana Ver Pedido
        private async void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text) || !int.TryParse(txtBuscar.Text, out int id))
            {
                //valida que el dato que se esta ingresando sea un int, ademas se asegura de que el campo no este vacio para realizar la accion
                MessageBox.Show("El campo debe contener un ID valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //antes de que ingresar busca si el id que se esta ingresando en la base de datos o si esta esta vacia o no
            var order = await _orderService.GetOrderByIdAsync(id);

            //verifica que el objeto creado para extraer los datos no sea null y que coincida con el id ingresado
            if (order != null && order.OrderId == id)
            {
                VerPedido verPedido = new VerPedido(id);//se llama a la ventana pedidos y se le ingresa por parametro el id a mostrar
                verPedido.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se encontró un pedido con el ID ingresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBuscar.Text = "";
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GerentePrincipal gerentePrincipal = new GerentePrincipal();
            gerentePrincipal.Show();
            this.Hide();
        }

        //con el boton buscar extraemos la informacion del pedido a buscar
        private async void button2_Click(object sender, EventArgs e) //boton buscar
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Ingrese el ID del pedido para buscar en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtBuscar.Text, out int id))
            {
                MessageBox.Show("El ID debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);

                if (order != null)
                {
                    dataPedidos.DataSource = new List<Order> { order };
                }
                else
                {
                    MessageBox.Show("No se encontró un pedido con el ID ingresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void CargarDatos()
        {
            try
            {
                // Instanciar la clase que contiene el método GetOrdersAsync
                var service = new OrderService(); // 

                // Obtener la lista de órdenes
                var orders = await service.GetOrdersAsync();

                // Asignar la lista de órdenes al DataGridView
                dataPedidos.DataSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
            txtBuscar.Text = "";
        }
    }
}



