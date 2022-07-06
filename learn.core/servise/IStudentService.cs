using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.servise
{
    public interface IStudentService
    {
        public List<Student_api> getallstudent();

        public bool insertstudent(Student_api Student);

        public bool deletestudent(int? id);

        public Student_api getbyid(int id);

        public bool updatestudent(Student_api Student);

        public int count();

        public List<string> studentmark();
    }
}
