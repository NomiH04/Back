﻿using System;
using System.Windows.Forms;
using LibreriaBoscoso.Views.InicioLogin;

namespace LibreriaBoscoso.Views.Administrador
{
    public partial class AdministradorPrincipal : Form
    {
        public AdministradorPrincipal()
        {
            InitializeComponent();
            Rolelb.Text = "Admin";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void consultarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios();
            gestionUsuarios.Show();
            this.Hide();
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

        private void librosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Rolelb_Click(object sender, EventArgs e)
        {

        }
    }
}
