﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PruebaController : Controller
    {

        public IActionResult prueba()
        {
            var claims = User.Claims;

            return Ok();
        }
    }
}
