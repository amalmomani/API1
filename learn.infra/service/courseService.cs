using learn.core.Data;
using learn.core.Repository;
using learn.core.servise;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class courseService : ICourseService
    {
        private readonly ICourseRepository repo;
        public courseService(ICourseRepository repo)
        {
            this.repo = repo;
        }

        public int count()
        {
            return repo.count();
        }
        public List<string> CategoryCount()
        {
            return repo.CategoryCount();
        }
        public List<course_api> takelastThree()
        {
            return repo.takelastThree();
        }

        public bool deletecoure(int? id)
        {
            return repo.deletecoure(id);
        }

        public List<course_api> getallcourse()
        {
            return repo.getallcourse();
        }

        public course_api getbyid(int id)
        {
            return repo.getbyid(id);
        }

        public bool insertcourse(course_api course)
        {
            return repo.insertcourse(course);
        }

        public int sum()
        {
            return repo.sum();
        }

        public bool updatecourse(course_api course)
        {
            return repo.updatecourse(course);
        }
    }
}
