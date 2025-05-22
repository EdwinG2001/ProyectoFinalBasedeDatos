using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using DAL;

namespace BL
{
    public class UsuariosBL
    {
        private UsuariosDAL _usuariosDAL = new UsuariosDAL();

        public Usuarios AutenticarUsuario(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(contrasena))
                throw new ArgumentException("La contraseña es obligatoria.");

            Usuarios usuario = _usuariosDAL.AutenticarUsuario(nombreUsuario, contrasena);

            if (usuario == null)
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");

            return usuario;
        }
    }
}
