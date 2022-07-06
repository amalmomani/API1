using learn.core.Data;
using learn.core.servise;
using learn.infra.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courserservice;
        public CourseController(ICourseService courserservice)
        {
            this.courserservice = courserservice;

        }

        [HttpDelete("delete/{id}")] //delete record from database
        public bool detecourse(int id)
        {

            return courserservice.deletecoure(id);
        }
        [HttpGet]//retrevie all data
        public List<course_api>course()
        {
            return courserservice.getallcourse();
        }
        [HttpGet("{id}")] // retrive data by id
        public course_api course(int id)
        {

            return courserservice.getbyid(id);
        }
        [HttpPost]//insert new record in database
        public bool createcourse([FromBody]course_api cc)
        {

            return courserservice.insertcourse(cc);
        }
        [HttpPut] //update
        public bool updatecourse( [FromBody]course_api cc)
        {

            return courserservice.updatecourse(cc);
        }
        [HttpGet]
        [Route("c")]
        public int Count()
        {
            return courserservice.count();
        }
        [HttpGet]
        [Route("sum")]
        public int sum()
        {
            return courserservice.sum();
        }
        [HttpGet]
        [Route("take")]
        public List<course_api> take()
        {
            return courserservice.takelastThree();
        }
        [HttpGet]
        [Route("cat")]
        public List<string> CategoryCount()
        {
            return courserservice.CategoryCount();
        }


    }
}
