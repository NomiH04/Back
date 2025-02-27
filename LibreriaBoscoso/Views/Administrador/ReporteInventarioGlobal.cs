using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using LibreriaBoscoso.Views.InicioLogin;
using LibreriaBoscoso.Views.Proveedor;

namespace LibreriaBoscoso.Views.Administrador
{
    public partial class ReporteInventarioGlobal : Form
    {
        private readonly InventoryService _inventoryService;
        private List<Inventory> _inventoryList;

        public ReporteInventarioGlobal()
        {
            InitializeComponent();
            _inventoryService = new InventoryService();
            _inventoryList = new List<Inventory>();
        }

        private async void ReporteInventarioGlobal_Load(object sender, EventArgs e)
        {
            await CargarInventario();
        }

        private async Task CargarInventario()
        {
            try
            {
                _inventoryList = await _inventoryService.GetInventoryAsync();
                Console.WriteLine($"Inventarios obtenidos: {_inventoryList.Count}"); // Depuración

                if (_inventoryList == null || _inventoryList.Count == 0)
                {
                    MessageBox.Show("No hay inventarios disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Asignar datos al DataGridView
                dgv_Inventario.DataSource = null;
                dgv_Inventario.Columns.Clear();
                dgv_Inventario.AutoGenerateColumns = true;
                dgv_Inventario.DataSource = _inventoryList;



                // Configurar encabezados de columnas
                if (dgv_Inventario.Columns["Quantity"] != null)
                    dgv_Inventario.Columns["Quantity"].HeaderText = "Cantidad";
                if (dgv_Inventario.Columns["StoreId"] != null)
                    dgv_Inventario.Columns["StoreId"].HeaderText = "ID Tienda";

                // Ajustar ancho de columnas
                foreach (DataGridViewColumn column in dgv_Inventario.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                dgv_Inventario.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            AdministradorPrincipal administradorPrincipal = new AdministradorPrincipal();
            administradorPrincipal.Show();
            this.Hide();
        }

      

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Seguro que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private async Task FiltrarInventario(string filtro)
        {
            try
            {
                // Obtener todos los registros de inventario desde el servicio de manera asíncrona
                List<Inventory> allInventory = await _inventoryService.GetInventoryAsync();

                // Filtrar los registros de inventario por BookId o StoreId si el filtro no está vacío
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    allInventory = allInventory
                        .Where(i => i.StoreId.ToString().Contains(filtro))
                        .ToList();
                }

                // Asignar los resultados filtrados al DataGridView
                dgv_Inventario.DataSource = allInventory;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar el inventario: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Evento del botón de buscar
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string filtro = txt_Buscador.Text.Trim(); // Obtener el texto del buscador
            FiltrarInventario(filtro); // Llamar al método para filtrar los inventarios
        }

        // Limpia el TextBox cuando entra (si tiene el valor por defecto)
        private void txt_Buscador_Enter(object sender, EventArgs e)
        {
            if (txt_Buscador.Text == "Buscar")
            {
                txt_Buscador.Clear(); // Limpiar el texto por defecto
            }
        }

        // Vuelve a poner el texto "Buscar" cuando se sale del TextBox y está vacío
        private void txt_Buscador_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Buscador.Text))
            {
                txt_Buscador.Text = "Buscar"; // Volver a poner "Buscar" si está vacío
            }
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            try
            {
                // 📂 Obtener la ruta de la carpeta "Descargas"
                string rutaDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string rutaArchivo = Path.Combine(rutaDescargas, "ReporteInventario_Boscoso.pdf");

                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // 📌 Título con el nombre de la empresa
                    Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, new BaseColor(0, 128, 0)); // Verde corporativo
                    Paragraph titulo = new Paragraph("📚 Reporte de Inventario - Boscoso 📚\n\n", tituloFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(titulo);

                    // 📆 Fecha y hora de generación
                    Font fechaFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.DARK_GRAY);
                    Paragraph fecha = new Paragraph($"📅 Generado el: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n", fechaFont)
                    {
                        Alignment = Element.ALIGN_RIGHT
                    };
                    doc.Add(fecha);

                    // 📌 Obtener las columnas del DataGridView
                    int numColumnas = dgv_Inventario.Columns.Count;
                    PdfPTable tabla = new PdfPTable(numColumnas) { WidthPercentage = 100 };

                    // Definir anchos de columna dinámicamente
                    float[] anchos = Enumerable.Repeat(100f / numColumnas, numColumnas).ToArray();
                    tabla.SetWidths(anchos);

                    // 🎨 Estilos
                    Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                    BaseColor headerColor = new BaseColor(0, 128, 0); // Verde corporativo
                    Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                    // 📌 Agregar encabezados
                    foreach (DataGridViewColumn columna in dgv_Inventario.Columns)
                    {
                        PdfPCell celdaEncabezado = new PdfPCell(new Phrase(columna.HeaderText, headerFont))
                        {
                            BackgroundColor = headerColor,
                            Padding = 5,
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                        tabla.AddCell(celdaEncabezado);
                    }

                    // 📌 Agregar filas de datos
                    foreach (DataGridViewRow fila in dgv_Inventario.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            foreach (DataGridViewCell celda in fila.Cells)
                            {
                                string texto = celda.Value?.ToString() ?? "";
                                PdfPCell celdaDato = new PdfPCell(new Phrase(texto, cellFont))
                                {
                                    Padding = 5,
                                    HorizontalAlignment = Element.ALIGN_CENTER
                                };
                                tabla.AddCell(celdaDato);
                            }
                        }
                    }

                    doc.Add(tabla);

                    // 📌 Pie de página con nombre de la empresa
                    Font footerFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
                    Paragraph footer = new Paragraph("\n📌 Boscoso - Todos los derechos reservados", footerFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(footer);

                    doc.Close();
                }

                MessageBox.Show($"✅ Reporte generado correctamente en:\n{rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() { FileName = rutaArchivo, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al generar el PDF:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }












        private void GestionUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios();
            gestionUsuarios.Show();
            this.Hide();
        }

        private void ReporteVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteVentas reporteVentas = new ReporteVentas();
            reporteVentas.Show();
            this.Hide();
        }
        private void reportesInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ya estás en el reporte de inventario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void GestionTiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionTiendas aws = new GestionTiendas();
            aws.Show();
            this.Hide();
        }

        private void gestionarCategoriasLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionCategorias gestionCategorias = new GestionCategorias();
            gestionCategorias.Show();
            this.Hide();
        }

    }
}