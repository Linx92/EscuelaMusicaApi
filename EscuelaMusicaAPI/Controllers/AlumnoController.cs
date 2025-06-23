using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaMusicaAPI.Controllers
{
    [ApiController]
    [Route("api/alumnos")]
    public class AlumnoController:ControllerBase
    {
        private readonly IAlumnoService _alumnoService;
        public AlumnoController(IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlumnoCreacionDTO alumnoCreacionDTO)
        {
            if (alumnoCreacionDTO == null)
            {
                return BadRequest("El objeto no puede ser nulo.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultado = await _alumnoService.AgregarAlumnoAsync(alumnoCreacionDTO);
            if (resultado.Exito)
            {
                var alumnoDTO = new AlumnoDTO
                {
                    AlumnoId = resultado.Id,
                    DNI = alumnoCreacionDTO.DNI,
                    Nombre = alumnoCreacionDTO.Nombre,
                    Apellido = alumnoCreacionDTO.Apellido,
                    FechaNacimiento = alumnoCreacionDTO.FechaNacimiento,
                    EscuelaId = alumnoCreacionDTO.EscuelaId
                };
                return CreatedAtRoute("ObtenerAlumno", new { alumnoId = resultado.Id }, alumnoDTO);
            }
            return BadRequest(resultado.Mensaje);
        }

        [HttpGet("{alumnoId:int}", Name ="ObtenerAlumno")]
        public async Task<ActionResult<EscuelaDTO>> Get(int alumnoId)
        {
            var alumno = await _alumnoService.ObtenerAlumnoPorIdAsync(alumnoId);
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumno);
        }

        [HttpGet()]
        public async Task<ActionResult<EscuelaDTO>> Get()
        {
            var alumno = await _alumnoService.ObtenerAlumnosAsync();
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumno);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] AlumnoCreacionDTO alumnoCreacionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultado = await _alumnoService.ActualizarAlumnoAsync(id, alumnoCreacionDTO);

            if (resultado.Exito)
                return Ok(new { mensaje = resultado.Mensaje });

            return Conflict(new { error = resultado.Mensaje });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _alumnoService.EliminarAlumnoAsync(id);

            if (resultado.Exito)
                return Ok(new { mensaje = resultado.Mensaje });

            return NotFound(new { error = resultado.Mensaje });
        }

    }
}
