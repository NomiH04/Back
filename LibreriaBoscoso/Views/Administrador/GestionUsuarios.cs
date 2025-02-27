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
            try
            {
                // 🔹 Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txt_Nombre.Text) ||
                    string.IsNullOrWhiteSpace(txt_Email.Text) ||
                    string.IsNullOrWhiteSpace(txt_Contrasena.Text))
                {
                    MessageBox.Show("❌ Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Validar que la contraseña tenga al menos 6 caracteres
                if (txt_Contrasena.Text.Length < 6)
                {
                    MessageBox.Show("❌ La contraseña debe tener al menos 6 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Validar que el campo de email sea valido
                if (txt_Email.Text.Length < 6)
                {
                    MessageBox.Show("❌ La contraseña debe tener al menos 6 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Validar que el email contenga un '@'
                if (!txt_Email.Text.Contains("@"))
                {
                    MessageBox.Show("❌ El correo electrónico debe contener un '@'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Obtener el rol seleccionado
                string role = GetSelectedRole();
                if (string.IsNullOrWhiteSpace(role))
                {
                    MessageBox.Show("❌ Seleccione un rol válido para el usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Crear el usuario con los datos del formulario
                var newUser = new User
                {
                    Name = txt_Nombre.Text.Trim(),
                    Email = txt_Email.Text.Trim(),
                    Pass = txt_Contrasena.Text.Trim(),
                    Role = role
                };

                // 🔹 Mostrar en consola los datos que se están enviando
                Console.WriteLine($"📤 Enviando usuario: {newUser.Name}, {newUser.Email}, {newUser.Pass}, {newUser.Role}");

                // 🔹 Marcar que se está agregando un usuario
                isAddingUser = true;

                // 🔹 Intentar crear el usuario
                bool isSuccess = await _userService.CreateUserAsync(newUser);

                if (isSuccess)
                {
                    MessageBox.Show("✅ Usuario creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🔹 Recargar la lista de usuarios en el DataGridView
                    var users = await _userService.GetUsersAsync();
                    allUsers = users; // Guardamos los usuarios nuevamente
                    dataGridView1.DataSource = users;
                }
                else
                {
                    MessageBox.Show("❌ No se pudo crear el usuario. Verifique los datos e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error inesperado al crear el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"❌ Excepción: {ex}");
            }
            finally
            {
                // 🔹 Restablecer la variable después de la adición
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


        private async void btn_actualizar_Usuario_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un usuario antes de actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Obtener el ID del usuario seleccionado en la DataGridView
                object value = null;
                if (dataGridView1.Columns.Contains("UserId"))
                {
                    value = dataGridView1.SelectedRows[0].Cells["UserId"].Value;
                }
                else
                {
                    // Si "UserId" no existe, intenta con la primera columna
                    value = dataGridView1.SelectedRows[0].Cells[0].Value;
                }

                if (value == null || value == DBNull.Value)
                {
                    MessageBox.Show("No se pudo obtener el ID del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int userId = Convert.ToInt32(value);
                Console.WriteLine($"🔹 Actualizando usuario con ID: {userId}");

                // 🔹 Validar los datos antes de enviar
                if (string.IsNullOrWhiteSpace(txt_Nombre.Text) || string.IsNullOrWhiteSpace(txt_Email.Text))
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios (Nombre y Email).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var updatedUser = new User
                {
                    UserId = userId,
                    Name = txt_Nombre.Text.Trim(),
                    Email = txt_Email.Text.Trim(),
                    Pass = string.IsNullOrEmpty(txt_Contrasena.Text) ? null : txt_Contrasena.Text.Trim(),
                    Role = GetSelectedRole()
                };

                bool actualizado = await _userService.UpdateUserAsync(userId, updatedUser);

                if (actualizado)
                {
                    MessageBox.Show("✅ Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🔹 Recargar usuarios en el DataGridView
                    var users = await _userService.GetUsersAsync();
                    dataGridView1.DataSource = users;
                }
                else
                {
                    MessageBox.Show("❌ No se pudo actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"❌ Excepción al actualizar usuario: {ex}");
            }
        }




        private async void btn_eliminar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario antes de eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId;
            try
            {
                // Verificar si "UserId" existe en las columnas
                string columnName = "UserId";
                if (!dataGridView1.Columns.Contains(columnName))
                {
                    // Intentar con la primera columna si "UserId" no existe
                    columnName = dataGridView1.Columns[0].Name;
                }

                object value = dataGridView1.SelectedRows[0].Cells[columnName].Value;

                if (value == null || value == DBNull.Value)
                {
                    MessageBox.Show("No se pudo obtener el ID del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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


  

    }
}
