using System;
using System.Linq;
using System.Windows.Forms;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.Gerente;

namespace LibreriaBoscoso.Views
{
    public partial class ModuloConfirmacion : Form
    {
        int idLibro;
        private BookService _bookService;
        public ModuloConfirmacion(int idLibro)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _bookService = new BookService();
            this.idLibro = idLibro;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //Metodo que reconoce la accion de confirmar que el libro seleccionado sera eliminado
        private async void button1_Click(object sender, EventArgs e)
        {
            bool eliminado = await _bookService.DeleteBookByIdAsync(idLibro);

            if (eliminado)
            {
                MessageBox.Show("Libro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la tabla para reflejar los cambios
                var formularioPrincipal = Application.OpenForms.OfType<ConsultarLibro>().FirstOrDefault();
                formularioPrincipal?.Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el libro. Verifique e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
