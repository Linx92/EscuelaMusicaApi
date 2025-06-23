# EscuelaMusicaApi
Implementación de un sistema básico de una escuela de música

Este proyecto es una API REST construida en .NET 8 que permite gestionar escuelas, alumnos, profesores y su inscripción académica. También incluye procedimientos almacenados en SQL Server para validaciones y lógica de negocio.

---

## 🚀 Tecnologías

- ASP.NET Core 7
- Dapper
- SQL Server
- Git + GitHub

---

## 📦 Funcionalidades

- CRUD de **Escuelas**, **Alumnos** y **Profesores**
- Validaciones de DNI únicos en ambas tablas
- Asignación de alumnos a profesores (con validación por escuela)
- Consultas personalizadas:
  - Alumnos inscritos por profesor
  - Profesores por alumno inscrito

---

## ⚙️ Endpoints principales

### Escuelas

- `POST /api/escuelas` → Crear escuela
- `GET /api/escuelas/{id}` → Obtener escuela por ID
- `GET /api/escuelas` → Obtiene el listado de todas las escuelas
- `PUT /api/escuelas/{id}` → Actualizar escuela
- `DELETE /api/escuelas/{id}` → Eliminar escuela

### Alumnos

- `POST /api/alumnos`
- `GET /api/alumnos/{id}`
- `GET /api/alumnos`
- `PUT /api/alumnos/{id}`
- `DELETE /api/alumnos/{id}`

### Profesores

- `POST /api/profesores`
- `GET /api/profesores/{id}`
- `GET /api/profesores`
- `PUT /api/profesores/{id}`
- `DELETE /api/profesores/{id}`

### Asignación

- `POST /api/alumnoprofesor/asignar` → Asignar alumno a profesor

### Consultas

- `GET /api/alumnoprofesorconsulta/profesor/{profesorId}`
- `GET /api/alumnoprofesorconsulta/alumno/{alumnoId}`

---

## 🗃️ Estructura del Proyecto

```
/Common                  ← ResultadoOperacion.cs
/Controllers             ← API RESTful endpoints
/Data                    ← SqlConnectionFactory.cs
/DTOs                    ← Objetos de transferencia de datos
/Repositories            ← Acceso a datos (Dapper)
/Services                ← Lógica de negocio (Services)
/EscuelaMusicaBD         ← Scripts .sql y archivos de base de datos
appsettings.json         ← Configuración general
Program.cs               ← Punto de entrada
```
---

## 🗄️ Configuración de la Base de Datos

Este proyecto incluye scripts `.sql` necesarios para crear y poblar la base de datos.

### 📁 Ubicación

Los scripts están en la carpeta:

```
/EscuelaMusicaBD
  ├── ScriptEscuelaMusicaDB.sql               ← Crea tablas y procedimientos
  ├── ScriptDatosInicialesEscuelaMusicaDB.sql ← Inserta registros de ejemplo
  ├── ScriptStoredProceduresEscuelaMusicaDB.sql ← Lógica almacenada adicional
```

También puedes encontrar los archivos físicos `.mdf` y `.ldf` si deseas adjuntar directamente la base desde SSMS.

---

### ⚙️ Pasos para ejecutar en SQL Server

1. Crea una base de datos en blanco en SSMS llamada `EscuelaMusicaDB`.
2. Ejecuta los scripts `.sql` en este orden:
   - `ScriptEscuelaMusicaDB.sql`
   - `ScriptStoredProceduresEscuelaMusicaDB.sql`
   - `ScriptDatosInicialesEscuelaMusicaDB.sql`

---

## 📤 Ejemplos de Peticiones y Respuestas

### 🎒 Escuela

#### ✅ POST `/api/escuelas`

**Cuerpo de la solicitud:**
```json
{
  "Codigo": "ESCU000005",
  "Nombre": "Centro de Estudios Musicales",
  "Descripcion": "Formación integral en teoría, composición y ejecución musical."
}
```

**Respuesta exitosa:**
```json
{
  "escuelaId": 5,
  "codigo": "ESCU000005",
  "nombre": "Centro de Estudios Musicales",
  "descripcion": "Formación integral en teoría, composición y ejecución musical."
}
```

#### 🔁 PUT `/api/escuelas/{id}`

**Cuerpo:**
```json
{
  "Codigo": "ESCU000005",
  "Nombre": "Centro de Estudios Musicales Actualizado",
  "Descripcion": "Descripción modificada."
}
```

---

### 👨‍🎓 Alumno

#### ✅ POST `/api/alumnos`

**Cuerpo:**
```json
{
  "DNI": "12345678",
  "Nombre": "Juan",
  "Apellido": "Pérez",
  "FechaNacimiento": "2005-08-15",
  "EscuelaId": 1
}
```

**Respuesta:**
```json
{
  "alumnoId": 10,
  "dni": "12345678",
  "nombre": "Juan",
  "apellido": "Pérez",
  "fechaNacimiento": "2005-08-15",
  "escuelaId": 1
}
```

#### 🔁 PUT `/api/alumnos/{id}`

```json
{
  "DNI": "12345678",
  "Nombre": "Juan Actualizado",
  "Apellido": "Pérez Modificado",
  "FechaNacimiento": "2005-08-15",
  "EscuelaId": 1
}
```

---

### 👨‍🏫 Profesor

#### ✅ POST `/api/profesores`

**Cuerpo:**
```json
{
  "DNI": "87654321",
  "Nombre": "María",
  "Apellido": "López",
  "EscuelaId": 1
}
```

**Respuesta:**
```json
{
  "profesorId": 4,
  "dni": "87654321",
  "nombre": "María",
  "apellido": "López",
  "escuelaId": 1
}
```

#### 🔁 PUT `/api/profesores/{id}`

```json
{
  "DNI": "87654321",
  "Nombre": "María Actualizada",
  "Apellido": "López Reformulada",
  "EscuelaId": 1
}
```
---

## 📄 Autor

Desarrollado por Linford Taricuarima
📧 linford.tt@gmail.com  
🐙 [github.com/Linx92](https://github.com/Linx92)

---

