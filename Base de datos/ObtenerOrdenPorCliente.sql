USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerOrdenesCliente]    Script Date: 05/14/2025 19:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Muestra las ordenes de un cliente en especifico>
-- =============================================
ALTER PROCEDURE [dbo].[sp_ObtenerOrdenesCliente] (
    @ClienteId BIGINT
)
AS
BEGIN
    -- Seleccionar todas las órdenes para un cliente específico
    SELECT
        OrdenId,
        EventoPredefinidoId,
        FechaSolicitud,
        FechaEventoPersonalizado,
        LugarEventoPersonalizado,
        ExtrasSolicitados,
        NumeroAsistentes,
        PrecioFinalEstimado,
        EstadoOrden
    FROM dbo.OrdenesEventos
    WHERE ClienteId = @ClienteId;
END;
