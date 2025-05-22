using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGrupo5
{
    public static class UsuarioSesion
    {
        public static long ClienteID { get; set; }
        public static long EmpleadoID { get; set; }
        public static string NombreUsuario { get; set; } = string.Empty;
        public static string TipoUsuario { get; set; } = string.Empty;
    }
}
