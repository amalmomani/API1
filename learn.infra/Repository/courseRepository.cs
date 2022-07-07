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
    public class courseRepository : ICourseRepository
    {
        private readonly IDBContext dbContext;
        public courseRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int count()
        {
            IEnumerable<course_api> result = dbContext.dBConnection.Query<course_api>("course_package_api.getallcourse", commandType: CommandType.StoredProcedure);
            List<course_api> r = result.ToList();
            return r.Count();
        }

        public bool deletecoure(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("choice", "delete", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("idofcourse", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("nameofcourse", null, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("price", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("catid", null, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dBConnection.ExecuteAsync("CRUD.CRUD_operation", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public List<course_api> takelastThree()
        {

            IEnumerable<course_api> result = dbContext.dBConnection.Query<course_api>("course_package_api.getallcourse", commandType: CommandType.StoredProcedure);
            List<course_api> r = result.OrderByDescending(c => c.courseId).Take(5).ToList();
            return r;
        }
        public List<course_api> getallcourse()
        {

            var parameter = new DynamicParameters();
            parameter.Add("choice", "select", dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("idofcourse", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("nameofcourse", null, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("price", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("catid", null, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<course_api> result = dbContext.dBConnection.Query<course_api>("CRUD.CRUD_operation",parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public course_api getbyid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcourse", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<course_api> result = dbContext.dBConnection.Query<course_api>("course_package_api.getById", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.FirstOrDefault();
        }
        public List<string> CategoryCount()
        {
            IEnumerable<course_api> courses = dbContext.dBConnection.Query<course_api>("course_package_api.getallcourse", commandType: CommandType.StoredProcedure);
            IEnumerable<Category_api> cats = dbContext.dBConnection.Query<Category_api>("category_package_api.getallcategory", commandType: CommandType.StoredProcedure);

            List<string> categ = new List<string>();
            int count = 0;

            foreach (var item in cats)
            {
                foreach (var item1 in courses)
                {
                    if (item.categoryId == item1.categoryId)
                    {
                        count++;
                    }

                }

                categ.Add("category: " + item.categoryId + " || count: " + count);
                count = 0;

            }

            return categ;
        }
        public bool insertcourse(course_api course)
        {
            var parameter = new DynamicParameters();
            parameter.Add("choice", "insert", dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("idofcourse", course.courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("nameofcourse", course.courseName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("price", course.coursePrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("catid", course.categoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("CRUD.CRUD_operation", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public int sum()
        {
            int sum = 0;
            List<course_api> course_Apis = getallcourse();
            foreach(var i in course_Apis)
            {
                sum = (Int32)sum + i.coursePrice;
            }
            return sum;
        }

        public bool updatecourse(course_api course)
        {
            var parameter = new DynamicParameters();
            parameter.Add("choice", "update", dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("idofcourse", course.courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("nameofcourse", course.courseName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("price", course.coursePrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("catid", course.categoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("CRUD.CRUD_operation", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
