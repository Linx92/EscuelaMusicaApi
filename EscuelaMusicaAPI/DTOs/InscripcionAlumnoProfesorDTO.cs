using System.ComponentModel.DataAnnotations;

namespace EscuelaMusicaAPI.DTOs
{
    public class InscripcionAlumnoProfesorDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int AlumnoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ProfesorId { get; set; }
    }
}
