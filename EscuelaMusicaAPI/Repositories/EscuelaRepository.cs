using Dapper;
using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.Data;
using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace EscuelaMusicaAPI.Repositories
{
    public class EscuelaRepository : IEscuelaRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        public EscuelaRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<ResultadoOperacion> AgregarEscuelaAsync(EscuelaCreacionDTO escuelaCreacionDTO)
        {
            using var connection = _connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Codigo", escuelaCreacionDTO.Codigo);
            parameters.Add("@Nombre", escuelaCreacionDTO.Nombre);
            parameters.Add("@Descripcion", escuelaCreacionDTO.Descripcion);
            parameters.Add("@EscuelaId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
            parameters.Add("@Exito", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await connection.ExecuteAsync("AgregarEscuela", parameters, commandType: CommandType.StoredProcedure);

            var mensaje = parameters.Get<string>("@Mensaje");
            var exito = parameters.Get<bool>("@Exito");
            var escuelaId = parameters.Get<int>("@EscuelaId");

            return new ResultadoOperacion
            {
                Exito = exito,
                Mensaje = mensaje,
                Id = escuelaId
            };
        }


        public async Task<IEnumerable<EscuelaDTO>> ObtenerEscuelasAsync()
        {

            using var connection = _connectionFactory.CreateConnection();

            var result = await connection.QueryAsync<EscuelaDTO>(
                "ObtenerEscuelas",
                commandType: CommandType.StoredProcedure
            );

            return result;

        }       
        public async Task<EscuelaDTO> ObtenerEscuelaPorIdAsync(int EscuelaId)
        {

            using var connection = _connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@EscuelaId", EscuelaId);

            var result = await connection.QueryFirstOrDefaultAsync<EscuelaDTO>(
                "ObtenerEscuelaPorId", parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;

        }
        public async Task<ResultadoOperacion> ActualizarEscuelaAsync(int id, EscuelaCreacionDTO escuelaCreacionDTO)
        {
            using var connection = _connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@EscuelaId", id);
            parameters.Add("@Codigo", escuelaCreacionDTO.Codigo);
            parameters.Add("@Nombre", escuelaCreacionDTO.Nombre);
            parameters.Add("@Descripcion", escuelaCreacionDTO.Descripcion);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
            parameters.Add("@Exito", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await connection.ExecuteAsync("ActualizarEscuela", parameters, commandType: CommandType.StoredProcedure);

            var mensaje = parameters.Get<string>("@Mensaje");
            var exito = parameters.Get<bool>("@Exito");

            return new ResultadoOperacion { Exito = exito, Mensaje = mensaje };
        }
        public async Task<ResultadoOperacion> EliminarEscuelaAsync(int escuelaId)
        {
            using var _connection = _connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@EscuelaId", escuelaId);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
            parameters.Add("@Exito", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync("EliminarEscuela", parameters, commandType: CommandType.StoredProcedure);

            var mensaje = parameters.Get<string>("@Mensaje");
            var exito = parameters.Get<bool>("@Exito");

            return new ResultadoOperacion
            {
                Exito = exito,
                Mensaje = mensaje
            };
        }

    }
}

