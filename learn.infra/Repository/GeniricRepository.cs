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
    public class GeniricRepository : IGeniricRepository
    {
        private readonly IDBContext dbContext;
        public GeniricRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public string NumberOfCategory()
        {
            IEnumerable<Geniric<Category_api>> result = dbContext.dBConnection.Query<Geniric<Category_api>>("category_package_api.getallcategory", commandType: CommandType.StoredProcedure);
            List<Geniric<Category_api>> Category = result.ToList();
           
            return Category.Count() + " Category";
        }

        public List<string> NumberOfCourse()
        {
            IEnumerable<course_api> result = dbContext.dBConnection.Query<course_api>("course_package_api.getallcourse", commandType: CommandType.StoredProcedure);
            List<string> categ = new List<string>();
            foreach (var item in result)
            {
                int count = 0;
                int cat = item.categoryId;
                foreach (var item1 in result)
                {
                    if (cat == item1.categoryId)
                    {
                        count++;
                    }

                }
                categ.Add("category: " + item.categoryId + " || count: " + count);
            }
            return categ;
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
    }
}
