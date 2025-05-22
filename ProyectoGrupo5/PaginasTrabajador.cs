using BL;
using DAL;
using EN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using iText.Kernel.Font;

namespace ProyectoGrupo5
{
    public partial class PaginasTrabajador : Form
    {
        private OrdenesEventosBL _ordenesBL = new OrdenesEventosBL();
        private long _ordenIdSeleccionada = 0;
        private bool _detenerAviso = false;
        public PaginasTrabajador()
        {
            InitializeComponent();
            ltrabajador.Text = $"Logeado: {UsuarioSesion.NombreUsuario}";
            lblTooltip.Padding = new Padding(5);
            lblTooltip.BackColor = Color.White;
            lblTooltip.BorderStyle = BorderStyle.FixedSingle;
            lblTooltip.AutoSize = true;
            lblTooltip.ForeColor = Color.Black;
            lblTooltip.Font = new Font("Segoe UI", 7);
            lblTooltip.Visible = false;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
        private void CargarOrdenesEnDataGridView()
        {
            try
            {
                // 1. Obtener los datos de las órdenes
                List<OrdenesEventos> ordenes = _ordenesBL.ObtenerTodasLasOrdenesConDetalles();
                dgvOrdenes.DataSource = ordenes;

                // 2. Definir el encabezado de las columnas
                Dictionary<string, string> encabezados = new Dictionary<string, string>
        {
            { "OrdenId", "ID Orden" },
            { "Cliente", "Cliente" },
            { "EventoPredefinido", "Evento" },
            { "FechaSolicitud", "Fecha Solicitud" },
            { "FechaEventoPersonalizado", "Fecha Evento" },
            { "LugarEventoPersonalizado", "Lugar" },
            { "ExtrasSolicitados", "Extras" },
            { "NumeroAsistentes", "# Asistentes" },
            { "PrecioFinalEstimado", "Precio Estimado" },
            { "EstadoOrden", "Estado" }
        };

                // 3. Aplicar los encabezados y ocultar columnas no deseadas
                foreach (DataGridViewColumn columna in dgvOrdenes.Columns)
                {
                    if (encabezados.ContainsKey(columna.Name))
                    {
                        columna.HeaderText = encabezados[columna.Name];
                    }
                    if (columna.Name == "ClienteId" || columna.Name == "EventoPredefinidoId")
                    {
                        columna.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las órdenes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvOrdenes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdenes.SelectedRows.Count > 0)
            {
                string estado = dgvOrdenes.SelectedRows[0].Cells["EstadoOrden"].Value.ToString()!;
                rbEnProceso.Checked = (estado == "EN PROCESO");
                rbCancelado.Checked = (estado == "CANCELADO");
                rbPendiente.Checked = (estado == "PENDIENTE");
            }
        }
        private void FiltrarOrdenesPorEstado(string estado)
        {
            try
            {
                List<OrdenesEventos> ordenesFiltradas = _ordenesBL.ObtenerOrdenesPorEstado(estado);
                dgvOrdenes.DataSource = ordenesFiltradas;

                // Puedes volver a aplicar encabezados si es necesario
                AplicarEncabezadosYVisibilidad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar órdenes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEnProceso_Click(object sender, EventArgs e)
        {
            FiltrarOrdenesPorEstado("EN PROCESO");
        }
        private void btnCancelado_Click(object sender, EventArgs e)
        {
            FiltrarOrdenesPorEstado("CANCELADO");
        }
        private void btnPendiente_Click(object sender, EventArgs e)
        {
            FiltrarOrdenesPorEstado("PENDIENTE");
        }
        private void btnTerminado_Click(object sender, EventArgs e)
        {
            FiltrarOrdenesPorEstado("FINALIZADO");
        }
        private void lblMostrarTodas_Click(object sender, EventArgs e)
        {
            CargarOrdenesEnDataGridView();
        }
        private void AplicarEncabezadosYVisibilidad()
        {
            Dictionary<string, string> encabezados = new Dictionary<string, string>
    {
        { "OrdenId", "ID Orden" },
        { "Cliente", "Cliente" },
        { "EventoPredefinido", "Evento" },
        { "FechaSolicitud", "Fecha Solicitud" },
        { "FechaEventoPersonalizado", "Fecha Evento" },
        { "LugarEventoPersonalizado", "Lugar" },
        { "ExtrasSolicitados", "Extras" },
        { "NumeroAsistentes", "# Asistentes" },
        { "PrecioFinalEstimado", "Precio Estimado" },
        { "EstadoOrden", "Estado" }
    };

            foreach (DataGridViewColumn columna in dgvOrdenes.Columns)
            {
                if (encabezados.ContainsKey(columna.Name))
                    columna.HeaderText = encabezados[columna.Name];
                if (columna.Name == "ClienteId" || columna.Name == "EventoPredefinidoId")
                    columna.Visible = false;
            }
        }
        private void btnGuardarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrdenes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, selecciona una orden.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el ID de la orden seleccionada
                long ordenId = Convert.ToInt64(dgvOrdenes.SelectedRows[0].Cells["OrdenId"].Value);

                // Detectar qué radio button está marcado
                string nuevoEstado = "";
                if (rbEnProceso.Checked)
                    nuevoEstado = "EN PROCESO";
                else if (rbCancelado.Checked)
                    nuevoEstado = "CANCELADO";
                else if (rbPendiente.Checked)
                    nuevoEstado = "PENDIENTE";
                else
                {
                    MessageBox.Show("Selecciona un estado para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmación opcional
                DialogResult confirm = MessageBox.Show($"¿Deseas cambiar el estado de la orden {ordenId} a \"{nuevoEstado}\"?",
                                                       "Confirmar cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Llamar al DAL
                    OrdenesEventosDAL dal = new OrdenesEventosDAL();
                    dal.ActualizarEstadoOrden(ordenId, nuevoEstado);

                    MessageBox.Show("Estado actualizado correctamente ✅", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar el DataGridView
                    CargarOrdenesEnDataGridView(); // Este método lo veremos abajo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PaginasTrabajador_Load(object sender, EventArgs e)
        {
            CargarOrdenesEnDataGridView();
            CargarOrdenesEnProcesoDataGridView1();
            btimprimirclientes.Enabled = false;
            btimprimirordenes.Enabled = false;
        }
        int indiceMensaje = 0;
        List<string> mensajesAyuda = new List<string>
        {
            "En esta página podrás verificar todas las ordenes" +
            "\nde los clientes y eventos.",
            "Este proyecto fue creado por el Grupo #5.",
            "Puedes filtrar las órdenes por su estado usando " +
            "\nlos botones de la izquierda.",
            "Tenemos un buzon para registrat todos los problemas" +
            "\nque encuentres en la pestaña ayuda."
        };
        private void picconsejos_Click(object sender, EventArgs e)
        {
            lblTooltip.Text = mensajesAyuda[indiceMensaje];

            // Obtener la posición del PictureBox en pantalla, pero para la izquierda
            var posicion = picconsejos.PointToScreen(new Point(-lblTooltip.Width - 8, -8));

            // Convertir la posición a coordenadas relativas al formulario
            var posicionEnForm = this.PointToClient(posicion);

            // Ajustar la posición del label
            lblTooltip.Location = posicionEnForm;

            lblTooltip.Visible = true;
            lblTooltip.BringToFront();

            // Reiniciar el timer para que desaparezca luego de 3 segundos
            timerTooltip.Stop();
            timerTooltip.Interval = 3000; // 3000 ms = 3 segundos
            timerTooltip.Start();

            // Pasar al siguiente mensaje (ciclo)
            indiceMensaje = (indiceMensaje + 1) % mensajesAyuda.Count;
        }
        private void timerTooltip_Tick(object sender, EventArgs e)
        {
            lblTooltip.Visible = false;
            timerTooltip.Stop();
        }
        private void CargarOrdenesEnProcesoDataGridView1()
        {
            try
            {
                List<OrdenesEventos> ordenesEnProceso = _ordenesBL.ObtenerOrdenesPorEstado("EN PROCESO");
                dataGridView1.DataSource = ordenesEnProceso;
                Dictionary<string, string> encabezadosDataGridView1 = new Dictionary<string, string>
        {
            { "OrdenId", "ID Orden" },
            { "Cliente", "Cliente" },
            { "EventoPredefinido", "Evento" },
            { "FechaSolicitud", "Fecha Solicitud" },
            { "FechaEventoPersonalizado", "Fecha Evento" },
            { "LugarEventoPersonalizado", "Lugar" },
            { "ExtrasSolicitados", "Extras" },
            { "NumeroAsistentes", "# Asistentes" },
            { "PrecioFinalEstimado", "Precio Estimado" },
            { "EstadoOrden", "Estado" }
        };
                foreach (DataGridViewColumn columna in dataGridView1.Columns)
                {
                    if (encabezadosDataGridView1.ContainsKey(columna.Name))
                    {
                        columna.HeaderText = encabezadosDataGridView1[columna.Name];
                    }
                    if (columna.Name == "ClienteId" || columna.Name == "EventoPredefinidoId")
                    {
                        columna.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las órdenes en proceso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter ingresado
            }
        }
        private async void btguardar1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un evento del listado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Por favor, ingresa un tiempo estimado en horas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox1.Text, out int horasEstimadas))
            {
                MessageBox.Show("Por favor, ingresa un número entero válido para las horas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID del evento seleccionado
            if (dataGridView1.SelectedRows[0].DataBoundItem is OrdenesEventos eventoSeleccionado)
            {
                long eventoId = eventoSeleccionado.OrdenId;

                // Bloquear el TextBox después de guardar
                textBox1.ReadOnly = true;

                // Calcular el tiempo en milisegundos (horas a minutos a segundos a milisegundos)
                int tiempoEnMilisegundos = horasEstimadas * 60 * 1000; // Simulación: 1 hora = 1 minuto = 60000 ms
                progressBar1.Maximum = tiempoEnMilisegundos;
                progressBar1.Value = 0;

                // Reiniciar la variable de control
                _detenerAviso = false;

                // Iniciar la simulación del progreso y los avisos
                await Task.Run(async () =>
                {
                    while (progressBar1.Value < progressBar1.Maximum && !_detenerAviso)
                    {
                        progressBar1.Invoke(new Action(() => progressBar1.Value += 1000)); // Actualizar cada segundo
                        await Task.Delay(1000);
                    }

                    // Cuando el progreso termine, iniciar los avisos periódicos (si no se ha detenido)
                    while (!_detenerAviso)
                    {
                        // Verificar si el formulario sigue visible (opcional)
                        if (!IsHandleCreated || IsDisposed)
                            break;

                        // Mostrar el aviso cada 5 segundos
                        MessageBox.Show("AVISO: LA ORDEN NO HA SIDO TERMINADA, POR FAVOR TERMINALA.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        await Task.Delay(5000);
                    }
                });
            }
        }
        private void btdetener1_Click(object sender, EventArgs e)
        {
            _detenerAviso = true;
            progressBar1.Value = 0;
            textBox1.Text = "";
            textBox1.ReadOnly = false;
        }
        private void btcancelar1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un evento del listado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows[0].DataBoundItem is OrdenesEventos eventoSeleccionado)
            {
                long ordenId = eventoSeleccionado.OrdenId;

                DialogResult confirm = MessageBox.Show($"¿Estás seguro de cancelar el evento con ID {ordenId}?", "Confirmación de Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        // Llamar al método de la capa de BL
                        _ordenesBL.ActualizarEstadoOrden(ordenId, "CANCELADO");

                        MessageBox.Show($"El estado de la orden con ID {ordenId} ha sido cambiado a 'CANCELADO'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar el DataGridView para reflejar el cambio
                        CargarOrdenesEnProcesoDataGridView1();

                        // Reiniciar el ProgressBar y TextBox (opcional)
                        progressBar1.Value = 0;
                        textBox1.Text = "";
                        textBox1.ReadOnly = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al cancelar la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            CargarOrdenesEnProcesoDataGridView1();
        }
        private void tabControltrabajadores_Enter(object sender, EventArgs e)
        {
            CargarOrdenesEnDataGridView();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un evento del listado para finalizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows[0].DataBoundItem is OrdenesEventos eventoSeleccionado)
            {
                long ordenId = eventoSeleccionado.OrdenId;

                DialogResult confirm = MessageBox.Show($"¿Estás seguro de finalizar el evento con ID {ordenId}?", "Confirmación de Finalización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        // 1. Cambiar el estado de la orden a "FINALIZADO" usando la capa de BL
                        _ordenesBL.ActualizarEstadoOrden(ordenId, "FINALIZADO");

                        MessageBox.Show($"El evento con ID {ordenId} ha sido marcado como 'FINALIZADO'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 2. Detener el bucle de avisos
                        _detenerAviso = true;

                        // 3. Reiniciar el ProgressBar
                        progressBar1.Value = 0;

                        // 4. Limpiar el TextBox
                        textBox1.Text = "";

                        // 5. Desbloquear el TextBox
                        textBox1.ReadOnly = false;

                        // 6. Recargar el DataGridView para quitar la orden finalizada
                        CargarOrdenesEnProcesoDataGridView1();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al finalizar la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Login newForm = new Login();
            newForm.Show();
            this.Hide();
        }
        private void btimprimirclientes_Click(object sender, EventArgs e)
        {
            ClientesBL clientesBL = new ClientesBL();
            List<Clientes> listaClientes = clientesBL.ObtenerClientes();

            if (listaClientes.Count == 0)
            {
                MessageBox.Show("No hay clientes para imprimir.");
                return;
            }

            string rutaDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string rutaArchivo = Path.Combine(rutaDescargas, "Clientes_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf");

            using (PdfWriter writer = new PdfWriter(rutaArchivo))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

                    document.Add(new Paragraph("Listado de Clientes Registrados")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(16)
                        .SetFont(boldFont));

                    document.Add(new Paragraph("\n"));

                    Table tabla = new Table(5, true);

                    tabla.AddHeaderCell("Nombre");
                    tabla.AddHeaderCell("Apellido");
                    tabla.AddHeaderCell("Teléfono");
                    tabla.AddHeaderCell("Correo");
                    tabla.AddHeaderCell("Usuario");

                    foreach (var cliente in listaClientes)
                    {
                        tabla.AddCell(cliente.Nombre);
                        tabla.AddCell(cliente.Apellido);
                        tabla.AddCell(cliente.NumeroTelefono.ToString());
                        tabla.AddCell(cliente.Correo);
                        tabla.AddCell(cliente.NombreUsuario);
                    }

                    document.Add(tabla);
                    document.Close();
                }
            }

            MessageBox.Show($"PDF generado correctamente:\n{rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (File.Exists(rutaArchivo))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = rutaArchivo,
                    UseShellExecute = true
                });
            }
        }
        private void btimprimirordenes_Click(object sender, EventArgs e)
        {
            OrdenesEventosBL ordenesBL = new OrdenesEventosBL();
            List<OrdenesEventos> listaOrdenes = ordenesBL.ObtenerTodasLasOrdenesConDetalles();

            if (listaOrdenes.Count == 0)
            {
                MessageBox.Show("No hay órdenes para imprimir.");
                return;
            }

            string rutaDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string rutaArchivo = Path.Combine(rutaDescargas, "Ordenes_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf");

            using (PdfWriter writer = new PdfWriter(rutaArchivo))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);
                    PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

                    // Título
                    document.Add(new Paragraph("Listado de Órdenes de Eventos")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(16)
                        .SetFont(boldFont));
                    document.Add(new Paragraph("\n"));

                    // Tabla de 9 columnas (según los datos visibles)
                    Table tabla = new Table(9, true);

                    tabla.AddHeaderCell("Cliente");
                    tabla.AddHeaderCell("Correo");
                    tabla.AddHeaderCell("Evento");
                    tabla.AddHeaderCell("Fecha Solicitud");
                    tabla.AddHeaderCell("Fecha Evento");
                    tabla.AddHeaderCell("Lugar");
                    tabla.AddHeaderCell("Extras");
                    tabla.AddHeaderCell("# Asistentes");
                    tabla.AddHeaderCell("Precio / Estado");

                    foreach (var orden in listaOrdenes)
                    {
                        tabla.AddCell(orden.Nombre);
                        tabla.AddCell(orden.Correo ?? "-");
                        tabla.AddCell(orden.NombreEvento);
                        tabla.AddCell(orden.FechaSolicitud.ToString("yyyy-MM-dd"));

                        tabla.AddCell(orden.FechaEventoPersonalizado.HasValue ?
                            orden.FechaEventoPersonalizado.Value.ToString("yyyy-MM-dd") : "-");

                        tabla.AddCell(string.IsNullOrEmpty(orden.LugarEventoPersonalizado) ? "-" : orden.LugarEventoPersonalizado);
                        tabla.AddCell(string.IsNullOrEmpty(orden.ExtrasSolicitados) ? "-" : orden.ExtrasSolicitados);
                        tabla.AddCell(orden.NumeroAsistentes?.ToString() ?? "-");
                        tabla.AddCell($"${orden.PrecioFinalEstimado?.ToString("N2") ?? "0.00"}\n{orden.EstadoOrden}");
                    }

                    document.Add(tabla);
                    document.Close();
                }
            }

            MessageBox.Show($"PDF generado correctamente:\n{rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (File.Exists(rutaArchivo))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = rutaArchivo,
                    UseShellExecute = true
                });
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Habilita los botones solo si está seleccionado el radioButton1
            bool estaSeleccionado = radioButton1.Checked;

            btimprimirclientes.Enabled = estaSeleccionado;
            btimprimirordenes.Enabled = estaSeleccionado;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuejasoSugerencias newForm = new QuejasoSugerencias();
            newForm.Show();
            this.Hide();
        }
    }
}


