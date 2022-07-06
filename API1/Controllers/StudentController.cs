using learn.core.Data;
using learn.core.servise;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService  studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;

        }

        [HttpDelete("delete/{id}")] //delete record from database
        public bool detestudent(int id)
        {

            return studentService.deletestudent(id);
        }
        [HttpGet]//retrevie all data
        public List<Student_api> student()
        {
            return studentService.getallstudent();
        }
        [HttpGet("{id}")] // retrive data by id
        public Student_api student(int id)
        {

            return studentService.getbyid(id);
        }
        [HttpPost]//insert new record in database
        public bool createstudent([FromBody] Student_api s)
        {

            return studentService.insertstudent(s);
        }
        [HttpPut] //update
        public bool updatestudent([FromBody] Student_api s)
        {

            return studentService.updatestudent(s);
        }
        [HttpGet]
        [Route("c")]
        public int Count()
        {
            return studentService.count();
        }
      
        [HttpGet]
        [Route("mark")]
        public List<string> marks()
        {
            return studentService.studentmark();
        }
       

    }
}
