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
        private readonly ILoginLogService _log;
        private oResponse resp;

        public EmployeeController(IEmployeeService employe, ILoginLogService log)
        {
            this._log = log;
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

        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(PasswordDTO pw)
        {
            resp = new oResponse();

            if(pw.Password != pw.ConfirmPassword)
            {
                resp.status = 1010;
                resp.message = "Las contraseñas no coinciden";
                return Ok(resp);
            }

            if(_log.verifyPasswordUsed(pw.Password, HelpersFunctions.getIdUser(User.Claims.ToList())))
            {
                resp.status = 1011;
                resp.message = "La contraseña ya ha sido utilizada, intente con otra";
                return Ok(resp);
            }


            return Ok();

        }
    }
}
