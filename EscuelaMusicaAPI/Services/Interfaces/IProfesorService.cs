using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;

namespace EscuelaMusicaAPI.Services.Interfaces
{
    public interface IProfesorService
    {
        Task<ResultadoOperacion> AgregarProfesorAsync(ProfesorCreacionDTO dto);
        Task<ResultadoOperacion> ActualizarProfesorAsync(int id, ProfesorCreacionDTO profesorDTO);
        Task<ResultadoOperacion> EliminarProfesorAsync(int profesorId);
        Task<ProfesorDTO?> ObtenerProfesorPorIdAsync(int profesorId);
        Task<IEnumerable<ProfesorDTO>> ObtenerProfesoresAsync();
    }
}
