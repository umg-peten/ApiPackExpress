using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Rest_Cine.IServices
{
    public interface ITokenHandler
    {
        public string GenerateToken(string username);
    }
}
