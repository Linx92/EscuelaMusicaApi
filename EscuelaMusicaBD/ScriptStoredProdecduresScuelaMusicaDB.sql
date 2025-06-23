USE EscuelaMusicaDB;
GO
CREATE   PROCEDURE [ActualizarAlumno]
    @AlumnoId INT,
    @DNI VARCHAR(8),
    @Nombre VARCHAR(30),
    @Apellido VARCHAR(50),
    @FechaNacimiento DATE,
    @EscuelaId INT,
    @Mensaje NVARCHAR(200) OUTPUT,
    @Exito BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Alumno WHERE AlumnoId = @AlumnoId)
    BEGIN
        SET @Mensaje = 'El alumno no existe.'
        SET @Exito = 0
        RETURN
    END

    IF EXISTS (SELECT 1 FROM Alumno WHERE DNI = @DNI AND AlumnoId <> @AlumnoId)
    BEGIN
        SET @Mensaje = 'Ya existe otro alumno con el mismo DNI.'
        SET @Exito = 0
        RETURN
    END

    IF EXISTS (SELECT 1 FROM Profesor WHERE DNI = @DNI)
    BEGIN
        SET @Mensaje = 'El DNI ya está registrado como profesor.'
        SET @Exito = 0
        SET @AlumnoId = 0
        RETURN
    END

    IF NOT EXISTS (SELECT 1 FROM Escuela WHERE EscuelaId = @EscuelaId)
    BEGIN
        SET @Mensaje = 'La escuela no existe.'
        SET @Exito = 0
        SET @AlumnoId = 0
        RETURN
    END
    BEGIN TRY
        UPDATE Alumno
        SET DNI = @DNI,
            Nombre = @Nombre,
            Apellido = @Apellido,
            FechaNacimiento = @FechaNacimiento,
            EscuelaId = @EscuelaId
        WHERE AlumnoId = @AlumnoId;

        SET @Mensaje = 'Alumno actualizado correctamente.'
        SET @Exito = 1
    END TRY
    BEGIN CATCH
        SET @Mensaje = ERROR_MESSAGE()
        SET @Exito = 0
    END CATCH
END
GO
CREATE PROC [ActualizarEscuela]
    @EscuelaId INT,
    @Codigo VARCHAR(10),
    @Nombre VARCHAR(150),
    @Descripcion TEXT,
    @Mensaje NVARCHAR(200) OUTPUT,
    @Exito BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Escuela WHERE EscuelaId = @EscuelaId)
    BEGIN
        SET @Mensaje = 'La escuela no existe.'
        SET @Exito = 0
        RETURN
    END

    IF EXISTS (SELECT 1 FROM Escuela WHERE Codigo = @Codigo AND EscuelaId <> @EscuelaId)
    BEGIN
        SET @Mensaje = 'Ya existe otra escuela con el mismo código.'
        SET @Exito = 0
        RETURN
    END

    BEGIN TRY
        UPDATE Escuela
        SET Codigo = @Codigo,
            Nombre = @Nombre,
            Descripcion = @Descripcion
        WHERE EscuelaId = @EscuelaId;

        SET @Mensaje = 'Escuela actualizada correctamente.'
        SET @Exito = 1
    END TRY
    BEGIN CATCH
        SET @Mensaje = ERROR_MESSAGE()
        SET @Exito = 0
    END CATCH
