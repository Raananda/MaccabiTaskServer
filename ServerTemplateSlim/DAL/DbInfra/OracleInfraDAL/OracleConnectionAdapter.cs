using Contracts.Interfaces.DAL;
using Oracle.ManagedDataAccess.Client;

namespace ServerTemplateSlim.DAL.OracleInfraDAL
{
    public class OracleConnectionAdapter : IDBConnection
    {
        public OracleConnection Connection { get; }

        public OracleConnectionAdapter(string connectionString)
        {
            Connection = new OracleConnection(connectionString);
        }
    }
}
