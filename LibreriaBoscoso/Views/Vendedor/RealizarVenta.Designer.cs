﻿using System.Windows.Forms;

namespace LibreriaBoscoso.Views.Vendedor
{
    partial class RealizarVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_Rol = new System.Windows.Forms.Label();
            this.label_Usuario = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.librosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultar_Stock_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizar_Venta_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizar_Pedido_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_Libros = new System.Windows.Forms.DataGridView();
            this.btn_Agregar_Libro = new System.Windows.Forms.Button();
            this.btn_Finalizar_Venta = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label_Total = new System.Windows.Forms.Label();
            this.txt_Buscador = new System.Windows.Forms.TextBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Libros)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Rol
            // 
            this.label_Rol.AutoSize = true;
            this.label_Rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rol.Location = new System.Drawing.Point(749, 54);
            this.label_Rol.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Rol.Name = "label_Rol";
            this.label_Rol.Size = new System.Drawing.Size(29, 15);
            this.label_Rol.TabIndex = 11;
            this.label_Rol.Text = "Rol";
            // 
            // label_Usuario
            // 
            this.label_Usuario.AutoSize = true;
            this.label_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Usuario.Location = new System.Drawing.Point(684, 54);
            this.label_Usuario.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Usuario.Name = "label_Usuario";
            this.label_Usuario.Size = new System.Drawing.Size(57, 15);
            this.label_Usuario.TabIndex = 10;
            this.label_Usuario.Text = "Usuario";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(678, 0);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(1);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(122, 37);
            this.btnCerrarSesion.TabIndex = 9;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscar.Location = new System.Drawing.Point(454, 8);
            this.txt_Buscar.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(190, 25);
            this.txt_Buscar.TabIndex = 8;
            this.txt_Buscar.Text = "Buscar";
            this.txt_Buscar.Enter += new System.EventHandler(this.txt_Buscar_Enter);
            this.txt_Buscar.Leave += new System.EventHandler(this.txt_Buscar_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.librosToolStripMenuItem,
            this.ventaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(802, 38);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // librosToolStripMenuItem
            // 
            this.librosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultar_Stock_ToolStripMenuItem});
            this.librosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.librosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            this.librosToolStripMenuItem.Size = new System.Drawing.Size(91, 36);
            this.librosToolStripMenuItem.Text = "Libros";
            // 
            // consultar_Stock_ToolStripMenuItem
            // 
            this.consultar_Stock_ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.consultar_Stock_ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultar_Stock_ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.consultar_Stock_ToolStripMenuItem.Name = "consultar_Stock_ToolStripMenuItem";
            this.consultar_Stock_ToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.consultar_Stock_ToolStripMenuItem.Text = "Consultar Stock";
            this.consultar_Stock_ToolStripMenuItem.Click += new System.EventHandler(this.consultar_Stock_ToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realizar_Venta_ToolStripMenuItem,
            this.realizar_Pedido_ToolStripMenuItem});
            this.ventaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(88, 36);
            this.ventaToolStripMenuItem.Text = "Venta";
            // 
            // realizar_Venta_ToolStripMenuItem
            // 
            this.realizar_Venta_ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.realizar_Venta_ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realizar_Venta_ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.realizar_Venta_ToolStripMenuItem.Name = "realizar_Venta_ToolStripMenuItem";
            this.realizar_Venta_ToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.realizar_Venta_ToolStripMenuItem.Text = "Realizar Venta";
            this.realizar_Venta_ToolStripMenuItem.Click += new System.EventHandler(this.realizar_Venta_ToolStripMenuItem_Click);
            // 
            // realizar_Pedido_ToolStripMenuItem
            // 
            this.realizar_Pedido_ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.realizar_Pedido_ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realizar_Pedido_ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.realizar_Pedido_ToolStripMenuItem.Name = "realizar_Pedido_ToolStripMenuItem";
            this.realizar_Pedido_ToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.realizar_Pedido_ToolStripMenuItem.Text = "Realizar Pedido";
            this.realizar_Pedido_ToolStripMenuItem.Click += new System.EventHandler(this.realizar_Pedido_ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(697, 426);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 24);
            this.button1.TabIndex = 57;
            this.button1.Text = "Accesibilidad";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem,
            this.facebookToolStripMenuItem,
            this.twitterToolStripMenuItem,
            this.instagramToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 411);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip2.Size = new System.Drawing.Size(802, 46);
            this.menuStrip2.TabIndex = 56;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acercaDeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(89, 44);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // facebookToolStripMenuItem
            // 
            this.facebookToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.facebookToolStripMenuItem.Image = global::LibreriaBoscoso.Properties.Resources._5305154_fb_facebook_facebook_logo_icon;
            this.facebookToolStripMenuItem.Name = "facebookToolStripMenuItem";
            this.facebookToolStripMenuItem.Size = new System.Drawing.Size(52, 44);
            // 
            // twitterToolStripMenuItem
            // 
            this.twitterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.twitterToolStripMenuItem.Image = global::LibreriaBoscoso.Properties.Resources._104501_twitter_bird_icon;
            this.twitterToolStripMenuItem.Name = "twitterToolStripMenuItem";
            this.twitterToolStripMenuItem.Size = new System.Drawing.Size(52, 44);
            // 
            // instagramToolStripMenuItem
            // 
            this.instagramToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.instagramToolStripMenuItem.Image = global::LibreriaBoscoso.Properties.Resources._5279112_camera_instagram_social_media_instagram_logo_icon;
            this.instagramToolStripMenuItem.Name = "instagramToolStripMenuItem";
            this.instagramToolStripMenuItem.Size = new System.Drawing.Size(52, 44);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 25);
            this.label5.TabIndex = 60;
            this.label5.Text = "Libros Agregados";
            // 
            // dgv_Libros
            // 
            this.dgv_Libros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Libros.Location = new System.Drawing.Point(46, 169);
            this.dgv_Libros.Margin = new System.Windows.Forms.Padding(1);
            this.dgv_Libros.Name = "dgv_Libros";
            this.dgv_Libros.ReadOnly = true;
            this.dgv_Libros.RowHeadersWidth = 102;
            this.dgv_Libros.RowTemplate.Height = 40;
            this.dgv_Libros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Libros.Size = new System.Drawing.Size(701, 138);
            this.dgv_Libros.TabIndex = 61;
            this.dgv_Libros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Libros_CellClick);
            // 
            // btn_Agregar_Libro
            // 
            this.btn_Agregar_Libro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Agregar_Libro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Agregar_Libro.Location = new System.Drawing.Point(46, 318);
            this.btn_Agregar_Libro.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Agregar_Libro.Name = "btn_Agregar_Libro";
            this.btn_Agregar_Libro.Size = new System.Drawing.Size(87, 34);
            this.btn_Agregar_Libro.TabIndex = 62;
            this.btn_Agregar_Libro.Text = "Agregar Libro";
            this.btn_Agregar_Libro.UseVisualStyleBackColor = false;
            this.btn_Agregar_Libro.Click += new System.EventHandler(this.btn_Agregar_Libro_Click);
            // 
            // btn_Finalizar_Venta
            // 
            this.btn_Finalizar_Venta.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Finalizar_Venta.ForeColor = System.Drawing.Color.White;
            this.btn_Finalizar_Venta.Location = new System.Drawing.Point(543, 352);
            this.btn_Finalizar_Venta.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Finalizar_Venta.Name = "btn_Finalizar_Venta";
            this.btn_Finalizar_Venta.Size = new System.Drawing.Size(87, 34);
            this.btn_Finalizar_Venta.TabIndex = 63;
            this.btn_Finalizar_Venta.Text = "Finalizar Venta";
            this.btn_Finalizar_Venta.UseVisualStyleBackColor = false;
            this.btn_Finalizar_Venta.Click += new System.EventHandler(this.btn_Finalizar_Venta_Click_1);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar.Location = new System.Drawing.Point(661, 352);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(87, 34);
            this.btn_Cancelar.TabIndex = 64;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(584, 318);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 25);
            this.label6.TabIndex = 65;
            this.label6.Text = "Total:";
            // 
            // label_Total
            // 
            this.label_Total.AutoSize = true;
            this.label_Total.Font = new System.Drawing.Font("Segoe UI", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Total.Location = new System.Drawing.Point(653, 318);
            this.label_Total.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(100, 25);
            this.label_Total.TabIndex = 66;
            this.label_Total.Text = "########";
            // 
            // txt_Buscador
            // 
            this.txt_Buscador.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscador.Location = new System.Drawing.Point(467, 138);
            this.txt_Buscador.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Buscador.Name = "txt_Buscador";
            this.txt_Buscador.Size = new System.Drawing.Size(190, 25);
            this.txt_Buscador.TabIndex = 67;
            this.txt_Buscador.Text = "Buscar";
            this.txt_Buscador.Enter += new System.EventHandler(this.txt_Buscador_Enter);
            this.txt_Buscador.Leave += new System.EventHandler(this.txt_Buscador_Leave);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.Gray;
            this.btn_Buscar.ForeColor = System.Drawing.Color.White;
            this.btn_Buscar.Location = new System.Drawing.Point(681, 133);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(66, 26);
            this.btn_Buscar.TabIndex = 68;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // RealizarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 457);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.txt_Buscador);
            this.Controls.Add(this.label_Total);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Finalizar_Venta);
            this.Controls.Add(this.btn_Agregar_Libro);
            this.Controls.Add(this.dgv_Libros);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.label_Rol);
            this.Controls.Add(this.label_Usuario);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.txt_Buscar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "RealizarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RealizarVenta";
            this.Load += new System.EventHandler(this.Realizar_Venta_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Libros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Rol;
        private System.Windows.Forms.Label label_Usuario;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem librosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultar_Stock_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizar_Venta_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizar_Pedido_ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instagramToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_Libros;
        private System.Windows.Forms.Button btn_Agregar_Libro;
        private System.Windows.Forms.Button btn_Finalizar_Venta;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.TextBox txt_Buscador;
        private System.Windows.Forms.Button btn_Buscar;
    }
}