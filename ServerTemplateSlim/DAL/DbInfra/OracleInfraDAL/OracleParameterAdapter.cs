using Contracts.Interfaces.DAL;
using Oracle.ManagedDataAccess.Client;

namespace ServerTemplateSlim.DAL.OracleInfraDAL
{
    public class OracleParameterAdapter : IDBParameter
    {
        public OracleParameter Parameter { get; }

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

        public OracleParameterAdapter()
        {
            Parameter = new OracleParameter();
        }
    }
}
