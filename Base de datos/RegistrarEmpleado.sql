USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarEmpleado]    Script Date: 05/15/2025 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Registra la informacion del emplado>
-- =============================================
ALTER PROCEDURE [dbo].[sp_RegistrarEmpleado] (
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @NumeroTelefono VARCHAR(20),
    @Correo VARCHAR(100),
    @Cargo VARCHAR(50),
    @NombreUsuario VARCHAR(50),
    @Contrasena NVARCHAR(255)
)
AS
BEGIN
    -- Transacción para asegurar la integridad de las inserciones
    BEGIN TRANSACTION;

    BEGIN TRY
        -- 1. Insertar el nuevo empleado en la tabla Empleados
        INSERT INTO dbo.Empleados (Nombre, Apellido, NumeroTelefono, Correo, Cargo, NombreUsuario) -- ¡AGREGAR NombreUsuario AQUÍ!
        VALUES (@Nombre, @Apellido, @NumeroTelefono, @Correo, @Cargo, @NombreUsuario); -- ¡Y EL VALOR AQUÍ!

        -- Obtener el ID del empleado recién insertado
        DECLARE @EmpleadoID INT;
        SELECT @EmpleadoID = SCOPE_IDENTITY();

        -- 2. Insertar el registro del usuario en la tabla Usuarios
        INSERT INTO dbo.Usuarios (TipoUsuario, NombreUsuario, Contrasena, EmpleadoId)
        VALUES (
            'Trabajador',
            @NombreUsuario,
            EncryptByPassPhrase('MiClaveSecreta123', @Contrasena),
            @EmpleadoID
        );

        -- Si todo sale bien, confirmar la transacción
        COMMIT TRANSACTION;
        RETURN 0; -- Indica éxito
    END TRY
    BEGIN CATCH
        -- Si ocurre algún error, deshacer la transacción
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Devolver información sobre el error (compatible con SQL Server 2008)
        DECLARE @ErrorMessage NVARCHAR(MAX);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
        RETURN 1; -- Indica fallo
    END CATCH;
END;