using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using Microsoft.Data.SqlClient;



namespace DAL
{
    public class UsuariosDAL
    {
        public Usuarios AutenticarUsuario(string nombreUsuario, string contrasena)
        {
            Usuarios usuarioAutenticado = null;
            using (IDbConnection _conn = DBComon.Conexion())
            {
                _conn.Open();
                using (SqlCommand _Command = new SqlCommand("sp_AutenticarUsuario", _conn as SqlConnection))
                {
                    _Command.CommandType = CommandType.StoredProcedure;
                    _Command.Parameters.Add(new SqlParameter("@NombreUsuario", nombreUsuario));
                    _Command.Parameters.Add(new SqlParameter("@Contrasena", contrasena));

                    using (SqlDataReader _reader = _Command.ExecuteReader())
                    {
                        if (_reader.Read())
                        {
                            usuarioAutenticado = new Usuarios();
                            usuarioAutenticado.UsuarioId = _reader.GetInt32(0); // Columna UsuarioId
                            usuarioAutenticado.TipoUsuario = _reader.GetString(1); // Columna TipoUsuario
                            usuarioAutenticado.NombreUsuario = _reader.GetString(2); // Columna NombreUsuario
                            usuarioAutenticado.Contrasena = _reader.GetString(3); // Columna Contrasena
                            usuarioAutenticado.EmpleadoId = _reader.IsDBNull(4) ? (int?)null : _reader.GetInt32(4); // Columna EmpleadoId
                            usuarioAutenticado.ClienteId = _reader.IsDBNull(5) ? (int?)null : _reader.GetInt32(5); // Columna ClienteId
                        }
                    }
                }
                _conn.Close();
            }
            return usuarioAutenticado;
        }
    }
}

