USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDetalleEventoPredefinido]    Script Date: 05/14/2025 19:44:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Obtener los detalles de los eventos ya creados >
-- =============================================
ALTER PROCEDURE [dbo].[sp_ObtenerDetalleEventoPredefinido] (
    @EventoPredefinidoID BIGINT
)
AS
BEGIN
    -- Seleccionar todos los detalles del evento predefinido con el ID especificado
    SELECT
        EventoPredefinidoID,
        NombreEvento,
        Descripcion,
        PrecioBase
    FROM dbo.EventosPredefinidos
    WHERE EventoPredefinidoID = @EventoPredefinidoID;
END;
