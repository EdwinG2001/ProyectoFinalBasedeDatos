USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarEstadoOrden]    Script Date: 05/14/2025 20:16:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Actualizar el estado de la orden>
-- =============================================
ALTER PROCEDURE [dbo].[sp_ActualizarEstadoOrden] (
    @OrdenId BIGINT,
    @EstadoOrden VARCHAR(50)
)
AS
BEGIN
    -- Transacción para asegurar la integridad de la actualización
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Actualizar el estado de la orden en la tabla OrdenesEventos
        UPDATE dbo.OrdenesEventos
        SET EstadoOrden = @EstadoOrden
        WHERE OrdenId = @OrdenId;
IF @EstadoOrden IS NULL OR LTRIM(RTRIM(@EstadoOrden)) = ''
BEGIN
    RAISERROR('El estado de la orden no puede estar vacío.', 16, 1);
    RETURN 1;
END

        -- Verificar si se actualizó alguna fila
        IF @@ROWCOUNT > 0
        BEGIN
            -- Si la actualización fue exitosa, confirmar la transacción
            COMMIT TRANSACTION;
            RETURN 0; -- Indica éxito
        END
        ELSE
        BEGIN
            -- Si no se encontró la orden a actualizar
            RAISERROR('No se encontró la orden con el ID especificado.', 16, 1);
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
