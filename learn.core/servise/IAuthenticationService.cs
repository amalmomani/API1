using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.servise
{
    public interface IAuthenticationService
    {
        public string Authenticatin_jwt(Login_Api login_Api);

    }
}
