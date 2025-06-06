USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearOrdenEvento]    Script Date: 05/14/2025 19:47:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Crear una orden del evento seleccionado por el cliente>
-- =============================================
ALTER PROCEDURE [dbo].[sp_CrearOrdenEvento] (
    @ClienteId BIGINT,
    @EventoPredefinidoId BIGINT,
    @FechaEventoPersonalizado DATE = NULL,
    @LugarEventoPersonalizado VARCHAR(MAX) = NULL,
    @ExtrasSolicitados VARCHAR(MAX) = NULL,
    @NumeroAsistentes INT = NULL,
    @PrecioFinalEstimado DECIMAL(10, 2) = NULL
)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        INSERT INTO dbo.OrdenesEventos (
            ClienteId,
            EventoPredefinidoId,
            FechaSolicitud,
            FechaEventoPersonalizado,
            LugarEventoPersonalizado,
            ExtrasSolicitados,
            NumeroAsistentes,
            PrecioFinalEstimado,
            EstadoOrden
        )
        VALUES (
            @ClienteId,
            @EventoPredefinidoId,
            GETDATE(), -- Fecha actual
            @FechaEventoPersonalizado,
            @LugarEventoPersonalizado,
            @ExtrasSolicitados,
            @NumeroAsistentes,
            @PrecioFinalEstimado,
            'DISPONIBLE' -- Estado inicial
        );

        COMMIT TRANSACTION;
        RETURN 0;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(MAX);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
        RETURN 1;
    END CATCH;
END;