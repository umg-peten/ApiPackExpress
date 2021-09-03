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
        private readonly IBitacoraWSService _bitacoraWS;
        private readonly ILoginLogService _loginLog;
        private BitacoraWS bitacoraWS;
        private oResponse oResponse;
        private LoginLog loginLog;
        public AuthServices(IConnection connection, ITokenHandler token, IBitacoraWSService bitacoraWS, ILoginLogService loginLog)
        {
            this._bitacoraWS = bitacoraWS;
            this._token = token;
            this._connection = connection;
            this._loginLog = loginLog;
        }
        public oResponse Authentication(AuthDto auth)
        {
            bitacoraWS = new BitacoraWS("Ok", "Authentication-Controller", auth.username);
            

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
                            employee.IdEmployee = Int32.Parse(sqlDataReader["idEmployee"].ToString());
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

                        loginLog = new LoginLog();
                        loginLog.IdEmployee = employee.IdEmployee;
                        loginLog.Token = employee.Token;

                        _loginLog.insertLoginLog(loginLog);
                    }
                    else
                    {
                        this.bitacoraWS.MessageError = "Usuario o contraseña incorrecta";
                        oResponse.status = 401;
                        oResponse.message = "Usuario o contraseña incorrecta";
                        oResponse.data = null;

                    }

                    _bitacoraWS.InsertBitacoraWS(this.bitacoraWS);
                }
            }
            catch (Exception ex)
            {
                this.bitacoraWS.MessageError = ex.Message + "\n" + ex.ToString();
               
                _bitacoraWS.InsertBitacoraWS(this.bitacoraWS);
                  
                oResponse.status = 500;
                oResponse.message = "Ha ocurrido un error en el servidor, si el problema persiste comunícate con el administrador";
                oResponse.data = null;

            }

            return oResponse;
        }
    }
}