END
GO
CREATE   PROCEDURE [ActualizarProfesor]
    @ProfesorId INT,
    @DNI VARCHAR(8),
    @Nombre VARCHAR(30),
    @Apellido VARCHAR(50),
    @EscuelaId INT,
    @Mensaje NVARCHAR(200) OUTPUT,
    @Exito BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Profesor WHERE ProfesorId = @ProfesorId)
    BEGIN
        SET @Mensaje = 'El profesor no existe.'
        SET @Exito = 0
        RETURN
    END

    IF EXISTS (SELECT 1 FROM Profesor WHERE DNI = @DNI AND ProfesorId <> @ProfesorId)
    BEGIN
        SET @Mensaje = 'Ya existe otro profesor con el mismo DNI.'
        SET @Exito = 0
        RETURN
    END

    IF EXISTS (SELECT 1 FROM Alumno WHERE DNI = @DNI)
    BEGIN
        SET @Mensaje = 'El DNI ya está registrado como alumno.'
        SET @Exito = 0
        RETURN
    END

    BEGIN TRY
        UPDATE Profesor
        SET DNI = @DNI,
            Nombre = @Nombre,
            Apellido = @Apellido,
            EscuelaId = @EscuelaId
        WHERE ProfesorId = @ProfesorId;

        SET @Mensaje = 'Profesor actualizado correctamente.'
        SET @Exito = 1
    END TRY
    BEGIN CATCH
        SET @Mensaje = ERROR_MESSAGE()
        SET @Exito = 0
    END CATCH
END
GO
CREATE   PROCEDURE [AgregarAlumno]
    @DNI VARCHAR(8),
    @Nombre VARCHAR(30),
    @Apellido VARCHAR(50),
    @FechaNacimiento DATE,
    @EscuelaId INT,
    @AlumnoId INT OUTPUT,
    @Mensaje NVARCHAR(200) OUTPUT,
    @Exito BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM Escuela WHERE EscuelaId = @EscuelaId)
    BEGIN
        SET @Mensaje = 'La escuela no existe.'
        SET @Exito = 0
        SET @AlumnoId = 0
        RETURN
    END

    IF EXISTS (SELECT 1 FROM Alumno WHERE DNI = @DNI)
    BEGIN
        SET @Mensaje = 'Ya existe un alumno con el mismo DNI.'
        SET @Exito = 0
        SET @AlumnoId = 0
        RETURN
    END
   
    IF EXISTS (SELECT 1 FROM Profesor WHERE DNI = @DNI)
    BEGIN
        SET @Mensaje = 'El DNI ya está registrado como profesor.'
        SET @Exito = 0
        SET @AlumnoId = 0
        RETURN
    END

    BEGIN TRY
        INSERT INTO Alumno (DNI, Nombre, Apellido, FechaNacimiento, EscuelaId)
        VALUES (@DNI, @Nombre, @Apellido, @FechaNacimiento, @EscuelaId);

        SET @AlumnoId = SCOPE_IDENTITY();
        SET @Mensaje = 'Alumno registrado correctamente.'
        SET @Exito = 1
    END TRY
    BEGIN CATCH
        SET @Mensaje = ERROR_MESSAGE()
        SET @Exito = 0
        SET @AlumnoId = 0
    END CATCH
END
GO
CREATE PROCEDURE [AgregarEscuela] 
    @Codigo VARCHAR(20),
    @Nombre VARCHAR(100),
    @Descripcion TEXT,
    @EscuelaId INT OUTPUT,
    @Mensaje NVARCHAR(200) OUTPUT,
    @Exito BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Escuela WHERE Codigo = @Codigo)
    BEGIN
        SET @Mensaje = 'Ya existe una escuela con el mismo código.'
        SET @Exito = 0
        SET @EscuelaId = 0
        RETURN
    END

    BEGIN TRY
        INSERT INTO Escuela (Codigo, Nombre, Descripcion)
        VALUES (@Codigo, @Nombre, @Descripcion);

        SET @EscuelaId = SCOPE_IDENTITY();
        SET @Mensaje = 'Escuela registrada correctamente.'
        SET @Exito = 1
    END TRY
    BEGIN CATCH
        SET @Mensaje = ERROR_MESSAGE()
        SET @Exito = 0
        SET @EscuelaId = 0
    END CATCH
