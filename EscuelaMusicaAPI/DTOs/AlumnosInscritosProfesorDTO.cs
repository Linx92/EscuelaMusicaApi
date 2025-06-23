namespace EscuelaMusicaAPI.DTOs
{
    public class AlumnosInscritosProfesorDTO
    {
        public string? AlumnoDni { get; set; }
        public string? AlumnoNombre { get; set; }
        public string? AlumnoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? EscuelaCodigo { get; set; }
        public string? EscuelaNombre { get; set; }
        public string? EscuelaDescripcion { get; set; }
    }
}
