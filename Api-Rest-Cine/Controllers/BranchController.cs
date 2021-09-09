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
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchservice;
        public BranchController(IBranchService branchService)
        {
            this._branchservice = branchService;
        }

        [HttpGet]
        [Route("getBranchs")]

        public IActionResult getBranchs()
        {
            var result = _branchservice.getBranchs();

            return Ok(result);
        }


    }


}
