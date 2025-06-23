using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;

namespace EscuelaMusicaAPI.Services.Interfaces
{
    public interface IEscuelaService
    {
        Task<ResultadoOperacion> AgregarEscuelaAsync(EscuelaCreacionDTO escuelaCreacionDTO);
        Task<IEnumerable<EscuelaDTO>> ObtenerEscuelasAsync();
        Task<EscuelaDTO> ObtenerEscuelaPorIdAsync(int EscuelaId);
        Task<ResultadoOperacion> ActualizarEscuelaAsync(int id, EscuelaCreacionDTO escuelaCreacionDTO);
        Task<ResultadoOperacion> EliminarEscuelaAsync(int escuelaId);
    }
}
