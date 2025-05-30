USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerOrdenesPorEstado]    Script Date: 05/14/2025 19:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Para filtrar las ordenes dependiendo su estado>
-- =============================================
ALTER PROCEDURE [dbo].[sp_ObtenerOrdenesPorEstado] (
    @EstadoOrden VARCHAR(50)
)
AS
BEGIN
    -- Seleccionar todas las órdenes con el estado especificado
    SELECT
        OrdenId,
        ClienteId,
        EventoPredefinidoId,
        FechaSolicitud,
        FechaEventoPersonalizado,
        LugarEventoPersonalizado,
        ExtrasSolicitados,
        NumeroAsistentes,
        PrecioFinalEstimado,
        EstadoOrden
    FROM dbo.OrdenesEventos
    WHERE EstadoOrden = @EstadoOrden;
END;
