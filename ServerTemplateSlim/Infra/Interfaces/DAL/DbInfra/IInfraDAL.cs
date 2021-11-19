using Contracts.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Infra.Interfaces.DAL
{
    public interface IInfraDAL
    {
        IDBConnection GetConnection(string connectionString);
        IDBParameter GetParameter(string paramName, object paramValue);
        DataSet ExecSP(IDBConnection connection, string StoredProcedure, IDBParamertList parameterList);
        IDBParamertList GetParametersList();
        DataSet ExecSQL(IDBConnection connection, string sqlText);

    }
}
