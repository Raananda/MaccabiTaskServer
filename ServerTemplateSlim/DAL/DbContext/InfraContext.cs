using Microsoft.Extensions.Configuration;
using ServerTemplateSlim.Infra.Interfaces.DAL;
using ServerTemplateSlim.Infra.Interfaces.DAL.DbContext;
using ServerTemplateSlim.Infra.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace ServerTemplateSlim.DAL.DbContext
{
    public class InfraContext : IInfraConext
    {
        private readonly IConfiguration _configuration;
        private readonly IInfraDAL _infraDAL;
        private string _connectionString;

        public InfraContext(IConfiguration configuration, IInfraDAL infraDAL)
        {
            _configuration = configuration;
            _infraDAL = infraDAL;
            _connectionString = _configuration.GetConnectionString("Default");
        }

        public async Task<List<AppInitResponseDTO>> GetInitDataAsync()
        {
            var ListResponse = new List<AppInitResponseDTO>();
            var Response = new AppInitResponseDTO
            {
                Data1 = "This is data 1",
                Data2 = 999,
                Data3 = 235235

            };
            ListResponse.Add(Response);


            return ListResponse;

            #region DAL INFRA
            // DAL INFRA
            // var connection = _infraDAL.GetConnection(_connectionString);

            // Execute SQL query
            // var Response2 = await Task.Run(() => _infraDAL.ExecSQL(connection, "select t.* from db_template.init t"));

            // Execute SP
            //  var Response2 =  await Task.Run(() => _infraDAL.ExecSP(connection, "db_template.get_init_data",_infraDAL.GetParametersList()));
            #endregion

            #region DAPPER SQL
            // DAPPER SQL
            //string sql = "select t.* from db_template.init t";
            //using (var connection = new MySqlConnection(_connectionString))
            //{
            //    var Response2 = await connection.QueryAsync<AppInitResponseDTO>(sql).ConfigureAwait(false);           

            //    return Response2.ToList();
            //}
            #endregion

            #region DAPPER SP
            //DAPPER SP
            string sql = "db_template.get_init_data";

            using (var connection = new MySqlConnection(_connectionString))
            {
                var Params = new
                {
                    l_data3 = 111
                };
                var Response2 = await connection.QueryAsync<AppInitResponseDTO>(sql, Params, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return Response2.ToList();
            }
            #endregion
        }

        public async Task PostDataAsync(AppRequestDTO appRequestDTO)
        {

            #region DAL INFRA
            // DAL INFRA
            /*
            var connection = _infraDAL.GetConnection(_connectionString);

            var parameterList = _infraDAL.GetParametersList();

            parameterList.Add("l_first_name", appRequestDTO.Data1);
            parameterList.Add("l_Id", appRequestDTO.Data2);

            // Execute SP
            await Task.Run(() => _infraDAL.ExecSP(connection, "db_template.set_init_data", parameterList));
            */
            #endregion

            #region DAPPER
            //DAPPER

            //string sql = "db_template.set_init_data";


            //using (var connection = new MySqlConnection(_connectionString))
            //{
            //    var Params = new
            //    {
            //        l_first_name = appRequestDTO.Data1,
            //        l_Id = appRequestDTO.Data2,
            //        l_data3 = appRequestDTO.Data3
            //    };
            //    var affectedRows = await connection.ExecuteAsync(sql, Params, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            //}
            #endregion

        }
    }
}
