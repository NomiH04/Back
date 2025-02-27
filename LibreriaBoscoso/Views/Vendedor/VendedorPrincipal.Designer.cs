using System.Windows.Forms;

namespace LibreriaBoscoso.Views
{
    partial class VendedorPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.librosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultar_Stock_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizar_Venta_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizar_Pedido_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.btn_Cerrar_Sesion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(805, 38);
            this.menuStrip1.TabIndex = 0;
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
            // txt_Buscar
            // 
            this.txt_Buscar.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscar.Location = new System.Drawing.Point(454, 8);
            this.txt_Buscar.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(190, 25);
            this.txt_Buscar.TabIndex = 1;
            this.txt_Buscar.Text = "Buscar";
            this.txt_Buscar.Enter += new System.EventHandler(this.txt_Buscar_Enter);
            this.txt_Buscar.Leave += new System.EventHandler(this.txt_Buscar_Leave);
            // 
            // btn_Cerrar_Sesion
            // 
            this.btn_Cerrar_Sesion.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Cerrar_Sesion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cerrar_Sesion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cerrar_Sesion.ForeColor = System.Drawing.Color.White;
            this.btn_Cerrar_Sesion.Location = new System.Drawing.Point(678, 0);
            this.btn_Cerrar_Sesion.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Cerrar_Sesion.Name = "btn_Cerrar_Sesion";
            this.btn_Cerrar_Sesion.Size = new System.Drawing.Size(122, 37);
            this.btn_Cerrar_Sesion.TabIndex = 2;
            this.btn_Cerrar_Sesion.Text = "Cerrar Sesion";
            this.btn_Cerrar_Sesion.UseVisualStyleBackColor = false;
            this.btn_Cerrar_Sesion.Click += new System.EventHandler(this.btn_Cerrar_Sesion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibreriaBoscoso.Properties.Resources.LogoG1;
            this.pictureBox1.Location = new System.Drawing.Point(289, 124);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 197);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(51)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(711, 426);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 24);
            this.button1.TabIndex = 55;
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
            this.menuStrip2.Location = new System.Drawing.Point(0, 417);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip2.Size = new System.Drawing.Size(805, 46);
            this.menuStrip2.TabIndex = 54;
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
            // VendedorPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(805, 463);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Cerrar_Sesion);
            this.Controls.Add(this.txt_Buscar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "VendedorPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VendedorPrincipal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem librosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultar_Stock_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizar_Venta_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizar_Pedido_ToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.Button btn_Cerrar_Sesion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instagramToolStripMenuItem;
    }
}