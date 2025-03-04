﻿using System;
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
        int idPedidoSeleccionado = -1;
        public ConsultarPedido()
        {
            InitializeComponent();
            _orderService = new OrderService();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos(); //se creo un metodo que cargue todos los datos a la tabla
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
            //se hace una validacion para que el usuario ya sea que escriba el ID del pedido o elija una fila de tabla
            //que desea ver a detalle 
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text) && int.TryParse(txtBuscar.Text, out int idDesdeTextbox))
            {
                idPedidoSeleccionado = idDesdeTextbox;
            }
            else
            {
                // Si no se ingresó un ID válido en el TextBox, obtener el ID seleccionado en la tabla
                idPedidoSeleccionado = ObtenerIdSeleccionado();
            }

            if (idPedidoSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un libro de la tabla o ingrese un ID válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            VerPedido verPedido = new VerPedido(idPedidoSeleccionado);//se llama a la ventana pedidos y se le ingresa por parametro el id a mostrar
            verPedido.Show();
            this.Hide();
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
            //se hace la validacion de que el campo requiere del ID parea iniciar la busqueda
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Ingrese el ID del pedido para buscar en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //y se verifica que sea un numero valido
            if (!int.TryParse(txtBuscar.Text, out int id))
            {
                MessageBox.Show("El ID debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //se llama al metodo para obtener el pedido por medio del ID
                var order = await _orderService.GetOrderByIdAsync(id);
                //se verifica que el ID que se pasa no este vacio 
                if (order != null)
                {
                    //y se coloca en la tabla para mostrar 
                    dataPedidos.DataSource = new List<Order> { order };
                }
                else
                {
                    //en caso de no encontrar se envia un mensaje
                    MessageBox.Show("No se encontró un pedido con el ID ingresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // en caso de que ocurra un error sera capturado y se envia un mensaje
                MessageBox.Show($"Error al obtener el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void CargarDatos()
        {
            try
            {
                // Instanciar la clase que contiene el método GetOrdersAsync
                var service = new OrderService(); 

                // Obtener la lista de órdenes
                var orders = await service.GetOrdersAsync();

                // Asignar la lista de órdenes al DataGridView
                dataPedidos.DataSource = orders;
            }
            catch (Exception ex)
            {
                //se envia un mensaje en caso de error
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //se habilito una boton para vaciar el textbox y deseleccionar la tabla
            CargarDatos();
            txtBuscar.Text = "";
        }

        private void dataPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que no se haga clic en el encabezado
            {
                DataGridViewRow filaSeleccionada = dataPedidos.Rows[e.RowIndex];

                // Verificar que la celda no sea nula antes de convertirla a int
                if (filaSeleccionada.Cells[0].Value != null)
                {
                    idPedidoSeleccionado = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                }
            }
        }

        private int ObtenerIdSeleccionado()
        {
            return idPedidoSeleccionado;//se obtiene el ID de la fila seleccionada en la tabla
        }
    }
}



