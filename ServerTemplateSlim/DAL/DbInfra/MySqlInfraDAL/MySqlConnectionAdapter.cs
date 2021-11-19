using Contracts.Interfaces.DAL;
using MySql.Data.MySqlClient;


namespace ServerTemplateSlim.DAL.MySqlInfraDAL
{
    public class MySqlConnectionAdapter : IDBConnection
    {
        public MySqlConnection Connection { get; }

        public MySqlConnectionAdapter(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }
    }
}
