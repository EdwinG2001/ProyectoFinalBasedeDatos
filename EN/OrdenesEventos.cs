using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class OrdenesEventos
    {
        public long OrdenId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string NombreEvento {  get; set; } = string.Empty;
        public long EventoPredefinidoId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaEventoPersonalizado { get; set; }
        public string LugarEventoPersonalizado { get; set; } = string.Empty;
        public string ExtrasSolicitados { get; set; } = string.Empty;
        public int? NumeroAsistentes { get; set; }
        public decimal? PrecioFinalEstimado { get; set; }
        public string EstadoOrden { get; set; } = string.Empty;
        public long ClienteId { get; set; }

    }
}
