using ApiPackExpress.Dtos;
using ApiPackExpress.IServices;
using ApiPackExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Services
{
    public class AuthServices : IAuthService
    {
        private readonly IConnection _connection;
        private readonly ITokenHandler _token;
        private BitacoraWS _bitacoraWS;
        private oResponse oResponse;
        public AuthServices(IConnection connection, ITokenHandler token)
        {
            this._token = token;
            this._connection = connection;
        }
        public oResponse  Authentication(AuthDto auth)
        {
            oResponse = new oResponse();
            EmployeeDTO employee = new EmployeeDTO();

            try
            {
                using (var sqlCon = _connection.GetSqlConnection(_connection.GetConnectionString()))
                {

                    SqlCommand command = new SqlCommand("SPAuthentication", sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@_USERNAME", auth.username);
                    command.Parameters.AddWithValue("@_PASSWORD", Helpers.Encrypter.EncryptString(auth.password));
                    command.Connection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employee.Fullname = sqlDataReader["fullname"].ToString();
                            employee.Username = sqlDataReader["username"].ToString();
                            employee.Token = _token.GenerateToken(auth.username);
                            employee.Gender = new Gender()
                            {
                                GenderId = Int32.Parse(sqlDataReader["idGender"].ToString()),
                                GenderName = sqlDataReader["gender"].ToString()
                            };
                            employee.Position = new PositionDTO()
                            {
                                IdPosition = Int32.Parse(sqlDataReader["idPosition"].ToString()),
                                Position = sqlDataReader["positionName"].ToString()
                            };
                            employee.Branch = new BranchDTO()
                            {
                                IdBranch = Int32.Parse(sqlDataReader["idBranch"].ToString()),
                                Branch = sqlDataReader["branchName"].ToString(),
                                Telephone = sqlDataReader["telephone"].ToString(),
                                Address = sqlDataReader["address"].ToString()
                            };

                        }
                        oResponse.status = 200;
                        oResponse.message = "Ok";
                        oResponse.data = employee;
                    }
                    else
                    {
                        oResponse.status = 401;
                        oResponse.message = "Usuario o contraseña incorrecta";
                        oResponse.data = null;

                    }

                }
            }
            catch (Exception ex)
            {
                this._bitacoraWS = new BitacoraWS();
                this._bitacoraWS.DateBegin = DateTime.Now;
                this._bitacoraWS.MessageError = ex.Message + "\n" + ex.ToString();
                this._bitacoraWS.Username = auth.username;
                this._bitacoraWS.Section = "Authentication-Controller";
                this._bitacoraWS.Pc = Environment.MachineName;
                this._bitacoraWS.Ip = "localhost";

                using (var SqlCon = _connection.GetSqlConnection(_connection.GetConnectionString()))
                {
                    SqlCommand command = new SqlCommand("SPInsertBitacoraWS", SqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@_MessageError", _bitacoraWS.MessageError);
                    command.Parameters.AddWithValue("@_Section", _bitacoraWS.Section);
                    command.Parameters.AddWithValue("@_DateBegin", _bitacoraWS.DateBegin);
                    command.Parameters.AddWithValue("@_DateEnd", _bitacoraWS.DateEnd);
                    command.Parameters.AddWithValue("@_Username", _bitacoraWS.Username);
                    command.Parameters.AddWithValue("@_PC", _bitacoraWS.Pc);
                    command.Parameters.AddWithValue("@_IP", _bitacoraWS.Ip);
                    command.Connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    oResponse.status = 500;
                    oResponse.message = "Ha ocurrido un error en el servidor, si el problema persiste comunícate con el administrador";
                    oResponse.data = null;

                }

            }

            return oResponse;
        }
    }
}
