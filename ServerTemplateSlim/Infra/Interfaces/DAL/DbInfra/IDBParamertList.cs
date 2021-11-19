using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interfaces.DAL
{
    public interface IDBParamertList
    {
        void Add(string ParameterName, object Value);

        List<IDBParameter> Get();

    }
}
