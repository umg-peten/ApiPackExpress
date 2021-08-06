﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Rest_Cine.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        public IActionResult prueba()
        {
            var claims = User.Claims;

            return Ok();
        }
    }
}
