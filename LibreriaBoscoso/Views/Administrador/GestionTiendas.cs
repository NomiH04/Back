﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaBoscoso.Views.InicioLogin;


using LibreriaBoscoso.Models;
using LibreriaBoscoso.Services;
using System.Windows.Forms.Design;

namespace LibreriaBoscoso.Views.Administrador
{
    public partial class GestionTiendas : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
