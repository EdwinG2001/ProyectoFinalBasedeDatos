USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarCliente]    Script Date: 05/15/2025 22:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Registra la informacion del cliente>
-- =============================================
ALTER PROCEDURE [dbo].[sp_RegistrarCliente] (
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @NumeroTelefono VARCHAR(20),
    @Correo VARCHAR(100),
    @NombreUsuario VARCHAR(50),
    @Contrasena NVARCHAR(255)
)
AS
BEGIN
    -- Transacción para asegurar la integridad de las inserciones
    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Insertar el nuevo cliente en la tabla Clientes
        INSERT INTO dbo.Clientes (Nombre, Apellido, NumeroTelefono, Correo, NombreUsuario) -- ¡AGREGAR NombreUsuario AQUÍ!
        VALUES (@Nombre, @Apellido, @NumeroTelefono, @Correo, @NombreUsuario); -- ¡Y EL VALOR AQUÍ!

        -- Obtener el ID del cliente recién insertado
        DECLARE @ClienteID INT;
        SELECT @ClienteID = SCOPE_IDENTITY();

        -- 2. Insertar el registro del usuario en la tabla Usuarios
        -- Encriptar
        INSERT INTO dbo.Usuarios (TipoUsuario, NombreUsuario, Contrasena, ClienteID)
        VALUES (
            'Cliente',
            @NombreUsuario,
            EncryptByPassPhrase('MiClaveSecreta123', @Contrasena),
            @ClienteID
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
