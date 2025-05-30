USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearEventoPredefinido]    Script Date: 05/14/2025 20:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Permite crear eventos para luego ser mostrados a los clientes>
-- =============================================
ALTER PROCEDURE [dbo].[sp_CrearEventoPredefinido] (
    @NombreEvento VARCHAR(100),
    @Descripcion VARCHAR(MAX),
    @PrecioBase DECIMAL(10, 2)
)
AS
BEGIN
    -- Transacción para asegurar la integridad de la inserción
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Insertar el nuevo evento predefinido en la tabla EventosPredefinidos
        INSERT INTO dbo.EventosPredefinidos (NombreEvento, Descripcion, PrecioBase)
        VALUES (@NombreEvento, @Descripcion, @PrecioBase);

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
