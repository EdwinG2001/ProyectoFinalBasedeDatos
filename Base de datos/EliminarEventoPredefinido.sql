USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarEventoPredefinido]    Script Date: 05/14/2025 19:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo #5>
-- Create date: <12-05-2025>
-- Description:	<Eliminar evento>
-- =============================================
ALTER PROCEDURE [dbo].[sp_EliminarEventoPredefinido]
    @EventoID BIGINT
AS
BEGIN
    DELETE FROM EventosPredefinidos WHERE EventoPredefinidoID = @EventoID
END
