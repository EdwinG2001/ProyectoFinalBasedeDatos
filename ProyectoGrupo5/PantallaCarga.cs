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
    public partial class PantallaCarga : Form
    {
        public PantallaCarga()
        {
            InitializeComponent();
        }
        private void PantallaCarga_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\USER\Documents\Todos los documentos\Universidad\3 B Tecnologia\Programacion II\Programas\ProyectoFinalBasedeDatos\ProyectoGrupo5\Resources\carga.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Inicio pantallaPrincipal = new  Inicio();
            // Mostrar el formulario principal
            pantallaPrincipal.Show();
            this.Hide();
        }
    }
}
