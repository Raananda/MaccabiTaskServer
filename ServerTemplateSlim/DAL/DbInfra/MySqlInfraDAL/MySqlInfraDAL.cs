using Contracts.Interfaces.DAL;
using MySql.Data.MySqlClient;
using ServerTemplateSlim.Infra.Interfaces.DAL;
using System.Data;

namespace ServerTemplateSlim.DAL.MySqlInfraDAL
{
    public class MySqlInfraDAL : IInfraDAL
    {
        public DataSet ExecSP(IDBConnection connection, string StoredProcedure, IDBParamertList parameterList)
        {
            DataSet Response = new DataSet();
            MySqlCommand mysqlCommand = new MySqlCommand();
            MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter();

            //Associate the command to the connection that was opened ptrviously
            mysqlCommand.Connection = (connection as MySqlConnectionAdapter).Connection;

            //Define the type of the command as stored procedure
            mysqlCommand.CommandType = CommandType.StoredProcedure;

            mysqlCommand.CommandText = StoredProcedure;

            // Input parameters
            foreach (var parameter in parameterList.Get())
            {
                var parameterAdepter = parameter as MySqlParameterAdapter;
                mysqlCommand.Parameters.Add(parameterAdepter.Parameter);
            }

            mysqlDataAdapter.SelectCommand = mysqlCommand;

            mysqlDataAdapter.Fill(Response);

            return Response;
        }

        public DataSet ExecSQL(IDBConnection connection, string sqlText)
        {

            DataSet Response = new DataSet();
            MySqlCommand mysqlCommand = new MySqlCommand();
            MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter();

            //Associate the command to the connection that was opened ptrviously
            mysqlCommand.Connection = (connection as MySqlConnectionAdapter).Connection;

            //Define the type of the command as stored procedure
            mysqlCommand.CommandType = CommandType.Text;

            //The SQL query
            mysqlCommand.CommandText = sqlText;

            mysqlDataAdapter.SelectCommand = mysqlCommand;

            mysqlDataAdapter.Fill(Response); //opens and closes the DB connection automatically !! (fetches from pool)

            return Response;

        }

        public IDBConnection GetConnection(string connectionString)
        {
            return new MySqlConnectionAdapter(connectionString);
        }

        public IDBParameter GetParameter(string parameterName, object parameterValue)
        {
            IDBParameter Response = new MySqlParameterAdapter();
            Response.ParameterName = parameterName;
            Response.Value = parameterValue;
            return Response;
        }

        IDBParamertList IInfraDAL.GetParametersList()
        {
            return new MySqlParameterListAdapter();
        }
    }
}

