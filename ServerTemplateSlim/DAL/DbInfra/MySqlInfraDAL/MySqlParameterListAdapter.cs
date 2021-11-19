using Contracts.Interfaces.DAL;
using System.Collections.Generic;

namespace ServerTemplateSlim.DAL.MySqlInfraDAL
{
    public class MySqlParameterListAdapter : IDBParamertList
    {
        private List<IDBParameter> _parameterList;

        public MySqlParameterListAdapter()
        {
            _parameterList = new List<IDBParameter>();
        }

        public void Add(string parameterName, object parameterValue)
        {
            IDBParameter parameter = new MySqlParameterAdapter();

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
