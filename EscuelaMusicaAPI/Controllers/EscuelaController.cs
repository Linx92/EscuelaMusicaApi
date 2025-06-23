using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaMusicaAPI.Controllers
{
    [ApiController]
    [Route("api/escuelas")]
    public class EscuelaController : ControllerBase
    {
        private readonly IEscuelaService _escuelaService;
        public EscuelaController(IEscuelaService escuelaService)
        {
            _escuelaService = escuelaService;
        }
        [HttpGet("{EscuelaId:int}", Name = "ObtenerEscuela")]
        public async Task<ActionResult<EscuelaDTO>> Get(int EscuelaId)
        {
            var resultado = await _escuelaService.ObtenerEscuelaPorIdAsync(EscuelaId);
            if (resultado == null) 
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EscuelaDTO>>> Get() 
        {
            var resultado = await _escuelaService.ObtenerEscuelasAsync();
            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] EscuelaCreacionDTO escuelaCreacionDTO)
        {
            var resultado = await _escuelaService.AgregarEscuelaAsync(escuelaCreacionDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (resultado.Exito)
            {
                var escuelaDTO = new EscuelaDTO
                {
                    EscuelaId = resultado.Id,
                    Codigo = escuelaCreacionDTO.Codigo,
                    Nombre = escuelaCreacionDTO.Nombre,
                    Descripcion = escuelaCreacionDTO.Descripcion
                };
                return CreatedAtRoute("ObtenerEscuela", new { EscuelaId = resultado.Id }, escuelaDTO);
            }

            return Conflict(new { error = resultado });
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, EscuelaCreacionDTO escuelaCreacionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultado = await _escuelaService.ActualizarEscuelaAsync(id, escuelaCreacionDTO);

            if (resultado.Exito)
                return Ok(new { mensaje = resultado.Mensaje });

            return Conflict(new { error = resultado.Mensaje });
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _escuelaService.EliminarEscuelaAsync(id);

            if (resultado.Exito)
                return Ok(new { mensaje = resultado.Mensaje });

            return NotFound(new { error = resultado.Mensaje });
        }

    }
}
