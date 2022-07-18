using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
    public class Authenticaion: IAuthenticaion
    {
        private readonly IDBContext dbContext;
        public Authenticaion(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Login_Api auth(Login_Api login_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("username1",login_Api.username,  dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("password1",login_Api.password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Login_Api> result = dbContext.dBConnection.Query<Login_Api>("loginApi_package.Auth", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

    }
}
