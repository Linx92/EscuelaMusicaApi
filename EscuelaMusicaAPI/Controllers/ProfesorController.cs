using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaMusicaAPI.Controllers
{
    [ApiController]
    [Route("api/profesores")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _profesorService;

        public ProfesorController(IProfesorService service)
        {
            _profesorService = service;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProfesorCreacionDTO profesorCreacionDTO)
        {
            if (profesorCreacionDTO == null)
            {
                return BadRequest("El objeto no puede ser nulo.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _profesorService.AgregarProfesorAsync(profesorCreacionDTO);

            if (!resultado.Exito)
                return Conflict(new { error = resultado.Mensaje });

            var profesorDTO = new ProfesorDTO
            {
                ProfesorId = resultado.Id,
                DNI = profesorCreacionDTO.DNI,
                Nombre = profesorCreacionDTO.Nombre,
                Apellido = profesorCreacionDTO.Apellido,
                EscuelaId = profesorCreacionDTO.EscuelaId
            };

            return CreatedAtRoute("ObtenerProfesor", new { profesoId = resultado.Id }, profesorDTO);
        }

        [HttpGet("{profesoId:int}", Name = "ObtenerProfesor")]
        public async Task<ActionResult> Get(int profesoId)
        {
            var profesor = await _profesorService.ObtenerProfesorPorIdAsync(profesoId);

            if (profesor == null)
                return NotFound();

            return Ok(profesor);
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var profesor = await _profesorService.ObtenerProfesoresAsync();

            if (profesor == null)
                return NotFound();

            return Ok(profesor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProfesorCreacionDTO profesorCreacionDTO)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultado = await _profesorService.ActualizarProfesorAsync(id, profesorCreacionDTO);

            if (resultado.Exito)
                return Ok(new { mensaje = resultado.Mensaje });

            return Conflict(new { error = resultado.Mensaje });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _profesorService.EliminarProfesorAsync(id);

            if (resultado.Exito)
                return Ok(new { mensaje = resultado.Mensaje });

            return NotFound(new { error = resultado.Mensaje });
        }

    }
}
