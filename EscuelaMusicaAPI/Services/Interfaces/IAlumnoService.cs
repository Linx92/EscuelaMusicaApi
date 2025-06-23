using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;

namespace EscuelaMusicaAPI.Services.Interfaces
{
    public interface IAlumnoService
    {
        Task<ResultadoOperacion> AgregarAlumnoAsync(AlumnoCreacionDTO dto);
        Task<AlumnoDTO?> ObtenerAlumnoPorIdAsync(int alumnoId);
        Task<IEnumerable<AlumnoDTO>> ObtenerAlumnosAsync();
        Task<ResultadoOperacion> ActualizarAlumnoAsync(int id, AlumnoCreacionDTO alumnoCreacionDTO);
        Task<ResultadoOperacion> EliminarAlumnoAsync(int alumnoId);
    }
}
