using Api_Rest_Cine.IServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Rest_Cine.AppDbContext
{
    public class Connection : IConnection
    {
        private readonly IConfiguration _confing;
        public Connection(IConfiguration config)
        {
            this._confing = config;
        }

        public string GetConnectionString()
        {
            string connectionString = ConfigurationExtensions.GetConnectionString(this._confing, "GoogleCloudServerDB");
            return connectionString;
        }

        public SqlConnection GetSqlConnection(String conString)
        {
            SqlConnection sqlConnection = new SqlConnection(Helpers.Encrypter.Decrypt(conString));
            return sqlConnection;
        }

    }
}
