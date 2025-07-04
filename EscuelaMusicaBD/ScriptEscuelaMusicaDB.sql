CREATE DATABASE [EscuelaMusicaDB];
GO

-- Cambiar a la nueva base de datos
USE [EscuelaMusicaDB];
GO

-- Tabla Escuela
CREATE TABLE [Escuela](
	[EscuelaId] INT IDENTITY(1,1) NOT NULL,
	[Codigo] VARCHAR(10) NOT NULL,
	[Nombre] VARCHAR(150) NOT NULL,
	[Descripcion] VARCHAR(MAX) NULL,
	CONSTRAINT [PK_Escuela] PRIMARY KEY CLUSTERED ([EscuelaId]),
	CONSTRAINT [UQ_Escuela_Codigo] UNIQUE ([Codigo])
);

-- Tabla Alumno
CREATE TABLE [Alumno](
	[AlumnoId] INT IDENTITY(1,1) NOT NULL,
	[DNI] VARCHAR(8) NOT NULL,
	[Nombre] VARCHAR(30) NOT NULL,
	[Apellido] VARCHAR(50) NOT NULL,
	[FechaNacimiento] DATE NULL,
	[EscuelaId] INT NOT NULL,
	CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED ([AlumnoId]),
	CONSTRAINT [UQ_Alumno_DNI] UNIQUE ([DNI]),
	CONSTRAINT [FK_Alumno_Escuela] FOREIGN KEY ([EscuelaId]) REFERENCES [Escuela]([EscuelaId])
);

-- Tabla Profesor
CREATE TABLE [Profesor](
	[ProfesorId] INT IDENTITY(1,1) NOT NULL,
	[DNI] VARCHAR(8) NOT NULL,
	[Nombre] VARCHAR(30) NOT NULL,
	[Apellido] VARCHAR(50) NOT NULL,
	[EscuelaId] INT NOT NULL,
	CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED ([ProfesorId]),
	CONSTRAINT [UQ_Profesor_DNI] UNIQUE ([DNI]),
	CONSTRAINT [FK_Profesor_Escuela] FOREIGN KEY ([EscuelaId]) REFERENCES [Escuela]([EscuelaId])
);

-- Tabla AlumnoProfesor
CREATE TABLE [AlumnoProfesor](
	[AlumnoId] INT NOT NULL,
	[ProfesorId] INT NOT NULL,
	CONSTRAINT [PK_AlumnoProfesor] PRIMARY KEY CLUSTERED ([AlumnoId], [ProfesorId]),
	CONSTRAINT [FK_AlumnoProfesor_Alumno] FOREIGN KEY ([AlumnoId]) REFERENCES [Alumno]([AlumnoId]),
	CONSTRAINT [FK_AlumnoProfesor_Profesor] FOREIGN KEY ([ProfesorId]) REFERENCES [Profesor]([ProfesorId])
);

