using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using DAL;
using BL;
using EN;

namespace ProyectoGrupo5
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            button2.CausesValidation = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Login newForm = new Login();
            newForm.Show();
            this.Hide();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox1.Visible = false;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox1.Visible = true;
        }
        private void textNombre_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombre.Text))
            {
                e.Cancel = true; // Cancela la pérdida de foco
                MessageBox.Show("El campo Nombre es obligatorio.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNombre.Focus(); // Devuelve el foco al campo vacío
            }
        }
        private void textApellido_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textApellido.Text))
            {
                e.Cancel = true; // Cancela la pérdida de foco
                MessageBox.Show("El campo Apellido es obligatorio.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textApellido.Focus(); // Devuelve el foco al campo vacío
            }
        }
        private void textNumeroTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNumeroTelefono.Text))
            {
                e.Cancel = true;
                MessageBox.Show("El campo Numero Telefonico es obligatorio.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNumeroTelefono.Focus();
            }
            else
            {
                // Verificar si el texto contiene solo números
                if (!int.TryParse(textNumeroTelefono.Text, out _)) // TryParse intenta convertir a entero, si falla, devuelve false
                {
                    e.Cancel = true;
                    MessageBox.Show("El campo Numero Telefonico solo debe contener números.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textNumeroTelefono.SelectAll(); // Selecciona todo el texto para facilitar la corrección
                }
            }
        }
        private void textCorreoElectronico_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textCorreoElectronico.Text))
            {
                e.Cancel = true; // Cancela la pérdida de foco
                MessageBox.Show("El campo Correo Electronico es obligatorio.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCorreoElectronico.Focus(); // Devuelve el foco al campo vacío
            }
        }
        private void textBoxusuario_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxusuario.Text))
            {
                e.Cancel = true; // Cancela la pérdida de foco
                MessageBox.Show("El campo Usuario es obligatorio.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxusuario.Focus(); // Devuelve el foco al campo vacío
            }
        }
        private void textBoxcontrasena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxcontrasena.Text))
            {
                e.Cancel = true; // Cancela la pérdida de foco
                MessageBox.Show("El campo Contraseña es obligatorio.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxcontrasena.Focus(); // Devuelve el foco al campo vacío
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Debes seleccionar si eres un Nuevo Cliente o un Nuevo Trabajador.", "Selección Obligatoria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (radioButton2.Checked && comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un Cargo.", "Selección Obligatoria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            string nombre = textNombre.Text.Trim();
            string apellido = textApellido.Text.Trim();
            string telefono = textNumeroTelefono.Text.Trim();
            string correo = textCorreoElectronico.Text.Trim();
            string usuario = textBoxusuario.Text.Trim();
            string contrasena = textBoxcontrasena.Text.Trim();
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Debes ingresar un nombre de usuario y una contraseña.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Campos Obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(telefono, out long telefonoNumerico))
            {
                MessageBox.Show("El campo Número Telefónico solo debe contener números.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNumeroTelefono.Focus();
                return;
            }

            // 🧪 Mostrar para verificar que todo esté correcto antes de insertar
            MessageBox.Show($"Nombre Usuario: {usuario}\nContraseña: {contrasena}", "DEBUG: Verificando datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (radioButton1.Checked)
            {
                RegistrarCliente(nombre, apellido, telefonoNumerico, correo, usuario, contrasena);
            }
            else if (radioButton2.Checked)
            {
                string cargo = comboBox1.SelectedItem?.ToString() ??"";
                RegistrarTrabajador(nombre, apellido, telefonoNumerico, correo, usuario, contrasena, cargo);
            }
        }
        private void RegistrarCliente(string nombre, string apellido, long telefono, string correo, string usuario, string contrasena)
        {
            ClientesBL bl = new ClientesBL();
            Clientes nuevoCliente = new Clientes
            {
                Nombre = nombre,
                Apellido = apellido,
                NumeroTelefono = telefono,
                Correo = correo
            };

            // Ahora, pasamos también el nombre de usuario y la contraseña a la función DAL
            int resultado = bl.AgregarCliente(nuevoCliente, usuario, contrasena);
            if (resultado > 0)
                MessageBox.Show("Cliente registrado con éxito.");
            else
                MessageBox.Show("Ocurrió un error al registrar el cliente.");
        }
        private void RegistrarTrabajador(string nombre, string apellido, long telefono, string correo, string usuario, string contrasena, string cargo)
        {
            TrabajadoresBL bl = new TrabajadoresBL();
            Trabajadores nuevoTrabajador = new Trabajadores
            {
                Nombre = nombre,
                Apellido = apellido,
                NumeroTelefono = telefono,
                Correo = correo,
                Cargo = cargo
            };

            // Igualmente, pasamos el nombre de usuario y la contraseña al método DAL
            int resultado = bl.AgregarTrabajador(nuevoTrabajador, usuario, contrasena);
            if (resultado > 0)
                MessageBox.Show("Trabajador registrado con éxito.");
            else
                MessageBox.Show("Ocurrió un error al registrar el trabajador.");
        }
    }
}
