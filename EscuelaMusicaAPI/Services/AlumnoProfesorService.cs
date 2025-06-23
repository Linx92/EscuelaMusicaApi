using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Repositories.Interfaces;
using EscuelaMusicaAPI.Services.Interfaces;

namespace EscuelaMusicaAPI.Services
{
    public class AlumnoProfesorService: IAlumnoProfesorService
    {
        private readonly IAlumnoProfesorRepository _alumnoProfesorRepository;
        public AlumnoProfesorService(IAlumnoProfesorRepository alumnoProfesorRepository)
        {
            _alumnoProfesorRepository = alumnoProfesorRepository;
        }
        public async Task<ResultadoOperacion> AsignarAlumnoAProfesorAsync(InscripcionAlumnoProfesorDTO inscripcionAlumnoProfesorDTO)
        {
            return await _alumnoProfesorRepository.AsignarAlumnoAProfesorAsync(inscripcionAlumnoProfesorDTO);
        }

        public async Task<IEnumerable<AlumnosInscritosProfesorDTO>> ObtenerAlumnosPorProfesorAsync(int profesorId)
        {
           return await _alumnoProfesorRepository.ObtenerAlumnosPorProfesorAsync(profesorId);
        }

        public async Task<IEnumerable<ProfesorAlumnoInscritoTO>> ObtenerProfesoresPorAlumnoAsync(int alumnoId)
        {
            return await _alumnoProfesorRepository.ObtenerProfesoresPorAlumnoAsync(alumnoId);
        }
    }
}
