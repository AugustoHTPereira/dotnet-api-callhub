using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Callhub.Infra.Data.Connection
{
    public interface IConnection : IDisposable
    {
        IDbConnection Connect();

        void Disconnect();
    }
}
