using DAL;
using EN;

namespace BL
{
    public class OrdenesEventosBL
    {
        private OrdenesEventosDAL _ordenesDAL = new OrdenesEventosDAL();

        public int CrearOrdenEvento(OrdenesEventos orden)
        {
            // Validaciones básicas
            if (orden.ClienteId <= 0)
                throw new ArgumentException("El ID del cliente es inválido.");

            if (orden.EventoPredefinidoId <= 0)
                throw new ArgumentException("El evento seleccionado no es válido.");

            if (orden.FechaEventoPersonalizado.HasValue && orden.FechaEventoPersonalizado.Value < DateTime.Today)
                throw new ArgumentException("La fecha del evento no puede estar en el pasado.");

            return _ordenesDAL.CrearOrdenEvento(orden);
        }
        public List<OrdenesEventos> ObtenerOrdenesPorEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("El estado de la orden es requerido.");
            return _ordenesDAL.ObtenerOrdenesPorEstado(estado);
        }
        public List<OrdenesEventos> ObtenerTodasLasOrdenesConDetalles()
        {
            return _ordenesDAL.ObtenerTodasLasOrdenesConDetalles();
        }
        public void ActualizarEstadoOrden(long ordenId, string nuevoEstado)
        {
            try
            {
                _ordenesDAL.ActualizarEstadoOrden(ordenId, nuevoEstado);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la capa de negocio al actualizar el estado de la orden: {ex.Message}");
            }
        }
    }
}

