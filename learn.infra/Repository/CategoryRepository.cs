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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDBContext dbContext;
        public CategoryRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool deletecat(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcategory", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dBConnection.ExecuteAsync("category_package_api.deletecategory", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Category_api> getall()
        {
            IEnumerable<Category_api> result = dbContext.dBConnection.Query<Category_api>("category_package_api.getallcategory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public int count()
        {
            IEnumerable<Category_api> result = dbContext.dBConnection.Query<Category_api>("category_package_api.getallcategory", commandType: CommandType.StoredProcedure);
            List<Category_api> r = result.ToList();
            return r.Count();
        }
        public Category_api getbyidcat(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcategory", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<Category_api> result = dbContext.dBConnection.Query<Category_api>("category_package_api.getById", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.FirstOrDefault();
        }

        public bool insertcat(Category_api categorey_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcategory", categorey_Api.categoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("nameofcategory", categorey_Api.categoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("image", categorey_Api.imagePath, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.dBConnection.ExecuteAsync("category_package_api.createinsertcategory", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updatecat(Category_api categorey_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcategory", categorey_Api.categoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("nameofcategory", categorey_Api.categoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("image",categorey_Api.imagePath, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.dBConnection.ExecuteAsync("category_package_api.Updatecategory", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
