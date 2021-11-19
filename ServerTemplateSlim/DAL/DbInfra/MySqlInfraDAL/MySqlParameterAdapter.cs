using Contracts.Interfaces.DAL;
using MySql.Data.MySqlClient;

namespace ServerTemplateSlim.DAL.MySqlInfraDAL
{
    public class MySqlParameterAdapter : IDBParameter
    {
        public MySqlParameter Parameter { get; }

        public string ParameterName
        {
            get => Parameter.ParameterName;
            set => Parameter.ParameterName = value;
        }

        public object Value
        {
            get => Parameter.Value;
            set => Parameter.Value = value;
        }

        public MySqlParameterAdapter()
        {
            Parameter = new MySqlParameter();
        }
    }
}
