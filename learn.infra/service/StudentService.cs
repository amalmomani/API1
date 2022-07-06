using learn.core.Data;
using learn.core.Repository;
using learn.core.servise;
using System;
using System.Collections.Generic;
using System.Text;
namespace learn.infra.service
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository repo;
        public StudentService(IStudentRepository repo)
        {
            this.repo = repo;
        }
        public int count()
        {
            return repo.count();
        }
        public bool deletestudent(int? id)
        {
            return repo.deletestudent(id);
        }
        public List<Student_api> getallstudent()
        {
            return repo.getallstudent();
        }
        public Student_api getbyid(int id)
        {
            return repo.getbyid(id);
        }
        public List<string> studentmark()
        {
            return repo.studentmark();
        }
        public bool insertstudent(Student_api student_Api)
        {
            return repo.insertstudent(student_Api);
        }
        public bool updatestudent(Student_api student_Api)
        {
            return repo.updatestudent(student_Api);
        }
    }
}
