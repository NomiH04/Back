using System;
using System.Windows.Forms;
using LibreriaBoscoso.Views.Gerente;

namespace LibreriaBoscoso
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new ConsultarLibro());
=======

            Application.Run(new Catalogo());

>>>>>>> beb6ed0898577fe3f9e5808a52b2df446d6ada52
        }
    }
}
