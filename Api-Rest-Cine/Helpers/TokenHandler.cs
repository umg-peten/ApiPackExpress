using ApiPackExpress.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiPackExpress.Helpers
{
    public class TokenHandler : IServices.ITokenHandler
    {
        private readonly JWT _jwt;
        public TokenHandler(IOptions<JWT> jwt)
        {
            this._jwt = jwt.Value;
        }
        public string GenerateToken(EmployeeDTO employee)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.SigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(

                    new Claim[]
                    {
                        new Claim("Id", employee.IdEmployee.ToString()),
                        new Claim("Fullname", employee.Fullname),
                        new Claim("Username", employee.Username),
                        new Claim("Rol", employee.Position.IdPosition.ToString()),
                        new Claim("IdBranch", employee.Branch.IdBranch.ToString())
                        //new Claim(ClaimTypes.Email, usuario.email.ToString()),
                        //new Claim("rol", usuario.tipoUsuario.idTipoUsuario.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
