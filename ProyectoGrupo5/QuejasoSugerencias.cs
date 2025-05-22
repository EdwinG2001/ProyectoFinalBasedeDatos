using System;
using BL;
using DAL;
using EN;
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
    public partial class QuejasoSugerencias : Form
    {
        public QuejasoSugerencias()
        {
            InitializeComponent();
        }

        private void txtayudausuario_Enter(object sender, EventArgs e)
        {
            if (txtayudausuario.Text == "Usuario")
            {
                txtayudausuario.Text = "";
                txtayudausuario.ForeColor = Color.Black;
            }
        }
        private void txtayudacorreo_Enter(object sender, EventArgs e)
        {
            if (txtayudacorreo.Text == "Correo")
            {
                txtayudacorreo.Text = "";
                txtayudacorreo.ForeColor = Color.Black;
            }
        }

        private void QuejasoSugerencias_Load(object sender, EventArgs e)
        {
            txtayudausuario.Text = "Usuario";
            txtayudausuario.ForeColor = Color.Gray;
            txtayudacorreo.Text = "Correo";
            txtayudacorreo.ForeColor = Color.Gray;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // Validar que al menos un RadioButton esté seleccionado
            if (!rbQueja.Checked && !rbSugerencia.Checked)
            {
                MessageBox.Show("Por favor, selecciona si es una Queja o una Sugerencia.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipoMensaje = rbQueja.Checked ? "Queja" : "Sugerencia";

            MensajesAyuda mensaje = new MensajesAyuda
            {
                NombreCompleto = txtNombreAyuda.Text,
                Usuario = txtayudausuario.Text,
                Correo = txtayudacorreo.Text,
                TipoMensaje = tipoMensaje,
                Mensaje = rtbproblema.Text
            };

            MensajeAyudaBL bl = new MensajeAyudaBL();
            bool enviado = bl.EnviarMensaje(mensaje);

            if (enviado)
            {
                MessageBox.Show("Mensaje enviado correctamente. ¡Gracias por tu opinión!", "Éxito");

                // Limpiar campos después del envío exitoso
                txtNombreAyuda.Clear();
                txtayudausuario.Clear();
                txtayudacorreo.Clear();
                rtbproblema.Clear();
                rbQueja.Checked = false;
                rbSugerencia.Checked = false;
            }
            else
            {
                MessageBox.Show("Error al enviar el mensaje. Intenta de nuevo.", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio newForm = new Inicio();
            newForm.Show();
            this.Hide();
        }
    }
}
