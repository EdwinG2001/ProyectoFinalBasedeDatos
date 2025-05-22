using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoGrupo5
{
    public partial class Inicio1 : Form
    {
        public Inicio1()
        {
            InitializeComponent();
            labelogeado.Text = $"Logeado: {UsuarioSesion.NombreUsuario}";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Inicio nuevoForm = new Inicio();
            nuevoForm.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Sobrenosotros nuevoForm = new Sobrenosotros();
            nuevoForm.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Inicio nuevoForm = new Inicio();
            nuevoForm.Show();
            this.Hide();
        }
        private void btnLogin2_Click(object sender, EventArgs e)
        {
            Login newForm = new Login();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
    }
}
