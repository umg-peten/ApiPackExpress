using ApiPackExpress.IServices;
using ApiPackExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Services
{
    public class LoginLogService : ILoginLogService
    {
        private readonly IConnection _connection;
        public LoginLogService(IConnection connection)
        {
            this._connection = connection;
        }
        public void insertLoginLog(LoginLog loginlog)
        {
            using(var sqlCon = _connection.GetSqlConnection(_connection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SPInsertLoginLog", sqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_DateLogin", Helpers.CastDate.castDateFormatSQL(loginlog.DateLogin));
                cmd.Parameters.AddWithValue("@_IdEmployee", loginlog.IdEmployee);
                cmd.Parameters.AddWithValue("@_IP", loginlog.Ip);
                cmd.Parameters.AddWithValue("@_Token", Helpers.Encrypter.EncryptString(loginlog.Token));

                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
