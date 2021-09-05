using ApiPackExpress.Dtos;
using ApiPackExpress.Helpers;
using ApiPackExpress.IServices;
using ApiPackExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConnection _connection;
        private oResponse _resp = new oResponse();
        public EmployeeService(IConnection connection)
        {
            this._connection = connection;
        }

        public oResponse addEmployee(EmployeeRequestDTO emp)
        {

            Employee employee = new Employee()
            {
                Name = emp.Name,
                LastName = emp.LastName,
                Dni = emp.Dni,
                Birthdate = DateTime.ParseExact(emp.Birthdate, "yyyy-MM-dd", null),
                Address = emp.Address,
                Username = HelpersFunctions.generateUsername(emp.Name, emp.LastName),
                GenderId = emp.GenderId,
                PositionId = emp.PositionId,
                BranchId = emp.BranchId,
                CreatedAt =  DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            _resp.status = 200;
            _resp.message = "Ok";
            _resp.data = employee;

            return _resp;
        }
    }
}
