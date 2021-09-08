using ApiPackExpress.IServices;
using ApiPackExpress.Models;
using Newtonsoft.Json;
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
        private readonly IBitacoraWSService _bitacoraWS;
        public LoginLogService(IConnection connection, IBitacoraWSService bitacoraWSs)
        {
            this._connection = connection;
            this._bitacoraWS = bitacoraWSs;
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


        public bool verifyPasswordUsed(string pw, int idUser)
        {
            BitacoraWS bitacora = new BitacoraWS("", "Verify-Password", "admin");
            bool existPw = true;
            try
            {
               
                using (var sqlConn = _connection.GetSqlConnection(_connection.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("SPVerifyPasswordUsed", sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_idEmployee", idUser);
                    cmd.Parameters.AddWithValue("@_pw", Helpers.Encrypter.EncryptString(pw));

                    cmd.Connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        int count= 0;
                        while (rdr.Read())
                        {
                            count = Int32.Parse(rdr["pws"].ToString());
                        }
                        if(count == 0)
                        {
                            existPw = false;
                        }
                    }

                }
            }catch(Exception ex)
            {
                BitacoraJSON jsonObject = new BitacoraJSON();
                jsonObject.HResult = ex.HResult;
                jsonObject.StackTrace = ex.StackTrace;
                jsonObject.Exception = ex.ToString();
                jsonObject.Message = ex.Message;
                string json = JsonConvert.SerializeObject(jsonObject);

                bitacora.DateEnd = DateTime.Now;
                bitacora.MessageError = json;

                _bitacoraWS.InsertBitacoraWS(bitacora);
                
            }
            return existPw;
        }
    }
}
