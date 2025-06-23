using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;

namespace EscuelaMusicaAPI.Repositories.Interfaces
{
    public interface IEscuelaRepository
    {
        Task<ResultadoOperacion> AgregarEscuelaAsync(EscuelaCreacionDTO escuelaDTO);
        Task<IEnumerable<EscuelaDTO>> ObtenerEscuelasAsync();
        Task<EscuelaDTO> ObtenerEscuelaPorIdAsync(int EscuelaId);
        Task<ResultadoOperacion> ActualizarEscuelaAsync(int id, EscuelaCreacionDTO escuelaDTO);
        Task<ResultadoOperacion> EliminarEscuelaAsync(int escuelaId);
    }
}
