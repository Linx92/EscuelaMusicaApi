using System.ComponentModel.DataAnnotations;

namespace EscuelaMusicaAPI.DTOs
{
    public class ProfesorCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener exactamente {1} caracteres.")]
        public string? DNI { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int EscuelaId { get; set; }
    }
}
