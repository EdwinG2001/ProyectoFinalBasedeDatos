using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class Usuarios
    {
        public int UsuarioId { get; set; }
        public string TipoUsuario { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public int? EmpleadoId { get; set; } // Usamos int? porque puede ser NULL
        public int? ClienteId { get; set; }   // Usamos int? porque puede ser NULL
    }
}
