using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.servise
{
    public interface ICourseService
    {
        public List<course_api> getallcourse();

        public bool insertcourse(course_api course);

        public bool deletecoure(int? id);

        public course_api getbyid(int id);

        public bool updatecourse(course_api course);

        public int count();
        public int sum();
        public List<course_api> takelastThree();
        public List<string> CategoryCount();


    }
}