END
GO
CREATE   PROCEDURE [AgregarProfesor]
    @DNI VARCHAR(8),
    @Nombre VARCHAR(30),
    @Apellido VARCHAR(50),
    @EscuelaId INT,
    @ProfesorId INT OUTPUT,
    @Mensaje NVARCHAR(200) OUTPUT,
    @Exito BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Profesor WHERE DNI = @DNI)
    BEGIN
        SET @Mensaje = 'Ya existe un profesor con el mismo DNI.'
        SET @Exito = 0
        SET @ProfesorId = 0
        RETURN
    END
    
    IF EXISTS (SELECT 1 FROM Alumno WHERE DNI = @DNI)
    BEGIN
        SET @Mensaje = 'El DNI ya está registrado como alumno.'
        SET @Exito = 0
        SET @ProfesorId = 0
        RETURN
    END

    BEGIN TRY
        INSERT INTO Profesor (DNI, Nombre, Apellido, EscuelaId)
        VALUES (@DNI, @Nombre, @Apellido, @EscuelaId);

        SET @ProfesorId = SCOPE_IDENTITY()
        SET @Mensaje = 'Profesor registrado correctamente.'
        SET @Exito = 1
    END TRY
    BEGIN CATCH
        SET @Mensaje = ERROR_MESSAGE()
        SET @Exito = 0
        SET @ProfesorId = 0
    END CATCH
END
GO
CREATE   PROC [AlumnoInscritoPorProfesor]
    @ProfesorId INT
AS
BEGIN
    SELECT  
            a.DNI AS AlumnoDni,
            a.Nombre AS AlumnoNombre, 
            a.Apellido AS AlumnoApellido, 
            a.FechaNacimiento,
            e.Codigo AS EscuelaCodigo, 
            e.Nombre AS EscuelaNombre,
            e.Descripcion AS EscuelaDescripcion
    FROM Escuela e JOIN Alumno a ON a.EscuelaId = e.EscuelaId
    JOIN AlumnoProfesor ap ON ap.AlumnoId = a.AlumnoId
    JOIN Profesor p ON p.ProfesorId = ap.ProfesorId
    WHERE p.ProfesorId = @ProfesorId
END
GO
CREATE   PROCEDURE [EliminarAlumno]
    @AlumnoId INT,
    @Mensaje NVARCHAR(200) OUTPUT,
    @Exito BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Alumno WHERE AlumnoId = @AlumnoId)
    BEGIN
        SET @Mensaje = 'El alumno no existe.'
        SET @Exito = 0
        RETURN
    END

    BEGIN TRY
        DELETE FROM Alumno WHERE AlumnoId = @AlumnoId;

        SET @Mensaje = 'Alumno eliminado correctamente.'
        SET @Exito = 1
    END TRY
    BEGIN CATCH
        SET @Mensaje = ERROR_MESSAGE()
        SET @Exito = 0
    END CATCH
END
GO
CREATE   PROCEDURE [EliminarEscuela]
    @EscuelaId INT,
    @Mensaje NVARCHAR(200) OUTPUT,
    @Exito BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Escuela WHERE EscuelaId = @EscuelaId)
    BEGIN
        SET @Mensaje = 'La escuela no existe.'
        SET @Exito = 0
        RETURN
    END

    BEGIN TRY
        DELETE FROM Escuela WHERE EscuelaId = @EscuelaId;

        SET @Mensaje = 'Escuela eliminada correctamente.'
        SET @Exito = 1
    END TRY
    BEGIN CATCH
        SET @Mensaje = ERROR_MESSAGE()
        SET @Exito = 0
    END CATCH
END
GO
CREATE   PROCEDURE [EliminarProfesor]
    @ProfesorId INT,
    @Mensaje NVARCHAR(200) OUTPUT,
    @Exito BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Profesor WHERE ProfesorId = @ProfesorId)
    BEGIN
        SET @Mensaje = 'El profesor no existe.'
        SET @Exito = 0
        RETURN
    END

    BEGIN TRY
        DELETE FROM Profesor WHERE ProfesorId = @ProfesorId;

        SET @Mensaje = 'Profesor eliminado correctamente.'
        SET @Exito = 1
    END TRY
    BEGIN CATCH
        SET @Mensaje = ERROR_MESSAGE()
        SET @Exito = 0
    END CATCH
