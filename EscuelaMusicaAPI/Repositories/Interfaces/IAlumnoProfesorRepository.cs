using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;

namespace EscuelaMusicaAPI.Repositories.Interfaces
{
    public interface IAlumnoProfesorRepository
    {
        Task<ResultadoOperacion> AsignarAlumnoAProfesorAsync(InscripcionAlumnoProfesorDTO inscripcionAlumnoProfesorDTO);
        Task<IEnumerable<ProfesorAlumnoInscritoTO>> ObtenerProfesoresPorAlumnoAsync(int alumnoId);
        Task<IEnumerable<AlumnosInscritosProfesorDTO>> ObtenerAlumnosPorProfesorAsync(int profesorId);
    }
}
