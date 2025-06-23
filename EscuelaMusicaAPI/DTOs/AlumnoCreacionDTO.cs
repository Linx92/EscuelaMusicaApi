using System.ComponentModel.DataAnnotations;

namespace EscuelaMusicaAPI.DTOs
{
    public class AlumnoCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener exactamente {1} caracteres.")]
        public required string DNI { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string Apellido { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Debe asignar una escuela al Alumno")]
        public int EscuelaId { get; set; }
    }
}
