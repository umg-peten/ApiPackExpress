using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Rest_Cine.IServices
{
    public interface IConnection
    {
        public string GetConnectionString();
        public SqlConnection GetSqlConnection(String conString);
    }
}
