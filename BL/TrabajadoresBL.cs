using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using DAL;

namespace BL
{
    public class TrabajadoresBL
    {
        private TrabajadoresDAL _trabajadoresDAL = new TrabajadoresDAL();
        public int AgregarTrabajador(Trabajadores trabajador, string nombreUsuario, string contrasena)
        {
            // VALIDACIONES
            if (string.IsNullOrWhiteSpace(trabajador.Nombre))
                throw new ArgumentException("El nombre del trabajador es obligatorio.");

            if (string.IsNullOrWhiteSpace(trabajador.Apellido))
                throw new ArgumentException("El apellido del trabajador es obligatorio.");

            if (trabajador.NumeroTelefono <= 0)
                throw new ArgumentException("El número de teléfono no es válido.");

            if (string.IsNullOrWhiteSpace(trabajador.Correo) || !trabajador.Correo.Contains("@"))
                throw new ArgumentException("El correo electrónico no es válido.");

            if (string.IsNullOrWhiteSpace(trabajador.Cargo))
                throw new ArgumentException("El cargo del trabajador es obligatorio.");

            if (string.IsNullOrWhiteSpace(nombreUsuario) || nombreUsuario.Length < 3)
                throw new ArgumentException("El nombre de usuario debe tener al menos 4 caracteres.");

            if (string.IsNullOrWhiteSpace(contrasena) || contrasena.Length < 3)
                throw new ArgumentException("La contraseña debe tener al menOs 3 caracteres.");

            return _trabajadoresDAL.AgregarTrabajador(trabajador, nombreUsuario, contrasena);
        }
    }
}

