using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Views.Administrador;
using LibreriaBoscoso.Views.Gerente;
using LibreriaBoscoso.Views.Proveedor;

namespace LibreriaBoscoso.Views.InicioLogin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string password = txtContrasena.Text;

            if (user == "admin" && password == "admin123")
            {
                AbrirVentana<AdministradorPrincipal>("Bienvenido, Administrador");
            }
            else if (user == "gerente" && password == "gerente456")
            {
                AbrirVentana<GerentePrincipal>("Bienvenido, Gerente");
            }
            else if (user == "vendedor" && password == "vendedor789")
            {
                AbrirVentana<VendedorPrincipal>("Bienvenido, Vendedor");
            }
            else if (user == "proveedor" && password == "proveedor012")
            {
                AbrirVentana<ProveedorPrincipal>("Bienvenido, Proovedor");
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        // Función para abrir ventanas
        private void AbrirVentana<T>(string mensaje) where T : Form, new()
        {
            T ventana = new T();
            MessageBox.Show(mensaje);
            ventana.Show();
            this.Hide();
        }


        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            txtUsuario.Clear();
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            txtContrasena.Clear();
        }
    }
}
