using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;

namespace EscuelaMusicaAPI.Services.Interfaces
{
    public interface IAlumnoProfesorService
    {
        Task<ResultadoOperacion> AsignarAlumnoAProfesorAsync(InscripcionAlumnoProfesorDTO inscripcionAlumnoProfesorDTO);
        Task<IEnumerable<ProfesorAlumnoInscritoTO>> ObtenerProfesoresPorAlumnoAsync(int alumnoId);
        Task<IEnumerable<AlumnosInscritosProfesorDTO>> ObtenerAlumnosPorProfesorAsync(int profesorId);
    }
}
