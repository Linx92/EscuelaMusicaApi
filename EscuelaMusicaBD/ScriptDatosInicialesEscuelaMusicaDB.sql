USE [EscuelaMusicaDB]
GO
SET IDENTITY_INSERT [Escuela] ON 
GO
INSERT [Escuela] ([EscuelaId], [Codigo], [Nombre], [Descripcion]) VALUES (1, N'ESCU000001', N'Escuela Nacional de Música', N'Institución dedicada a la formación musical académica.')
GO
INSERT [Escuela] ([EscuelaId], [Codigo], [Nombre], [Descripcion]) VALUES (2, N'ESCU000002', N'Conservatorio Popular', N'Centro educativo enfocado en música popular y folclore.')
GO
INSERT [Escuela] ([EscuelaId], [Codigo], [Nombre], [Descripcion]) VALUES (3, N'ESCU000003', N'Escuela Sinfónica Juvenil', N'Escuela orientada a jóvenes con talento musical.')
GO
INSERT [Escuela] ([EscuelaId], [Codigo], [Nombre], [Descripcion]) VALUES (4, N'ESCU000004', N'Instituto Coral del Sur', N'Especializado en canto coral y dirección de coros.')
GO
INSERT [Escuela] ([EscuelaId], [Codigo], [Nombre], [Descripcion]) VALUES (5, N'ESCU000005', N'Centro de Estudios Musicales', N'Formación integral en teoría, composición y ejecución musical.')
GO
SET IDENTITY_INSERT [Escuela] OFF
GO
SET IDENTITY_INSERT [Alumno] ON 
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (1, N'12345678', N'Carlos', N'Ramírez', CAST(N'2004-03-15' AS Date), 1)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (2, N'86876879', N'Carlos', N'Ramírez de Prueba', CAST(N'2000-05-14' AS Date), 4)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (3, N'11223344', N'Martín', N'Vega', CAST(N'2005-11-10' AS Date), 1)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (4, N'55667788', N'Diana', N'Castro', CAST(N'2002-09-30' AS Date), 3)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (5, N'99887766', N'Valeria', N'Morales', CAST(N'2001-05-05' AS Date), 2)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (6, N'10000001', N'Andrés', N'Pérez', CAST(N'2005-01-10' AS Date), 1)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (7, N'10000002', N'Camila', N'Vargas', CAST(N'2004-05-22' AS Date), 1)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (8, N'10000003', N'Luis', N'Mendoza', CAST(N'2003-08-14' AS Date), 2)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (9, N'10000004', N'Sofía', N'Delgado', CAST(N'2005-12-01' AS Date), 2)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (10, N'10000005', N'Daniel', N'Carranza', CAST(N'2004-03-18' AS Date), 3)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (11, N'10000006', N'Valeria', N'Navarro', CAST(N'2002-09-25' AS Date), 3)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (12, N'10000007', N'Martina', N'Silva', CAST(N'2001-07-09' AS Date), 4)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (13, N'10000008', N'Sebastián', N'Ruiz', CAST(N'2005-11-13' AS Date), 4)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (14, N'10000009', N'Carla', N'Reyes', CAST(N'2003-06-30' AS Date), 5)
GO
INSERT [Alumno] ([AlumnoId], [DNI], [Nombre], [Apellido], [FechaNacimiento], [EscuelaId]) VALUES (15, N'10000010', N'Joaquín', N'Rosales', CAST(N'2004-10-04' AS Date), 5)
GO
SET IDENTITY_INSERT [Alumno] OFF
GO
SET IDENTITY_INSERT [Profesor] ON 
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (1, N'11112222', N'Marco', N'Sánchez', 1)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (2, N'22223333', N'Elena', N'Rojas', 2)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (3, N'33334444', N'Luis', N'Torres', 3)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (4, N'20000001', N'María', N'Fernández', 1)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (5, N'20000002', N'Jorge', N'Castillo', 1)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (6, N'20000003', N'Ana', N'Lozano', 2)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (7, N'20000004', N'Óscar', N'Gamarra', 2)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (8, N'20000005', N'Natalia', N'Campos', 3)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (9, N'20000006', N'Ricardo', N'Santos', 3)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (10, N'20000007', N'Claudia', N'Ramos', 4)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (11, N'20000008', N'Alberto', N'Vargas', 4)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (12, N'20000009', N'Verónica', N'Paredes', 5)
GO
INSERT [Profesor] ([ProfesorId], [DNI], [Nombre], [Apellido], [EscuelaId]) VALUES (13, N'20000010', N'Héctor', N'Gómez', 5)
GO
SET IDENTITY_INSERT [Profesor] OFF
GO
INSERT [AlumnoProfesor] ([AlumnoId], [ProfesorId]) VALUES (1, 1)
GO
INSERT [AlumnoProfesor] ([AlumnoId], [ProfesorId]) VALUES (1, 4)
GO
INSERT [AlumnoProfesor] ([AlumnoId], [ProfesorId]) VALUES (3, 4)
GO
