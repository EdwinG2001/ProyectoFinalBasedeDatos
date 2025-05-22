using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ProyectoGrupo5
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Inicio nuevoForm = new Inicio();
            nuevoForm.Show();
            this.Hide();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro newForm = new Registro();
            newForm.Show();
            this.Hide();
        }
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string usuario = textUsuario.Text;
                string contrasena = textContrasena.Text;

                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
                {
                    MessageBox.Show("Por favor ingrese usuario y contraseña.");
                    return;
                }

                string connectionString = @"Data Source=EDWIN-PC\SQLEXPRESS;Initial Catalog=ProyectoFinal;Integrated Security=True;Encrypt=False";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("sp_AutenticarUsuario", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@NombreUsuario", usuario);
                        cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                        SqlParameter tipoUsuarioParam = new SqlParameter("@TipoUsuarioOUT", SqlDbType.VarChar, 15) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(tipoUsuarioParam);

                        SqlParameter usuarioIdParam = new SqlParameter("@UsuarioIDOUT", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(usuarioIdParam);

                        SqlParameter exitoParam = new SqlParameter("@Exito", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(exitoParam);

                        cmd.ExecuteNonQuery();

                        bool exito = Convert.ToBoolean(exitoParam.Value);

                        if (exito)
                        {
                            string tipoUsuario = tipoUsuarioParam.Value?.ToString()??"";
                            int usuarioID = Convert.ToInt32(usuarioIdParam.Value);

                            UsuarioSesion.NombreUsuario = usuario;
                            UsuarioSesion.TipoUsuario = tipoUsuario;

                            if (tipoUsuario == "Cliente")
                            {
                                UsuarioSesion.ClienteID = usuarioID;
                                // ** NUEVO: Mostrar mensaje de bienvenida **
                                MessageBox.Show($"Bienvenidos a TASKREADY, {UsuarioSesion.NombreUsuario}", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Inicio clienteForm = new Inicio();
                                clienteForm.Show();
                                this.Hide();
                            }
                            else if (tipoUsuario == "Trabajador")
                            {
                                UsuarioSesion.EmpleadoID = usuarioID;
                                MessageBox.Show($"Bienvenidos a TASKREADY, {UsuarioSesion.NombreUsuario}", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PaginasTrabajador trabajadorForm = new PaginasTrabajador();
                                trabajadorForm.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de conexión: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debes aceptar los términos y condiciones para ingresar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void pbMostrarContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            textContrasena.PasswordChar = '\0';
        }
        private void pbMostrarContraseña_MouseUp(object sender, MouseEventArgs e)
        {
            textContrasena.PasswordChar = '●'; 
        }
    }
}

    

