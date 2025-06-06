USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDetalleOrden]    Script Date: 05/14/2025 19:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Muestra los detalles de la orden>
-- =============================================
ALTER PROCEDURE [dbo].[sp_ObtenerDetalleOrden] (
    @OrdenId BIGINT
)
AS
BEGIN
    -- Seleccionar los detalles de una orden específica, incluyendo información del cliente y el evento
    SELECT
        o.OrdenId,
        o.FechaSolicitud,
        o.FechaEventoPersonalizado,
        o.LugarEventoPersonalizado,
        o.ExtrasSolicitados,
        o.NumeroAsistentes,
        o.PrecioFinalEstimado,
        o.EstadoOrden,
        c.ClienteId,
        c.Nombre AS NombreCliente,
        c.Apellido AS ApellidoCliente,
        c.NumeroTelefono AS TelefonoCliente,
        c.Correo AS CorreoCliente,
        e.EventoPredefinidoId,
        e.NombreEvento,
        e.Descripcion AS DescripcionEvento,
        e.PrecioBase AS PrecioBaseEvento
    FROM dbo.OrdenesEventos o
    INNER JOIN dbo.Clientes c ON o.ClienteId = c.ClienteId
    INNER JOIN dbo.EventosPredefinidos e ON o.EventoPredefinidoId = e.EventoPredefinidoId
    WHERE o.OrdenId = @OrdenId;
END;
