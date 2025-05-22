using EN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class MensajeAyudaDAL
    {
        public bool RegistrarMensaje(MensajesAyuda m)
        {
            using (IDbConnection conn = DBComon.Conexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarMensajeAyuda", conn as SqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@NombreCompleto", m.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Usuario", m.Usuario);
                    cmd.Parameters.AddWithValue("@Correo", m.Correo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TipoMensaje", m.TipoMensaje);
                    cmd.Parameters.AddWithValue("@Mensaje", m.Mensaje);

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    returnValue.DbType = DbType.Int32;
                    cmd.Parameters.Add(returnValue);

                    cmd.ExecuteNonQuery();
                    int resultado = (int)returnValue.Value;
                    return resultado == 1;
                }
            }
        }
    }
}
