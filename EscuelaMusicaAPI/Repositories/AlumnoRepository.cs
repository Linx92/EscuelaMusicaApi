using Dapper;
using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EscuelaMusicaAPI.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly IDbConnection _connection;

        public AlumnoRepository(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        public async Task<ResultadoOperacion> ActualizarAlumnoAsync(int id,AlumnoCreacionDTO alumnoCreacionDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AlumnoId", id);
            parameters.Add("@DNI", alumnoCreacionDTO.DNI);
            parameters.Add("@Nombre", alumnoCreacionDTO.Nombre);
            parameters.Add("@Apellido", alumnoCreacionDTO.Apellido);
            parameters.Add("@FechaNacimiento", alumnoCreacionDTO.FechaNacimiento);
            parameters.Add("@EscuelaId", alumnoCreacionDTO.EscuelaId);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
            parameters.Add("@Exito", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync("ActualizarAlumno", parameters, commandType: CommandType.StoredProcedure);

            return new ResultadoOperacion
            {
                Exito = parameters.Get<bool>("@Exito"),
                Mensaje = parameters.Get<string>("@Mensaje")
            };
        }

        public async Task<ResultadoOperacion> AgregarAlumnoAsync(AlumnoCreacionDTO dto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DNI", dto.DNI);
            parameters.Add("@Nombre", dto.Nombre);
            parameters.Add("@Apellido", dto.Apellido);
            parameters.Add("@FechaNacimiento", dto.FechaNacimiento);
            parameters.Add("@EscuelaId", dto.EscuelaId);
            parameters.Add("@AlumnoId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
            parameters.Add("@Exito", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync("AgregarAlumno", parameters, commandType: CommandType.StoredProcedure);

            var mensaje = parameters.Get<string>("@Mensaje");
            var exito = parameters.Get<bool>("@Exito");
            var alumnoId = parameters.Get<int>("@AlumnoId");

            return new ResultadoOperacion
            {
                Exito = exito,
                Mensaje = mensaje,
                Id = alumnoId
            };
        }

        public async Task<ResultadoOperacion> EliminarAlumnoAsync(int alumnoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AlumnoId", alumnoId);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
            parameters.Add("@Exito", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync("EliminarAlumno", parameters, commandType: CommandType.StoredProcedure);

            return new ResultadoOperacion
            {
                Exito = parameters.Get<bool>("@Exito"),
                Mensaje = parameters.Get<string>("@Mensaje")
            };
        }

        public async Task<AlumnoDTO?> ObtenerAlumnoPorIdAsync(int alumnoId)
        {
            var resultado = await _connection.QueryFirstOrDefaultAsync<AlumnoDTO>(
                "ObtenerAlumnoPorId",
                new { AlumnoId = alumnoId },
                commandType: CommandType.StoredProcedure
            );

            return resultado;
        }

        public async Task<IEnumerable<AlumnoDTO>> ObtenerAlumnosAsync()
        {
            var resultado = await _connection.QueryAsync<AlumnoDTO>(
                "ObtenerAlumnos",
                commandType: CommandType.StoredProcedure
            );

            return resultado;
        }
    }

}
