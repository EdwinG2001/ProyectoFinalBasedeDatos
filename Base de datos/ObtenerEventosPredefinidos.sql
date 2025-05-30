USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerEventosPredefinidos]    Script Date: 05/14/2025 19:14:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Muestra los eventos ya guardados >
-- =============================================
ALTER PROCEDURE [dbo].[sp_ObtenerEventosPredefinidos]
AS
BEGIN
    -- Seleccionar todos los eventos predefinidos de la tabla EventosPredefinidos
    SELECT
        EventoPredefinidoID,
        NombreEvento,
        Descripcion,
        PrecioBase
    FROM dbo.EventosPredefinidos;
END;
