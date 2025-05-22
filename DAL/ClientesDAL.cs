using EN;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ClientesDAL
    {
        public int AgregarCliente(Clientes pEn, string nombreUsuario, string contrasena)
        {
            int resultado = 0;
            using (IDbConnection _conn = DBComon.Conexion())
            {
                _conn.Open();
                using (SqlCommand _Comand = new SqlCommand("sp_RegistrarCliente", _conn as SqlConnection))
                {
                    _Comand.CommandType = CommandType.StoredProcedure;

                    // Agregar los datos del cliente
                    _Comand.Parameters.Add(new SqlParameter("@Nombre", pEn.Nombre));
                    _Comand.Parameters.Add(new SqlParameter("@Apellido", pEn.Apellido));
                    _Comand.Parameters.Add(new SqlParameter("@NumeroTelefono", pEn.NumeroTelefono));
                    _Comand.Parameters.Add(new SqlParameter("@Correo", pEn.Correo));

                    // Agregar el nombre de usuario y contraseña del cliente
                    _Comand.Parameters.Add(new SqlParameter("@NombreUsuario", nombreUsuario));
                    _Comand.Parameters.Add(new SqlParameter("@Contrasena", contrasena));

                    resultado = _Comand.ExecuteNonQuery();
                }
                _conn.Close();
            }
            return resultado;
        }

        public List<Clientes> ObtenerClientes()
        {
            List<Clientes> lista = new List<Clientes>();
            using (IDbConnection _conn = DBComon.Conexion())
            {
                _conn.Open();
                using (SqlCommand _command = new SqlCommand("sp_ObtenerClientes", _conn as SqlConnection))
                {
                    _command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = _command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Clientes cliente = new Clientes
                            {
                                Nombre = reader["Nombre"].ToString()!,
                                Apellido = reader["Apellido"].ToString()!,
                                NumeroTelefono = Convert.ToInt32(reader["NumeroTelefono"]),
                                Correo = reader["Correo"].ToString()!,
                                NombreUsuario = reader["NombreUsuario"].ToString()!
                            };
                            lista.Add(cliente);
                        }
                    }
                }
                _conn.Close();
            }
            return lista;
        }
    }
}


