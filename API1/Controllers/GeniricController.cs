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
    public class GeniricController : ControllerBase
    {
        private readonly IGeniricService geniricService;
        public GeniricController(IGeniricService geniricService)
        {
            this.geniricService = geniricService;
        }
        [HttpGet]
        [Route("c")]
        public string Count()
        {
            return geniricService.NumberOfCategory();
        }
        [HttpGet]
        [Route("course")]
        public List<string> course()
        {
            return geniricService.NumberOfCourse();
        }
        [HttpGet]
        [Route("student")]
        public List<string> student()
        {
            return geniricService.studentmark();
        }
    }
}
