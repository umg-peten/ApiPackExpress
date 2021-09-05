using ApiPackExpress.Dtos;
using ApiPackExpress.Helpers;
using ApiPackExpress.IServices;
using ApiPackExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConnection _connection;
        private readonly IBitacoraWSService _bitacoraWsService;
        private BitacoraWS bitacoraWS;
        private oResponse _resp = new oResponse();
        public EmployeeService(IConnection connection, IBitacoraWSService bitacoraWSService)
        {
            this._bitacoraWsService = bitacoraWSService;
            this._connection = connection;
        }

        public oResponse addEmployee(EmployeeRequestDTO emp)
        {
            bitacoraWS = new BitacoraWS("Ok", "AddEmployee-Controller", "admin");

            Employee employee = new Employee()
            {
                Name = emp.Name,
                LastName = emp.LastName,
                Dni = emp.Dni,
                Nit = emp.Nit,
                Birthdate = DateTime.ParseExact(emp.Birthdate, "yyyy-MM-dd", null),
                Address = emp.Address,
                Username = HelpersFunctions.generateUsername(emp.Name, emp.LastName),
                GenderId = emp.GenderId,
                PositionId = emp.PositionId,
                BranchId = emp.BranchId,
                CreatedAt =  DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            PasswordLog pwLog = new PasswordLog();

            try
            {
                using (var sqlCon = _connection.GetSqlConnection(_connection.GetConnectionString()))
                {
                    int statusQuery = 0;
                    SqlCommand cmd = new SqlCommand("PSAddEmployee", sqlCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_name", employee.Name);
                    cmd.Parameters.AddWithValue("@_lastname", employee.LastName);
                    cmd.Parameters.AddWithValue("@_dni", employee.Dni);
                    cmd.Parameters.AddWithValue("@_nit", employee.Nit);
                    cmd.Parameters.AddWithValue("@_birthdate", employee.Birthdate);
                    cmd.Parameters.AddWithValue("@_address", employee.Address);
                    cmd.Parameters.AddWithValue("@_createdAt", CastDate.castDateFormatSQL(employee.CreatedAt));
                    cmd.Parameters.AddWithValue("@_modifiedAt", CastDate.castDateFormatSQL(employee.ModifiedAt));
                    cmd.Parameters.AddWithValue("@_username", employee.Username);
                    cmd.Parameters.AddWithValue("@_idGender", employee.GenderId);
                    cmd.Parameters.AddWithValue("@_idPosition", employee.PositionId);
                    cmd.Parameters.AddWithValue("@_idBranch", employee.BranchId);
                    cmd.Parameters.AddWithValue("@_pw", pwLog.Password);
                    cmd.Parameters.AddWithValue("@_expDate", pwLog.ExpirationDate);
                    cmd.Parameters.AddWithValue("@_ip", pwLog.Ip);
                    cmd.Parameters.AddWithValue("@_statusQuery", statusQuery);
                    cmd.Connection.Open();

                    cmd.ExecuteReader();

                    _resp.status = 200;
                    _resp.message = "Ok";
                    _resp.data = null;
                }
            }catch(Exception ex)
            {
                bitacoraWS.MessageError = ex.Message + "\n" + ex.ToString();
                bitacoraWS.DateEnd = DateTime.Now;

                _bitacoraWsService.InsertBitacoraWS(bitacoraWS);

                _resp.status = 500;
                _resp.message = "Internar Server Error";
            }
          

            return _resp;
        }
    }
}
