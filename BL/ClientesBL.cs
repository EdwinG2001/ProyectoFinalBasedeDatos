using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using DAL;

namespace BL
{
    public class ClientesBL
    {
        private ClientesDAL _clientesDAL = new ClientesDAL();

        public int AgregarCliente(Clientes cliente, string nombreUsuario, string contrasena)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");
            if (string.IsNullOrWhiteSpace(cliente.Apellido))
                throw new ArgumentException("El apellido del cliente es obligatorio.");
            if (cliente.NumeroTelefono <= 0)
                throw new ArgumentException("El número de teléfono debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(cliente.Correo) || !cliente.Correo.Contains("@"))
                throw new ArgumentException("El correo electrónico no es válido.");
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(contrasena) || contrasena.Length < 3)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
            return _clientesDAL.AgregarCliente(cliente, nombreUsuario, contrasena);
        }
        public List<Clientes> ObtenerClientes()
        {
            return _clientesDAL.ObtenerClientes();
        }
    }
}
