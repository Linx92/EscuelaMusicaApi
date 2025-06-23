using Dapper;
using EscuelaMusicaAPI.Common.EscuelaMusicaAPI.Shared;
using EscuelaMusicaAPI.DTOs;
using EscuelaMusicaAPI.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EscuelaMusicaAPI.Repositories
{
    public class AlumnoProfesorRepository : IAlumnoProfesorRepository
    {
        private readonly IDbConnection _connection;

        public AlumnoProfesorRepository(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<ResultadoOperacion> AsignarAlumnoAProfesorAsync(InscripcionAlumnoProfesorDTO inscripcionAlumnoProfesorDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AlumnoId", inscripcionAlumnoProfesorDTO.AlumnoId);
            parameters.Add("@ProfesorId", inscripcionAlumnoProfesorDTO.ProfesorId);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
            parameters.Add("@Exito", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync("InscribirAlumnoAProfesor", parameters, commandType: CommandType.StoredProcedure);

            return new ResultadoOperacion
            {
                Exito = parameters.Get<bool>("@Exito"),
                Mensaje = parameters.Get<string>("@Mensaje")
            };
        }

        public async Task<IEnumerable<AlumnosInscritosProfesorDTO>> ObtenerAlumnosPorProfesorAsync(int profesorId)
        {
            return await _connection.QueryAsync<AlumnosInscritosProfesorDTO>(
                "AlumnoInscritoPorProfesor",
                new { ProfesorId = profesorId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<ProfesorAlumnoInscritoTO>> ObtenerProfesoresPorAlumnoAsync(int alumnoId)
        {
            return await _connection.QueryAsync<ProfesorAlumnoInscritoTO>(
                  "ProfesorPorAlumnoInscrito",
                  new { AlumnoId = alumnoId },
                  commandType: CommandType.StoredProcedure
             );
        }
    }

}
