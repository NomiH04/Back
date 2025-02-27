using System;
using System.Windows.Forms;
using LibreriaBoscoso.Views.Administrador;
using LibreriaBoscoso.Views.Gerente;
using LibreriaBoscoso.Views.Proveedor;
using LibreriaBoscoso.Views.Vendedor;

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
            Application.Run(new GerentePrincipal());
        }
    }
}
