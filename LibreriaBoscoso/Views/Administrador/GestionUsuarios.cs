using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Administrador
{
    public partial class GestionUsuarios : Form
    {
        private readonly UserService _userService;
        private bool isAddingUser = false; // Flag para indicar cuando estamos agregando un usuario
        private List<User> allUsers;

        public GestionUsuarios()
        {
            InitializeComponent();
            _userService = new UserService();  // Inicializamos el servicio
        }

        // Método para cargar los usuarios en el DataGridView al iniciar el formulario
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                allUsers = users; // Guardamos todos los usuarios
                if (users != null && users.Count > 0)
                {
                    // Configurar las columnas del DataGridView
                    ConfigureDataGridView();
                    // Asignar los usuarios al DataGridView
                    dataGridView1.DataSource = users;
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los usuarios.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}");
            }
        }

        // Método para obtener el rol seleccionado del usuario
        private string GetSelectedRole()
        {
            if (Admin.Checked) return "Admin";
            if (Manager.Checked) return "Manager";
            if (Supplier.Checked) return "Supplier";
            if (Seller.Checked) return "Seller";

            return "User";  // Valor por defecto si no se selecciona ningún rol
        }

        // Método para crear un nuevo usuario
        private async void button2_Click_1(object sender, EventArgs e)
        {
            // Validar los datos antes de proceder
            if (string.IsNullOrWhiteSpace(txt_Nombre.Text) || string.IsNullOrWhiteSpace(txt_Email.Text) || string.IsNullOrWhiteSpace(txt_Contrasena.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            var newUser = new User
            {
                Name = txt_Nombre.Text,
                Email = txt_Email.Text,
                Pass = txt_Contrasena.Text,
                Role = GetSelectedRole() // Asegúrate de que este método obtiene el rol correctamente
            };

            try
            {
                // Indicamos que estamos agregando un usuario
                isAddingUser = true;

                // Llamamos al servicio para crear el nuevo usuario
                bool isSuccess = await _userService.CreateUserAsync(newUser);

                if (isSuccess)
                {
                    MessageBox.Show("Usuario creado correctamente.");
                    // Recargamos los usuarios en el DataGridView
                    var users = await _userService.GetUsersAsync();
                    allUsers = users; // Guardamos los usuarios nuevamente
                    dataGridView1.DataSource = users;
                }
                else
                {
                    MessageBox.Show("Hubo un error al crear el usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el usuario: {ex.Message}");
            }
            finally
            {
                // Restablecemos el flag después de la adición
                isAddingUser = false;
            }
        }

        // Método para filtrar la búsqueda por nombre de usuario o correo electrónico
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchQuery = txt_Buscar.Text.Trim().ToLower();  // Convertimos el texto a minúsculas

                // Si el campo de búsqueda está vacío, mostramos todos los usuarios
                if (string.IsNullOrEmpty(searchQuery))
                {
                    dataGridView1.DataSource = allUsers;  // Recargamos todos los usuarios
                }
                else
                {
                    // Filtramos los usuarios por nombre o correo electrónico
                    var filteredUsers = allUsers.Where(user =>
                        user.Name.ToLower().Contains(searchQuery) ||
                        user.Email.ToLower().Contains(searchQuery)
                    ).ToList();

                    // Actualizamos el DataGridView con los resultados filtrados
                    dataGridView1.DataSource = filteredUsers;
                }

                // Aseguramos que las columnas se muestren correctamente
                dataGridView1.AutoGenerateColumns = true; // Generamos las columnas automáticamente si no están configuradas
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar los usuarios: {ex.Message}");
            }
        }

        // Método que configura las columnas del DataGridView
        private void ConfigureDataGridView()
        {
            // Configuración de las columnas del DataGridView
            this.dataGridView1.AutoGenerateColumns = false;  // Desactiva la generación automática de columnas

            // Limpiar las columnas previas
            this.dataGridView1.Columns.Clear();

            // Crear las columnas manualmente (sin incluir la columna 'Pass')
            var colId = new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "UserId",
                Visible = true // Hacemos visible la columna ID
            };

            var colName = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Name"
            };

            var colEmail = new DataGridViewTextBoxColumn
            {
                HeaderText = "Correo",
                DataPropertyName = "Email"
            };

            var colRole = new DataGridViewTextBoxColumn
            {
                HeaderText = "Rol",
                DataPropertyName = "Role"
            };

            // Agregar las columnas necesarias (sin la columna 'Pass')
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                colId,
                colName,
                colEmail,
                colRole
            });
        }

        private void consultarLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteVentas reporteVentas = new ReporteVentas();
            reporteVentas.Show();
            this.Hide();
        }

        private void reportesInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteInventarioGlobal reporteInventarioGlobal = new ReporteInventarioGlobal();
            reporteInventarioGlobal.Show();
            this.Hide();
        }

        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionTiendas gestionTiendas = new GestionTiendas();
            gestionTiendas.Show();
            this.Hide();
        }

        private void gestionarCategoriasLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionCategorias gestionCategorias = new GestionCategorias();
            gestionCategorias.Show();
            this.Hide();
        }

        private void consultarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios();
            gestionUsuarios.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdministradorPrincipal principal = new AdministradorPrincipal();
            principal.Show();
            this.Hide();
        }

        private async void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificamos si el clic fue en una celda de datos, no en los encabezados de columna
                if (e.RowIndex >= 0)
                {
                    // Obtenemos el usuario seleccionado en la fila
                    var selectedUser = (User)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                    // Rellenamos los TextBox con los datos del usuario seleccionado
                    txt_Nombre.Text = selectedUser.Name;  // Nombre
                    txt_Email.Text = selectedUser.Email; // Correo

                    // Deja el campo de la contraseña vacío (no lo mostramos)
                    txt_Contrasena.Text = "";  // No mostramos la contraseña

                    // Puedes seleccionar el rol, si tienes una forma de hacerlo en el formulario
                    Admin.Checked = selectedUser.Role == "Admin";
                    Manager.Checked = selectedUser.Role == "Manager";
                    Supplier.Checked = selectedUser.Role == "Supplier";
                    Seller.Checked = selectedUser.Role == "Seller";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar el usuario: {ex.Message}");
            }
        }




        private async void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario antes de eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId;
            try
            {
                // 🔹 Método 1: Obtenerlo por nombre de columna
                object value = dataGridView1.SelectedRows[0].Cells["UserId"].Value;
                Console.WriteLine($"Valor de UserId obtenido: {value}");

                // 🔹 Método 2: Si el nombre de la columna no funciona, probar con índice 0
                if (value == null)
                {
                    value = dataGridView1.SelectedRows[0].Cells[0].Value;
                    Console.WriteLine($"Valor de UserId obtenido por índice: {value}");
                }

                // 🔹 Convertir a int
                userId = Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el ID del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"¿Está seguro de que desea eliminar este usuario con ID {userId}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                bool eliminado = await _userService.DeleteUserAsync(userId);

                if (eliminado)
                {
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar la lista de usuarios en el DataGridView
                    var users = await _userService.GetUsersAsync();
                    dataGridView1.DataSource = users;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void btn_eliminar_Click1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario antes de eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = -1;
            try
            {
                // 🔹 Depurar: Mostrar todas las columnas disponibles
                Console.WriteLine("Columnas en DataGridView:");
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    Console.WriteLine($"Nombre: {col.Name}");
                }

                // 🔹 Intentar obtener el UserId por nombre de columna
                object value = dataGridView1.SelectedRows[0].Cells["UserId"].Value;
                Console.WriteLine($"Valor de UserId obtenido: {value}");

                // 🔹 Si no se obtiene, probar por índice 0
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    value = dataGridView1.SelectedRows[0].Cells[0].Value;
                    Console.WriteLine($"Valor de UserId obtenido por índice: {value}");
                }

                // 🔹 Intentar convertir a int
                userId = Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el ID del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userId <= 0)
            {
                MessageBox.Show("El ID del usuario no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmar eliminación
            var confirmResult = MessageBox.Show(
                $"¿Está seguro de que desea eliminar este usuario con ID {userId}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                bool eliminado = await _userService.DeleteUserAsync(userId);

                if (eliminado)
                {
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar la lista de usuarios en el DataGridView
                    var users = await _userService.GetUsersAsync();
                    dataGridView1.DataSource = users;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
