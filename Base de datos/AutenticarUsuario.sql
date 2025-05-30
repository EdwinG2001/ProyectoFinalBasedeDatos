USE [ProyectoFinal]
GO
/****** Object:  StoredProcedure [dbo].[sp_AutenticarUsuario]    Script Date: 05/14/2025 20:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Grupo 5>
-- Create date: <3-05-2025>
-- Description:	<Autenticar Usuario>
-- =============================================
ALTER PROCEDURE [dbo].[sp_AutenticarUsuario] (
    @NombreUsuario VARCHAR(50),
    @Contrasena NVARCHAR(255), -- 👈 Debe ser NVARCHAR para que coincida
    @TipoUsuarioOUT VARCHAR(15) OUTPUT,
    @UsuarioIDOUT INT OUTPUT,
    @Exito BIT OUTPUT
)
AS
BEGIN
    -- Inicializar los parámetros de salida
    SET @Exito = 0;
    SET @TipoUsuarioOUT = NULL;
    SET @UsuarioIDOUT = NULL;

    -- Buscar y comparar la contraseña desencriptada
    SELECT
        @TipoUsuarioOUT = TipoUsuario,
        @UsuarioIDOUT = UsuarioID
    FROM dbo.Usuarios
    WHERE NombreUsuario = @NombreUsuario
      AND CONVERT(NVARCHAR(MAX), DecryptByPassPhrase('MiClaveSecreta123', Contrasena)) = @Contrasena;

    -- Si hay coincidencia, éxito = 1
    IF @@ROWCOUNT > 0
    BEGIN
        SET @Exito = 1;
    END;
END;