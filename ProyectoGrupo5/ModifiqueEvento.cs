using BL;
using DAL;
using EN;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoGrupo5
{
    public partial class ModifiqueEvento : Form
    {
        private readonly EventosPredefinidosBL _eventosBL = new EventosPredefinidosBL();
        private List<EventosPredefinidos> _listaEventos;
        private ToolTip toolTipMensajes;
        public ModifiqueEvento()
        {
            InitializeComponent();
            
        }
        private void CargarNombresEventosEnComboBox()
        {
            try
            {
                _listaEventos = _eventosBL.ObtenerEventosPredefinidos(); // Obtén la lista y guárdala

                cmbEventos1.DataSource = null; // Limpiamos el DataSource anterior
                cmbEventos1.DisplayMember = "NombreEvento"; // Qué propiedad mostrar en el ComboBox
                cmbEventos1.ValueMember = "EventoPredefinidoID"; // Qué valor usar cuando se selecciona un item
                cmbEventos1.DataSource = _listaEventos; // Asignamos la lista

                cmbEventos1.SelectedIndex = -1; // Deseleccionamos cualquier item al inicio
                lblPrecio.Text = "$0"; // Inicializamos el precio
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al cargar los nombres de los eventos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones (asegurándonos de que los campos necesarios estén llenos)
                if (cmbEventos1.SelectedValue == null)
                {
                    MessageBox.Show("⚠️ Debes seleccionar un evento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text)) // Validar Lugar del Evento
                {
                    MessageBox.Show("⚠️ Debes indicar el lugar del evento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                string nombreUsuario = UsuarioSesion.NombreUsuario;
                long clienteID = 0;

                string connectionString = @"Data Source=EDWIN-PC\SQLEXPRESS;Initial Catalog=ProyectoFinal;Integrated Security=True;Encrypt=False";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // ** OBTENER EL ClienteId CORRECTO DE LA TABLA CLIENTES (PRIMERO) **
                        string query = "SELECT ClienteId FROM dbo.Clientes WHERE NombreUsuario = @NombreUsuario";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            clienteID = Convert.ToInt64(result);
                            // ** AHORA MOSTRAMOS EL ClienteId CORRECTO **
                            MessageBox.Show($"ID del cliente para guardar: {clienteID}", "Depuración en Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("❌ Error al obtener el Cliente ID para guardar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // No continuar si no se pudo obtener el ClienteId
                        }

                        // 2. Crear un objeto OrdenesEventos y asignar los valores de los controles
                        OrdenesEventos nuevaOrden = new OrdenesEventos
                        {
                            ClienteId = clienteID, // ¡Usando el ClienteId obtenido de la tabla Clientes!
                            EventoPredefinidoId = Convert.ToInt64(cmbEventos1.SelectedValue),
                            FechaEventoPersonalizado = dateTimePicker1.Value.Date,
                            LugarEventoPersonalizado = textBox1.Text.Trim(),
                            ExtrasSolicitados = richTextBox1.Text.Trim(),
                            NumeroAsistentes = (int)numericUpDown1.Value,
                            PrecioFinalEstimado = decimal.Parse(lblPrecio.Text.Replace("$", ""))
                            // FechaSolicitud y EstadoOrden se manejan en el Stored Procedure
                        };

                        // 3. Crear una instancia de la capa BL para OrdenesEventos
                        OrdenesEventosBL ordenesBL = new OrdenesEventosBL();

                        // 4. Llamar al método en la BL para crear la nueva orden
                        int resultado = ordenesBL.CrearOrdenEvento(nuevaOrden);

                        // 5. Manejar el resultado de la inserción
                        if (resultado == 0) // El Stored Procedure devuelve 0 en caso de éxito
                        {
                            MessageBox.Show("✅ Orden registrada con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCamposOrden();
                        }
                        else
                        {
                            MessageBox.Show("❌ Error al registrar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("❌ Error de conexión: " + ex.Message);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("❌ Error en el formato del precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"⚠️ Error de validación: {ex.Message}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCamposOrden()
        {
            cmbEventos1.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
            textBox1.Clear();
            richTextBox1.Clear();
            numericUpDown1.Value = 0;
            lblPrecio.Text = "$0";
        }
        private void CalcularPrecioFinal()
        {
            if (cmbEventos1.SelectedItem is EventosPredefinidos eventoSeleccionado)
            {
                int asistentes = (int)numericUpDown1.Value;
                decimal precioBase = eventoSeleccionado.PrecioBase;
                decimal precioFinal = precioBase + (asistentes * 5); // $5 por asistente
                lblPrecio.Text = $"${precioFinal}";
            }
            else
            {
                lblPrecio.Text = "$0";
            }
        }
        private void btnregresar_Click(object sender, EventArgs e)
        {
            Inicio newForm = new Inicio();
            newForm.Show();
            this.Hide();
        }
        private void cmbEventos1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbEventos1.SelectedItem is EventosPredefinidos eventoSeleccionado)
            {
                lblPrecio.Text = $"${eventoSeleccionado.PrecioBase}";
                CalcularPrecioFinal();
            }
            else
            {
                lblPrecio.Text = "$0";
            }
        }
        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            CalcularPrecioFinal();
        }
        private void AsignarToolTipsAPictureBoxes()
        {
            // Asigna ToolTip a pictureBox dentro de tabPage1
            toolTipMensajes.SetToolTip(tabPage1.Controls["pictureBox5"]!, "INCLUYE:\r\nArreglos florales\r\nCapacidad (ej: 50 personas)\r\nPastel (ej: 2 pisos)\r\nLocal (ej: Hacienda)\r\nMúsica (ej: DJ)\r\nCatering (ej: Cena formal)\r\nFotografía\r\nRecuerdos.");
            toolTipMensajes.SetToolTip(tabPage1.Controls["pictureBox6"]!, "INCLUYE:\r\nSala de conferencias\r\nEquipo audiovisual\r\nCoffee break\r\nAlmuerzo empresarial\r\nMateriales de presentación\r\nPersonal de apoyo\r\nTeam building\r\nTraducción");
            toolTipMensajes.SetToolTip(tabPage1.Controls["pictureBox7"]!, "INCLUYE:\r\nDecoración religiosa\r\nPastel bautizo\r\nRecuerdos\r\nMesa de dulces\r\nCatering infantil/adulto\r\nMúsica suave\r\nFotografía\r\nLugar ceremonia/celebración");
            toolTipMensajes.SetToolTip(tabPage1.Controls["pictureBox8"]!, "INCLUYE:\r\nAlquiler instalación (ej: Cancha fútbol)\r\nEquipamiento (ej: Balones)\r\nÁrbitros\r\nPrimeros auxilios\r\nHidratación\r\nTrofeos\r\nFotografía deportiva\r\nÁreas descanso");
            toolTipMensajes.SetToolTip(tabPage1.Controls["pictureBox9"]!, "INCLUYE:\r\nLugar celebración (ej: Bar)\r\nDecoración festiva\r\nActividades/Juegos\r\nComida/Bebidas\r\nMúsica/Entretenimiento\r\nRecuerdos\r\nTransporte\r\nReservaciones");
            toolTipMensajes.SetToolTip(tabPage1.Controls["pictureBox10"]!, "INCLUYE:\r\nDegustación (ej: Tapas)\r\nMaridaje (ej: Vinos)\r\nClase de cocina\r\nChef invitado\r\nMúsica ambiental\r\nDecoración temática\r\nCata (ej: Quesos)\r\nTaller (ej: Panadería)");

            // Asigna ToolTip a pictureBox dentro de tabPage2
            toolTipMensajes.SetToolTip(tabPage2.Controls["pictureBox11"]!, "INCLUYE:\r\nTarimas\r\nSillas (opcional, según el tipo de concierto)\r\nPuestos de comida rápida\r\nSeguridad\r\nSistema de sonido profesional\r\nIluminación espectacular\r\nPantallas gigantes\r\nCamerinos para artistas");
            toolTipMensajes.SetToolTip(tabPage2.Controls["pictureBox12"]!, "INCLUYE:\r\nMúsica (DJ, banda en vivo)\r\nBarra de bebidas (con o sin alcohol)\r\nPista de baile\r\nIluminación de fiesta\r\nMesas y sillas\r\nServicio de catering o bocadillos\r\nSeguridad\r\nDecoración acorde a la temática (si la hay)");
            toolTipMensajes.SetToolTip(tabPage2.Controls["pictureBox13"]!, "INCLUYE:\r\nAnimadores o payasos\r\nJuegos y actividades para niños\r\nPastel temático\r\nPiñata\r\nDulces y sorpresas\r\nDecoración infantil (globos, personajes)\r\nComida para niños (pizza, hot dogs)\r\nBebidas (jugos, refrescos)");
            toolTipMensajes.SetToolTip(tabPage2.Controls["pictureBox14"]!, "INCLUYE:\r\nDecoración inmersiva según el tema\r\nDisfraces (sugeridos u obligatorios)\r\nMúsica acorde al tema\r\nComida y bebidas temáticas\r\nActividades o juegos relacionados con el tema\r\nIluminación especial para crear ambiente\r\nFotografía temática\r\nPersonal caracterizado (opcional)");
            toolTipMensajes.SetToolTip(tabPage2.Controls["pictureBox15"]!, "INCLUYE:\r\nEscenario o presídium\r\nSillas para graduados e invitados\r\nSistema de sonido para discursos\r\nEntrega de diplomas\r\nFotografía y video profesional\r\nDecoración (flores, pancartas)\r\nMúsica ceremonial\r\nRecepción posterior (comida y bebida)");
            toolTipMensajes.SetToolTip(tabPage2.Controls["pictureBox16"]!, "INCLUYE:\r\nDecoración bebé\r\nPastel pañales\r\nJuegos\r\nMesa de regalos\r\nComida ligera\r\nBebidas\r\nRecuerdos\r\nInvitaciones");
        }
        private void ModifiqueEvento_Load(object sender, EventArgs e)
        {
            CargarNombresEventosEnComboBox();
            toolTipMensajes = new ToolTip();
            toolTipMensajes.InitialDelay = 500;
            toolTipMensajes.ReshowDelay = 100;
            toolTipMensajes.AutoPopDelay = 5000;
            toolTipMensajes.ShowAlways = true;
            AsignarToolTipsAPictureBoxes();
            label19.Text = $"USUARIO : {UsuarioSesion.NombreUsuario} 😃 ";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuejasoSugerencias newForm = new QuejasoSugerencias();
            newForm.Show();
            this.Hide();
        }
    }
}

