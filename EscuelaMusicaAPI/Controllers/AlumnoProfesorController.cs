using Dapper;
using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Common;

namespace EscuelaMusicaAPI.Controllers
{
    [ApiController]
    [Route("api/alumnoprofesor")]
    public class AlumnoProfesorController : ControllerBase
    {
        private readonly IAlumnoProfesorService _alumnoProfesorService;
        public AlumnoProfesorController(IAlumnoProfesorService alumnoProfesorService)
        {
            _alumnoProfesorService = alumnoProfesorService;
        }
        [HttpPost("inscribir")]
        public async Task<IActionResult> Post([FromBody] InscripcionAlumnoProfesorDTO inscripcionAlumnoProfesorDTO)
        {
            var resultado = await _alumnoProfesorService.AsignarAlumnoAProfesorAsync( inscripcionAlumnoProfesorDTO);

            if (resultado.Exito)
                return Ok(new { mensaje = resultado.Mensaje });

            return Conflict(new { error = resultado.Mensaje });
        }
        [HttpGet("profesor/{profesorId:int}")]
        public async Task<ActionResult<IEnumerable<AlumnosInscritosProfesorDTO>>> GetAlumnosPorProfesor(int profesorId)
        {
            var alumnos = await _alumnoProfesorService.ObtenerAlumnosPorProfesorAsync(profesorId);
            if (alumnos == null || !alumnos.Any())
            {
                return NotFound("No se encontraron alumnos inscritos para el profesor especificado.");
            }
            return Ok(alumnos);
        }
        [HttpGet("alumno/{alumnoId:int}")]
        public async Task<ActionResult<IEnumerable<ProfesorAlumnoInscritoTO>>> GetProfesoresPorAlumno(int alumnoId)
        {
            var profesores = await _alumnoProfesorService.ObtenerProfesoresPorAlumnoAsync(alumnoId);
            if (profesores == null || !profesores.Any())
            {
                return NotFound("El alumno aún no ha sido inscrito a ningún profesor.");
            }
            return Ok(profesores);
        }
    }
}
