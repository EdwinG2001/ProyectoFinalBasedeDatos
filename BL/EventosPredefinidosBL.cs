using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using DAL;

namespace BL
{
    public class EventosPredefinidosBL
    {
        private readonly EventosPredefinidosDAL _eventosPredefinidosDAL;

        public EventosPredefinidosBL()
        {
            _eventosPredefinidosDAL = new EventosPredefinidosDAL();
        }

        // Crear Evento Predefinido
        public int CrearEventoPredefinido(EventosPredefinidos evento)
        {
            if (string.IsNullOrWhiteSpace(evento.NombreEvento))
                throw new ArgumentException("El nombre del evento es obligatorio.");

            if (string.IsNullOrWhiteSpace(evento.Descripcion))
                throw new ArgumentException("La descripción del evento es obligatoria.");

            if (evento.PrecioBase < 0)
                throw new ArgumentException("El precio base no puede ser negativo.");

            return _eventosPredefinidosDAL.CrearEventoPredefinido(evento);
        }


        // Obtener todos los eventos predefinidos
        public List<EventosPredefinidos> ObtenerEventosPredefinidos()
        {
            return _eventosPredefinidosDAL.ObtenerEventos();
        }
    }
}


