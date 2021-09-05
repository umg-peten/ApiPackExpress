using ApiPackExpress.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPackExpress.Helpers;
using ApiPackExpress.IServices;
using ApiPackExpress.Dtos;

namespace ApiPackExpress.Controllers
{

    [Route("api/Employee")]
    [Authorize]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employee;
        private oResponse resp;

        public EmployeeController(IEmployeeService employe)
        {
            this._employee = employe;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(EmployeeRequestDTO employee)
        {
            resp = new oResponse();
            if (!HelpersFunctions.isAdmin(User.Claims.ToList()))
            {
                resp.status = 401;
                resp.message = "Unauthorized";
                resp.data = new Object();
                return Unauthorized(resp);
            }
            
            var emp = _employee.addEmployee(employee);

            switch(emp.status){
                case 200:
                    return Ok(emp);

                case 500:
                    return StatusCode(500, resp);
            }

            return BadRequest();
        }
    }
}
