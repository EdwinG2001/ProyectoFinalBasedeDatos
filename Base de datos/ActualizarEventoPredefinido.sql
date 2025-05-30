USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarEventoPredefinido]    Script Date: 05/14/2025 20:15:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<permitirá a los administradores modificar la información de un evento predefinido existente en la tabla >
-- =============================================
ALTER PROCEDURE [dbo].[sp_ActualizarEventoPredefinido] (
    @EventoPredefinidoID BIGINT,
    @NombreEvento VARCHAR(100) = NULL,
    @Descripcion VARCHAR(MAX) = NULL,
    @PrecioBase DECIMAL(10, 2) = NULL
)
AS
BEGIN
    -- Transacción para asegurar la integridad de la actualización
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Actualizar el evento predefinido en la tabla EventosPredefinidos
        UPDATE dbo.EventosPredefinidos
        SET
            NombreEvento = ISNULL(@NombreEvento, NombreEvento),
            Descripcion = ISNULL(@Descripcion, Descripcion),
            PrecioBase = ISNULL(@PrecioBase, PrecioBase)
        WHERE EventoPredefinidoId = @EventoPredefinidoID;

        -- Verificar si se actualizó alguna fila
        IF @@ROWCOUNT > 0
        BEGIN
            -- Si la actualización fue exitosa, confirmar la transacción
            COMMIT TRANSACTION;
            RETURN 0; -- Indica éxito
        END
        ELSE
        BEGIN
            -- Si no se encontró el evento a actualizar
            RAISERROR('No se encontró el evento predefinido con el ID especificado.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN 1; -- Indica fallo
        END
    END TRY
    BEGIN CATCH
        -- Si ocurre algún otro error, deshacer la transacción
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Devolver información sobre el error (compatible con SQL Server 2008)
        DECLARE @ErrorMessage NVARCHAR(MAX);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
        RETURN 1; -- Indica fallo
    END CATCH;
END;
