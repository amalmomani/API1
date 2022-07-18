using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.DTO;
using learn.core.Repository;
using learn.infra.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
    public class Student_DTORepository : IStudent_DTORepository
    {
        private readonly IDBContext dbContext;

        public Student_DTORepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Student_DTO> getinfo()
        {         
            IEnumerable<Student_DTO> result = dbContext.dBConnection.Query<Student_DTO>("stu_api_package.getinfo", commandType: System.Data.CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
