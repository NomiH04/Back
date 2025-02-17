using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Views.Administrador;
using LibreriaBoscoso.Views.Gerente;
using LibreriaBoscoso.Views.Proveedor;

namespace LibreriaBoscoso.Views.InicioLogin
{
    public partial class Login : Form
    {
        private readonly HttpClient _httpClient;

        public Login()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7021/api/User/") };
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }

        private void AbrirVentanaPorRol(string role)
        {
            Form ventana = null;

            switch (role.ToLower()) // Convertimos a minúsculas para evitar errores de comparación
            {
                case "Seller":
                    ventana = new VendedorPrincipal();
                    break;
                case "Manager":
                    ventana = new GerentePrincipal();
                    break;
                case "Admin":
                    ventana = new AdministradorPrincipal();
                    break;
                case "Supplier":
                    ventana = new ProveedorPrincipal();
                    break;
                default:
                    MessageBox.Show("Rol no reconocido. Contacte con soporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            ventana.Show();
            this.Hide(); // Oculta el formulario de login
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            txtUsuario.Clear();
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            txtContrasena.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private async void Loginbtn_Click(object sender, EventArgs e)
        {
            string email = txtUsuario.Text;
            string password = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var loginData = new { Email = email, Password = password };
                var response = await _httpClient.PostAsJsonAsync("login", loginData);

                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<User>();

                    MessageBox.Show($"Bienvenido {user.Name}", "Acceso permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrir la ventana según el rol del usuario
                    AbrirVentanaPorRol(user.Role);
                }
                else
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error en el login: {response.StatusCode}\n{errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
