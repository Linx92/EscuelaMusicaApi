using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Repositories.Interfaces;
using EscuelaMusicaAPI.Services.Interfaces;

namespace EscuelaMusicaAPI.Services
{
    public class AlumnoService: IAlumnoService
    {
        private readonly IAlumnoRepository _alumnoRepository;
        public AlumnoService(IAlumnoRepository alumnoRepository)
        {
            _alumnoRepository = alumnoRepository;
        }

        public async Task<ResultadoOperacion> ActualizarAlumnoAsync(int id, AlumnoCreacionDTO alumnoCreacionDTO)
        {
            return await _alumnoRepository.ActualizarAlumnoAsync(id, alumnoCreacionDTO);
        }

        public async Task<ResultadoOperacion> AgregarAlumnoAsync(AlumnoCreacionDTO dto)
        {
            return await _alumnoRepository.AgregarAlumnoAsync(dto);
        }

        public async Task<ResultadoOperacion> EliminarAlumnoAsync(int alumnoId)
        {
            return await _alumnoRepository.EliminarAlumnoAsync(alumnoId);
        }

        public async Task<AlumnoDTO?> ObtenerAlumnoPorIdAsync(int alumnoId)
        {
            return await _alumnoRepository.ObtenerAlumnoPorIdAsync(alumnoId);
        }
        public async Task<IEnumerable<AlumnoDTO>> ObtenerAlumnosAsync() 
        {
            return await _alumnoRepository.ObtenerAlumnosAsync();
        }
    }
}
