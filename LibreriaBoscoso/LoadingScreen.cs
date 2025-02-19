using System;
using System.Windows.Forms;
using LibreriaBoscoso.Views;

namespace LibreriaBoscoso
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                Inicio inicio1 = new Inicio();
                inicio1.Show();
                this.Hide();
            }
        }
    }
}