END
GO
CREATE   PROCEDURE [InscribirAlumnoAProfesor]
    @AlumnoId INT,
    @ProfesorId INT,
    @Mensaje NVARCHAR(200) OUTPUT,
    @Exito BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Alumno WHERE AlumnoId = @AlumnoId)
    BEGIN
        SET @Mensaje = 'El alumno no existe.'
        SET @Exito = 0
        RETURN
    END

    IF NOT EXISTS (SELECT 1 FROM Profesor WHERE ProfesorId = @ProfesorId)
    BEGIN
        SET @Mensaje = 'El profesor no existe.'
        SET @Exito = 0
        RETURN
    END

    IF NOT EXISTS (
        SELECT 1
        FROM Alumno a
        JOIN Profesor p ON p.EscuelaId = a.EscuelaId
        WHERE a.AlumnoId = @AlumnoId AND p.ProfesorId = @ProfesorId
    )
    BEGIN
        SET @Mensaje = 'El alumno y el profesor no pertenecen a la misma escuela.'
        SET @Exito = 0
        RETURN
    END

    IF EXISTS ( SELECT 1 FROM AlumnoProfesor WHERE AlumnoId = @AlumnoId AND ProfesorId = @ProfesorId)
    BEGIN
        SET @Mensaje = 'El alumno ya está asignado a este profesor.'
        SET @Exito = 0
        RETURN
    END

    BEGIN TRY
        INSERT INTO AlumnoProfesor (AlumnoId, ProfesorId)
        VALUES (@AlumnoId, @ProfesorId);

        SET @Mensaje = 'Alumno asignado al profesor correctamente.'
        SET @Exito = 1
    END TRY
    BEGIN CATCH
        SET @Mensaje = ERROR_MESSAGE()
        SET @Exito = 0
    END CATCH
END
GO
CREATE   PROCEDURE [ObtenerAlumnoPorId]
    @AlumnoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        AlumnoId,
        DNI,
        Nombre,
        Apellido,
        FechaNacimiento,
        EscuelaId
    FROM Alumno
    WHERE AlumnoId = @AlumnoId;
END
GO
CREATE   PROCEDURE [ObtenerAlumnos]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        AlumnoId,
        DNI,
        Nombre,
        Apellido,
        FechaNacimiento,
        EscuelaId
    FROM Alumno
END
GO
CREATE PROC [ObtenerEscuelaPorId]
    @EscuelaId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT EscuelaId,Codigo,Nombre,Descripcion FROM Escuela
    WHERE EscuelaId = @EscuelaId;
END
GO
CREATE PROC [ObtenerEscuelas]
AS
BEGIN 
    SET NOCOUNT ON;
    SELECT EscuelaId,Codigo,Nombre,Descripcion FROM Escuela;
END
GO
CREATE   PROCEDURE [ObtenerProfesores]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ProfesorId,
        DNI,
        Nombre,
        Apellido,
        EscuelaId
    FROM Profesor
END
GO
CREATE   PROCEDURE [ObtenerProfesorPorId]
    @ProfesorId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ProfesorId,
        DNI,
        Nombre,
        Apellido,
        EscuelaId
    FROM Profesor
    WHERE ProfesorId = @ProfesorId;
END
GO
CREATE PROC [ProfesorPorAlumnoInscrito]
    @AlumnoId INT
AS
BEGIN
    SELECT 
        p.DNI AS ProfesorDni,
        p.Nombre AS ProfesorNombre, 
        p.Apellido AS ProfesorApellido, 
        e.Codigo AS EscuelaCodigo, 
        e.Nombre AS EscuelaNombre,
        e.Descripcion AS EscuelaDescripcion
    FROM Escuela e JOIN Alumno a ON a.EscuelaId = e.EscuelaId
    JOIN AlumnoProfesor ap ON ap.AlumnoId = a.AlumnoId
    JOIN Profesor p ON p.ProfesorId = ap.ProfesorId
    WHERE a.AlumnoId = @AlumnoId
END

