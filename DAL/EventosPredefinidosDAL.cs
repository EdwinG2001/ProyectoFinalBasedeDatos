using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class EventosPredefinidosDAL
    {
        private string connectionString = @"Data Source=EDWIN-PC\SQLEXPRESS;Initial Catalog=ProyectoFinal;Integrated Security=True;Encrypt=False";

        public int CrearEventoPredefinido(EventosPredefinidos evento)
        {
            int resultado = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CrearEventoPredefinido", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreEvento", evento.NombreEvento);
                cmd.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                cmd.Parameters.AddWithValue("@PrecioBase", evento.PrecioBase);

                conn.Open();
                resultado = cmd.ExecuteNonQuery();
            }
            return resultado;
        }
     
        // ✅ Obtener todos los eventos
        public List<EventosPredefinidos> ObtenerEventos()
        {
            List<EventosPredefinidos> lista = new List<EventosPredefinidos>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerEventosPredefinidos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EventosPredefinidos evento = new EventosPredefinidos
                    {
                        EventoPredefinidoID = Convert.ToInt32(reader["EventoPredefinidoID"]),
                        NombreEvento = reader["NombreEvento"]?.ToString() ?? string.Empty,
                        Descripcion = reader["Descripcion"]?.ToString() ?? string.Empty,
                        PrecioBase = Convert.ToDecimal(reader["PrecioBase"])
                    };
                    lista.Add(evento);
                }
            }

            return lista;
        }

       /* public int EliminarEventoPredefinido(long id)
        {
            int resultado = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarEventoPredefinido", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EventoID", id);

                conn.Open();
                resultado = cmd.ExecuteNonQuery();
            }

            return resultado;
        } */
    }
}

