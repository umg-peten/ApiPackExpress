using ApiPackExpress.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.IServices
{
    public interface ITokenHandler
    {
        public string GenerateToken(EmployeeDTO employee);
    }
}
