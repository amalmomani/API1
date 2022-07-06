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
    public class StudentRepository: IStudentRepository
    {
        private readonly IDBContext dbContext;
        public StudentRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int count()
        {
            IEnumerable<Student_api> result = dbContext.dBConnection.Query<Student_api>("student_package_api.getallstudent", commandType: CommandType.StoredProcedure);
            List<Student_api> r = result.ToList();
            return r.Count();
        }

        public bool deletestudent(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofstudent", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dBConnection.ExecuteAsync("student_package_api.deletestudent", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
       
        public List<Student_api> getallstudent()
        {
            IEnumerable<Student_api> result = dbContext.dBConnection.Query<Student_api>("student_package_api.getallstudent", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Student_api getbyid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofstudent", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<Student_api> result = dbContext.dBConnection.Query<Student_api>("Student_package_api.getById", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.FirstOrDefault();
        }
        public List<string> studentmark()
        {
            IEnumerable<Student_api> result = dbContext.dBConnection.Query<Student_api>("student_package_api.getallstudent", commandType: CommandType.StoredProcedure);
            List<string> mark = new List<string>();
            foreach (var item in result)
            {
                
                mark.Add("student: " + item.studentName + " || mark: " + item.mark);
            }
            return mark;
        }
        public bool insertstudent(Student_api student_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofstudent", student_Api.studentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("nameofstudent", student_Api.studentName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("birth", student_Api.birthdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("markk", student_Api.mark, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("student_package_api.createinsertstudent", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool updatestudent(Student_api student_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofstudent", student_Api.studentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("nameofstudent", student_Api.studentName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("birth", student_Api.birthdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("markk", student_Api.mark, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("student_package_api.Updatestudent", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
