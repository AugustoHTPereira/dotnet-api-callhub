using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Callhub.Infra.Data.Connection
{
    public class ConnectionSqlServer : IConnection
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _sqlConnection;

        public ConnectionSqlServer(IConfiguration configuration, SqlConnection sqlConnection = null)
        {
            this._configuration = configuration;
            if (sqlConnection != null)
                this._sqlConnection = sqlConnection;

            else this._sqlConnection = new SqlConnection(this._configuration.GetConnectionString("DefaultSqlConnection"));
        }

        public IDbConnection Connect()
        {
            this._sqlConnection.Open();
            return this._sqlConnection;
        }

        public void Disconnect()
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
        }

        public void Dispose()
        {
            if (this._sqlConnection.State == System.Data.ConnectionState.Open || this._sqlConnection.State == System.Data.ConnectionState.Connecting)
                this._sqlConnection.Close();
            GC.SuppressFinalize(this);
        }
    }
}
