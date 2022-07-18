using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repository
{
    public interface IAuthenticaion
    {
        public Login_Api auth(Login_Api login_Api);

    }
}
