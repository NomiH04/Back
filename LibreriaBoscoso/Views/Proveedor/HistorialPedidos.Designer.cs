using System.Windows.Forms;

namespace LibreriaBoscoso.Views.Proveedor
{
    partial class HistorialPedidos
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
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_Buscador = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.librosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.librosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Estado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OrdenId = new System.Windows.Forms.Label();
            this.facebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(713, 426);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 24);
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
            this.menuStrip2.Location = new System.Drawing.Point(0, 415);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip2.Size = new System.Drawing.Size(804, 46);
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
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(684, 372);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(1);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(86, 34);
            this.btnSalir.TabIndex = 85;
            this.btnSalir.Text = "Salir.";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.Gray;
            this.btn_Buscar.ForeColor = System.Drawing.Color.White;
            this.btn_Buscar.Location = new System.Drawing.Point(283, 110);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(71, 34);
            this.btn_Buscar.TabIndex = 81;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_Buscador
            // 
            this.txt_Buscador.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscador.Location = new System.Drawing.Point(16, 110);
            this.txt_Buscador.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Buscador.Name = "txt_Buscador";
            this.txt_Buscador.Size = new System.Drawing.Size(247, 29);
            this.txt_Buscador.TabIndex = 80;
            this.txt_Buscador.Text = "Buscar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 32);
            this.label3.TabIndex = 78;
            this.label3.Text = "Historial Pedidos";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(368, 110);
            this.button3.Margin = new System.Windows.Forms.Padding(1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 34);
            this.button3.TabIndex = 89;
            this.button3.Text = "Ver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.btnCerrarSesion.TabIndex = 92;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(516, 8);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 25);
            this.textBox1.TabIndex = 91;
            this.textBox1.Text = "Buscar";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem,
            this.librosToolStripMenuItem,
            this.librosToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(804, 38);
            this.menuStrip1.TabIndex = 90;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarVentasToolStripMenuItem,
            this.pedidosToolStripMenuItem});
            this.ventasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(138, 36);
            this.ventasToolStripMenuItem.Text = "Proveedor";
            // 
            // consultarVentasToolStripMenuItem
            // 
            this.consultarVentasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.consultarVentasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultarVentasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.consultarVentasToolStripMenuItem.Name = "consultarVentasToolStripMenuItem";
            this.consultarVentasToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.consultarVentasToolStripMenuItem.Text = "Historial Pedidos";
            this.consultarVentasToolStripMenuItem.Click += new System.EventHandler(this.consultarVentasToolStripMenuItem_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.pedidosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pedidosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            this.pedidosToolStripMenuItem.Click += new System.EventHandler(this.pedidosToolStripMenuItem_Click);
            // 
            // librosToolStripMenuItem
            // 
            this.librosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catalogoToolStripMenuItem});
            this.librosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.librosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            this.librosToolStripMenuItem.Size = new System.Drawing.Size(91, 36);
            this.librosToolStripMenuItem.Text = "Libros";
            // 
            // catalogoToolStripMenuItem
            // 
            this.catalogoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.catalogoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.catalogoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.catalogoToolStripMenuItem.Name = "catalogoToolStripMenuItem";
            this.catalogoToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.catalogoToolStripMenuItem.Text = "Catalogo";
            this.catalogoToolStripMenuItem.Click += new System.EventHandler(this.catalogoToolStripMenuItem_Click);
            // 
            // librosToolStripMenuItem1
            // 
            this.librosToolStripMenuItem1.Name = "librosToolStripMenuItem1";
            this.librosToolStripMenuItem1.Size = new System.Drawing.Size(12, 36);
            // 
            // catalogoToolStripMenuItem1
            // 
            this.catalogoToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.catalogoToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.catalogoToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.catalogoToolStripMenuItem1.Name = "catalogoToolStripMenuItem1";
            this.catalogoToolStripMenuItem1.Size = new System.Drawing.Size(180, 26);
            this.catalogoToolStripMenuItem1.Text = "Catalogo";
            this.catalogoToolStripMenuItem1.Click += new System.EventHandler(this.catalogoToolStripMenuItem_Click);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(16, 143);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.Size = new System.Drawing.Size(754, 225);
            this.dataGridViewOrders.TabIndex = 93;
            this.dataGridViewOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Estado);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.OrdenId);
            this.panel1.Location = new System.Drawing.Point(570, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 94;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 95;
            this.label6.Text = "--->";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 94;
            this.label5.Text = "--->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 93;
            this.label2.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Identificador";
            // 
            // Estado
            // 
            this.Estado.AutoSize = true;
            this.Estado.Location = new System.Drawing.Point(111, 63);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(0, 13);
            this.Estado.TabIndex = 91;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 8);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 89;
            this.label4.Text = "OrdenSeleccionada";
            // 
            // OrdenId
            // 
            this.OrdenId.AutoSize = true;
            this.OrdenId.Location = new System.Drawing.Point(138, 35);
            this.OrdenId.Name = "OrdenId";
            this.OrdenId.Size = new System.Drawing.Size(0, 13);
            this.OrdenId.TabIndex = 90;
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
            // HistorialPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.txt_Buscador);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "HistorialPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HistorialPedidos";
            this.Load += new System.EventHandler(this.HistorialPedidos_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instagramToolStripMenuItem;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_Buscador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem librosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem librosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem catalogoToolStripMenuItem1;
        private DataGridView dataGridViewOrders;
        private Panel panel1;
        private Label label6;
        private Label label5;
        private Label label2;
        private Label label1;
        private Label Estado;
        private Label label4;
        private Label OrdenId;
    }
}