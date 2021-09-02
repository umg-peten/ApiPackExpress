using ApiPackExpress.IServices;
using ApiPackExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Services
{
    public class BitacoraWsService : IBitacoraWSService
    {
        private readonly IConnection _connection;
        private BitacoraWS bitacoraWS;
        public BitacoraWsService(IConnection connection)
        {
            this._connection = connection;
        }
        public void InsertBitacoraWS(BitacoraWS bitacoraWS)
        {
            bitacoraWS.DateEnd = DateTime.Now;
            using (var SqlCon = _connection.GetSqlConnection(_connection.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("SPInsertBitacoraWS", SqlCon);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@_MessageError", bitacoraWS.MessageError);
                command.Parameters.AddWithValue("@_Section", bitacoraWS.Section);
                command.Parameters.AddWithValue("@_DateBegin", Helpers.CastDate.castDateFormatSQL(bitacoraWS.DateBegin));
                command.Parameters.AddWithValue("@_DateEnd", Helpers.CastDate.castDateFormatSQL(bitacoraWS.DateEnd));
                command.Parameters.AddWithValue("@_Username", bitacoraWS.Username);
                command.Parameters.AddWithValue("@_PC", bitacoraWS.Pc);
                command.Parameters.AddWithValue("@_IP", bitacoraWS.Ip);
                command.Connection.Open();

                command.ExecuteNonQuery();

            }
        }
    }
}
