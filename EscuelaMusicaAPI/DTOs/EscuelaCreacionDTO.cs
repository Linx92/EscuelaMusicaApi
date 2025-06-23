using System.ComponentModel.DataAnnotations;

namespace EscuelaMusicaAPI.DTOs
{
    public class EscuelaCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El campo {0} debe tener exactamente {1} caracteres.")]
        public required string Codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string Descripcion { get; set; }
    }
}
