using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Repositories.Interfaces;
using EscuelaMusicaAPI.Services.Interfaces;

namespace EscuelaMusicaAPI.Services
{
    public class ProfesorService: IProfesorService
    {
        private readonly IProfesorRepository _repository;

        public ProfesorService(IProfesorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultadoOperacion> AgregarProfesorAsync(ProfesorCreacionDTO profesorCreacionDTO)
        {
            return await _repository.AgregarProfesorAsync(profesorCreacionDTO);
        }


        public async Task<ResultadoOperacion> ActualizarProfesorAsync(int id, ProfesorCreacionDTO profesorDTO)
        {
            return await _repository.ActualizarProfesorAsync(id, profesorDTO);
        }


        public async Task<ResultadoOperacion> EliminarProfesorAsync(int profesorId) 
        {
            return await _repository.EliminarProfesorAsync(profesorId);
        }


        public async  Task<ProfesorDTO?> ObtenerProfesorPorIdAsync(int profesorId) 
        {
            return await _repository.ObtenerProfesorPorIdAsync(profesorId);
        }

        public async Task<IEnumerable<ProfesorDTO>> ObtenerProfesoresAsync()
        {
            return await _repository.ObtenerProfesoresAsync();
        }
    }
}
