using ApiPackExpress.Dtos;
using ApiPackExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.IServices
{
    public interface IAuthService
    {
        public oResponse Authentication(AuthDto auth);
    }
}
