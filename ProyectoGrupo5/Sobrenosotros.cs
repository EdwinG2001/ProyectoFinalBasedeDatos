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
    public partial class Sobrenosotros : Form
    {
        public Sobrenosotros()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Inicio nuevoForm = new Inicio();
            nuevoForm.Show();
            this.Hide();
        }
    }
}
