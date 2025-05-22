using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class Trabajadores
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public long NumeroTelefono { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty; // ¡AGREGAR ESTA PROPIEDAD!
    }
}
