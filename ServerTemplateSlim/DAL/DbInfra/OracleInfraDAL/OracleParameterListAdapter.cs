using Contracts.Interfaces.DAL;
using System.Collections.Generic;

namespace ServerTemplateSlim.DAL.OracleInfraDAL
{
    public class OracleParameterListAdapter : IDBParamertList
    {
        private List<IDBParameter> _parameterList;

        public OracleParameterListAdapter()
        {
            _parameterList = new List<IDBParameter>();
        }

        public void Add(string parameterName, object parameterValue)
        {
            IDBParameter parameter = new OracleParameterAdapter();

            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;

            _parameterList.Add(parameter);
        }

        List<IDBParameter> IDBParamertList.Get()
        {
            return _parameterList;
        }
    }
}
