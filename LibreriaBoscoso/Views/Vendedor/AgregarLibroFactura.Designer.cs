using System.Windows.Forms;

namespace LibreriaBoscoso.Views.Vendedor
{
    partial class AgregarLibroFactura
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
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_Buscador = new System.Windows.Forms.TextBox();
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.btn_Agregar_Libro = new System.Windows.Forms.Button();
            this.dgv_Libros_Disponibles = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label_Rol = new System.Windows.Forms.Label();
            this.label_Usuario = new System.Windows.Forms.Label();
            this.btn_Cerrar_Sesion = new System.Windows.Forms.Button();
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
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Cantidad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Libros_Disponibles)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.Gray;
            this.btn_Buscar.ForeColor = System.Drawing.Color.White;
            this.btn_Buscar.Location = new System.Drawing.Point(905, 153);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(88, 32);
            this.btn_Buscar.TabIndex = 84;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_Buscador
            // 
            this.txt_Buscador.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscador.Location = new System.Drawing.Point(620, 158);
            this.txt_Buscador.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Buscador.Name = "txt_Buscador";
            this.txt_Buscador.Size = new System.Drawing.Size(252, 29);
            this.txt_Buscador.TabIndex = 83;
            this.txt_Buscador.Text = "Buscar";
            this.txt_Buscador.Enter += new System.EventHandler(this.txt_Buscador_Enter);
            this.txt_Buscador.Leave += new System.EventHandler(this.txt_Buscador_Leave);
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Regresar.ForeColor = System.Drawing.Color.White;
            this.btn_Regresar.Location = new System.Drawing.Point(877, 380);
            this.btn_Regresar.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(116, 42);
            this.btn_Regresar.TabIndex = 80;
            this.btn_Regresar.Text = "Regresar";
            this.btn_Regresar.UseVisualStyleBackColor = false;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // btn_Agregar_Libro
            // 
            this.btn_Agregar_Libro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Agregar_Libro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Agregar_Libro.Location = new System.Drawing.Point(59, 380);
            this.btn_Agregar_Libro.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Agregar_Libro.Name = "btn_Agregar_Libro";
            this.btn_Agregar_Libro.Size = new System.Drawing.Size(116, 42);
            this.btn_Agregar_Libro.TabIndex = 78;
            this.btn_Agregar_Libro.Text = "Agregar Libro";
            this.btn_Agregar_Libro.UseVisualStyleBackColor = false;
            this.btn_Agregar_Libro.Click += new System.EventHandler(this.btn_Agregar_Libro_Click);
            // 
            // dgv_Libros_Disponibles
            // 
            this.dgv_Libros_Disponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Libros_Disponibles.Location = new System.Drawing.Point(59, 197);
            this.dgv_Libros_Disponibles.Margin = new System.Windows.Forms.Padding(1);
            this.dgv_Libros_Disponibles.MultiSelect = false;
            this.dgv_Libros_Disponibles.Name = "dgv_Libros_Disponibles";
            this.dgv_Libros_Disponibles.RowHeadersWidth = 102;
            this.dgv_Libros_Disponibles.RowTemplate.Height = 40;
            this.dgv_Libros_Disponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Libros_Disponibles.Size = new System.Drawing.Size(935, 170);
            this.dgv_Libros_Disponibles.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(53, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 32);
            this.label5.TabIndex = 76;
            this.label5.Text = "Libros Disponibles";
            // 
            // label_Rol
            // 
            this.label_Rol.AutoSize = true;
            this.label_Rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rol.Location = new System.Drawing.Point(999, 66);
            this.label_Rol.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Rol.Name = "label_Rol";
            this.label_Rol.Size = new System.Drawing.Size(34, 18);
            this.label_Rol.TabIndex = 73;
            this.label_Rol.Text = "Rol";
            // 
            // label_Usuario
            // 
            this.label_Usuario.AutoSize = true;
            this.label_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Usuario.Location = new System.Drawing.Point(912, 66);
            this.label_Usuario.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Usuario.Name = "label_Usuario";
            this.label_Usuario.Size = new System.Drawing.Size(67, 18);
            this.label_Usuario.TabIndex = 72;
            this.label_Usuario.Text = "Usuario";
            // 
            // btn_Cerrar_Sesion
            // 
            this.btn_Cerrar_Sesion.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Cerrar_Sesion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cerrar_Sesion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cerrar_Sesion.ForeColor = System.Drawing.Color.White;
            this.btn_Cerrar_Sesion.Location = new System.Drawing.Point(904, 0);
            this.btn_Cerrar_Sesion.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Cerrar_Sesion.Name = "btn_Cerrar_Sesion";
            this.btn_Cerrar_Sesion.Size = new System.Drawing.Size(163, 46);
            this.btn_Cerrar_Sesion.TabIndex = 71;
            this.btn_Cerrar_Sesion.Text = "Cerrar Sesion";
            this.btn_Cerrar_Sesion.UseVisualStyleBackColor = false;
            this.btn_Cerrar_Sesion.Click += new System.EventHandler(this.btn_Cerrar_Sesion_Click);
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscar.Location = new System.Drawing.Point(605, 10);
            this.txt_Buscar.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(252, 29);
            this.txt_Buscar.TabIndex = 70;
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1075, 47);
            this.menuStrip1.TabIndex = 69;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // librosToolStripMenuItem
            // 
            this.librosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultar_Stock_ToolStripMenuItem});
            this.librosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.librosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            this.librosToolStripMenuItem.Size = new System.Drawing.Size(115, 45);
            this.librosToolStripMenuItem.Text = "Libros";
            // 
            // consultar_Stock_ToolStripMenuItem
            // 
            this.consultar_Stock_ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.consultar_Stock_ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultar_Stock_ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.consultar_Stock_ToolStripMenuItem.Name = "consultar_Stock_ToolStripMenuItem";
            this.consultar_Stock_ToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
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
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(110, 45);
            this.ventaToolStripMenuItem.Text = "Venta";
            // 
            // realizar_Venta_ToolStripMenuItem
            // 
            this.realizar_Venta_ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.realizar_Venta_ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realizar_Venta_ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.realizar_Venta_ToolStripMenuItem.Name = "realizar_Venta_ToolStripMenuItem";
            this.realizar_Venta_ToolStripMenuItem.Size = new System.Drawing.Size(237, 32);
            this.realizar_Venta_ToolStripMenuItem.Text = "Realizar Venta";
            this.realizar_Venta_ToolStripMenuItem.Click += new System.EventHandler(this.realizar_Venta_ToolStripMenuItem_Click);
            // 
            // realizar_Pedido_ToolStripMenuItem
            // 
            this.realizar_Pedido_ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.realizar_Pedido_ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realizar_Pedido_ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.realizar_Pedido_ToolStripMenuItem.Name = "realizar_Pedido_ToolStripMenuItem";
            this.realizar_Pedido_ToolStripMenuItem.Size = new System.Drawing.Size(237, 32);
            this.realizar_Pedido_ToolStripMenuItem.Text = "Realizar Pedido";
            this.realizar_Pedido_ToolStripMenuItem.Click += new System.EventHandler(this.realizar_Pedido_ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(943, 522);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 30);
            this.button1.TabIndex = 86;
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
            this.menuStrip2.Location = new System.Drawing.Point(0, 518);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip2.Size = new System.Drawing.Size(1075, 46);
            this.menuStrip2.TabIndex = 85;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acercaDeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(111, 44);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // facebookToolStripMenuItem
            // 
            this.facebookToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.facebookToolStripMenuItem.Image = global::LibreriaBoscoso.Properties.Resources._5305154_fb_facebook_facebook_logo_icon;
            this.facebookToolStripMenuItem.Name = "facebookToolStripMenuItem";
            this.facebookToolStripMenuItem.Size = new System.Drawing.Size(54, 44);
            // 
            // twitterToolStripMenuItem
            // 
            this.twitterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.twitterToolStripMenuItem.Image = global::LibreriaBoscoso.Properties.Resources._104501_twitter_bird_icon;
            this.twitterToolStripMenuItem.Name = "twitterToolStripMenuItem";
            this.twitterToolStripMenuItem.Size = new System.Drawing.Size(54, 44);
            // 
            // instagramToolStripMenuItem
            // 
            this.instagramToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.instagramToolStripMenuItem.Image = global::LibreriaBoscoso.Properties.Resources._5279112_camera_instagram_social_media_instagram_logo_icon;
            this.instagramToolStripMenuItem.Name = "instagramToolStripMenuItem";
            this.instagramToolStripMenuItem.Size = new System.Drawing.Size(54, 44);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 384);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 28);
            this.label3.TabIndex = 87;
            this.label3.Text = "Cantidad Libros";
            // 
            // txt_Cantidad
            // 
            this.txt_Cantidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Cantidad.Location = new System.Drawing.Point(359, 383);
            this.txt_Cantidad.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Cantidad.Name = "txt_Cantidad";
            this.txt_Cantidad.Size = new System.Drawing.Size(85, 34);
            this.txt_Cantidad.TabIndex = 88;
            // 
            // AgregarLibroFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 564);
            this.Controls.Add(this.txt_Cantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.txt_Buscador);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.btn_Agregar_Libro);
            this.Controls.Add(this.dgv_Libros_Disponibles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_Rol);
            this.Controls.Add(this.label_Usuario);
            this.Controls.Add(this.btn_Cerrar_Sesion);
            this.Controls.Add(this.txt_Buscar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "AgregarLibroFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarLibroFactura";
            this.Load += new System.EventHandler(this.AgregarLibroFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Libros_Disponibles)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_Buscador;
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.Button btn_Agregar_Libro;
        private System.Windows.Forms.DataGridView dgv_Libros_Disponibles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_Rol;
        private System.Windows.Forms.Label label_Usuario;
        private System.Windows.Forms.Button btn_Cerrar_Sesion;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Cantidad;
    }
}