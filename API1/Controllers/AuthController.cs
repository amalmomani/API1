using learn.core.Data;
using learn.core.servise;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService authenticationservice;
        public AuthController(IAuthenticationService authenticationservice)
        {
            this.authenticationservice = authenticationservice;
        }

        [HttpPost]
        public IActionResult authen([FromBody] Login_Api login)
        {
            var RESULT = authenticationservice.Authenticatin_jwt(login);

            if (RESULT == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(RESULT);
            }
        }
    }
}
