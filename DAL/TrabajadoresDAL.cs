using EN;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class TrabajadoresDAL
    {
        public int AgregarTrabajador(Trabajadores pEn, string nombreUsuario, string contrasena)
        {
            int resultado = 0;
            using (IDbConnection _conn = DBComon.Conexion())
            {
                _conn.Open();
                using (SqlCommand _Comand = new SqlCommand("sp_RegistrarEmpleado", _conn as SqlConnection))
                {
                    _Comand.CommandType = CommandType.StoredProcedure;

                    // Agregar los datos del trabajador
                    _Comand.Parameters.Add(new SqlParameter("@Nombre", pEn.Nombre));
                    _Comand.Parameters.Add(new SqlParameter("@Apellido", pEn.Apellido));
                    _Comand.Parameters.Add(new SqlParameter("@NumeroTelefono", pEn.NumeroTelefono));
                    _Comand.Parameters.Add(new SqlParameter("@Correo", pEn.Correo));

                    // Agregar el cargo del trabajador
                    _Comand.Parameters.Add(new SqlParameter("@Cargo", pEn.Cargo));

                    // Agregar el nombre de usuario y la contraseña del trabajador
                    _Comand.Parameters.Add(new SqlParameter("@NombreUsuario", nombreUsuario));
                    _Comand.Parameters.Add(new SqlParameter("@Contrasena", contrasena));

                    resultado = _Comand.ExecuteNonQuery();
                }
                _conn.Close();
            }
            return resultado;
        }
    }
}
