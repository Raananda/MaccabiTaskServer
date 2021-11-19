using Contracts.Interfaces.DAL;
using Oracle.ManagedDataAccess.Client;
using ServerTemplateSlim.Infra.Interfaces.DAL;
using System.Data;

namespace ServerTemplateSlim.DAL.OracleInfraDAL
{
    public class OracleInfraDAL : IInfraDAL
    {
       
        public DataSet ExecSP(IDBConnection connection, string StoredProcedure, IDBParamertList parameterList)
        {
            DataSet Response = new DataSet();
            OracleCommand oracleCommand = new OracleCommand();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();

            //Associate the command to the connection that was opened ptrviously
            oracleCommand.Connection = (connection as OracleConnectionAdapter).Connection;

            //Define the type of the command as stored procedure
            oracleCommand.CommandType = CommandType.StoredProcedure;

            //Create the command text: the package name combined with the stored procedure
            oracleCommand.CommandText = StoredProcedure;

            // Input parameters
            foreach (var parameter in parameterList.Get())
            {
                var parameterAdepter = parameter as OracleParameterAdapter;
                oracleCommand.Parameters.Add(parameterAdepter.Parameter);
            }

            oracleDataAdapter.SelectCommand = oracleCommand;

            oracleDataAdapter.Fill(Response);

            return Response;
        }

        public DataSet ExecSQL(IDBConnection connection, string sqlText)
        {
            DataSet Response = new DataSet();
            OracleCommand mysqlCommand = new OracleCommand();
            OracleDataAdapter mysqlDataAdapter = new OracleDataAdapter();

            //Associate the command to the connection that was opened ptrviously
            mysqlCommand.Connection = (connection as OracleConnectionAdapter).Connection;

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
            return new OracleConnectionAdapter(connectionString);
        }

        public IDBParameter GetParameter(string parameterName, object parameterValue)
        {
            IDBParameter Response = new OracleParameterAdapter();
            Response.ParameterName = parameterName;
            Response.Value = parameterValue;
            return Response;
        }

        IDBParamertList IInfraDAL.GetParametersList()
        {
            return new OracleParameterListAdapter();
        }
    }
}

