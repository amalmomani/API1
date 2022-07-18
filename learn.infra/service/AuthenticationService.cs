using learn.core.Data;
using learn.core.Repository;
using learn.core.servise;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace learn.infra.service
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IAuthenticaion authen;
        public AuthenticationService(IAuthenticaion authen)
        {
            this.authen = authen;
        }
        public string Authenticatin_jwt(Login_Api login_Api)
        {
            var result = authen.auth(login_Api);

            if (result == null)
            {
                return null;
            }


            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Email,result.username),
                    new Claim(ClaimTypes.Role, result.roleName),
                    new Claim(ClaimTypes.Name, 1.ToString())

                }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


            };

            var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
            return tokenhandler.WriteToken(generatetoken);
        }      
    }
}
