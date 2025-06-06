USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerEmpleados]    Script Date: 05/14/2025 19:15:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Muestra los empleados agregados a la empresa>
-- =============================================
ALTER PROCEDURE [dbo].[sp_ObtenerEmpleados]
AS
BEGIN
    -- Seleccionar todos los empleados de la tabla Empleados
    SELECT
        EmpleadoID,
        Nombre,
        Apellido,
        NumeroTelefono,
        Correo,
        Cargo
    FROM dbo.Empleados;
END;
