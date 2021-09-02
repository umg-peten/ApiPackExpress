using ApiPackExpress.Dtos;
using ApiPackExpress.IServices;
using ApiPackExpress.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IBitacoraWSService _bitacoraWS;

        public AuthController(IAuthService authService, IBitacoraWSService bitacoraWS)
        {
            this._bitacoraWS = bitacoraWS;
            this._authService = authService;
        }
        

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(AuthDto auth)
        {
            oResponse response = new oResponse();
            

            if(auth.password.Trim() == "" || auth.username.Trim() == "" ||
                auth.password == null || auth.username == null)
            {
                response.status = 400;
                response.message = "Bad Request";
                response.data = new Object();
                BitacoraWS bitacoraWS = new BitacoraWS(response.message, "Authentication-Controller", auth.username);
                _bitacoraWS.InsertBitacoraWS(bitacoraWS);
                return BadRequest(response);
            }

            response = _authService.Authentication(auth);

            if(response.status == 500)
            {
                return StatusCode(500, response);
            }
            else if (response.status == 401)
            {
                return Unauthorized(response);
            }

            if(response.status == 200)
            {

            }
            return Ok(response);
                
            
            
        }
    }
}
