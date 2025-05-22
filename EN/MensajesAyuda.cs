using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class MensajesAyuda
    {
      public string NombreCompleto { get; set; } = string.Empty;
      public string Usuario { get; set; } = string.Empty;
      public string Correo { get; set; } = string.Empty;
      public string TipoMensaje { get; set; } = string.Empty;  // Queja o Sugerencia
      public string Mensaje { get; set; } = string.Empty;
    }
}
