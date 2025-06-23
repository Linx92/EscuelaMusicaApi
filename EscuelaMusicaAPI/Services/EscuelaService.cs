using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Repositories.Interfaces;
using EscuelaMusicaAPI.Services.Interfaces;

namespace EscuelaMusicaAPI.Services
{
    
    public class EscuelaService : IEscuelaService
    {
        private readonly IEscuelaRepository _repository;

        public EscuelaService(IEscuelaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultadoOperacion> AgregarEscuelaAsync(EscuelaCreacionDTO escuelaCreacionDTO)
        {
            return await _repository.AgregarEscuelaAsync(escuelaCreacionDTO);
        }

        public async Task<IEnumerable<EscuelaDTO>> ObtenerEscuelasAsync()
        {
            return await _repository.ObtenerEscuelasAsync();
        }       
        public async Task<EscuelaDTO> ObtenerEscuelaPorIdAsync(int EscuelaId)
        {
            return await _repository.ObtenerEscuelaPorIdAsync(EscuelaId);
        }

        public async Task<ResultadoOperacion> ActualizarEscuelaAsync(int id, EscuelaCreacionDTO escuelaCreacionDTO)
        {
            return await _repository.ActualizarEscuelaAsync(id,escuelaCreacionDTO);
        }
        public async Task<ResultadoOperacion> EliminarEscuelaAsync(int escuelaId)
        {
            return await _repository.EliminarEscuelaAsync(escuelaId);
        }
    }
}
