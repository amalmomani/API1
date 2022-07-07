using learn.core.DTO;
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
    public class DTOController : ControllerBase
    {
        private readonly IStudent_DTOService studentService;
        public DTOController(IStudent_DTOService studentService)
        {
            this.studentService = studentService;
        }
        [HttpGet]
        [Route("get")]
        public List<Student_DTO> get()
        {
            return studentService.getinfo();
        }
    }
}
