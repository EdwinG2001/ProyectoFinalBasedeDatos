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
    public class OrdenesEventosDAL
    {
        public int CrearOrdenEvento(OrdenesEventos pEn)
        {
            int resultado = 0;
            using (IDbConnection _conn = DBComon.Conexion())
            {
                _conn.Open();
                using (SqlCommand _Comand = new SqlCommand("sp_CrearOrdenEvento", _conn as SqlConnection))
                {
                    _Comand.CommandType = CommandType.StoredProcedure;
                    _Comand.Parameters.Add(new SqlParameter("@ClienteId", pEn.ClienteId));
                    _Comand.Parameters.Add(new SqlParameter("@EventoPredefinidoId", pEn.EventoPredefinidoId));
                    _Comand.Parameters.Add(new SqlParameter("@FechaEventoPersonalizado", pEn.FechaEventoPersonalizado.HasValue ? (object)pEn.FechaEventoPersonalizado.Value : DBNull.Value));
                    _Comand.Parameters.Add(new SqlParameter("@LugarEventoPersonalizado", pEn.LugarEventoPersonalizado ?? (object)DBNull.Value));
                    _Comand.Parameters.Add(new SqlParameter("@ExtrasSolicitados", pEn.ExtrasSolicitados ?? (object)DBNull.Value));
                    _Comand.Parameters.Add(new SqlParameter("@NumeroAsistentes", pEn.NumeroAsistentes.HasValue ? (object)pEn.NumeroAsistentes.Value : DBNull.Value));
                    _Comand.Parameters.Add(new SqlParameter("@PrecioFinalEstimado", pEn.PrecioFinalEstimado.HasValue ? (object)pEn.PrecioFinalEstimado.Value : DBNull.Value));

                    int filasAfectadas = _Comand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        resultado = 0; // Indica éxito
                    }
                    else
                    {
                        resultado = 1; // Indica fallo (aunque esto ya lo maneja el CATCH del SP)
                    }
                }
                _conn.Close();
            }
            return resultado;
        }
        public List<OrdenesEventos> ObtenerOrdenesPorEstado(string estadoOrden)
        {
            List<OrdenesEventos> lista = new List<OrdenesEventos>();
            using (IDbConnection _conn = DBComon.Conexion())
            {
                _conn.Open();
                using (SqlCommand _Command = new SqlCommand("sp_ObtenerOrdenesPorEstado", _conn as SqlConnection))
                {
                    _Command.CommandType = CommandType.StoredProcedure;
                    _Command.Parameters.Add(new SqlParameter("@EstadoOrden", estadoOrden));
                    using (SqlDataReader _reader = _Command.ExecuteReader())
                    {
                        while (_reader.Read())
                        {
                            OrdenesEventos _orden = new OrdenesEventos
                            {
                                OrdenId = _reader.GetInt64(0),
                                ClienteId = _reader.GetInt64(1),
                                Nombre = _reader.GetString(2),
                                Correo = _reader.IsDBNull(3) ? null : _reader.GetString(3),
                                EventoPredefinidoId = _reader.GetInt64(4),
                                NombreEvento = _reader.GetString(5),
                                FechaSolicitud = _reader.GetDateTime(6),
                                FechaEventoPersonalizado = _reader.IsDBNull(7) ? (DateTime?)null : _reader.GetDateTime(7),
                                LugarEventoPersonalizado = _reader.IsDBNull(8) ? null : _reader.GetString(8),
                                ExtrasSolicitados = _reader.IsDBNull(9) ? null : _reader.GetString(9),
                                NumeroAsistentes = _reader.IsDBNull(10) ? (int?)null : _reader.GetInt32(10),
                                PrecioFinalEstimado = _reader.IsDBNull(11) ? (decimal?)null : _reader.GetDecimal(11),
                                EstadoOrden = _reader.GetString(12)
                            };
                            lista.Add(_orden);
                        }
                    }
                }
                _conn.Close();
            }
            return lista;
        }
        public int ActualizarEstadoOrden(long ordenId, string estadoOrden)
        {
            int resultado = 0;
            using (IDbConnection _conn = DBComon.Conexion())
            {
                _conn.Open();
                using (SqlCommand _Comand = new SqlCommand("sp_ActualizarEstadoOrden", _conn as SqlConnection))
                {
                    _Comand.CommandType = CommandType.StoredProcedure;
                    _Comand.Parameters.Add(new SqlParameter("@OrdenId", ordenId));
                    _Comand.Parameters.Add(new SqlParameter("@EstadoOrden", estadoOrden));

                    // Añadir parámetro de salida para el valor de retorno
                    SqlParameter returnValueParam = new SqlParameter("@ReturnValue", SqlDbType.Int);
                    returnValueParam.Direction = ParameterDirection.ReturnValue;
                    _Comand.Parameters.Add(returnValueParam);
                    _Comand.ExecuteNonQuery();
                    resultado = (int)returnValueParam.Value;
                    if (resultado != 0)
                    {
                        throw new Exception($"Error al actualizar el estado de la orden (SP retorno: {resultado}).");
                    }
                }
                _conn.Close();
            }
            return resultado;
        }
        public List<OrdenesEventos> ObtenerTodasLasOrdenesConDetalles()
        {
            List<OrdenesEventos> lista = new List<OrdenesEventos>();
            using (IDbConnection _conn = DBComon.Conexion())
            {
                _conn.Open();
                using (SqlCommand _Command = new SqlCommand("sp_ObtenerOrdenesConDetalles", _conn as SqlConnection))
                {
                    _Command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader _reader = _Command.ExecuteReader())
                    {
                        while (_reader.Read())
                        {
                            OrdenesEventos _orden = new OrdenesEventos
                            {
                                OrdenId = _reader.GetInt64(0),
                                ClienteId = _reader.GetInt64(1),
                                Nombre = _reader.GetString(2),
                                Correo = _reader.IsDBNull(3) ? null : _reader.GetString(3),
                                EventoPredefinidoId = _reader.GetInt64(4),
                                NombreEvento = _reader.GetString(5),
                                FechaSolicitud = _reader.GetDateTime(6),
                                FechaEventoPersonalizado = _reader.IsDBNull(7) ? (DateTime?)null : _reader.GetDateTime(7),
                                LugarEventoPersonalizado = _reader.IsDBNull(8) ? null : _reader.GetString(8),
                                ExtrasSolicitados = _reader.IsDBNull(9) ? null : _reader.GetString(9),
                                NumeroAsistentes = _reader.IsDBNull(10) ? (int?)null : _reader.GetInt32(10),
                                PrecioFinalEstimado = _reader.IsDBNull(11) ? (decimal?)null : _reader.GetDecimal(11),
                                EstadoOrden = _reader.GetString(12)
                            };
                            lista.Add(_orden);
                        }
                    }
                }
                _conn.Close();
                return lista;
            }
        }
    }
}

