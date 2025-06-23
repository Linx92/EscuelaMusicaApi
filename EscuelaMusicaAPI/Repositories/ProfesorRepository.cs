using Dapper;
using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EscuelaMusicaAPI.Repositories
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly IDbConnection _connection;

        public ProfesorRepository(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        public async Task<ResultadoOperacion> AgregarProfesorAsync(ProfesorCreacionDTO dto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DNI", dto.DNI);
            parameters.Add("@Nombre", dto.Nombre);
            parameters.Add("@Apellido", dto.Apellido);
            parameters.Add("@EscuelaId", dto.EscuelaId);
            parameters.Add("@ProfesorId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
            parameters.Add("@Exito", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync("AgregarProfesor", parameters, commandType: CommandType.StoredProcedure);

            return new ResultadoOperacion
            {
                Exito = parameters.Get<bool>("@Exito"),
                Mensaje = parameters.Get<string>("@Mensaje"),
                Id = parameters.Get<int>("@ProfesorId")
            };
        }

        public async Task<ResultadoOperacion> ActualizarProfesorAsync(int id, ProfesorCreacionDTO profesorCreacionDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProfesorId", id);
            parameters.Add("@DNI", profesorCreacionDTO.DNI);
            parameters.Add("@Nombre", profesorCreacionDTO.Nombre);
            parameters.Add("@Apellido", profesorCreacionDTO.Apellido);
            parameters.Add("@EscuelaId", profesorCreacionDTO.EscuelaId);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
            parameters.Add("@Exito", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync("ActualizarProfesor", parameters, commandType: CommandType.StoredProcedure);

            return new ResultadoOperacion
            {
                Exito = parameters.Get<bool>("@Exito"),
                Mensaje = parameters.Get<string>("@Mensaje")
            };
        }

        public async Task<ResultadoOperacion> EliminarProfesorAsync(int profesorId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProfesorId", profesorId);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
            parameters.Add("@Exito", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync("EliminarProfesor", parameters, commandType: CommandType.StoredProcedure);

            return new ResultadoOperacion
            {
                Exito = parameters.Get<bool>("@Exito"),
                Mensaje = parameters.Get<string>("@Mensaje")
            };
        }

        public async Task<ProfesorDTO?> ObtenerProfesorPorIdAsync(int profesorId)
        {
            return await _connection.QueryFirstOrDefaultAsync<ProfesorDTO>(
                "ObtenerProfesorPorId",
                new { ProfesorId = profesorId },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<ProfesorDTO>> ObtenerProfesoresAsync()
        {
            var resultado =  await _connection.QueryAsync<ProfesorDTO>(
                "ObtenerProfesores",
                commandType: CommandType.StoredProcedure
            );

            return resultado;
        }
    }

}
